using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgiCore.Characters.Shared.Models
{
	public interface ICharacter
	{
		Guid Id { get; set; }
		string Forename { get; set; }
		string Middlename { get; set; }
		string Surname { get; set; }
		DateTime DateOfBirth { get; set; }
		short Gender { get; set; }
		bool Alive { get; set; }
		int Health { get; set; }
		int Armor { get; set; }
		string Ssn { get; set; }
		float PosX { get; set; }
		float PosY { get; set; }
		float PosZ { get; set; }
		string Model { get; set; }
		string WalkingStyle { get; set; }
		DateTime? LastPlayed { get; set; }
		DateTime? Deleted { get; set; }
		DateTime Created { get; set; }
	}
}
