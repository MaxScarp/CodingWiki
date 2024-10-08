﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
	[Table("Books")]
	public class Book
	{
		[Key]
		public int IdBook { get; set; }
		public string Title { get; set; }
		[MaxLength(20), Required]
		public string ISBN { get; set; }
		public decimal Price { get; set; }

		[NotMapped]
		public string PriceRange { get; set; }

		public BookDetail BookDetail { get; set; }

		[ForeignKey(nameof(Publisher))]
		public int PublshiderId { get; set; }
		public Publisher Publisher { get; set; }

		public List<BookAuthorMap> BookAuthorMapList { get; set; }
	}
}
