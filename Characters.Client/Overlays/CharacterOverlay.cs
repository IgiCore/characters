using IgiCore.Characters.Client.Models;
using NFive.SDK.Client.Interface;
using System;
using System.Collections.Generic;

namespace IgiCore.Characters.Client.Overlays
{
	public class CharacterOverlay : Overlay
	{
		public event EventHandler<CreateOverlayEventArgs> Create;
		public event EventHandler<OverlayEventArgs> Disconnect;
		public event EventHandler<IdOverlayEventArgs> Select;
		public event EventHandler<IdOverlayEventArgs> Delete;

		public List<Character> Characters { get; set; }

		public CharacterOverlay(List<Character> characters, OverlayManager manager) : base("CharacterOverlay.html", manager)
		{
			this.Characters = characters;

			this.Attach("disconnect", (_, callback) => this.Disconnect?.Invoke(this, new OverlayEventArgs(this)));
			this.Attach("load", (_, callback) => this.Send("load", this.Characters.ToArray()));
			this.Attach<Character>("create", (character, callback) => this.Create?.Invoke(this, new CreateOverlayEventArgs(character, this)));
			this.Attach<Guid>("select", (id, callback) => this.Select?.Invoke(this, new IdOverlayEventArgs(id, this)));
			this.Attach<Guid>("delete", (id, callback) => this.Delete?.Invoke(this, new IdOverlayEventArgs(id, this)));
		}

		public void SyncCharacters()
		{
			this.Send("load", this.Characters.ToArray());
		}
	}

	public class CreateOverlayEventArgs : OverlayEventArgs
	{
		public Character Character { get; }

		public CreateOverlayEventArgs(Character character, Overlay overlay) : base(overlay)
		{
			this.Character = character;
		}
	}

	public class IdOverlayEventArgs : OverlayEventArgs
	{
		public Guid Id { get; }

		public IdOverlayEventArgs(Guid id, Overlay overlay) : base(overlay)
		{
			this.Id = id;
		}
	}
}
