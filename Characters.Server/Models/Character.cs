using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgiCore.Characters.Shared.Models;
using Newtonsoft.Json;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	public class Character : IdentityModel, ICharacter
	{
		public string Forename { get; set; }
		public string Middlename { get; set; }
		public string Surname { get; set; }
		public DateTime DateOfBirth { get; set; }
		public short Gender { get; set; }
		public bool Alive { get; set; }
		public int Health { get; set; }
		public int Armor { get; set; }
		public string Ssn { get; set; }
		public float PosX { get; set; }
		public float PosY { get; set; }
		public float PosZ { get; set; }
		public string Model { get; set; }
		public string WalkingStyle { get; set; }
		public DateTime? LastPlayed { get; set; }

		[JsonIgnore]
		public string FullName => $"{this.Forename} {this.Middlename} {this.Surname}".Replace("  ", " ");
	}
}
