using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
	public class BookAuthorMap
	{
		[ForeignKey(nameof(Book))]
		public int IdBook { get; set; }
		[ForeignKey(nameof(Author))]
		public int AuthorId { get; set; }

		public Book Book { get; set; }
		public Author Author { get; set; }
	}
}
