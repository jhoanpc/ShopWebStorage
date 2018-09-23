using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopDataStorage.Models.Categories
{
    public class CategoriesIndexModel
    {
        public IEnumerable<CategoriesDetailsModel> CategoriesModel { get; set; }
    }
}
