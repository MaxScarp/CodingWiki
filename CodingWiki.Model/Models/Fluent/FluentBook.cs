namespace CodingWiki.Model.Models
{
	public class FluentBook
	{
		public int IdBook { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public string PriceRange { get; set; }

		public FluentBookDetail BookDetail { get; set; }

		public int PublshiderId { get; set; }
		public FluentPublisher FluentPublisher { get; set; }

		public List<FluentBookAuthorMap> FluentBookAuthorMapList { get; set; }
	}
}
