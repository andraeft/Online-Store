using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReviewController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        
        public ActionResult New(int ProductId, string Review)
        {
            //Product product = db.Products.Find(ProductId);
            Review review = new Review();
            review.ProductId = ProductId;
            review.Comment = Review;
            db.Reviews.Add(review);
            db.SaveChanges();
            return Redirect("/Product/Show/" + ProductId); ;
        }
    }
}