using CitizenFX.Core;
using IgiCore.Characters.Shared.Models;
using Newtonsoft.Json;
using NFive.SDK.Client.Extensions;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using CitizenFX.Core.Native;
using IgiCore.Characters.Shared.Models.Apparel;
using IgiCore.Characters.Shared.Models.Appearance;
using Prop = IgiCore.Characters.Shared.Models.Apparel.Prop;

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
		public Guid ApparelId { get; set; }
		public Apparel Apparel { get; set; }
		public Guid AppearanceId { get; set; }
		public Appearance Appearance { get; set; }
		public DateTime? LastPlayed { get; set; }
		public Guid UserId { get; set; }

		[JsonIgnore] public string FullName => $"{this.Forename} {this.Middlename} {this.Surname}".Replace("  ", " ");

		[JsonIgnore] public PedHash ModelHash => (PedHash)Convert.ToUInt32(this.Model);


		public void RenderCustom()
		{
			var player = Game.Player.Character.Handle;
			//https://gtaforums.com/topic/858970-all-gtao-face-ids-pedset_ped_head_blend_data-explained/
			//https://wiki.gt-mp.net/index.php/Character_Components

			API.SetPedHeadBlendData(player, 0,21,0, 0, 0, 0, 0.5f, 0.5f, 0.5f, true);

			// Hair Color https://wiki.gt-mp.net/index.php?title=Hair_Colors
			API.SetPedHairColor(player, this.Appearance.HairColorId, this.Appearance.HairHighlightColor);

			// Age & Opacity
			API.SetPedHeadOverlay(player, (int)FeatureTypes.Age, this.Appearance.Age.Index, this.Appearance.Age.Opacity);

			// Beard & Opcacity
			API.SetPedHeadOverlay(player, (int)FeatureTypes.Beard, this.Appearance.Beard.Index, this.Appearance.Beard.Opacity);

			// Eye color
			API.SetPedEyeColor(player, this.Appearance.EyeColorId);

			// EyeBrows & Opacity
			API.SetPedHeadOverlay(player, 2, 0, 0f);

			// Make up & Opacity
			API.SetPedHeadOverlay(player, 4, 0, 0f);

			// Lipstick
			API.SetPedHeadOverlay(player, 8, 0, 0f);

			// Hair
			//API.SetPedComponentVariation(player, 2, 0, 0, 0);

			// Beard Color
			API.SetPedHeadOverlayColor(player, (int)FeatureTypes.Beard, (int)this.Appearance.Beard.ColorType, this.Appearance.Beard.ColorId, this.Appearance.Beard.SecondColorId);

			// EyeBrows Color
			API.SetPedHeadOverlayColor(player, 2, 0,0,0);

			// Make up Color
			API.SetPedHeadOverlayColor(player, 4, 1,0,0);

			// Lipstick Color
			API.SetPedHeadOverlayColor(player, 8,1,0,0);

			// Blush & Opacity
			API.SetPedHeadOverlay(player, 5, 0, 0f);

			// Blush Color
			API.SetPedHeadOverlayColor(player, 5, 2, 0,0);

			// Complexion
			API.SetPedHeadOverlay(player, 6, 0,0f);

			// Sun Damage
			API.SetPedHeadOverlay(player, 7, 0, 0f);

			// Moles & Freckles
			API.SetPedHeadOverlay(player, 9, 0, 0f);

			// ChestHair & Opacity
			API.SetPedHeadOverlay(player, 10, 0, 0f);

			// Torso Color
			API.SetPedHeadOverlayColor(player, 10, 1, 0,0);

			// Body Blemishes & Opacity
			API.SetPedHeadOverlay(player, 11,0,0f);

			API.SetPedFaceFeature(player,0,0f);

		}







		public void Render()
		{
			// Apperantly this _must_ be called
			Game.Player.Character.Style.SetDefaultClothes();

			Game.Player.Character.Position = this.Position.ToVector3();
			Game.Player.Character.Armor = this.Armor;
			Game.Player.Character.MovementAnimationSet = this.WalkingStyle;

			Game.Player.Character.Style[PedComponents.Face].SetVariation(this.Apparel.Face.Index, this.Apparel.Face.Texture);
			Game.Player.Character.Style[PedComponents.Head].SetVariation(this.Apparel.Head.Index, this.Apparel.Head.Texture);

			// Temporary VisibilityFix Workaround
			Game.Player.Character.Style[PedComponents.Hair].SetVariation(1, 1);

			Game.Player.Character.Style[PedComponents.Hair].SetVariation(this.Apparel.Hair.Index, this.Apparel.Hair.Texture);

			Game.Player.Character.Style[PedComponents.Torso].SetVariation(this.Apparel.Torso.Index, this.Apparel.Torso.Texture);
			Game.Player.Character.Style[PedComponents.Legs].SetVariation(this.Apparel.Legs.Index, this.Apparel.Legs.Texture);
			Game.Player.Character.Style[PedComponents.Hands].SetVariation(this.Apparel.Hands.Index, this.Apparel.Hands.Texture);
			Game.Player.Character.Style[PedComponents.Shoes].SetVariation(this.Apparel.Shoes.Index, this.Apparel.Shoes.Texture);
			Game.Player.Character.Style[PedComponents.Special1].SetVariation(this.Apparel.Special1.Index, this.Apparel.Special1.Texture);
			Game.Player.Character.Style[PedComponents.Special2].SetVariation(this.Apparel.Special2.Index, this.Apparel.Special2.Texture);
			Game.Player.Character.Style[PedComponents.Special3].SetVariation(this.Apparel.Special3.Index, this.Apparel.Special3.Texture);
			Game.Player.Character.Style[PedComponents.Textures].SetVariation(this.Apparel.Textures.Index, this.Apparel.Textures.Texture);
			Game.Player.Character.Style[PedComponents.Torso2].SetVariation(this.Apparel.Torso2.Index, this.Apparel.Torso2.Texture);

			Game.Player.Character.Style[PedProps.Hats].SetVariation(this.Apparel.Hat.Index, this.Apparel.Hat.Texture);
			Game.Player.Character.Style[PedProps.Glasses].SetVariation(this.Apparel.Glasses.Index, this.Apparel.Glasses.Texture);
			Game.Player.Character.Style[PedProps.EarPieces].SetVariation(this.Apparel.EarPiece.Index, this.Apparel.EarPiece.Texture);
			Game.Player.Character.Style[PedProps.Unknown3].SetVariation(this.Apparel.Unknown3.Index, this.Apparel.Unknown3.Texture);
			Game.Player.Character.Style[PedProps.Unknown4].SetVariation(this.Apparel.Unknown4.Index, this.Apparel.Unknown4.Texture);
			Game.Player.Character.Style[PedProps.Unknown5].SetVariation(this.Apparel.Unknown5.Index, this.Apparel.Unknown5.Texture);
			Game.Player.Character.Style[PedProps.Watches].SetVariation(this.Apparel.Watch.Index, this.Apparel.Watch.Texture);
			Game.Player.Character.Style[PedProps.Wristbands].SetVariation(this.Apparel.Wristband.Index, this.Apparel.Wristband.Texture);
			Game.Player.Character.Style[PedProps.Unknown8].SetVariation(this.Apparel.Unknown8.Index, this.Apparel.Unknown8.Texture);
			Game.Player.Character.Style[PedProps.Unknown9].SetVariation(this.Apparel.Unknown9.Index, this.Apparel.Unknown9.Texture);
		}

		public void SetComponent(int type, int index, int texture)
		{
			var componentType = (PedComponents)type;
			Game.Player.Character.Style[componentType].Index = index;
			Game.Player.Character.Style[componentType].TextureIndex = texture;

			this.Apparel = ConvertStyle(Game.Player.Character.Style, this.Apparel.Id);
		}

		public void SetProp(int type, int index, int texture)
		{
			var propType = (PedProps)type;
			Game.Player.Character.Style[propType].Index = index;
			Game.Player.Character.Style[propType].TextureIndex = texture;

			this.Apparel = ConvertStyle(Game.Player.Character.Style, this.Apparel.Id);
		}

		protected static Apparel ConvertStyle(Style style, Guid? id = null)
		{
			return new Apparel
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
