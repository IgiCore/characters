using IgiCore.Characters.Shared.Models.Style;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	/// <summary>
	/// Represents a game character's clothing and props.
	/// </summary>
	/// <seealso cref="IIdentityModel" />
	public interface ICharacterStyle : IIdentityModel
	{
		/// <summary>
		/// Gets or sets the face component.
		/// </summary>
		/// <value>
		/// The face component.
		/// </value>
		Component Face { get; set; }

		/// <summary>
		/// Gets or sets the head component.
		/// </summary>
		/// <value>
		/// The head component.
		/// </value>
		Component Head { get; set; }

		/// <summary>
		/// Gets or sets the hair component.
		/// </summary>
		/// <value>
		/// The hair component.
		/// </value>
		Component Hair { get; set; }

		/// <summary>
		/// Gets or sets the torso component.
		/// </summary>
		/// <value>
		/// The torso component.
		/// </value>
		Component Torso { get; set; }

		/// <summary>
		/// Gets or sets the torso2 component.
		/// </summary>
		/// <value>
		/// The torso2 component.
		/// </value>
		Component Torso2 { get; set; }

		/// <summary>
		/// Gets or sets the legs component.
		/// </summary>
		/// <value>
		/// The legs component.
		/// </value>
		Component Legs { get; set; }

		/// <summary>
		/// Gets or sets the hands component.
		/// </summary>
		/// <value>
		/// The hands component.
		/// </value>
		Component Hands { get; set; }

		/// <summary>
		/// Gets or sets the shoes component.
		/// </summary>
		/// <value>
		/// The shoes component.
		/// </value>
		Component Shoes { get; set; }

		/// <summary>
		/// Gets or sets the special1 component.
		/// </summary>
		/// <value>
		/// The special1 component.
		/// </value>
		Component Special1 { get; set; }

		/// <summary>
		/// Gets or sets the special2 component.
		/// </summary>
		/// <value>
		/// The special2 component.
		/// </value>
		Component Special2 { get; set; }

		/// <summary>
		/// Gets or sets the special3 component.
		/// </summary>
		/// <value>
		/// The special3 component.
		/// </value>
		Component Special3 { get; set; }

		/// <summary>
		/// Gets or sets the textures component.
		/// </summary>
		/// <value>
		/// The textures component.
		/// </value>
		Component Textures { get; set; }


		/// <summary>
		/// Gets or sets the hat prop.
		/// </summary>
		/// <value>
		/// The hat prop.
		/// </value>
		Prop Hat { get; set; }

		/// <summary>
		/// Gets or sets the glasses prop.
		/// </summary>
		/// <value>
		/// The glasses prop.
		/// </value>
		Prop Glasses { get; set; }

		/// <summary>
		/// Gets or sets the ear piece prop.
		/// </summary>
		/// <value>
		/// The ear piece prop.
		/// </value>
		Prop EarPiece { get; set; }

		/// <summary>
		/// Gets or sets the unknown3 prop.
		/// </summary>
		/// <value>
		/// The unknown3 prop.
		/// </value>
		Prop Unknown3 { get; set; }

		/// <summary>
		/// Gets or sets the unknown4 prop.
		/// </summary>
		/// <value>
		/// The unknown4 prop.
		/// </value>
		Prop Unknown4 { get; set; }

		/// <summary>
		/// Gets or sets the unknown5 prop.
		/// </summary>
		/// <value>
		/// The unknown5 prop.
		/// </value>
		Prop Unknown5 { get; set; }

		/// <summary>
		/// Gets or sets the watch prop.
		/// </summary>
		/// <value>
		/// The watch prop.
		/// </value>
		Prop Watch { get; set; }

		/// <summary>
		/// Gets or sets the wristband prop.
		/// </summary>
		/// <value>
		/// The wristband prop.
		/// </value>
		Prop Wristband { get; set; }

		/// <summary>
		/// Gets or sets the unknown8 prop.
		/// </summary>
		/// <value>
		/// The unknown8 prop.
		/// </value>
		Prop Unknown8 { get; set; }

		/// <summary>
		/// Gets or sets the unknown9 prop.
		/// </summary>
		/// <value>
		/// The unknown9 prop.
		/// </value>
		Prop Unknown9 { get; set; }
	}
}
