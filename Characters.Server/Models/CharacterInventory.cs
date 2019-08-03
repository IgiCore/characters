using System;
using IgiCore.Characters.Shared.Models;
using IgiCore.Inventory.Server.Models;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	public class CharacterInventory : IdentityModel, ICharacterInventory
	{
		public Guid CharacterId { get; set; }

		public virtual Character Character { get; set; }

		public Guid ContainerId { get; set; }

		public virtual Container Container { get; set; }
	}
}
