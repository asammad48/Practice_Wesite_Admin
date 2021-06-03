using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{ 
    public class SubCategory_SubSubcategory
    {

        [Key]
        public int SubCategory_SubSubcategoryID { get; set; }
        [Display(Name = "SubSubCategory")]
        public virtual int SubSubCategoryID { get; set; }

        [ForeignKey("SubSubCategoryID")]
        public virtual SubSubCategory SubSubCategories { get; set; }
        [Display(Name = "SubCategory")]
        public virtual int SubCategoryID { get; set; }

        [ForeignKey("SubCategoryID")]
        public virtual SubCategory SubCategories { get; set; }
        public int status { get; set; }
    }
}
