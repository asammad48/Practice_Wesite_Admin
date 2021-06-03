using Practice_Wesite_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Practice_Wesite_Admin.Models
{
    public class Product_and__subcat
    {
        public Product product { get; set; }
        public Category category { get; set; }
        public SubSubCategory subSubCategory { get; set; }
        public SubCategory subCategory { get; set; }
        public List<SubCategory> subCategories { get; set; }

        public List<Category> categories { get; set; }
        public List<SubSubCategory> subSubCategories { get; set; }
        public List<Product_Images> product_Images { get; set; }
        public List<Variants> variants { get; set; }
        public List<List<Specification>> Product_variant_specifications { get; set; }
        public List<Product_Variants> product_Variants { get; set; }


    }
}
