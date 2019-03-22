using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Appearance;
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

		public FeaturePointF Brows { get; set; }
		public FeaturePointF CheekBones { get; set; }
		public FeaturePointF ChinProfile { get; set; }
		public FeaturePointF ChinShape { get; set; }
		public FeaturePointF Jaw { get; set; }
		public FeaturePointF Nose { get; set; }
		public FeaturePointF NoseProfile { get; set; }
		public FeaturePointF NoseTip { get; set; }

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
