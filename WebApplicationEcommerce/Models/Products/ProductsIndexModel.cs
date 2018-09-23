using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopDataStorage.Models.Products
{
    public class ProductsIndexModel
    {
        public IEnumerable<ProductsDetailsModel> Products { get; set; }
    }
}
