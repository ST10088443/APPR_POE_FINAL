using Microsoft.AspNetCore.Mvc;
using Disaster_Alleviation_Foundation_App.Data;
using Disaster_Alleviation_Foundation_App.NewFolder;
namespace Disaster_Alleviation_Foundation_App.Contoller
{
    public class GoodsCategoryController : Controller
    {
        private readonly DAFContext _context;

        public GoodsCategoryController(DAFContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.GoodsCategory.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GoodsCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.GoodsCategory.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _context.GoodsCategory.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GoodsCategory category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _context.GoodsCategory.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = _context.GoodsCategory.Find(id);
            _context.GoodsCategory.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
