using System;

namespace IgiCore.Characters.Shared.Models
{
	public interface ICharacterInventory
	{
		Guid CharacterId { get; set; }
		Guid ContainerId { get; set; }
	}
}
