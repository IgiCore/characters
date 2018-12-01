using IgiCore.Characters.Shared.Models;
using Newtonsoft.Json;
using NFive.SDK.Core.Models;
using NFive.SDK.Core.Models.Player;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgiCore.Characters.Server.Models
{
	public class Character : IdentityModel, ICharacter
	{
		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Forename { get; set; }

		[StringLength(100, MinimumLength = 0)]
		public string Middlename { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Surname { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		[Range(0, 1)]
		public short Gender { get; set; }

		[Required]
		public bool Alive { get; set; }

		[Required]
		[Range(0, 10000)]
		public int Health { get; set; }

		[Required]
		[Range(0, 100)]
		public int Armor { get; set; }

		[Required]
		[Range(10000000, 999999999)]
		public int Ssn { get; set; }

		[Required]
		public Position Position { get; set; }

		[Required]
		[StringLength(200)] // TODO
		public string Model { get; set; }

		[Required]
		[StringLength(200)] // TODO
		public string WalkingStyle { get; set; }

		public DateTime? LastPlayed { get; set; }

		[Required]
		[ForeignKey("User")]
		public Guid UserId { get; set; }

		public virtual User User { get; set; }

		[JsonIgnore]
		public string FullName => $"{this.Forename} {this.Middlename} {this.Surname}".Replace("  ", " ");
	}
}
