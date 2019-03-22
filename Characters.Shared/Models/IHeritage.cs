using NFive.SDK.Core.Models;

namespace IgiCore.Characters.Shared.Models
{
	public interface IHeritage : IIdentityModel
	{
		int Mother { get; set; }			//21
		int Father { get; set; }			//0
		float Resemblance { get; set; }		//0.0f
		float SkinTone { get; set; }		//0.0f
	}
}
