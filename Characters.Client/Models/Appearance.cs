using System;
using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Appearance;

namespace IgiCore.Characters.Client.Models
{
	public class Appearance : IAppearance
	{
		public Guid Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Deleted { get; set; }
		public int EyeColorId { get; set; }
		public int HairColorId { get; set; }
		public int HairHighlightColor { get; set; }
		public Feature Beard { get; set; }
		public Feature Eyebrows { get; set; }
		public Feature Age { get; set; }
		public Feature Makeup { get; set; }
		public Feature Blush { get; set; }
		public Feature Complexion { get; set; }
		public Feature SunDamage { get; set; }
		public Feature Lipstick { get; set; }
		public Feature MolesAndFreckles { get; set; }
		public Feature Chest { get; set; }
		public Feature Blemishes { get; set; }
	}
}
