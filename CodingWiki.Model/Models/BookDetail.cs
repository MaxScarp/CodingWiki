using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
	[Table("BookDetails")]
	public class BookDetail
	{
		[Key, Column("IdBookDetail")]
		public int BookDetailId { get; set; }
		[Required]
		public int NumberOfChapters { get; set; }
		public int NumberOfPages { get; set; }
		public double Weight { get; set; }

		[ForeignKey(nameof(Book))]
		public int IdBook { get; set; }
		public Book Book { get; set; }
	}
}
