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

		public CharacterOverlay(List<Character> characters, IOverlayManager manager) : base(manager)
		{
			this.Characters = characters;

			On("disconnect", () => this.Disconnect?.Invoke(this, new OverlayEventArgs(this)));
			On<Character>("create", (character) => this.Create?.Invoke(this, new CreateOverlayEventArgs(character, this)));
			On<Guid>("select", (id) => this.Select?.Invoke(this, new IdOverlayEventArgs(id, this)));
			On<Guid>("delete", (id) => this.Delete?.Invoke(this, new IdOverlayEventArgs(id, this)));
		}

		protected override dynamic Ready() => this.Characters.ToArray();

		public void SyncCharacters()
		{
			Emit("sync", this.Characters.ToArray());
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
