using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	/// <summary>
	/// Represents a game character's heritage.
	/// </summary>
	/// <seealso cref="IIdentityModel" />
	public interface ICharacterHeritage : IIdentityModel
	{
		/// <summary>
		/// Gets or sets the first parent.
		/// </summary>
		/// <value>
		/// The first parent.
		/// </value>
		int Parent1 { get; set; }

		/// <summary>
		/// Gets or sets the second parent.
		/// </summary>
		/// <value>
		/// The second parent.
		/// </value>
		int Parent2 { get; set; }

		/// <summary>
		/// Gets or sets the parent resemblance.
		/// </summary>
		/// <value>
		/// The parent resemblance percentage.
		/// </value>
		float Resemblance { get; set; }

		/// <summary>
		/// Gets or sets the skin tone.
		/// </summary>
		/// <value>
		/// The skin tone percentage.
		/// </value>
		float SkinTone { get; set; }
	}
}
