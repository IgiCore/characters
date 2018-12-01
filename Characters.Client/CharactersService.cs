using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using IgiCore.Characters.Client.Models;
using IgiCore.Characters.Client.Overlays;
using IgiCore.Characters.Shared;
using JetBrains.Annotations;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Extensions;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System;
using System.Threading.Tasks;

namespace IgiCore.Characters.Client
{
	[PublicAPI]
	public class CharactersService : Service
	{
		public CharactersService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, overlay, user) { }

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
			while (API.GetPlayerSwitchState() != 5) await this.Delay(10);

			// Hide loading screen
			API.ShutdownLoadingScreen();

			// Fade out
			Screen.Fading.FadeOut(0);
			while (Screen.Fading.IsFadingOut) await this.Delay(10);

			// Show overlay
			var overlay = new CharacterOverlay(this.OverlayManager);
			overlay.Create += OnCreate;

			// Focus overlay
			API.SetNuiFocus(true, true);

			// Shut down the NUI loading screen
			API.ShutdownLoadingScreenNui();

			// Fade in
			Screen.Fading.FadeIn(500);
			while (Screen.Fading.IsFadingIn) await this.Delay(10);
		}

		private async void OnCreate(object sender, OverlayEventArgs e)
		{
			// Destroy overlay
			e.Overlay.Dispose();

			// Un-focus overlay
			API.SetNuiFocus(false, false);

			// Send new character
			var character = await this.Rpc.Event(CharacterEvents.Create).Request<Character>(new Character
			{
				Forename = "John",
				Middlename = "A",
				Surname = "Smith",
				DateOfBirth = new DateTime(1990, 1, 1),
				Gender = 0,
				WalkingStyle = "", // TODO
				Model = ((uint)PedHash.FreemodeMale01).ToString()
			});

			// Set character properties 
			Game.Player.Character.Position = character.Position.ToVector3();
			Game.Player.Character.Health = character.Health;
			Game.Player.Character.Armor = character.Armor;

			// Load character model
			while (!await Game.Player.ChangeModel(new Model(character.ModelHash))) await this.Delay(10);
			Game.Player.Character.Style.SetDefaultClothes();

			// Unfreeze
			Game.Player.Unfreeze();

			// Show HUD
			Screen.Hud.IsVisible = true;

			// Switch in
			API.SwitchInPlayer(API.PlayerPedId());
		}
	}
}
