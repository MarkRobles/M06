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
            return View();
        }

        public PartialViewResult _CategoryList()
        {
            throw new NotImplementedException();
        }

        public ActionResult GetImage(int v)
        {
            throw new NotImplementedException();
        }

        public ViewResult Display(int v)
        {
            throw new NotImplementedException();
        }
    }
}