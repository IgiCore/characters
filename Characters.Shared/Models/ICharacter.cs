using System;
using NFive.SDK.Core.Models;

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
		int Ssn { get; set; }
		Position Position { get; set; }
		string Model { get; set; }
		string WalkingStyle { get; set; }
		DateTime? LastPlayed { get; set; }
		DateTime? Deleted { get; set; }
		DateTime Created { get; set; }
	}
}
