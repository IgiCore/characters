using IgiCore.Characters.Shared.Models.Appearance;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	public interface IAppearance : IIdentityModel
	{
		int EyeColorId { get; set; }
		int HairColorId { get; set; }
		int HairHighlightColor { get; set; }
		
		Feature Ageing { get; set; }
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
