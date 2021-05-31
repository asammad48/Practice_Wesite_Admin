
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{
    public class Category_subCategory
    {
        [Key]
        public int SubCategory_SubSubcategoryID { get; set; }
        [Display(Name = "Category")]
        public virtual int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Categories { get; set; }
        [Display(Name = "SubCategory")]
        public virtual int SubCategoryID { get; set; }

        [ForeignKey("SubCategoryID")]
        public virtual SubCategory SubCategories { get; set; }
        public int status { get; set; }

    }
}
