using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWikiWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = [.. db.CategoryTable];

            return View(categoryList);
        }

        public async Task<IActionResult> Upsert(int? categoryId)
        {
            Category category = new Category();
            if (categoryId == null || categoryId == 0)
            {
                return View(category);
            }

            category = await db.CategoryTable.FindAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.IdCategory == 0)
            {
                await db.CategoryTable.AddAsync(category);
            }
            else
            {
                db.CategoryTable.Update(category);
            }

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? categoryId)
        {
            Category category = db.CategoryTable.Find(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            db.CategoryTable.Remove(category);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            List<Category> categoryList = new List<Category>();

            for (int i = 0; i < 2; i++)
            {
                categoryList.Add(new Category { Name = Guid.NewGuid().ToString() });
            }

            await db.CategoryTable.AddRangeAsync(categoryList);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            List<Category> categoryList = new List<Category>();

            for (int i = 0; i < 5; i++)
            {
                categoryList.Add(new Category { Name = Guid.NewGuid().ToString() });
            }

            await db.CategoryTable.AddRangeAsync(categoryList);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2()
        {
            IEnumerable<Category> categoryEnumerable = db.CategoryTable.OrderByDescending(c => c.IdCategory).Take(2);

            db.CategoryTable.RemoveRange(categoryEnumerable);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple5()
        {
            IEnumerable<Category> categoryEnumerable = db.CategoryTable.OrderByDescending(c => c.IdCategory).Take(5);

            db.CategoryTable.RemoveRange(categoryEnumerable);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
