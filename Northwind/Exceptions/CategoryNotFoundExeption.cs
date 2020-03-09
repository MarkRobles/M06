using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Exceptions
{
    public class CategoryNotFoundExeption:System.Exception
    {
        public CategoryNotFoundExeption(int ID) :
            base(string.Format(
                "La categoria '{0}' no ha sido encontrada",ID)) { }

    }
}