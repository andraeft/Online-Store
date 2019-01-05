using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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