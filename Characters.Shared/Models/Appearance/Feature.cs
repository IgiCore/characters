using System.Linq.Expressions;
using JetBrains.Annotations;

namespace IgiCore.Characters.Shared.Models.Appearance
{
	public class Feature
	{
		public FeatureTypes Type { get; set; }

		public int Index { get; set; }

		public float Opacity { get; set; }

		public FeatureColorTypes ColorType { get; set; }

		public int ColorId { get; set; }

		public int SecondColorId { get; set; }

		//public Feature(FeatureTypes featureType = FeatureTypes.Age, FeatureColorTypes featureColorType = FeatureColorTypes.Misc)
		//{
		//	this.Type = featureType;
		//	this.ColorType = featureColorType;
		//}
	}
}
