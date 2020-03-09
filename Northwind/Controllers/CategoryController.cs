using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Models;
namespace Northwind.Controllers
{
    public class CategoryController : Controller
    {

        private INorthwindContext Context;


        public CategoryController()
        {       
            //Instanciar contexto entoty framwork (Produccion)
            Context = new NorthWindContext();
        }


        public CategoryController(INorthwindContext context)
        {
            //Utilizar el contexto doble de prueba
            this.Context = context;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View("Index");
        }

        public PartialViewResult _CategoryList(int n = 0)
        {
            List<Models.Category> Categories;
            if (n == 0)
            {
                Categories = Context.Categories.ToList();
            }
            else
            {
                Categories = Context.Categories.Take(n).ToList();
            }

            //Antes d implementar repositorio
            //List<Models.Category> Categories = new List<Models.Category>();
            //return PartialView("_CategoryList", Categories);

            //Implementado el repositorio 

            return PartialView("_CategoryList",Categories);
        }

        public ActionResult GetImage(int id)
        {
          
            //Antes d implementar repositorio
            //byte[] Image = new byte[0];
            //return File(Image, "image/jpeg");

            //Implementado el repositorio 
            int Offset = 78;
            var Category = Context.FindCategoryByID(id);
            byte[] Image = Category == null ? null : Category.Picture.Skip(Offset).ToArray();
            return Image == null ? null : File(Image, "image/jpeg");
        }

        public ActionResult Display(int id)
        {
          Category  Category = null;
            ActionResult Result = null;

            if (id <= 0) {
                throw (new ArgumentException("El ID debe ser mayor que cero"));
                    }
            try
            {
                //Implementado el repositorio 
                Category = Context.FindCategoryByID(id);
                Result = View("Display", Category);
            }
            catch(Exceptions.CategoryNotFoundExeption ex)
            {
                var Model = new HandleErrorInfo(ex, "Category", "Display");
                Result = View("Error", Model);
            }

            //Antes d implementar repositorio
            //var Category = new Models.Category();
            //return View(Category);

            return Result;
         
        }

        protected override void OnException(ExceptionContext filterContext)
        {
          if(filterContext.Exception is ArgumentException)
            {
                var ControllerName =
                    filterContext.RouteData.Values["Controller"].ToString();
                var ActionName =
                    filterContext.RouteData.Values["Action"].ToString();
                var Model =
                    new HandleErrorInfo(filterContext.Exception, ControllerName, ActionName);

                var Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(Model),
                    TempData = filterContext.Controller.TempData
                  
            };
                filterContext.Result = Result;
                filterContext.ExceptionHandled = true;
            }

           
         
        }

    }
}