using System.ComponentModel.DataAnnotations.Schema;

namespace IgiCore.Characters.Shared.Models.Appearance
{
	public class Feature
	{
		[NotMapped]
		public FeatureTypes Type { get; set; }

		public int Index { get; set; }

		public float Opacity { get; set; }

		public FeatureColorTypes ColorType { get; set; }

		public int ColorId { get; set; }

		public int SecondColorId { get; set; }
	}
}
