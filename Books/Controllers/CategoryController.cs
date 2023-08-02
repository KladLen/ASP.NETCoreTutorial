using Books.Data;
using Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
            if (ModelState.IsValid)
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("", "Name and Display Order must have different values");
                }
                else
                {
					TempData["success"] = "Category created successfully";
                    _db.Categories.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
			}
			 return View(obj);
		}
		//GET
		public IActionResult Edit(int? Id)
		{
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            else
            {
                return View(categoryFromDb);
            }
		}
		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				if (obj.Name == obj.DisplayOrder.ToString())
				{
					ModelState.AddModelError("", "Name and Display Order must have different values");
				}
				else
				{
					TempData["success"] = "Category edited successfully";
					_db.Categories.Update(obj);
					_db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			return View(obj);
		}
		//GET
		public IActionResult Delete(int? Id)
		{
			if (Id == 0 || Id == null)
			{
				return NotFound();
			}
			var categoryFromDb = _db.Categories.Find(Id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			else
			{
				return View(categoryFromDb);
			}
		}
		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Category obj)
		{
			TempData["success"] = "Category deleted successfully";
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
