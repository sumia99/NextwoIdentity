using Microsoft.AspNetCore.Mvc;
using NextwoIdentity.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using NextwoIdentity.Models.ViewModels;
using System.Data;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Differencing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using NextwoIdentity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace NextwoIdentity.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private NextwoDbContext db;
        public ProductController(ILogger<ProductController> logger, NextwoDbContext _db)
        {
            _logger = logger;
            db = _db;
        }
        public IActionResult ProductList()
        {
            var data = db.Products;
        return View(data);
        }
            [HttpGet]
        public IActionResult? AllProduct() {
            List<Product> products = new List<Product>();
            {
                products.Add(new Product
                {
                    Id = 1,
                    Name = "Test",
                    Price = 50,
                    CategoryId = 10

                }) ;
                products.Add(new Product
                {
                    Id = 2,
                    Name = "Test1",
                    Price = 500,
                    CategoryId = 15

                });
                return View(products);
            }
           
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.CatList = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
           
        }
        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
           if (ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();  
                return RedirectToAction("AllProduct");
            }
           return View(p);
        }
        [HttpGet]
        public IActionResult EditProduct(int? id) {
            if (id == null)
            {
                return RedirectToAction("AllProduct");
            }
            var data = db.Products.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllProduct");
            }
            return View(data);
            }
        [HttpPost]
        public async Task<IActionResult> EditProduct(Product p)
        {

            if (ModelState.IsValid)
            {
                db.Products.Update(p);
              await  db.SaveChangesAsync();
                return RedirectToAction("AllProduct");
            }
            return View(p);
           
        }
        [HttpGet]
        public IActionResult DeleteProduct(int? id) {
            if (id == null)
            {
                return RedirectToAction("AllProduct");
            }
            var data = db.Products.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllProduct");
            }
            return View(data);
         
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product p)
        {
            var data = db.Products.Find(p.Id);
            if (data == null)
            {
                return RedirectToAction("AllProduct");
            }
            db.Products.Remove(data);
           await db.SaveChangesAsync();
            return RedirectToAction("AllProduct");
        }
            public IActionResult Index()
        {
            return View(db.Categories);
        }
    }
}
