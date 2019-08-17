using CitizenFX.Core;
using CitizenFX.Core.Native;
using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Trait;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Client.Models
{
	public class CharacterTrait : IdentityModel, ICharacterTrait
	{
		public int EyeColorId { get; set; }
		public int HairColorId { get; set; }
		public int HairHighlightColor { get; set; }

		public Feature Blemishes { get; set; }
		public Feature Beard { get; set; }
		public Feature Eyebrows { get; set; }
		public Feature Aging { get; set; }
		public Feature Makeup { get; set; }
		public Feature Blush { get; set; }
		public Feature Complexion { get; set; }
		public Feature SunDamage { get; set; }
		public Feature Lipstick { get; set; }
		public Feature MolesAndFreckles { get; set; }
		public Feature ChestHair { get; set; }
		public Feature BodyBlemishes { get; set; }
		public Feature AddBodyBlemishes { get; set; }


		public static CharacterTrait ConvertTrait(Ped player) => new CharacterTrait
		{
			EyeColorId = API.GetPedEyeColor(player.Handle),
			HairColorId = API.GetPedHairColor(player.Handle),
			HairHighlightColor = API.GetPedHairHighlightColor(player.Handle),

			Blemishes = PedTrait(player, 0),
			Beard = PedTrait(player, 1),
			Eyebrows = PedTrait(player, 2),
			Aging = PedTrait(player, 3),
			Makeup = PedTrait(player, 4),
			Blush = PedTrait(player, 5),
			Complexion = PedTrait(player, 6),
			SunDamage = PedTrait(player, 7),
			Lipstick = PedTrait(player, 8),
			MolesAndFreckles = PedTrait(player, 9),
			ChestHair = PedTrait(player, 10),
			BodyBlemishes = PedTrait(player, 11),
			AddBodyBlemishes = PedTrait(player, 12)
		};


		private static Feature PedTrait(Ped ped, int index)
		{
			var overlayValue = 0;
			var colorType = 0;
			var firstColor = 0;
			var secondColor = 0;
			var opacity = 0.0f;

			API.GetPedHeadOverlayData(ped.Handle, index, ref overlayValue, ref colorType, ref firstColor, ref secondColor, ref opacity);

			var feature = new Feature
			{
				Index = overlayValue,
				Opacity = opacity,
				ColorId = firstColor,
				SecondColorId = secondColor
			};

			return feature;
		}
	}
}
