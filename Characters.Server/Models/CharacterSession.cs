using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IgiCore.Characters.Shared.Models;
using Newtonsoft.Json;
using NFive.SDK.Core.Models.Player;

namespace IgiCore.Characters.Server.Models
{
	public class CharacterSession : ICharacterSession
	{
		/// <summary>
		/// Gets or sets the session identifier.
		/// </summary>
		/// <value>
		/// The session identifier.
		/// </value>
		[Key]
		[Required]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of when the session was created.
		/// </summary>
		/// <value>
		/// The timestamp of when the session was created.
		/// </value>
		[Required]
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
		/// The character identifier.
		/// </value>
		[Required]
		[ForeignKey("Character")]
		public Guid CharacterId { get; set; }

		/// <summary>
		/// Gets or sets the character which owns the session.
		/// </summary>
		/// <value>
		/// The character which owns the session.
		/// </value>
		[JsonIgnore]
		public virtual Character Character { get; set; }

		/// <summary>
		/// Gets or sets the user session identifier.
		/// </summary>
		/// <value>
		/// The session identifier.
		/// </value>
		[Required]
		[ForeignKey("Session")]
		public Guid SessionId { get; set; }

		/// <summary>
		/// Gets or sets the user session.
		/// </summary>
		/// <value>
		/// The user session.
		/// </value>
		[JsonIgnore]
		public virtual Session Session { get; set; }

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
