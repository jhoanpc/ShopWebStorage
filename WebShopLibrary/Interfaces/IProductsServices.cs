using System;
using System.Collections.Generic;
using System.Text;
using WebShopLibrary.Models;

namespace WebShopLibrary.Interfaces
{
    public interface IProductsServices
    {
        IEnumerable<Products> GetAll();
        Products Get(int id);
        void Add(Products products);
   
    }
}
