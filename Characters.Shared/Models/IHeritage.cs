using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	public interface IHeritage : IIdentityModel
	{
		int Parent1 { get; set; }
		int Parent2 { get; set; }
		float Resemblance { get; set; }
		float SkinTone { get; set; }
	}
}
