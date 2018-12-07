using IgiCore.Characters.Client.Models;
using NFive.SDK.Client.Interface;
using System;
using System.Collections.Generic;

namespace IgiCore.Characters.Client.Overlays
{
	public class CharacterOverlay : Overlay
	{
		public event EventHandler<OverlayEventArgs> Create;

		public CharacterOverlay(OverlayManager manager) : base("CharacterOverlay.html", manager)
		{
			this.Attach("create", (_, callback) => this.Create?.Invoke(this, new OverlayEventArgs(this)));
		}

		public void Load(List<Character> characters)
		{
			this.Send("load", characters.ToArray());
		}
	}
}
