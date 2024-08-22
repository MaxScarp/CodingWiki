using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWikiWeb.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext db;

        public PublisherController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Publisher> publisherEnumerable = db.PublisherTable;

            return View(publisherEnumerable);
        }

        public async Task<IActionResult> Upsert(int? publisherId)
        {
            Publisher publisher = new Publisher();
            if (publisherId == null || publisherId == 0)
            {
                return View(publisher);
            }

            publisher = await db.PublisherTable.FindAsync(publisherId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }

            if (publisher.PublisherId == 0)
            {
                await db.PublisherTable.AddAsync(publisher);
            }
            else
            {
                db.PublisherTable.Update(publisher);
            }

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? publisherId)
        {
            Publisher publisher = await db.PublisherTable.FindAsync(publisherId);
            if (publisher == null)
            {
                return NotFound();
            }

            db.PublisherTable.Remove(publisher);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
