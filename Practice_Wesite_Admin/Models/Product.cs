using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        [Display(Name = "SubSubCategory")]
        public virtual int SubSubCategoryID { get; set; }

        [ForeignKey("SubSubCategoryID")]
        public virtual SubSubCategory Product_Category { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
