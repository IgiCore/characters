using System;
using System.Collections.Generic;
using IgiCore.Characters.Server.Events;
using IgiCore.Characters.Server.Models;
using IgiCore.Characters.Shared;
using JetBrains.Annotations;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rpc;

namespace IgiCore.Characters.Server
{
	/// <summary>
	/// Wrapper library for accessing character data from external plugins.
	/// </summary>
	[PublicAPI]
	public class CharacterManager
	{
		/// <summary>
		/// The controller event manager.
		/// </summary>
		protected readonly IEventManager Events;

		/// <summary>
		/// The controller RPC handler.
		/// </summary>
		protected readonly IRpcHandler Rpc;

		/// <summary>
		/// Occurs when a character session is being created for the clients selected character to play.
		/// </summary>
		public event EventHandler<CharacterEventArgs> Selecting;

		/// <summary>
		/// Occurs when a character session has been created for the clients selected character to play.
		/// </summary>
		public event EventHandler<CharacterSessionEventArgs> Selected;

		/// <summary>
		/// Occurs when a character session for a client's selected character is being disconnected.
		/// </summary>
		public event EventHandler<CharacterSessionEventArgs> Deselecting;

		/// <summary>
		/// Occurs when a character session for a client's selected character is disconnected.
		/// </summary>
		public event EventHandler<CharacterSessionEventArgs> Deselected;

		/// <summary>
		/// Gets the active character sessions.
		/// </summary>
		/// <value>
		/// The active character sessions.
		/// </value>
		public List<CharacterSession> ActiveCharacterSessions =>
			this.Events.Request<List<CharacterSession>>(CharacterEvents.GetActive);

		/// <summary>
		/// Initializes a new instance of the <see cref="CharacterManager"/> class.
		/// </summary>
		/// <param name="events">The controller event manager.</param>
		/// <param name="rpc">The controller RPC handler.</param>
		public CharacterManager(IEventManager events, IRpcHandler rpc)
		{
			this.Events = events;
			this.Rpc = rpc;

			this.Events.On<Character>(CharacterEvents.Selecting, c => this.Selecting?.Invoke(this, new CharacterEventArgs(c)));
			this.Events.On<CharacterSession>(CharacterEvents.Selected, c => this.Selected?.Invoke(this, new CharacterSessionEventArgs(c)));
			this.Events.On<CharacterSession>(CharacterEvents.Deselecting, c => this.Deselecting?.Invoke(this, new CharacterSessionEventArgs(c)));
			this.Events.On<CharacterSession>(CharacterEvents.Deselected, c => this.Deselected?.Invoke(this, new CharacterSessionEventArgs(c)));
		}

		/// <summary>
		/// Selects the specified character identifier as the active character.
		/// </summary>
		/// <param name="characterId">The character identifier.</param>
		/// <returns></returns>
		public CharacterSession Select(Guid characterId)
		{
			return this.Events.Request<Guid, CharacterSession>(CharacterEvents.Select, characterId);
		}
	}
}

