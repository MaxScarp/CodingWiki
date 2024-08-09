using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
	[Table("Publishers")]
	public class Publisher
	{
		[Key, Column("IdPublisher")]
		public int PublisherId { get; set; }
		[Required]
		public string Name { get; set; }
		public string Location { get; set; }
	}
}
