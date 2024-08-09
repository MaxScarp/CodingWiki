namespace CodingWiki.Model.Models
{
	public class FluentBookDetail
	{
		public int BookDetailId { get; set; }
		public int NumberOfChapters { get; set; }
		public int NumberOfPages { get; set; }
		public double Weight { get; set; }

		public int IdBook { get; set; }
		public FluentBook FluentBook { get; set; }
	}
}
