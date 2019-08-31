using CitizenFX.Core.Native;
using IgiCore.Characters.Shared.Models;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Client.Models
{
	public class CharacterFacialTrait : IdentityModel, ICharacterFacialTrait
	{
		public float NoseWidth { get; set; }
		public float NosePeakHeight { get; set; }
		public float NosePeakLength { get; set; }
		public float NoseBoneHeight { get; set; }
		public float NosePeakLowering { get; set; }
		public float NoseBoneTwist { get; set; }
		public float EyeBrowHeight { get; set; }
		public float EyeBrowLength { get; set; }
		public float CheekBoneHeight { get; set; }
		public float CheekBoneWidth { get; set; }
		public float CheekWidth { get; set; }
		public float EyeOpenings { get; set; }
		public float LipThickness { get; set; }
		public float JawBoneWidth { get; set; }
		public float JawBoneLength { get; set; }
		public float ChinBoneLowering { get; set; }
		public float ChinBoneLength { get; set; }
		public float ChinBoneWidth { get; set; }
		public float ChinDimple { get; set; }
		public float NeckThickness { get; set; }

		public static CharacterFacialTrait ConvertFacialTrait(int playerHandle) => new CharacterFacialTrait
		{
			NoseWidth = API.GetPedFaceFeature(playerHandle, 0),
			NosePeakHeight = API.GetPedFaceFeature(playerHandle, 1),
			NosePeakLength = API.GetPedFaceFeature(playerHandle, 2),
			NoseBoneHeight = API.GetPedFaceFeature(playerHandle, 3),
			NosePeakLowering = API.GetPedFaceFeature(playerHandle, 4),
			NoseBoneTwist = API.GetPedFaceFeature(playerHandle, 5),
			EyeBrowHeight = API.GetPedFaceFeature(playerHandle, 6),
			EyeBrowLength = API.GetPedFaceFeature(playerHandle, 7),
			CheekBoneHeight = API.GetPedFaceFeature(playerHandle, 8),
			CheekBoneWidth = API.GetPedFaceFeature(playerHandle, 9),
			CheekWidth = API.GetPedFaceFeature(playerHandle, 10),
			EyeOpenings = API.GetPedFaceFeature(playerHandle, 11),
			LipThickness = API.GetPedFaceFeature(playerHandle, 12),
			JawBoneWidth = API.GetPedFaceFeature(playerHandle, 13),
			JawBoneLength = API.GetPedFaceFeature(playerHandle, 14),
			ChinBoneLowering = API.GetPedFaceFeature(playerHandle, 15),
			ChinBoneLength = API.GetPedFaceFeature(playerHandle, 16),
			ChinBoneWidth = API.GetPedFaceFeature(playerHandle, 17),
			ChinDimple = API.GetPedFaceFeature(playerHandle, 18),
			NeckThickness = API.GetPedFaceFeature(playerHandle, 19),
		};
	}
}
