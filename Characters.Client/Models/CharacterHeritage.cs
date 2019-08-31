using CitizenFX.Core;
using IgiCore.Characters.Shared.Models;
using NFive.SDK.Core.Models;
using System;

namespace IgiCore.Characters.Client.Models
{
	public class CharacterHeritage : IdentityModel, ICharacterHeritage
	{
		public int Parent1 { get; set; }
		public int Parent2 { get; set; }
		public float Resemblance { get; set; }
		public float SkinTone { get; set; }

		public static CharacterHeritage ConvertHeritage(PedHeadBlendData headBlendData, DateTime created) => new CharacterHeritage
		{
			Created = created,
			Parent1 = headBlendData.FirstFaceShape,
			Parent2 = headBlendData.SecondFaceShape,
			Resemblance = headBlendData.ParentFaceShapePercent,
			SkinTone = headBlendData.ParentSkinTonePercent
		};
	}
}
