using System;
using IgiCore.Characters.Server.Models;
using JetBrains.Annotations;

namespace IgiCore.Characters.Server.Events
{
	[PublicAPI]
	public class CharacterEventArgs : EventArgs
	{
		public Character Character { get; }

		public CharacterEventArgs(Character character)
		{
			this.Character = character;
		}
	}
}
