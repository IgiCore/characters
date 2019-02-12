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
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using NFive.SessionManager.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFive.SDK.Core.Rpc;

namespace IgiCore.Characters.Client
{
	[PublicAPI]
	public class CharactersService : Service
	{
		private CharacterOverlay overlay;

		public CharactersService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, ICommandManager commands, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, commands, overlay, user) { }

		public override async Task Started()
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
			var characters = await this.Rpc.Event(CharacterEvents.Load).Request<List<Character>>();

			// Show overlay
			this.overlay = new CharacterOverlay(characters, this.OverlayManager);
			this.overlay.Create += OnCreate;
			this.overlay.Disconnect += OnDisconnect;
			this.overlay.Select += OnSelect;
			this.overlay.Delete += OnDelete;

			// Focus overlay
			API.SetNuiFocus(true, true);

			// Shut down the NUI loading screen
			API.ShutdownLoadingScreenNui();

			// Fade in
			Screen.Fading.FadeIn(500);
			while (Screen.Fading.IsFadingIn) await Delay(10);
		}

		private async void OnCreate(object sender, CreateOverlayEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(e.Character.Middlename)) e.Character.Middlename = null;

			e.Character.WalkingStyle = "MOVE_M@DRUNK@VERYDRUNK";
			e.Character.Model = ((uint)PedHash.FreemodeMale01).ToString();

			// TODO: DOB

			this.Logger.Debug(e.Character.DateOfBirth.ToString());

			// Send new character
			var character = await this.Rpc.Event(CharacterEvents.Create).Request<Character>(e.Character);

			await Play(e.Overlay, character);
		}

		private void OnDisconnect(object sender, OverlayEventArgs e)
		{
			this.Rpc.Event(SessionEvents.DisconnectPlayer).Trigger("Thanks for playing");
		}

		private async void OnSelect(object sender, IdOverlayEventArgs e)
		{
			await Play(e.Overlay, this.overlay.Characters.First(c => c.Id == e.Id));
		}

		private async void OnDelete(object sender, IdOverlayEventArgs e)
		{
			this.Logger.Debug($"Delete {e.Id}");

			this.overlay.Characters = await this.Rpc.Event(CharacterEvents.Delete).Request<List<Character>>(e.Id);

			this.overlay.SyncCharacters();
		}

		private async Task Play(Overlay o, Character character)
		{
			// Destroy overlay
			o.Dispose();

			// Un-focus overlay
			API.SetNuiFocus(false, false);

			//this.Logger.Debug( new Serializer().Serialize(Game.Player.Character.Style.GetAllVariations()));

			// Load and Render character model
			while (!await Game.Player.ChangeModel(new Model(character.ModelHash))) await Delay(10);
			character.Render();

			// Set character properties
			//Game.Player.Character.Position = character.Position.ToVector3();
			//Game.Player.Character.Health = character.Health;
			//Game.Player.Character.Armor = character.Armor;
			//Game.Player.Character.MovementAnimationSet = character.WalkingStyle;

			// Load character model
			//while (!await Game.Player.ChangeModel(new Model(character.ModelHash))) await Delay(10);
			//Game.Player.Character.Style.SetDefaultClothes();

			// Unfreeze
			Game.Player.Unfreeze();

			// Show HUD
			Screen.Hud.IsVisible = true;

			// Switch in
			API.SwitchInPlayer(API.PlayerPedId());
		}
	}
}
