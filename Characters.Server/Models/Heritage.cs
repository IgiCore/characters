using IgiCore.Characters.Shared.Models;
using NFive.SDK.Core.Helpers;
using System;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	public class Heritage : IdentityModel, IHeritage
	{
		public int Mother { get; set; }
		public int Father { get; set; }
		public float Resemblance { get; set; }
		public float SkinTone { get; set; }

		public Heritage()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();
		}
	}
}
