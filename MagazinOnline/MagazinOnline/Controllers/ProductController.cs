using MagazinOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinOnline.Controllers
{
    public class ProductController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        // GET: Produs
        public ActionResult Index()
        {
            return View();
        }
    }
}