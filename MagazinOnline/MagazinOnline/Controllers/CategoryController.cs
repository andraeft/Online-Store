using MagazinOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinOnline.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryDBContext db = new CategoryDBContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}