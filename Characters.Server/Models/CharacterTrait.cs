using System;
using System.ComponentModel.DataAnnotations;
using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Trait;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	/// <summary>
	/// Represents a game character's appearance traits.
	/// </summary>
	/// <seealso cref="IdentityModel" />
	/// <seealso cref="ICharacterTrait" />
	public class CharacterTrait : IdentityModel, ICharacterTrait
	{
		/// <summary>
		/// Gets or sets the eye color identifier.
		/// </summary>
		/// <value>
		/// The eye color identifier.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int EyeColorId { get; set; }

		/// <summary>
		/// Gets or sets the hair color identifier.
		/// </summary>
		/// <value>
		/// The hair color identifier.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int HairColorId { get; set; }

		/// <summary>
		/// Gets or sets the hair highlight color identifier.
		/// </summary>
		/// <value>
		/// The hair highlight color identifier.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int HairHighlightColor { get; set; }

		/// <summary>
		/// Gets or sets the blemishes trait.
		/// </summary>
		/// <value>
		/// The blemishes trait.
		/// </value>
		public Feature Blemishes { get; set; }

		/// <summary>
		/// Gets or sets the beard trait.
		/// </summary>
		/// <value>
		/// The beard trait.
		/// </value>
		public Feature Beard { get; set; }

		/// <summary>
		/// Gets or sets the eyebrows trait.
		/// </summary>
		/// <value>
		/// The eyebrows trait.
		/// </value>
		public Feature Eyebrows { get; set; }

		/// <summary>
		/// Gets or sets the aging trait.
		/// </summary>
		/// <value>
		/// The aging trait.
		/// </value>
		public Feature Aging { get; set; }

		/// <summary>
		/// Gets or sets the makeup trait.
		/// </summary>
		/// <value>
		/// The makeup trait.
		/// </value>
		public Feature Makeup { get; set; }

		/// <summary>
		/// Gets or sets the blush trait.
		/// </summary>
		/// <value>
		/// The blush trait.
		/// </value>
		public Feature Blush { get; set; }

		/// <summary>
		/// Gets or sets the complexion trait.
		/// </summary>
		/// <value>
		/// The complexion trait.
		/// </value>
		public Feature Complexion { get; set; }

		/// <summary>
		/// Gets or sets the sun damage trait.
		/// </summary>
		/// <value>
		/// The sun damage trait.
		/// </value>
		public Feature SunDamage { get; set; }

		/// <summary>
		/// Gets or sets the lipstick trait.
		/// </summary>
		/// <value>
		/// The lipstick trait.
		/// </value>
		public Feature Lipstick { get; set; }

		/// <summary>
		/// Gets or sets the moles and freckles trait.
		/// </summary>
		/// <value>
		/// The moles and freckles trait.
		/// </value>
		public Feature MolesAndFreckles { get; set; }

		/// <summary>
		/// Gets or sets the chest hair trait.
		/// </summary>
		/// <value>
		/// The chest hair trait.
		/// </value>
		public Feature ChestHair { get; set; }

		/// <summary>
		/// Gets or sets the body blemishes trait.
		/// </summary>
		/// <value>
		/// The body blemishes trait.
		/// </value>
		public Feature BodyBlemishes { get; set; }

		/// <summary>
		/// Gets or sets the add body blemishes trait.
		/// </summary>
		/// <value>
		/// The add body blemishes trait.
		/// </value>
		public Feature AddBodyBlemishes { get; set; }

		public CharacterTrait()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();

			this.Blemishes = new Feature();
			this.Beard = new Feature();
			this.Eyebrows = new Feature();
			this.Aging = new Feature();
			this.Makeup = new Feature();
			this.Blush = new Feature();
			this.Complexion = new Feature();
			this.SunDamage = new Feature();
			this.Lipstick = new Feature();
			this.MolesAndFreckles = new Feature();
			this.ChestHair = new Feature();
			this.BodyBlemishes = new Feature();
			this.AddBodyBlemishes = new Feature();
		}
	}
}
