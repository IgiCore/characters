using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Appearance;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	public class Appearance : IdentityModel, IAppearance
	{
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

		public Feature Ageing { get; set; }
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

		public Appearance()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();

			this.Brows = new FeaturePointF();
			this.CheekBones = new FeaturePointF();
			this.ChinProfile = new FeaturePointF();
			this.ChinShape = new FeaturePointF();
			this.Jaw = new FeaturePointF();
			this.Nose = new FeaturePointF();
			this.NoseProfile = new FeaturePointF();
			this.NoseTip = new FeaturePointF();

			this.Ageing = new Feature();
			this.Beard = new Feature();
			this.Blemishes = new Feature();
			this.Blush = new Feature();
			this.Chest = new Feature();
			this.Complexion = new Feature();
			this.Eyebrows = new Feature();
			this.Lipstick = new Feature();
			this.Makeup = new Feature();
			this.MolesAndFreckles = new Feature();
			this.SunDamage = new Feature();
		}

		
	}
}
