using System;
using System.Collections.Generic;
using WebShopLibrary.Interfaces;
using WebShopLibrary.Models;
using WebShopLibrary;
namespace WebShopServices
{
    public class ProductService : IProductsServices
    {
        private readonly ShopDataStorageContext _dbContext;

        public ProductService (ShopDataStorageContext context)
        {
            _dbContext = context;
        }
        public void Add(Products products)
        {
            _dbContext.Add(products);
            _dbContext.SaveChanges();
            
        }

        public Products Get(int id)
        {
            
            return _dbContext.Products
           //.Include(a => a.Categoriess)
               .Find(id);

            //var product = _dbContext.Products.GetType<Products>().where();
        }

        public IEnumerable<Products> GetAll()
        {
            return _dbContext.Products;
        }
    }
}
