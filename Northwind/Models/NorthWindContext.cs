using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Models
{
    public class NorthWindContext : INorthwindContext
    {

        NORTHWNDEntities Context = new NORTHWNDEntities();

        public IQueryable<Category> Categories
        {
            get { return Context.Categories; }
        }

        public IQueryable<Product> Products
        {
            get { return Context.Products; }
        }

        public T Add<T>(T entity) where T : class
        {
            return Context.Set<T>().Add(entity);
;        }

        public T Delete<T>(T entity) where T : class
        {
            return Context.Set<T>().Remove(entity);
        }

        public Category FindCategoryByID(int ID)
        {
            return Context.Categories.Find(ID);
        }

        public Product FindProductByID(int ID)
        {
            return Context.Products.Find(ID);
        }

        public int SaveCHanges()
        {
            return Context.SaveChanges();
        }
    }
}