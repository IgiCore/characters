using System;
using IgiCore.Characters.Shared.Models;
using Newtonsoft.Json;

namespace IgiCore.Characters.Client.Models
{
	public class CharacterSession : ICharacterSession
	{
		/// <summary>
		/// Gets or sets the session identifier.
		/// </summary>
		/// <value>
		/// The session identifier.
		/// </value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of when the session was created.
		/// </summary>
		/// <value>
		/// The timestamp of when the session was created.
		/// </value>
		public DateTime Created { get; set; } = DateTime.UtcNow;

		/// <summary>
		/// Gets or sets the timestamp of when the character connected to the session.
		/// </summary>
		/// <value>
		/// The timestamp of when the character connected to the session.
		/// </value>
		public DateTime? Connected { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of when the character disconnected from the session.
		/// </summary>
		/// <value>
		/// The timestamp of when the character disconnected from the session.
		/// </value>
		public DateTime? Disconnected { get; set; }

		/// <summary>
		/// Gets or sets the character identifier.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		public Guid CharacterId { get; set; }

		/// <summary>
		/// Gets a value indicating whether a character is currently connected.
		/// </summary>
		/// <value>
		///   <c>true</c> if a character is currently is connected; otherwise, <c>false</c>.
		/// </value>
		[JsonIgnore]
		public bool IsConnected => this.Connected.HasValue && !this.Disconnected.HasValue;
	}
}
