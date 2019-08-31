using System.ComponentModel.DataAnnotations;
using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Style;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
{
	/// <summary>
	/// Represents a game character's clothing and props.
	/// </summary>
	/// <seealso cref="IdentityModel" />
	/// <seealso cref="ICharacterStyle" />
	public class CharacterStyle : IdentityModel, ICharacterStyle
	{
		/// <summary>
		/// Gets or sets the face component.
		/// </summary>
		/// <value>
		/// The face component.
		/// </value>
		public Component Face { get; set; }

		/// <summary>
		/// Gets or sets the head component.
		/// </summary>
		/// <value>
		/// The head component.
		/// </value>
		public Component Head { get; set; }

		/// <summary>
		/// Gets or sets the hair component.
		/// </summary>
		/// <value>
		/// The hair component.
		/// </value>
		public Component Hair { get; set; }

		/// <summary>
		/// Gets or sets the torso component.
		/// </summary>
		/// <value>
		/// The torso component.
		/// </value>
		public Component Torso { get; set; }

		/// <summary>
		/// Gets or sets the torso2 component.
		/// </summary>
		/// <value>
		/// The torso2 component.
		/// </value>
		public Component Torso2 { get; set; }

		/// <summary>
		/// Gets or sets the legs component.
		/// </summary>
		/// <value>
		/// The legs component.
		/// </value>
		public Component Legs { get; set; }

		/// <summary>
		/// Gets or sets the hands component.
		/// </summary>
		/// <value>
		/// The hands component.
		/// </value>
		public Component Hands { get; set; }

		/// <summary>
		/// Gets or sets the shoes component.
		/// </summary>
		/// <value>
		/// The shoes component.
		/// </value>
		public Component Shoes { get; set; }

		/// <summary>
		/// Gets or sets the special1 component.
		/// </summary>
		/// <value>
		/// The special1 component.
		/// </value>
		public Component Special1 { get; set; }

		/// <summary>
		/// Gets or sets the special2 component.
		/// </summary>
		/// <value>
		/// The special2 component.
		/// </value>
		public Component Special2 { get; set; }

		/// <summary>
		/// Gets or sets the special3 component.
		/// </summary>
		/// <value>
		/// The special3 component.
		/// </value>
		public Component Special3 { get; set; }

		/// <summary>
		/// Gets or sets the textures component.
		/// </summary>
		/// <value>
		/// The textures component.
		/// </value>
		public Component Textures { get; set; }


		/// <summary>
		/// Gets or sets the hat prop.
		/// </summary>
		/// <value>
		/// The hat prop.
		/// </value>
		public Prop Hat { get; set; }

		/// <summary>
		/// Gets or sets the glasses prop.
		/// </summary>
		/// <value>
		/// The glasses prop.
		/// </value>
		public Prop Glasses { get; set; }

		/// <summary>
		/// Gets or sets the ear piece prop.
		/// </summary>
		/// <value>
		/// The ear piece prop.
		/// </value>
		public Prop EarPiece { get; set; }

		/// <summary>
		/// Gets or sets the unknown3 prop.
		/// </summary>
		/// <value>
		/// The unknown3 prop.
		/// </value>
		public Prop Unknown3 { get; set; }

		/// <summary>
		/// Gets or sets the unknown4 prop.
		/// </summary>
		/// <value>
		/// The unknown4 prop.
		/// </value>
		public Prop Unknown4 { get; set; }

		/// <summary>
		/// Gets or sets the unknown5 prop.
		/// </summary>
		/// <value>
		/// The unknown5 prop.
		/// </value>
		public Prop Unknown5 { get; set; }

		/// <summary>
		/// Gets or sets the watch prop.
		/// </summary>
		/// <value>
		/// The watch prop.
		/// </value>
		public Prop Watch { get; set; }

		/// <summary>
		/// Gets or sets the wristband prop.
		/// </summary>
		/// <value>
		/// The wristband prop.
		/// </value>
		public Prop Wristband { get; set; }

		/// <summary>
		/// Gets or sets the unknown8 prop.
		/// </summary>
		/// <value>
		/// The unknown8 prop.
		/// </value>
		public Prop Unknown8 { get; set; }

		/// <summary>
		/// Gets or sets the unknown9 prop.
		/// </summary>
		/// <value>
		/// The unknown9 prop.
		/// </value>
		public Prop Unknown9 { get; set; }

		public CharacterStyle()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();

			this.Face = new Component();
			this.Head = new Component();
			this.Hair = new Component();
			this.Torso = new Component();
			this.Torso2 = new Component();
			this.Legs = new Component();
			this.Hands = new Component();
			this.Shoes = new Component();
			this.Special1 = new Component();
			this.Special2 = new Component();
			this.Special3 = new Component();
			this.Textures = new Component();

			this.Hat = new Prop();
			this.Glasses = new Prop();
			this.EarPiece = new Prop();
			this.Unknown3 = new Prop();
			this.Unknown4 = new Prop();
			this.Unknown5 = new Prop();
			this.Watch = new Prop();
			this.Wristband = new Prop();
			this.Unknown8 = new Prop();
			this.Unknown9 = new Prop();
		}
	}
}
