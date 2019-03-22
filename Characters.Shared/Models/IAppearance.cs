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

		Position Brows { get; set; }
		Position CheekBones { get; set; }
		Position ChinProfile { get; set; }
		Position ChinShape { get; set; }
		Position Jaw { get; set; }
		Position Nose { get; set; }
		Position NoseProfile { get; set; }
		Position NoseTip { get; set; }
		
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
