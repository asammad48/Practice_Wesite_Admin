using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{
    public class Product_Variants
    {
        [Key]
        public int product_variant_ID { get; set; }
        [Display(Name = "Variants")]
        public virtual int VariantID { get; set; }

        [ForeignKey("VariantID")]
        public virtual Variants Variants { get; set; }
        [Display(Name = "Product")]
        public virtual int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
        public int status { get; set; }
        public int Var_Stock { get; set; }
        public decimal Var_Price { get; set; }
        public decimal Var_Discount { get; set; }
        public int Var_Reviews { get; set; }

    }
}
