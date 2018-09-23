using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebShopLibrary.Models
{
    public class Products
    {
        [Key]
        public int IdProduct { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "Limit product name to 50 characters.")]
        public String ProductName { get; set; }
        [Display(Name = "Product Name")]
        public int ProductNumber { get; set; }
        [Display(Name = "Product Description")]
        [StringLength(50, ErrorMessage = "Limit product description to 100 characters.")]
        public String ProductDescription { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public  Categories Categoriess { get; set; }
        public int IdCategories { get; set; }

        [Range(0,18)]
        public decimal QuantityUnit { get; set; }
        
        public decimal UnitPrice { get; set; }
        [Range(0, 3)]
        public int Discount { get; set; }

    }
}
