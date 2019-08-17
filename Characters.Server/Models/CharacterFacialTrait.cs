using System.ComponentModel.DataAnnotations;
using Google.Protobuf.WellKnownTypes;
using IgiCore.Characters.Shared.Models;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	/// <inheritdoc cref="ICharacterFacialTrait" />
	/// <summary>
	/// Represents a game character's facial traits
	/// </summary>
	/// <seealso cref="IdentityModel" />
	/// <seealso cref="ICharacterFacialTrait" />
	public class CharacterFacialTrait : IdentityModel, ICharacterFacialTrait
	{
		/// <summary>
		/// Gets or sets the width of the nose.
		/// </summary>
		/// <value>
		/// The width of the nose.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float NoseWidth { get; set; }

		/// <summary>
		/// Gets or sets the height of the nose peak.
		/// </summary>
		/// <value>
		/// The height of the nose peak.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float NosePeakHeight { get; set; }

		/// <summary>
		/// Gets or sets the length of the nose peak.
		/// </summary>
		/// <value>
		/// The length of the nose peak.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float NosePeakLength { get; set; }

		/// <summary>
		/// Gets or sets the height of the nose bone.
		/// </summary>
		/// <value>
		/// The height of the nose bone.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float NoseBoneHeight { get; set; }

		/// <summary>
		/// Gets or sets the nose peak lowering.
		/// </summary>
		/// <value>
		/// The nose peak lowering.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float NosePeakLowering { get; set; }

		/// <summary>
		/// Gets or sets the nose bone twist.
		/// </summary>
		/// <value>
		/// The nose bone twist.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float NoseBoneTwist { get; set; }

		/// <summary>
		/// Gets or sets the height of the eye brow.
		/// </summary>
		/// <value>
		/// The height of the eye brow.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float EyeBrowHeight { get; set; }

		/// <summary>
		/// Gets or sets the length of the eye brow.
		/// </summary>
		/// <value>
		/// The length of the eye brow.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float EyeBrowLength { get; set; }

		/// <summary>
		/// Gets or sets the height of the cheek bone.
		/// </summary>
		/// <value>
		/// The height of the cheek bone.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float CheekBoneHeight { get; set; }

		/// <summary>
		/// Gets or sets the width of the cheek bone.
		/// </summary>
		/// <value>
		/// The width of the cheek bone.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float CheekBoneWidth { get; set; }

		/// <summary>
		/// Gets or sets the width of the cheek.
		/// </summary>
		/// <value>
		/// The width of the cheek.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float CheekWidth { get; set; }

		/// <summary>
		/// Gets or sets the eye openings.
		/// </summary>
		/// <value>
		/// The eye openings.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float EyeOpenings { get; set; }

		/// <summary>
		/// Gets or sets the lip thickness.
		/// </summary>
		/// <value>
		/// The lip thickness.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float LipThickness { get; set; }

		/// <summary>
		/// Gets or sets the width of the jaw bone.
		/// </summary>
		/// <value>
		/// The width of the jaw bone.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float JawBoneWidth { get; set; }

		/// <summary>
		/// Gets or sets the length of the jaw bone.
		/// </summary>
		/// <value>
		/// The length of the jaw bone.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float JawBoneLength { get; set; }

		/// <summary>
		/// Gets or sets the chin bone lowering.
		/// </summary>
		/// <value>
		/// The chin bone lowering.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float ChinBoneLowering { get; set; }

		/// <summary>
		/// Gets or sets the length of the chin bone.
		/// </summary>
		/// <value>
		/// The length of the chin bone.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float ChinBoneLength { get; set; }

		/// <summary>
		/// Gets or sets the width of the chin bone.
		/// </summary>
		/// <value>
		/// The width of the chin bone.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float ChinBoneWidth { get; set; }

		/// <summary>
		/// Gets or sets the chin dimple.
		/// </summary>
		/// <value>
		/// The chin dimple.</value>
		[Required]
		[Range(-1f, 1f)]
		public float ChinDimple { get; set; }

		/// <summary>
		/// Gets or sets the neck thickness.
		/// </summary>
		/// <value>
		/// The neck thickness.
		/// </value>
		[Required]
		[Range(-1f, 1f)]
		public float NeckThickness { get; set; }

		public CharacterFacialTrait()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();
		}
	}
}
