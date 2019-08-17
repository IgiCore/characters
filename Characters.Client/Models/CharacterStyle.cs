using CitizenFX.Core;
using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Style;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;
using System;
using Prop = IgiCore.Characters.Shared.Models.Style.Prop;

namespace IgiCore.Characters.Client.Models
{
	public class CharacterStyle : IdentityModel, ICharacterStyle
	{
		public Component Face { get; set; }
		public Component Head { get; set; }
		public Component Hair { get; set; }
		public Component Torso { get; set; }
		public Component Torso2 { get; set; }
		public Component Legs { get; set; }
		public Component Hands { get; set; }
		public Component Shoes { get; set; }
		public Component Special1 { get; set; }
		public Component Special2 { get; set; }
		public Component Special3 { get; set; }
		public Component Textures { get; set; }
		public Prop Hat { get; set; }
		public Prop Glasses { get; set; }
		public Prop EarPiece { get; set; }
		public Prop Unknown3 { get; set; }
		public Prop Unknown4 { get; set; }
		public Prop Unknown5 { get; set; }
		public Prop Watch { get; set; }
		public Prop Wristband { get; set; }
		public Prop Unknown8 { get; set; }
		public Prop Unknown9 { get; set; }

		public static CharacterStyle ConvertStyle(CitizenFX.Core.Style style, Guid? id = null) => new CharacterStyle
		{
			Id = id ?? GuidGenerator.GenerateTimeBasedGuid(),
			Face = new Component
			{
				Type = ComponentTypes.Face,
				Index = style[PedComponents.Face].Index,
				Texture = style[PedComponents.Face].TextureIndex
			},
			Head = new Component
			{
				Type = ComponentTypes.Head,
				Index = style[PedComponents.Head].Index,
				Texture = style[PedComponents.Head].TextureIndex
			},
			Hair = new Component
			{
				Type = ComponentTypes.Hair,
				Index = style[PedComponents.Hair].Index,
				Texture = style[PedComponents.Hair].TextureIndex
			},
			Torso = new Component
			{
				Type = ComponentTypes.Torso,
				Index = style[PedComponents.Torso].Index,
				Texture = style[PedComponents.Torso].TextureIndex
			},
			Legs = new Component
			{
				Type = ComponentTypes.Legs,
				Index = style[PedComponents.Legs].Index,
				Texture = style[PedComponents.Legs].TextureIndex
			},
			Hands = new Component
			{
				Type = ComponentTypes.Hands,
				Index = style[PedComponents.Hands].Index,
				Texture = style[PedComponents.Hands].TextureIndex
			},
			Shoes = new Component
			{
				Type = ComponentTypes.Shoes,
				Index = style[PedComponents.Shoes].Index,
				Texture = style[PedComponents.Shoes].TextureIndex
			},
			Special1 = new Component
			{
				Type = ComponentTypes.Special1,
				Index = style[PedComponents.Special1].Index,
				Texture = style[PedComponents.Special1].TextureIndex
			},
			Special2 = new Component
			{
				Type = ComponentTypes.Special2,
				Index = style[PedComponents.Special2].Index,
				Texture = style[PedComponents.Special2].TextureIndex
			},
			Special3 = new Component
			{
				Type = ComponentTypes.Special3,
				Index = style[PedComponents.Special3].Index,
				Texture = style[PedComponents.Special3].TextureIndex
			},
			Textures = new Component
			{
				Type = ComponentTypes.Textures,
				Index = style[PedComponents.Textures].Index,
				Texture = style[PedComponents.Textures].TextureIndex
			},
			Torso2 = new Component
			{
				Type = ComponentTypes.Torso2,
				Index = style[PedComponents.Torso2].Index,
				Texture = style[PedComponents.Torso2].TextureIndex
			},

			Hat = new Prop
			{
				Type = PropTypes.Hats,
				Index = style[PedProps.Hats].Index,
				Texture = style[PedProps.Hats].TextureIndex
			},
			Glasses = new Prop
			{
				Type = PropTypes.Glasses,
				Index = style[PedProps.Glasses].Index,
				Texture = style[PedProps.Glasses].TextureIndex
			},
			EarPiece = new Prop
			{
				Type = PropTypes.EarPieces,
				Index = style[PedProps.EarPieces].Index,
				Texture = style[PedProps.EarPieces].TextureIndex
			},
			Unknown3 = new Prop
			{
				Type = PropTypes.Unknown3,
				Index = style[PedProps.Unknown3].Index,
				Texture = style[PedProps.Unknown3].TextureIndex
			},
			Unknown4 = new Prop
			{
				Type = PropTypes.Unknown4,
				Index = style[PedProps.Unknown4].Index,
				Texture = style[PedProps.Unknown4].TextureIndex
			},
			Unknown5 = new Prop
			{
				Type = PropTypes.Unknown5,
				Index = style[PedProps.Unknown5].Index,
				Texture = style[PedProps.Unknown5].TextureIndex
			},
			Watch = new Prop
			{
				Type = PropTypes.Watches,
				Index = style[PedProps.Watches].Index,
				Texture = style[PedProps.Watches].TextureIndex
			},
			Wristband = new Prop
			{
				Type = PropTypes.Wristbands,
				Index = style[PedProps.Wristbands].Index,
				Texture = style[PedProps.Wristbands].TextureIndex
			},
			Unknown8 = new Prop
			{
				Type = PropTypes.Unknown8,
				Index = style[PedProps.Unknown8].Index,
				Texture = style[PedProps.Unknown8].TextureIndex
			},
			Unknown9 = new Prop
			{
				Type = PropTypes.Unknown9,
				Index = style[PedProps.Unknown9].Index,
				Texture = style[PedProps.Unknown9].TextureIndex
			}
		};
	}
}
