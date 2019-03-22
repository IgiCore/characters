using IgiCore.Characters.Shared.Models.Appearance;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	public interface IAppearance : IIdentityModel
	{
		int EyeColorId { get; set; }
		int HairColorId { get; set; }
		int HairHighlightColor { get; set; }

		float Cheeks { get; set; }
		float EyesWidth { get; set; }
		float Lips { get; set; }

		FeaturePointF Brows { get; set; }
		FeaturePointF CheekBones { get; set; }
		FeaturePointF ChinProfile { get; set; }
		FeaturePointF ChinShape { get; set; }
		FeaturePointF Jaw { get; set; }
		FeaturePointF Nose { get; set; }
		FeaturePointF NoseProfile { get; set; }
		FeaturePointF NoseTip { get; set; }
		
		Feature Age { get; set; }
		Feature Beard { get; set; }
		Feature Blush { get; set; }
		Feature Blemishes { get; set; }
		Feature Chest { get; set; }
		Feature Complexion { get; set; }
		Feature Eyebrows { get; set; }
		Feature Lipstick { get; set; }
		Feature Makeup { get; set; }
		Feature MolesAndFreckles { get; set; }
		Feature SunDamage { get; set; }
	}
}
