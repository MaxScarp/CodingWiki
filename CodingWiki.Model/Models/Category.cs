using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
	[Table("Categories")]
	public class Category
	{
		[Key]
		public int IdCategory { get; set; }
		[Required]
		public string Name { get; set; }
		[Column("Order")]
		public int DisplayOrder { get; set; }
	}
}
