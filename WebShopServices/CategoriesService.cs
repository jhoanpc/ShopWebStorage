using System;
using System.Collections.Generic;
using System.Text;
using WebShopLibrary.Interfaces;
using WebShopLibrary.Models;
using WebShopLibrary;

namespace WebShopServices
{
    public class CategoriesService : ICategoriesServices
    {
        private readonly ShopDataStorageContext _dbContext;

        public CategoriesService(ShopDataStorageContext context)
        {
            _dbContext = context;
        }
        public void Add(Categories categories)
        {
            _dbContext.Add(categories);
            _dbContext.SaveChanges();
        }

        public Categories Get(int id)
        {
            return _dbContext.Categories
              //.Include(a => a.Categoriess)
              .Find(id);
        }

        public Categories GetName(String nameCategory)
        {
          return _dbContext.Categories.Find(3);
          
                                    
        }

        public IEnumerable<Categories> GetAll()
        {
            return _dbContext.Categories;
        }
    }
}
