using System;
using IgiCore.Characters.Server.Models;
using JetBrains.Annotations;

namespace IgiCore.Characters.Server.Events
{
	[PublicAPI]
	public class CharacterSessionEventArgs : EventArgs
	{
		public CharacterSession Session { get; }

		public CharacterSessionEventArgs(CharacterSession session)
		{
			this.Session = session;
		}
	}
}
