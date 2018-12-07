using IgiCore.Characters.Client.Models;
using NFive.SDK.Client.Interface;
using System;
using System.Collections.Generic;

namespace IgiCore.Characters.Client.Overlays
{
	public class CharacterOverlay : Overlay
	{
		public event EventHandler<OverlayEventArgs> Create;

		public CharacterOverlay(List<Character> characters, OverlayManager manager) : base("CharacterOverlay.html", manager)
		{
			this.Attach("create", (_, callback) => this.Create?.Invoke(this, new OverlayEventArgs(this)));
			this.Attach("load", (_, callback) => this.Send("load", characters.ToArray()));
		}
	}
}
