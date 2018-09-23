using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopDataStorage.Models.Categories;
using WebShopLibrary.Interfaces;

namespace WebShopDataStorage.Controllers.Categories
{
    public class CategoriesController : Controller
    {

        private ICategoriesServices _categoriesServices;

        public CategoriesController( ICategoriesServices iCategoriesServices)
        {
           
            _categoriesServices = iCategoriesServices;
        }

        public CategoriesIndexModel getAllCategories()
        {
            var allCategories= _categoriesServices.GetAll();

            var categoriesModels = allCategories.ToList()
                .Select(p => new CategoriesDetailsModel
                {
                    IdCategories = p.IdCategories,
                    NameCategories = p.NameCategories 
                }).ToList();

            var model = new CategoriesIndexModel
            {
                CategoriesModel = categoriesModels
            };

            return model;
        }
    }

    
}
