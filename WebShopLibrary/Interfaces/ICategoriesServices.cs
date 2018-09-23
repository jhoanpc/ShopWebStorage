using System;
using System.Collections.Generic;
using System.Text;
using WebShopLibrary.Models;

namespace WebShopLibrary.Interfaces
{
   public interface ICategoriesServices
    {
        IEnumerable<Categories> GetAll();
        Categories Get(int id);
        void Add(Categories products);
    }
}
