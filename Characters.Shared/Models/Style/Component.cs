using System.ComponentModel.DataAnnotations;

namespace IgiCore.Characters.Shared.Models.Style
{
	/// <summary>
	/// Represents a game character's style component
	/// </summary>
	public class Component
	{
		/// <summary>
		/// Gets or sets the component type.
		/// </summary>
		/// <value>
		/// The component type.
		/// </value>
		[Required]
		public ComponentTypes Type { get; set; }

		/// <summary>
		/// Gets or sets the component index.
		/// </summary>
		/// <value>
		/// The component index.
		/// </value>
		[Required]
		public int Index { get; set; }

		/// <summary>
		/// Gets or sets the component texture.
		/// </summary>
		/// <value>
		/// The component texture.
		/// </value>
		[Required]
		public int Texture { get; set; }
	}
}
