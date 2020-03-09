using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View("Index");
        }

        public PartialViewResult _CategoryList()
        {
            List<Models.Category> Categories = new List<Models.Category>();
            return PartialView("_CategoryList", Categories);
        }

        public ActionResult GetImage(int v)
        {
            byte[] Image = new byte[0];
            return File(Image, "image/jpeg");
        }

        public ViewResult Display(int id)
        {
            var Category = new Models.Category();
            return View(Category);
        }
    }
}