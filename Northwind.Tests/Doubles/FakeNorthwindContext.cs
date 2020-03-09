using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Models;
using System.Collections.ObjectModel;

namespace Northwind.Tests.Doubles
{
    class FakeNorthwindContext : INorthwindContext
    {

        DbContext_Mock Context = new DbContext_Mock();
        //Clase que simule contexto entity framework
        class DbContext_Mock:KeyedCollection<Type,object>
        {
            public HashSet<T> AddEntitySet<T>(IEnumerable<T> entities)
            {
                var EntitySet = new HashSet<T>(entities);
                if(Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(EntitySet);
                return EntitySet;
            }


            public HashSet<T> Set<T>()
            {
                return (HashSet<T>)this[typeof(T)];
            }

            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }
        public IQueryable<Category> Categories {
            get { return Context.Set<Category>().AsQueryable(); }
            set { Context.AddEntitySet<Category>(value); }
        }

        public IQueryable<Product> Products {
            get { return Context.Set<Product>().AsQueryable(); }
            set { Context.AddEntitySet<Product>(value); }
        }


        public T Add<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
            return entity;
        }

        public T Delete<T>(T entity) where T : class
        {
            Context.Set<T>().Remove(entity);
            return entity;
        }

        public Category FindCategoryByID(int ID)
        {
            return Categories.FirstOrDefault(c=> c.CategoryID == ID);
        }

        public Product FindProductByID(int ID)
        {
            return Products.FirstOrDefault(c => c.ProductID == ID);
        }

        public int SaveCHanges()
        {
            return 0;
        }
    }
}
