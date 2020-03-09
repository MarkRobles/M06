using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Northwind.Models;
using Northwind.Controllers;
using System.Web.Mvc;
using System.Linq;
using Northwind.Tests.Doubles;

namespace Northwind.Tests
{
    [TestClass]
    public class CategoryControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            //1 arrange
            
            var Context = new FakeNorthwindContext();
            CategoryController controller = new CategoryController(Context);

            //2 act
            var result = controller.Index() as ViewResult;
            //3
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_CategoryList_Model_Type()
        {
            //1 arrange
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category(), new Category(), new Category(), new Category()
            }.AsQueryable();

            var controller = new CategoryController(Context);

            //2result
            var result = controller._CategoryList() as PartialViewResult;
            //3 Assert
            Assert.AreEqual(typeof(List<Category>), result.Model.GetType());
        }


        [TestMethod]
        public void Test_GetIamge_ReturnType()
        {
            //1 arrange
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category { CategoryID = 1, Picture = new byte[0] },
                new Category { CategoryID = 2, Picture = new byte[0] },
                new Category { CategoryID = 3, Picture = new byte[0] },
                new Category { CategoryID = 4, Picture = new byte[0] }
            }.AsQueryable();

            var controller = new CategoryController(Context);

            //2 
            var result = controller.GetImage(1) as ActionResult;

            //3

            Assert.AreEqual(typeof(FileContentResult), result.GetType());

        }


        [TestMethod]
        public void Test_Display_Model_Type()
        {
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category { CategoryID = 1 },
                new Category { CategoryID = 2 },
                new Category { CategoryID = 3 },
                new Category { CategoryID = 4 }
            }.AsQueryable();

            var controller = new CategoryController(Context);

            var result = controller.Display(1) as ViewResult;
            Assert.AreEqual(typeof(Category),result.Model.GetType());

        }
    }
}
