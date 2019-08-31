using System.ComponentModel.DataAnnotations;
using IgiCore.Characters.Shared.Models;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	/// <summary>
	/// Represents a game character's heritage.
	/// </summary>
	/// <seealso cref="IdentityModel" />
	/// <seealso cref="ICharacterHeritage" />
	public class CharacterHeritage : IdentityModel, ICharacterHeritage
	{
		/// <summary>
		/// Gets or sets the first parent.
		/// </summary>
		/// <value>
		/// The first parent.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int Parent1 { get; set; }

		/// <summary>
		/// Gets or sets the second parent.
		/// </summary>
		/// <value>
		/// The second parent.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int Parent2 { get; set; }

		/// <summary>
		/// Gets or sets the parent resemblance.
		/// </summary>
		/// <value>
		/// The parent resemblance percentage.
		/// </value>
		[Required]
		[Range(0f, 1f)]
		public float Resemblance { get; set; }

		/// <summary>
		/// Gets or sets the skin tone.
		/// </summary>
		/// <value>
		/// The skin tone percentage.
		/// </value>
		[Required]
		[Range(0f, 1f)]
		public float SkinTone { get; set; }

		public CharacterHeritage()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();
		}
	}
}
