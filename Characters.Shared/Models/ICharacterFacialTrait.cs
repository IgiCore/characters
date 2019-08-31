using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	/// <summary>
	/// Represents a game character's facial traits
	/// </summary>
	public interface ICharacterFacialTrait : IIdentityModel
	{
		/// <summary>
		/// Gets or sets the width of the nose.
		/// </summary>
		/// <value>
		/// The width of the nose.
		/// </value>
		float NoseWidth { get; set; }

		/// <summary>
		/// Gets or sets the height of the nose peak.
		/// </summary>
		/// <value>
		/// The height of the nose peak.
		/// </value>
		float NosePeakHeight { get; set; }

		/// <summary>
		/// Gets or sets the length of the nose peak.
		/// </summary>
		/// <value>
		/// The length of the nose peak.
		/// </value>
		float NosePeakLength { get; set; }

		/// <summary>
		/// Gets or sets the height of the nose bone.
		/// </summary>
		/// <value>
		/// The height of the nose bone.
		/// </value>
		float NoseBoneHeight { get; set; }

		/// <summary>
		/// Gets or sets the nose peak lowering.
		/// </summary>
		/// <value>
		/// The nose peak lowering.
		/// </value>
		float NosePeakLowering { get; set; }

		/// <summary>
		/// Gets or sets the nose bone twist.
		/// </summary>
		/// <value>
		/// The nose bone twist.
		/// </value>
		float NoseBoneTwist { get; set; }

		/// <summary>
		/// Gets or sets the height of the eye brow.
		/// </summary>
		/// <value>
		/// The height of the eye brow.
		/// </value>
		float EyeBrowHeight { get; set; }

		/// <summary>
		/// Gets or sets the length of the eye brow.
		/// </summary>
		/// <value>
		/// The length of the eye brow.
		/// </value>
		float EyeBrowLength { get; set; }

		/// <summary>
		/// Gets or sets the height of the cheek bone.
		/// </summary>
		/// <value>
		/// The height of the cheek bone.
		/// </value>
		float CheekBoneHeight { get; set; }

		/// <summary>
		/// Gets or sets the width of the cheek bone.
		/// </summary>
		/// <value>
		/// The width of the cheek bone.
		/// </value>
		float CheekBoneWidth { get; set; }

		/// <summary>
		/// Gets or sets the width of the cheek.
		/// </summary>
		/// <value>
		/// The width of the cheek.
		/// </value>
		float CheekWidth { get; set; }

		/// <summary>
		/// Gets or sets the eye openings.
		/// </summary>
		/// <value>
		/// The eye openings.
		/// </value>
		float EyeOpenings { get; set; }

		/// <summary>
		/// Gets or sets the lip thickness.
		/// </summary>
		/// <value>
		/// The lip thickness.
		/// </value>
		float LipThickness { get; set; }

		/// <summary>
		/// Gets or sets the width of the jaw bone.
		/// </summary>
		/// <value>
		/// The width of the jaw bone.
		/// </value>
		float JawBoneWidth { get; set; }

		/// <summary>
		/// Gets or sets the length of the jaw bone.
		/// </summary>
		/// <value>
		/// The length of the jaw bone.
		/// </value>
		float JawBoneLength { get; set; }

		/// <summary>
		/// Gets or sets the chin bone lowering.
		/// </summary>
		/// <value>
		/// The chin bone lowering.
		/// </value>
		float ChinBoneLowering { get; set; }

		/// <summary>
		/// Gets or sets the length of the chin bone.
		/// </summary>
		/// <value>
		/// The length of the chin bone.
		/// </value>
		float ChinBoneLength { get; set; }

		/// <summary>
		/// Gets or sets the width of the chin bone.
		/// </summary>
		/// <value>
		/// The width of the chin bone.
		/// </value>
		float ChinBoneWidth { get; set; }

		/// <summary>
		/// Gets or sets the chin dimple.
		/// </summary>
		/// <value>
		/// The chin dimple.
		/// </value>
		float ChinDimple { get; set; }

		/// <summary>
		/// Gets or sets the neck thickness.
		/// </summary>
		/// <value>
		/// The neck thickness.
		/// </value>
		float NeckThickness { get; set; }
	}
}
