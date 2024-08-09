using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
	[Table("SubCategories")]
	public class SubCategory
	{
		[Key, Column("IdSubCategory")]
		public int SubCategoryId { get; set; }
		[MaxLength(50), Required]
		public string Name { get; set; }
	}
}
