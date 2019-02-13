using CitizenFX.Core;
using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Appearance;
using Newtonsoft.Json;
using NFive.SDK.Client.Extensions;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;
using System;
using Prop = IgiCore.Characters.Shared.Models.Appearance.Prop;

namespace IgiCore.Characters.Client.Models
{
	public class Character : IdentityModel, ICharacter
	{
		public string Forename { get; set; }
		public string Middlename { get; set; }
		public string Surname { get; set; }
		public DateTime DateOfBirth { get; set; }
		public short Gender { get; set; }
		public bool Alive { get; set; }
		public int Health { get; set; }
		public int Armor { get; set; }
		public int Ssn { get; set; }
		public Position Position { get; set; }
		public string Model { get; set; }
		public string WalkingStyle { get; set; }
		public Guid AppearanceId { get; set; }
		public Appearance Appearance { get; set; }
		public DateTime? LastPlayed { get; set; }
		public Guid UserId { get; set; }

		[JsonIgnore] public string FullName => $"{this.Forename} {this.Middlename} {this.Surname}".Replace("  ", " ");

		[JsonIgnore] public PedHash ModelHash => (PedHash) Convert.ToUInt32(this.Model);

		public void Render()
		{
			Game.Player.Character.Position = this.Position.ToVector3();
			Game.Player.Character.Health = this.Health;
			Game.Player.Character.Armor = this.Armor;
			Game.Player.Character.MovementAnimationSet = this.WalkingStyle;

			Game.Player.Character.Style[PedComponents.Face].SetVariation(this.Appearance.Face.Index, this.Appearance.Face.Texture);
			Game.Player.Character.Style[PedComponents.Head].SetVariation(this.Appearance.Head.Index, this.Appearance.Head.Texture);
			Game.Player.Character.Style[PedComponents.Hair].SetVariation(this.Appearance.Hair.Index, this.Appearance.Hair.Texture);
			Game.Player.Character.Style[PedComponents.Torso].SetVariation(this.Appearance.Torso.Index, this.Appearance.Torso.Texture);
			Game.Player.Character.Style[PedComponents.Legs].SetVariation(this.Appearance.Legs.Index, this.Appearance.Legs.Texture);
			Game.Player.Character.Style[PedComponents.Hands].SetVariation(this.Appearance.Hands.Index, this.Appearance.Hands.Texture);
			Game.Player.Character.Style[PedComponents.Shoes].SetVariation(this.Appearance.Shoes.Index, this.Appearance.Shoes.Texture);
			Game.Player.Character.Style[PedComponents.Special1].SetVariation(this.Appearance.Special1.Index, this.Appearance.Special1.Texture);
			Game.Player.Character.Style[PedComponents.Special2].SetVariation(this.Appearance.Special2.Index, this.Appearance.Special2.Texture);
			Game.Player.Character.Style[PedComponents.Special3].SetVariation(this.Appearance.Special3.Index, this.Appearance.Special3.Texture);
			Game.Player.Character.Style[PedComponents.Textures].SetVariation(this.Appearance.Textures.Index, this.Appearance.Textures.Texture);
			Game.Player.Character.Style[PedComponents.Torso2].SetVariation(this.Appearance.Torso2.Index, this.Appearance.Torso2.Texture);

			Game.Player.Character.Style[PedProps.Hats].SetVariation(this.Appearance.Hat.Index, this.Appearance.Hat.Texture);
			Game.Player.Character.Style[PedProps.Glasses].SetVariation(this.Appearance.Glasses.Index, this.Appearance.Glasses.Texture);
			Game.Player.Character.Style[PedProps.EarPieces].SetVariation(this.Appearance.EarPiece.Index, this.Appearance.EarPiece.Texture);
			Game.Player.Character.Style[PedProps.Unknown3].SetVariation(this.Appearance.Unknown3.Index, this.Appearance.Unknown3.Texture);
			Game.Player.Character.Style[PedProps.Unknown4].SetVariation(this.Appearance.Unknown4.Index, this.Appearance.Unknown4.Texture);
			Game.Player.Character.Style[PedProps.Unknown5].SetVariation(this.Appearance.Unknown5.Index, this.Appearance.Unknown5.Texture);
			Game.Player.Character.Style[PedProps.Watches].SetVariation(this.Appearance.Watch.Index, this.Appearance.Watch.Texture);
			Game.Player.Character.Style[PedProps.Wristbands].SetVariation(this.Appearance.Wristband.Index, this.Appearance.Wristband.Texture);
			Game.Player.Character.Style[PedProps.Unknown8].SetVariation(this.Appearance.Unknown8.Index, this.Appearance.Unknown8.Texture);
			Game.Player.Character.Style[PedProps.Unknown9].SetVariation(this.Appearance.Unknown9.Index, this.Appearance.Unknown9.Texture);
		}

		public void SetComponent(int type, int index, int texture)
		{
			PedComponents componentType = (PedComponents) type;
			Game.Player.Character.Style[componentType].Index = index;
			Game.Player.Character.Style[componentType].TextureIndex = texture;

			this.Appearance = ConvertStyle(Game.Player.Character.Style, this.Appearance.Id);
		}

		public void SetProp(int type, int index, int texture)
		{
			PedProps propType = (PedProps) type;
			Game.Player.Character.Style[propType].Index = index;
			Game.Player.Character.Style[propType].TextureIndex = texture;

			this.Appearance = ConvertStyle(Game.Player.Character.Style, this.Appearance.Id);
		}

		protected static Appearance ConvertStyle(Style style, Guid? id = null)
		{
			return new Appearance
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
}
