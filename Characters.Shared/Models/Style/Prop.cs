using System.ComponentModel.DataAnnotations;

namespace IgiCore.Characters.Shared.Models.Style
{
	/// <summary>
	/// Represents a game character's style prop
	/// </summary>
	public class Prop
	{
		/// <summary>
		/// Gets or sets the prop type.
		/// </summary>
		/// <value>
		/// The prop type.
		/// </value>
		[Required]
		public PropTypes Type { get; set; }

		/// <summary>
		/// Gets or sets the prop index.
		/// </summary>
		/// <value>
		/// The prop index.
		/// </value>
		[Required]
		public int Index { get; set; }

		/// <summary>
		/// Gets or sets the prop texture.
		/// </summary>
		/// <value>
		/// The prop texture.
		/// </value>
		[Required]
		public int Texture { get; set; }
	}
}
