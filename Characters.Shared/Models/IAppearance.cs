using IgiCore.Characters.Shared.Models.Appearance;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	public interface IAppearance : IIdentityModel
	{
		int EyeColorId { get; set; }
		int HairColorId { get; set; }
		int HairHighlightColor { get; set; }

		Feature Beard { get; set; }
		Feature Eyebrows { get; set; }
		Feature Age { get; set; }
		Feature Makeup { get; set; }
		Feature Blush { get; set; }
		Feature Complexion { get; set; }
		Feature SunDamage { get; set; }
		Feature Lipstick { get; set; }
		Feature MolesAndFreckles { get; set; }
		Feature Chest { get; set; }
		Feature Blemishes { get; set; }
	}
}
