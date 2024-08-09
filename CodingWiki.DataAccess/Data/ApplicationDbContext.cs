using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Book> BookTable { get; set; }
		public DbSet<Category> CategoryTable { get; set; }
		public DbSet<Author> AuthorTable { get; set; }
		public DbSet<Publisher> PublisherTable { get; set; }
		public DbSet<SubCategory> SubCategoryTable { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=sqldev;Database=CodingWiki;Trusted_Connection=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 5);

			modelBuilder.Entity<Book>().HasData(
				new Book { IdBook = 1, Title = "Spider Without Duty", ISBN = "123B12", Price = 10.99m },
				new Book { IdBook = 2, Title = "Fortune Of Time", ISBN = "12123B12", Price = 11.99m }
				);

			Book[] bookArray = new Book[]
			{
				new Book { IdBook = 3, Title = "Fake Sunday", ISBN = "77652", Price = 20.99m },
				new Book { IdBook = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m },
				new Book { IdBook = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m }
			};

			modelBuilder.Entity<Book>().HasData(bookArray);
		}
	}
}
