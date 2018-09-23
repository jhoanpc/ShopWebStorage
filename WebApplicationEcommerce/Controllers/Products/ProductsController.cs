using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebShopDataStorage.Controllers.Categories;
using WebShopDataStorage.Models.Products;
using WebShopLibrary.Interfaces;

namespace WebShopDataStorage.Controllers.Products
{
    public class ProductsController : Controller
    {
        private IProductsServices _productsService;
        private ICategoriesServices _categoriesServices;

        public ProductsController (IProductsServices iProductsServices, ICategoriesServices icategoriesServices)
        {
            _productsService = iProductsServices;
            _categoriesServices = icategoriesServices;
            
        }


        public IActionResult Index()
        {
           var allProducts =  _productsService.GetAll();

            var productsModels = allProducts
                .Select(p => new ProductsDetailsModel
                {
                    IdProduct = p.IdProduct,
                    ProductName = p.ProductName ?? "No First Name Provided",
                    ProductNumber = p.ProductNumber,
                    ProductDescription = p.ProductDescription,
                    QuantityUnit = p.QuantityUnit,
                    Discount = p.Discount,
                    CategoryName =  new List<SelectListItem>() { new SelectListItem(p.Categoriess.NameCategories,"1")}
                }).ToList();

            var model = new ProductsIndexModel
            {
                Products = productsModels
            };


            return View(model);
        }

        // GET: Propuesta/Create
        public ActionResult Create()
        {
            var fromDatabaseEF = new SelectList(GetSelectListItems().ToList(), "idCategories", "nameCateg");
            // ViewData["DBMySkills"] = fromDatabaseEF;
            ViewBag.IdCategories = fromDatabaseEF;
            return View();
        }

        private IEnumerable<SelectListItem> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();
            CategoriesController categoriesController = new CategoriesController(_categoriesServices);
            foreach (var element in categoriesController.getAllCategories().CategoriesModel)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.IdCategories.ToString(),
                    Text = element.NameCategories
                });
            }
            return selectList.ToList();
        }

        // POST: Propuesta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                WebShopLibrary.Models.Products product = new WebShopLibrary.Models.Products();
                product.ProductName = collection["ProductName"];
                product.ProductNumber = Convert.ToInt32(collection["ProductNumber"]);
                product.ProductDescription = collection["ProductDescription"];
                product.QuantityUnit = Convert.ToInt64(collection["QuantityUnit"]);
                product.UnitPrice = Convert.ToInt64(collection["UnitPrice"]);
                product.Discount = Convert.ToInt32(collection["Discount"]);


                // TODO: Add insert logic here
                _productsService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}