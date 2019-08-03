using System;
using IgiCore.Characters.Server.Models;
using JetBrains.Annotations;

namespace IgiCore.Characters.Server.Events
{
	[PublicAPI]
	public class CharacterSessionEventArgs : EventArgs
	{
		public CharacterSession CharacterSession { get; }

		public CharacterSessionEventArgs(CharacterSession session)
		{
			this.CharacterSession = session;
		}
	}
}
