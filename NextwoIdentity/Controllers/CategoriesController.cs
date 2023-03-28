using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NextwoIdentity.Data;
using NextwoIdentity.Models;
using System.IO;

namespace NextwoIdentity.Controllers
{
    public class CategoriesController : Controller
    {
        private NextwoDbContext db;
        public CategoriesController(NextwoDbContext _db)
        {
            db = _db;
            
        }
        [HttpGet]
        public IActionResult CreateCategory() {

                ViewBag.CatList = new SelectList(db.Categories, "CategoryId", "CategoryName");
                return View();

        }
        [HttpPost]
        public ActionResult CreateCategory(Category? p)
        {
           if( ModelState.IsValid)
            {
                var e = db.Categories.FirstOrDefault(c => c.CategoryName == p!.CategoryName);
                if (e == null)
                {
                    db.Categories.Add(p!);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                { ViewBag.Check = "exists";
                }
            }
         
           return View(p);
        }
        [HttpGet]
        public IActionResult UpdateCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var data = db.Categories.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category p)
        {

            if (ModelState.IsValid)
            {
               db.Categories.Update(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p);

        }
        [HttpGet]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var data = db.Categories.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Product p)
        {
            var data = db.Categories.Find(p.Id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(data);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var data = db.Categories.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
            
        }
        public IActionResult Index()
        {
            var data   =db.Categories;
            return View(data);
        }
    }
}
