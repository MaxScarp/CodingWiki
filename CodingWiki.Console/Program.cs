// See https://aka.ms/new-console-template for more information
using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//using(ApplicationDbContext context = new())
//{
//	//It ensures that a database with tables defined in the schemas will be created if nothing exists.
//	context.Database.EnsureCreated();
//	//If there are pending migrations that are not been applied it will automatically apply these migrations.
//	if(context.Database.GetPendingMigrations().Count() > 0)
//	{
//		context.Database.Migrate();
//	}
//}

/***********************
 * Remember that microsoft suggests to use async methods everywhere if you are not sure because,
 * in the worst case, it will took exactly the same amount of time as a sync method.
 ***********************/

//AddBook("New EF Core Book", "1231231212", 10.93m, 1);
//UpdateBookWithId(6);
//UpdatePriceOfAllBookWherePublisherId(55.55m, 1);
//DeleteBookWithId(6);
//GetAllBooks();
//GetFirstBook();
//GetAllBookOfPublsher(3);
//GetAllBookWherePriceIsGreaterThan(30m);
//GetBookWithId(6);
//GetOneBookWhereTitleContains("Forest");
//GetAllBookWhereIsbnStartsWith("12");
//GetAllBookWhereIsbnEndsWith("12");
//CountAllBookWhereIsbnContains("12");
//GetAllBooksOrderedByTitleAscAndIsbnDesc();
//GetFirstTwoBooksSkipTwoAndKeepOneMoreOnly();

void GetAllBooks()
{
	using ApplicationDbContext context = new ApplicationDbContext();
	List<Book> bookList = [.. context.BookTable];
	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			Console.WriteLine($"{book.Title} - {book.ISBN}");
		}
	}
}

void AddBook(string title, string ISBN, decimal price, int publisherId)
{
	Book newBook = new Book
	{
		Title = title,
		ISBN = ISBN,
		Price = price,
		PublshiderId = publisherId
	};

	using ApplicationDbContext context = new ApplicationDbContext();
	context.BookTable.Add(newBook);

	context.SaveChanges();
}

void UpdateBookWithId(int bookId)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	//Find is used only for filtering by Id, no other columns will be searched.
	Book book = context.BookTable.Find(bookId);
	if (book != null)
	{
		book.ISBN = "777";

		context.SaveChanges();
	}
}

void UpdatePriceOfAllBookWherePublisherId(decimal price, int publisherId)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	List<Book> bookList = [.. context.BookTable.Where(b => b.PublshiderId == publisherId)];
	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			book.Price = price;
		}

		context.SaveChanges();
	}
}

void DeleteBookWithId(int bookId)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	//Find is used only for filtering by Id, no other columns will be searched.
	Book book = context.BookTable.Find(bookId);
	if (book != null)
	{
		context.BookTable.Remove(book);

		context.SaveChanges();
	}
}

void GetFirstBook()
{
	using ApplicationDbContext context = new ApplicationDbContext();
	Book book = context.BookTable.FirstOrDefault();
	if (book != null)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}
}

void GetAllBookOfPublsher(int publisherId)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	List<Book> bookList = [.. context.BookTable.Where(b => b.PublshiderId == publisherId)];
	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			Console.WriteLine($"{book.Title} - {book.ISBN}");
		}
	}
}

void GetAllBookWherePriceIsGreaterThan(decimal price)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	List<Book> bookList = [.. context.BookTable.Where(b => b.Price > price)];
	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			Console.WriteLine($"{book.Title} - {book.ISBN}");
		}
	}
}

void GetBookWithId(int bookId)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	//Find is used only for filtering by Id, no other columns will be searched.
	Book book = context.BookTable.Find(bookId);
	if (book != null)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}
}

void GetOneBookWhereTitleContains(string subStringOfTitle)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	//Single will throw an exception if it finds more than one book, this is the difference from FirstOrDefault.
	Book book = context.BookTable.SingleOrDefault(b => b.Title.Contains(subStringOfTitle));
	if (book != null)
	{
		Console.WriteLine($"{book.Title} - {book.ISBN}");
	}
}

void GetAllBookWhereIsbnStartsWith(string subStringOfIsbn)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	List<Book> bookList = [.. context.BookTable.Where(b => EF.Functions.Like(b.ISBN, $"%{subStringOfIsbn}"))];
	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			Console.WriteLine($"{book.Title} - {book.ISBN}");
		}
	}
}

void GetAllBookWhereIsbnEndsWith(string subStringOfIsbn)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	List<Book> bookList = [.. context.BookTable.Where(b => EF.Functions.Like(b.ISBN, $"{subStringOfIsbn}%"))];
	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			Console.WriteLine($"{book.Title} - {book.ISBN}");
		}
	}
}

void CountAllBookWhereIsbnContains(string subStringOfIsbn)
{
	using ApplicationDbContext context = new ApplicationDbContext();
	//This is only an example of data aggregation
	int bookCount = context.BookTable.Where(b => EF.Functions.Like(b.ISBN, $"%{subStringOfIsbn}%")).Count();

	Console.WriteLine(bookCount);
}

void GetAllBooksOrderedByTitleAscAndIsbnDesc()
{
	using ApplicationDbContext context = new ApplicationDbContext();
	//In this way EF Core ignores the first order by, I want to order by desc ISBN only if there are duplicates.
	//List<Book> bookList = [.. context.BookTable.OrderBy(b => b.Title).OrderByDescending(b => b.ISBN)];

	//This is the right way for doing this...
	List<Book> bookList = [.. context.BookTable.OrderBy(b => b.Title).ThenByDescending(b => b.ISBN)];
	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			Console.WriteLine($"{book.Title} - {book.ISBN}");
		}
	}
}

void GetFirstTwoBooksSkipTwoAndKeepOneMoreOnly()
{
	using ApplicationDbContext context = new ApplicationDbContext();
	List<Book> bookList = [.. context.BookTable.Skip(0).Take(2), .. context.BookTable.Skip(4).Take(1)];

	if (bookList.Count > 0)
	{
		foreach (Book book in bookList)
		{
			Console.WriteLine($"{book.Title} - {book.ISBN}");
		}
	}
}