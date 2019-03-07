using IgiCore.Characters.Shared.Models.Appearance;
using JetBrains.Annotations;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	[PublicAPI]
	public interface IAppearance : IIdentityModel
	{
		Component Face { get; set; }
		Component Head { get; set; }
		Component Hair { get; set; }
		Component Torso { get; set; }
		Component Torso2 { get; set; }
		Component Legs { get; set; }
		Component Hands { get; set; }
		Component Shoes { get; set; }
		Component Special1 { get; set; }
		Component Special2 { get; set; }
		Component Special3 { get; set; }
		Component Textures { get; set; }

		Prop Hat { get; set; }
		Prop Glasses { get; set; }
		Prop EarPiece { get; set; }
		Prop Unknown3 { get; set; }
		Prop Unknown4 { get; set; }
		Prop Unknown5 { get; set; }
		Prop Watch { get; set; }
		Prop Wristband { get; set; }
		Prop Unknown8 { get; set; }
		Prop Unknown9 { get; set; }
	}
}
