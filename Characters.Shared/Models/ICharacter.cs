using JetBrains.Annotations;
using NFive.SDK.Core.Models;
using System;

namespace IgiCore.Characters.Shared.Models
{
	/// <summary>
	/// Represents a user's game character.
	/// </summary>
	[PublicAPI]
	public interface ICharacter : IIdentityModel
	{
		/// <summary>
		/// Gets or sets the character forename.
		/// </summary>
		/// <value>
		/// The character forename.
		/// </value>
		string Forename { get; set; }

		/// <summary>
		/// Gets or sets the character middle name.
		/// </summary>
		/// <value>
		/// The character middle name.
		/// </value>
		string Middlename { get; set; }

		/// <summary>
		/// Gets or sets the character surname.
		/// </summary>
		/// <value>
		/// The character surname.
		/// </value>
		string Surname { get; set; }

		/// <summary>
		/// Gets or sets the date of birth.
		/// </summary>
		/// <value>
		/// The date of birth.
		/// </value>
		DateTime DateOfBirth { get; set; }

		/// <summary>
		/// Gets or sets the gender.
		///   <c>0</c> for male; <c>1</c> for female.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		short Gender { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the character is alive.
		/// </summary>
		/// <value>
		///   <c>true</c> if alive; otherwise, <c>false</c>.
		/// </value>
		bool Alive { get; set; }

		/// <summary>
		/// Gets or sets the character health.
		/// </summary>
		/// <value>
		/// The character health.
		/// </value>
		int Health { get; set; }

		/// <summary>
		/// Gets or sets the character armor.
		/// </summary>
		/// <value>
		/// The character armor.
		/// </value>
		int Armor { get; set; }

		/// <summary>
		/// Gets or sets the social security number.
		/// </summary>
		/// <value>
		/// The social security number.
		/// </value>
		int Ssn { get; set; }

		/// <summary>
		/// Gets or sets the position in the game world.
		/// </summary>
		/// <value>
		/// The position in the game world.
		/// </value>
		Position Position { get; set; }

		/// <summary>
		/// Gets or sets the character model.
		/// </summary>
		/// <value>
		/// The character model.
		/// </value>
		string Model { get; set; }

		/// <summary>
		/// Gets or sets the character walking style.
		/// </summary>
		/// <value>
		/// The character walking style.
		/// </value>
		string WalkingStyle { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of when the character was created.
		/// </summary>
		/// <value>
		/// The timestamp of when the character was created.
		/// </value>
		DateTime? LastPlayed { get; set; }
	}
}
