using IgiCore.Characters.Shared.Models;
using IgiCore.Characters.Shared.Models.Appearance;
using NFive.SDK.Core.Helpers;
using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Server.Models
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

		public Appearance()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();

			this.Hair = new Hair();

			this.Aging = new Feature();
			this.Beard = new Feature();
			this.Blemishes = new Feature();
			this.Blush = new Feature();
			this.Chest = new Feature();
			this.Complexion = new Feature();
			this.Eyebrows = new Feature();
			this.Lipstick = new Feature();
			this.Makeup = new Feature();
			this.MolesAndFreckles = new Feature();
			this.SkinDamage = new Feature();
		}
	}
}
