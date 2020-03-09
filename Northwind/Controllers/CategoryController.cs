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

        public PartialViewResult _CategoryList()
        {
            //Antes d implementar repositorio
            //List<Models.Category> Categories = new List<Models.Category>();
            //return PartialView("_CategoryList", Categories);

            //Implementado el repositorio 
            List<Models.Category> Categories = Context.Categories.ToList();
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
            //Antes d implementar repositorio
            //var Category = new Models.Category();
            //return View(Category);

            //Implementado el repositorio 
            var Category = Context.FindCategoryByID(id);
            return Category == null ? HttpNotFound() as ActionResult : View("Display", Category);
        }
    }
}