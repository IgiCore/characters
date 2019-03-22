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

		public Appearance()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();

			this.Age = new Feature(FeatureTypes.Age, FeatureColorTypes.Misc);
			this.Beard = new Feature(FeatureTypes.Beard, FeatureColorTypes.Beards);
			this.Blemishes = new Feature(FeatureTypes.Blemishes, FeatureColorTypes.Misc);
			this.Blush = new Feature(FeatureTypes.Blush, FeatureColorTypes.Blush);
			this.Chest = new Feature(FeatureTypes.Chest, FeatureColorTypes.Chest);
			this.Complexion = new Feature(FeatureTypes.Complexion, FeatureColorTypes.Misc);
			this.Eyebrows = new Feature(FeatureTypes.Eyebrows, FeatureColorTypes.EyeBrows);
			this.Lipstick = new Feature(FeatureTypes.Lipstick, FeatureColorTypes.Lipstick);
			this.Makeup = new Feature(FeatureTypes.Makeup, FeatureColorTypes.Misc);
			this.MolesAndFreckles = new Feature(FeatureTypes.MolesAndFreckles, FeatureColorTypes.Misc);
			this.SunDamage = new Feature(FeatureTypes.SunDamage, FeatureColorTypes.Misc);
		}
	}
}
