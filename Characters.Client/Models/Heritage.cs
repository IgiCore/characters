using IgiCore.Characters.Shared.Models;
using System;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Client.Models
{
	public class Heritage : IHeritage
	{
		public Guid Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Deleted { get; set; }
		public int Mother { get; set; }
		public int Father { get; set; }
		public float Resemblance { get; set; }
		public float SkinTone { get; set; }
	}
}
