using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Appearance;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Client.Models
{
	public class Appearance : IdentityModel, IAppearance
	{
		public int EyeColorId { get; set; }
		public Hair Hair { get; set; }

		public Feature Aging { get; set; }
		public Feature Beard { get; set; }
		public Feature Blush { get; set; }
		public Feature Blemishes { get; set; }
		public Feature Chest { get; set; }
		public Feature Complexion { get; set; }
		public Feature Eyebrows { get; set; }
		public Feature Lipstick { get; set; }
		public Feature Makeup { get; set; }
		public Feature MolesAndFreckles { get; set; }
		public Feature SkinDamage { get; set; }
	}
}
