using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        // GET: Product
        public ActionResult Index([Bind(Include = "ProductId, Title, Date, Description, Price, Picture, ColabId, CategoryId, Category")] Product product)
        {
            var products = db.Products;
            ViewBag.Products = products;
            return View();
        }

        public ActionResult Show(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.Product = product;
            var reviews = from review in product.Reviews select review;
            ViewBag.Reviews = reviews;
            return View(product);
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllCategories()
        {
            // generam o lista goala            
            var selectList = new List<SelectListItem>();
            // Extragem toate categoriile din baza de date 
            var categories = from cat in db.Categories select cat;
            // iteram prin categorii   
            foreach (var category in categories)
            {
                // Adaugam in lista elementele necesare pentru dropdown              
                selectList.Add(new SelectListItem
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.Name.ToString()
                });
            }
            // returnam lista de categorii     
            return selectList; 
        }

        public ActionResult New()
        {
            Product product = new Product();
            product.Categories = GetAllCategories();
            return View(product);
        }

        [HttpPost]
        public ActionResult New(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Date = DateTime.Now;
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Redirect("/Category/Show/" + product.CategoryId);
                }
                else
                {
                    product.Categories = GetAllCategories();
                    return View(product);
                }
            } catch(Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            //ViewBag.Product = product;
            ViewBag.CategoryId = db.Categories;
            return View(product);
        }

        [HttpPut]
        public ActionResult Edit(int id, Product requestProduct)
        {
            try
            {
                Product product = db.Products.Find(id);
                if(TryUpdateModel(product))
                {
                    product.Title = requestProduct.Title;
                    product.Description = requestProduct.Description;
                    product.Date = DateTime.Now;
                    product.Price = requestProduct.Price;
                    product.CategoryId = requestProduct.CategoryId;
                    db.SaveChanges();
                }
                return Redirect("/Category/Show/" + product.CategoryId);
            } catch(Exception e)
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return Redirect("/Category/Show/" + product.CategoryId); ;
        }
    }
}