using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Northwind.Models;
using Northwind.Controllers;
using System.Web.Mvc;

namespace Northwind.Tests
{
    [TestClass]
    public class CategoryControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            //1 arrange
            CategoryController controller = new CategoryController();
            //2 act
            var result = controller.Index() as ViewResult;
            //3
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_CategoryList_Model_Type()
        {
            //1 arrange
            CategoryController controller = new CategoryController();

            //2result
            var result = controller._CategoryList() as PartialViewResult;
            //3 Assert
            Assert.AreEqual(typeof(List<Category>), result.Model.GetType());
        }


        [TestMethod]
        public void Test_GetIamge_ReturnType()
        {
            //1 arrange
            CategoryController controller = new CategoryController();

            //2 
            var result = controller.GetImage(1) as ActionResult;

            //3

            Assert.AreEqual(typeof(FileContentResult), result.GetType());

        }


        [TestMethod]
        public void Test_Display_Model_Type()
        {
            var controller = new CategoryController();
            var result = controller.Display(1) as ViewResult;
            Assert.AreEqual(typeof(Category),result.Model.GetType());

        }
    }
}
