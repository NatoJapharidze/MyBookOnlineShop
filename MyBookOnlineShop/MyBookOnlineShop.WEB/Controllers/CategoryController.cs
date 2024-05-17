using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookOnlineShop.DataAccess;
using MyBookOnlineShop.Models.Models;

namespace MyBookOnlineShop.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.OrderBy(x=>x.DisplayOrder).ToList();
            return View(categories);
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                Category categoryFromDb = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
                if (categoryFromDb == null)
                {
                    return NotFound();
                }

                _context.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();


        }

        // GET: CategoryController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category categoryFromDb = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _context.Remove(categoryFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
