using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Appearance;
using NFive.SDK.Core.Models;
using System;

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

		public float Cheeks { get; set; }
		public float EyesWidth { get; set; }
		public float Lips { get; set; }

		public Position Brows { get; set; }
		public Position CheekBones { get; set; }
		public Position ChinProfile { get; set; }
		public Position ChinShape { get; set; }
		public Position Jaw { get; set; }
		public Position Nose { get; set; }
		public Position NoseProfile { get; set; }
		public Position NoseTip { get; set; }

		public Feature Age { get; set; }
		public Feature Beard { get; set; }
		public Feature Blush { get; set; }
		public Feature Blemishes { get; set; }
		public Feature Chest { get; set; }
		public Feature Complexion { get; set; }
		public Feature Eyebrows { get; set; }
		public Feature Lipstick { get; set; }
		public Feature Makeup { get; set; }
		public Feature MolesAndFreckles { get; set; }
		public Feature SunDamage { get; set; }
	}
}
