using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWikiWeb.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext db;

        public AuthorController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Author> authorEnumerable = db.AuthorTable;

            return View(authorEnumerable);
        }

        public async Task<IActionResult> Upsert(int? authorId)
        {
            Author author = new Author();
            if (authorId == null || authorId == 0)
            {
                return View(author);
            }

            author = await db.AuthorTable.FindAsync(authorId);
            if (authorId == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            if (author.AuthorId == 0)
            {
                await db.AuthorTable.AddAsync(author);
            }
            else
            {
                db.AuthorTable.Update(author);
            }

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? authorId)
        {
            Author author = await db.AuthorTable.FindAsync(authorId);
            if (author == null)
            {
                return NotFound();
            }

            db.AuthorTable.Remove(author);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
