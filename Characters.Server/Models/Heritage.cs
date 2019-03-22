using IgiCore.Characters.Shared.Models;
using NFive.SDK.Core.Helpers;
using System;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	public class Heritage : IdentityModel, IHeritage
	{
		public int Parent1 { get; set; }
		public int Parent2 { get; set; }
		public float Resemblance { get; set; }
		public float SkinTone { get; set; }

		public Heritage()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();
		}
	}
}
