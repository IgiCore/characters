using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using IgiCore.Characters.Client.Models;
using IgiCore.Characters.Client.Overlays;
using IgiCore.Characters.Shared;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Extensions;
using NFive.SDK.Client.Input;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFive.SDK.Client.Communications;
using NFive.SDK.Core.Extensions;

namespace IgiCore.Characters.Client
{
	[PublicAPI]
	public class CharactersService : Service
	{
		private bool started = false;
		private bool isPlaying;
		private Configuration config;
		private Hotkey activateKey;
		private CharacterOverlay overlay;
		private CharacterSession session;
		private Character activeCharacter;

		public CharactersService(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlay, User user) : base(logger, ticks, comms, commands, overlay, user) { }

		public override async Task Started()
		{
			// Request server configuration
			this.config = await this.Comms.Event(CharacterEvents.Configuration).ToServer().Request<Configuration>();

			this.activateKey = new Hotkey(this.config.SelectionScreen.Hotkey);
		}

		public override async Task HoldFocus()
		{
			// Hide HUD
			Screen.Hud.IsVisible = false;

			// Disable the loading screen from automatically being dismissed
			API.SetManualShutdownLoadingScreenNui(true);

			// Position character, required for switching
			Game.Player.Character.Position = Vector3.Zero;

			// Freeze
			Game.Player.Freeze();

			// Switch out the player if it isn't already in a switch state
			if (!API.IsPlayerSwitchInProgress()) API.SwitchOutPlayer(API.PlayerPedId(), 0, 1);

			// Remove most clouds
			API.SetCloudHatOpacity(0.01f);

			// Wait for switch
			while (API.GetPlayerSwitchState() != 5) await Delay(10);

			// Hide loading screen
			API.ShutdownLoadingScreen();

			// Fade out
			Screen.Fading.FadeOut(0);
			while (Screen.Fading.IsFadingOut) await Delay(10);

			// Get characters
			var characters = await this.Comms.Event(CharacterEvents.GetCharactersForUser).ToServer().Request<List<Character>>();

			// Show overlay
			this.overlay = new CharacterOverlay(characters, this.OverlayManager);
			this.overlay.Create += OnCreate;
			this.overlay.Disconnect += OnDisconnect;
			this.overlay.Select += OnSelect;
			this.overlay.Delete += OnDelete;

			// Focus overlay
			this.overlay.Focus(true);

			// Shut down the NUI loading screen
			API.ShutdownLoadingScreenNui();

			// Fade in
			Screen.Fading.FadeIn(500);
			while (Screen.Fading.IsFadingIn) await Delay(10);

			// Wait for user before releasing focus
			while (!this.started) await Delay(20);
		}

		private async void OnCreate(object sender, CreateOverlayEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(e.Character.Middlename)) e.Character.Middlename = null;

			e.Character.WalkingStyle = "move_m@drunk@verydrunk";
			e.Character.Model = ((uint)(e.Character.Gender == 0 ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01)).ToString();

			// Send new character
			var character = await this.Comms.Event(CharacterEvents.Create).ToServer().Request<Character>(e.Character);

			this.session = await this.Comms.Event(CharacterEvents.Select).ToServer().Request<CharacterSession>(character.Id);
			await Play(e.Overlay, character);
		}

		private void OnDisconnect(object sender, OverlayEventArgs e)
		{
			this.Comms.Event(SessionEvents.DisconnectPlayer).ToServer().Emit("Thanks for playing");
		}

		private async void OnSelect(object sender, IdOverlayEventArgs e)
		{
			this.session = await this.Comms.Event(CharacterEvents.Select).ToServer().Request<CharacterSession>(e.Id);
			await Play(e.Overlay, this.overlay.Characters.First(c => c.Id == e.Id));
		}

		private async void OnDelete(object sender, IdOverlayEventArgs e)
		{
			this.Logger.Debug($"Delete {e.Id}");

			this.overlay.Characters = await this.Comms.Event(CharacterEvents.Delete).ToServer().Request<List<Character>>(e.Id);

			this.overlay.SyncCharacters();
		}

		private async Task Play(Overlay o, Character character)
		{
			// Destroy overlay
			o.Dispose();

			// Un-focus overlay
			this.overlay.Blur();

			// Load and render character model
			while (!await Game.Player.ChangeModel(new Model(character.ModelHash))) await Delay(10);
			character.RenderCustom(this.Logger);
			await character.Render(this.Logger);

			// Unfreeze
			Game.Player.Unfreeze();

			// Show HUD
			Screen.Hud.IsVisible = true;

			// Switch in
			API.SwitchInPlayer(API.PlayerPedId());

			// Set character as active character
			this.activeCharacter = character;

			// Set as playing
			this.isPlaying = true;

			// Set player health (Rare #OnSpawnDeath Fix)
			this.activeCharacter.Health = character.Health;

			// Attach tick handlers after character selection
			// to reduce character select click lag
			this.Ticks.On(OnHotkey);
			this.Ticks.On(OnSaveCharacter);
			this.Ticks.On(OnSavePosition);

			// Release focus hold
			this.started = true;
		}

		public async Task OnHotkey()
		{
			if (!this.activateKey.IsJustPressed()) return;

			// Set as playing
			this.isPlaying = false;

			// Hide HUD
			Screen.Hud.IsVisible = false;

			// Remove most clouds
			API.SetCloudHatOpacity(0.01f);

			// Switch out the player if it isn't already in a switch state
			if (!API.IsPlayerSwitchInProgress()) API.SwitchOutPlayer(API.PlayerPedId(), 0, 1);

			// Wait for switch
			while (API.GetPlayerSwitchState() != 5) await Delay(10);

			// Freeze
			Game.Player.Freeze();

			// Fade out
			Screen.Fading.FadeOut(1000);
			while (Screen.Fading.IsFadingOut) await Delay(10);

			// Position character, required for switching
			Game.Player.Character.Position = Vector3.Zero;

			// Get characters
			var characters = await this.Comms.Event(CharacterEvents.GetCharactersForUser).ToServer().Request<List<Character>>();

			// Show overlay
			this.overlay = new CharacterOverlay(characters, this.OverlayManager);
			this.overlay.Create += OnCreate;
			this.overlay.Disconnect += OnDisconnect;
			this.overlay.Select += OnSelect;
			this.overlay.Delete += OnDelete;

			// Focus overlay
			this.overlay.Focus(true);

			// Fade in
			Screen.Fading.FadeIn(500);
			while (Screen.Fading.IsFadingIn) await Delay(10);

			this.Ticks.Off(OnHotkey);
		}
		public async Task OnSaveCharacter()
		{
			SaveCharacter();

			await Delay(this.config.Autosave.CharacterInterval);
		}

		public async Task OnSavePosition()
		{
			SavePosition();

			await Delay(this.config.Autosave.PositionInterval);
		}

		private void SaveCharacter()
		{
			if (!this.isPlaying) return;

			this.activeCharacter.Position = Game.Player.Character.Position.ToVector3().ToPosition();
			this.Comms.Event(CharacterEvents.SaveCharacter).ToServer().Emit(this.activeCharacter);
		}

		private void SavePosition()
		{
			if (!this.isPlaying) return;

			this.Comms.Event(CharacterEvents.SavePosition).ToServer().Emit(this.activeCharacter.Id, Game.Player.Character.Position.ToVector3().ToPosition());
		}
	}
}
