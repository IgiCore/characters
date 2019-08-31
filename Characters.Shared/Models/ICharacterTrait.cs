using IgiCore.Characters.Shared.Models.Trait;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	/// <summary>
	/// Represents a game character's appearance traits.
	/// </summary>
	/// <seealso cref="IIdentityModel" />
	public interface ICharacterTrait : IIdentityModel
	{
		/// <summary>
		/// Gets or sets the eye color identifier.
		/// </summary>
		/// <value>
		/// The eye color identifier.
		/// </value>
		int EyeColorId { get; set; }

		/// <summary>
		/// Gets or sets the hair color identifier.
		/// </summary>
		/// <value>
		/// The hair color identifier.
		/// </value>
		int HairColorId { get; set; }

		/// <summary>
		/// Gets or sets the hair highlight color identifier.
		/// </summary>
		/// <value>
		/// The hair highlight color identifier.
		/// </value>
		int HairHighlightColor { get; set; }

		/// <summary>
		/// Gets or sets the blemishes trait.
		/// </summary>
		/// <value>
		/// The blemishes trait.
		/// </value>
		Feature Blemishes { get; set; }

		/// <summary>
		/// Gets or sets the beard trait.
		/// </summary>
		/// <value>
		/// The beard trait.
		/// </value>
		Feature Beard { get; set; }

		/// <summary>
		/// Gets or sets the eyebrows trait.
		/// </summary>
		/// <value>
		/// The eyebrows trait.
		/// </value>
		Feature Eyebrows { get; set; }

		/// <summary>
		/// Gets or sets the aging trait.
		/// </summary>
		/// <value>
		/// The aging trait.
		/// </value>
		Feature Aging { get; set; }

		/// <summary>
		/// Gets or sets the makeup trait.
		/// </summary>
		/// <value>
		/// The makeup trait.
		/// </value>
		Feature Makeup { get; set; }

		/// <summary>
		/// Gets or sets the blush trait.
		/// </summary>
		/// <value>
		/// The blush trait.
		/// </value>
		Feature Blush { get; set; }

		/// <summary>
		/// Gets or sets the complexion trait.
		/// </summary>
		/// <value>
		/// The complexion trait.
		/// </value>
		Feature Complexion { get; set; }

		/// <summary>
		/// Gets or sets the sun damage trait.
		/// </summary>
		/// <value>
		/// The sun damage trait.
		/// </value>
		Feature SunDamage { get; set; }

		/// <summary>
		/// Gets or sets the lipstick trait.
		/// </summary>
		/// <value>
		/// The lipstick trait.
		/// </value>
		Feature Lipstick { get; set; }

		/// <summary>
		/// Gets or sets the moles and freckles trait.
		/// </summary>
		/// <value>
		/// The moles and freckles trait.
		/// </value>
		Feature MolesAndFreckles { get; set; }

		/// <summary>
		/// Gets or sets the chest hair trait.
		/// </summary>
		/// <value>
		/// The chest hair trait.
		/// </value>
		Feature ChestHair { get; set; }

		/// <summary>
		/// Gets or sets the body blemishes trait.
		/// </summary>
		/// <value>
		/// The body blemishes trait.
		/// </value>
		Feature BodyBlemishes { get; set; }

		/// <summary>
		/// Gets or sets the add body blemishes trait.
		/// </summary>
		/// <value>
		/// The add body blemishes trait.
		/// </value>
		Feature AddBodyBlemishes { get; set; }
	}
}
