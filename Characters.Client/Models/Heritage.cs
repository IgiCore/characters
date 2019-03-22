using IgiCore.Characters.Shared.Models;
using System;

namespace IgiCore.Characters.Client.Models
{
	public class Heritage : IHeritage
	{
		public Guid Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Deleted { get; set; }
		public int Parent1 { get; set; }
		public int Parent2 { get; set; }
		public float Resemblance { get; set; }
		public float SkinTone { get; set; }
	}
}
