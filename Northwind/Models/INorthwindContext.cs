using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public interface INorthwindContext
    {

        IQueryable<Category> Categories { get; }
        IQueryable<Product> Products { get; }
        Category FindCategoryByID(int ID);

        Product FindProductByID(int ID);

        T Add<T>(T entity) where T : class;

        T Delete<T>(T entity) where T : class;

        int SaveCHanges();

    }
}
