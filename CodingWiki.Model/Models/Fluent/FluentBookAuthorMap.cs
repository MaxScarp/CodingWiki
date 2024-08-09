namespace CodingWiki.Model.Models
{
	public class FluentBookAuthorMap
	{
		public int IdBook { get; set; }
		public int AuthorId { get; set; }

		public FluentBook FluentBook { get; set; }
		public FluentAuthor FluentAuthor { get; set; }
	}
}
