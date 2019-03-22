using System.ComponentModel.DataAnnotations;

namespace IgiCore.Characters.Shared.Models
{
	public class FeaturePointF
	{
		[Required]
		public float X { get; set; }

		[Required]
		public float Y { get; set; }

		public FeaturePointF()
		{
		}

		public FeaturePointF(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}
	}
}
