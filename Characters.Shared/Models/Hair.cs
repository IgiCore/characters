namespace IgiCore.Characters.Shared.Models
{
	public class Hair
	{
		public int HairId { get; set; }
		public int ColorId { get; set; }
		public int HighlightColorId { get; set; }

		// Can be applied using SetPedDecoration
		public string ScalpCollection { get; set; }
		public string Scalp { get; set; }
	}
}
