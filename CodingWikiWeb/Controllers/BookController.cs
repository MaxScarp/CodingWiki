using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using CodingWiki.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWikiWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            //This is efficient - EAGER LOAD - This is doing a join
            List<Book> bookList = [.. db.BookTable.Include(b => b.Publisher)];

            //This is not so efficient event if I'm doing a query only for each publisher id and not on all books thanks to Entry and Reference
            //IEnumerable<Book> bookEnumerable = [.. db.BookTable];
            //foreach (Book book in bookEnumerable)
            //{
            //    db.Entry(book).Reference(r => r.Publisher).Load();
            //}

            return View(bookList);
        }

        public async Task<IActionResult> Upsert(int? bookId)
        {
            BookViewModel bookViewModel = new BookViewModel
            {
                Book = new Book()
            };

            //We are using an EF Core projection.
            //It translate into C# class an entity.
            //It is efficient because selects only field that are needed and not everything.
            bookViewModel.PublisherList = db.PublisherTable.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.PublisherId.ToString()
            });

            if (bookId == null || bookId == 0)
            {
                return View(bookViewModel);
            }

            bookViewModel.Book = await db.BookTable.FindAsync(bookId);
            if (bookViewModel.Book == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookViewModel bookViewModel)
        {
            if (bookViewModel.Book.IdBook == 0)
            {
                await db.BookTable.AddAsync(bookViewModel.Book);
            }
            else
            {
                db.BookTable.Update(bookViewModel.Book);
            }

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? bookId)
        {
            if (bookId == null || bookId == 0)
            {
                return NotFound();
            }

            BookDetail bookDetail = new BookDetail();
            bookDetail = await db.BookDetailTable.Include(b => b.Book).FirstOrDefaultAsync(b => b.IdBook == bookId);
            if (bookDetail == null)
            {
                return NotFound();
            }

            return View(bookDetail);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail bookDetail)
        {
            if (bookDetail.BookDetailId == 0)
            {
                await db.BookDetailTable.AddAsync(bookDetail);
            }
            else
            {
                db.BookDetailTable.Update(bookDetail);
            }

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? bookId)
        {
            Book book = await db.BookTable.FindAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            db.BookTable.Remove(book);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// This is used only for studying the Deferred Execution and difference between IQueryable and IEnumerable 
        /// </summary>
        public async Task<IActionResult> PlayGround()
        {
            //This retrieve before all the columns and all the books inside the table, then filter them, it is not efficient
            IEnumerable<Book> bookEnumerable = db.BookTable;
            IEnumerable<Book> filteredBookEnumerable = bookEnumerable.Where(b => b.Price >= 20.0m);

            //IQueryable is derived from IEnumarable so you can do everything you do in IEnumarable.
            //This retrieve only the filtered books because the WHERE statement is executed directly inside the database. This is efficient.
            IQueryable<Book> bookEnumerable2 = db.BookTable;
            IQueryable<Book> filteredBookEnumerable2 = bookEnumerable2.Where(b => b.Price >= 20.0m);

            //The query is executed in this moment
            Book bookTemp = await db.BookTable.FirstOrDefaultAsync();
            bookTemp.Price = 100.00m;

            //The query is not executed
            IEnumerable<Book> bookEnumarable = db.BookTable;
            decimal totalPrice = 0;

            //The query is executed in this moment
            foreach (Book book in bookEnumarable)
            {
                totalPrice += book.Price;
            }

            //The quey is executed in this moment
            List<Book> bookList = [.. db.BookTable];
            foreach (Book book in bookList)
            {
                totalPrice += book.Price;
            }

            //The query is not executed
            IEnumerable<Book> bookEnumarable2 = db.BookTable;

            //The query is executed in this moment but it is not efficient because it selected every columns before
            int bookCount1 = bookEnumarable2.Count();

            //The query is executed in this moment and is efficient because select directly what is needed for doing the calculation directly on the database
            int bookCount2 = db.BookTable.Count();

            return RedirectToAction(nameof(Index));
        }
    }
}
