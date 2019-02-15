using IgiCore.Characters.Shared.Models;
using Newtonsoft.Json;
using NFive.SDK.Core.Models;
using NFive.SDK.Core.Models.Player;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace IgiCore.Characters.Server.Models
{
	/// <inheritdoc cref="ICharacter" />
	/// <summary>
	/// Represents a user's game character.
	/// </summary>
	/// <seealso cref="IdentityModel" />
	/// <seealso cref="ICharacter" />
	public class Character : IdentityModel, ICharacter
	{
		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the character forename.
		/// </summary>
		/// <value>
		/// The character forename.
		/// </value>
		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Forename { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the character middle name.
		/// </summary>
		/// <value>
		/// The character middle name.
		/// </value>
		[StringLength(100, MinimumLength = 0)]
		public string Middlename { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the character surname.
		/// </summary>
		/// <value>
		/// The character surname.
		/// </value>
		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Surname { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the date of birth.
		/// </summary>
		/// <value>
		/// The date of birth.
		/// </value>
		[Required]
		public DateTime DateOfBirth { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the gender.
		/// <c>0</c> for male; <c>1</c> for female.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		[Required]
		[Range(0, 1)]
		public short Gender { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets a value indicating whether the character is alive.
		/// </summary>
		/// <value>
		/// <c>true</c> if alive; otherwise, <c>false</c>.
		/// </value>
		[Required]
		public bool Alive { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the character health.
		/// </summary>
		/// <value>
		/// The character health.
		/// </value>
		[Required]
		[Range(0, 10000)]
		public int Health { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the character armor.
		/// </summary>
		/// <value>
		/// The character armor.
		/// </value>
		[Required]
		[Range(0, 100)]
		public int Armor { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the social security number.
		/// </summary>
		/// <value>
		/// The social security number.
		/// </value>
		[Required]
		[Range(1000000, 999999999)]
		public int Ssn { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the position in the game world.
		/// </summary>
		/// <value>
		/// The position in the game world.
		/// </value>
		[Required]
		public Position Position { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the character model.
		/// </summary>
		/// <value>
		/// The character model.
		/// </value>
		[Required]
		[StringLength(200)] // TODO
		public string Model { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the character walking style.
		/// </summary>
		/// <value>
		/// The character walking style.
		/// </value>
		[Required]
		[StringLength(200)] // TODO
		public string WalkingStyle { get; set; }

		[Required]
		[ForeignKey("Appearance")]
		public Guid AppearanceId { get; set; }

		public virtual Appearance Appearance { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets or sets the timestamp of when the character was created.
		/// </summary>
		/// <value>
		/// The timestamp of when the character was created.
		/// </value>
		public DateTime? LastPlayed { get; set; }

		[Required]
		[ForeignKey("User")]
		public Guid UserId { get; set; }

		public virtual User User { get; set; }

		[JsonIgnore]
		public string FullName => $"{this.Forename} {this.Middlename} {this.Surname}".Replace("  ", " ");

		public static int GenerateSsn()
		{
			var rng = new Random();

			int ssn;
			do
			{
				ssn = rng.Next(1000000, 999999999);
			} while (Regex.IsMatch(ssn.ToString(), "^(?!b(d)1+b)(?!123456789|219099999|078051120)(?!666|000|9d{2})d{3}(?!00)d{2}(?!0{4})d{4}$")); // Validate its a valid US SSN

			return ssn;
		}
	}
}
