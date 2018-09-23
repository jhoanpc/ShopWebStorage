using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WebShopLibrary.Models;

namespace WebShopDataStorage.Models.Products
{
    public class ProductsDetailsModel
    {
        public int IdProduct { get; set; }
       
        public String ProductName { get; set; }
        
        public int ProductNumber { get; set; }
       
        public String ProductDescription { get; set; }
        
        public List<SelectListItem> CategoryName { get; set; }
       public decimal QuantityUnit { get; set; }

        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }


    }
}
