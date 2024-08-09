using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
	[Table("Authors")]
	public class Author
	{
		[Key, Column("IdAuthor")]
		public int AuthorId { get; set; }
		[MaxLength(50), Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Location { get; set; }

		[NotMapped]
		public string FullName
		{
			get => $"{FirstName} {LastName}";
		}

        public List<BookAuthorMap> BookAuthorMapList { get; set; }
    }
}
