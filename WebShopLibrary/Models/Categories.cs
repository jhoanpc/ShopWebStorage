using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebShopLibrary.Models
{
    public class Categories
    {
        [Key]
        public int IdCategories { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        [StringLength(50, ErrorMessage = "Limit category name to 50 characters.")]
        public String NameCategories { get; set; }

        public ICollection<Products> Productss { get; set; }
    }
}
