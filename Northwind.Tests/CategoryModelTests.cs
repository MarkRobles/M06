using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.Tests
{
    [TestClass]
    public class CategoryModelTests
    {
        [TestMethod]
        public void Test_Category_Products()
        {
            Category TestCategory = new Models.Category();
            TestCategory.CategoryID = 1;

            var Result = TestCategory.GetProducts();
            Assert.AreEqual(typeof(List<Product>),Result.GetType());

        }
    }
}
