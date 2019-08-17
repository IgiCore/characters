using System.ComponentModel.DataAnnotations;

namespace IgiCore.Characters.Shared.Models.Trait
{
	/// <summary>
	/// Represents a game character's trait feature
	/// </summary>
	public class Feature
	{
		/// <summary>
		/// Gets or sets the index identifier.
		/// </summary>
		/// <value>
		/// The index identifier.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int Index { get; set; }

		/// <summary>
		/// Gets or sets the opacity.
		/// </summary>
		/// <value>
		/// The opacity.
		/// </value>
		[Required]
		[Range(0f, 1f)]
		public float Opacity { get; set; }

		/// <summary>
		/// Gets or sets the color identifier.
		/// </summary>
		/// <value>
		/// The color identifier.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int ColorId { get; set; }

		/// <summary>
		/// Gets or sets the second color identifier.
		/// </summary>
		/// <value>
		/// The second color identifier.
		/// </value>
		[Required]
		[Range(0, 255)]
		public int SecondColorId { get; set; }
	}
}
