using System;

namespace IgiCore.Characters.Shared.Models
{
	public interface ICharacterSession
	{
		/// <summary>
		/// Gets or sets the session identifier.
		/// </summary>
		/// <value>
		/// The session identifier.
		/// </value>
		Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of when the session was created.
		/// </summary>
		/// <value>
		/// The timestamp of when the session was created.
		/// </value>
		DateTime Created { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of when the character connected to the session.
		/// </summary>
		/// <value>
		/// The timestamp of when the character connected to the session.
		/// </value>
		DateTime? Connected { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of when the character disconnected from the session.
		/// </summary>
		/// <value>
		/// The timestamp of when the character disconnected from the session.
		/// </value>
		DateTime? Disconnected { get; set; }

		/// <summary>
		/// Gets or sets the character identifier.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		Guid CharacterId { get; set; }
	}
}
