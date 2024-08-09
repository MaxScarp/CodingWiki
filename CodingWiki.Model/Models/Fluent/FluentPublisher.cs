namespace CodingWiki.Model.Models
{
	public class FluentPublisher
	{
		public int PublisherId { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }

		public List<FluentBook> FluentBookList { get; set; }
	}
}
