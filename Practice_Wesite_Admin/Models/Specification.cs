using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{
    public class Specification
    {
        [Key]
        public int SpecID { get; set; }
        [Display(Name = "Product")]
        public virtual int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
        public string SpecName { get; set; }
        public string SpecValue { get; set; }
        [Display(Name = "Variants")]
        public virtual int VariantID { get; set; }

        [ForeignKey("VariantID")]
        public virtual Variants Variants { get; set; }
        public int top { get; set; }

    }
}
