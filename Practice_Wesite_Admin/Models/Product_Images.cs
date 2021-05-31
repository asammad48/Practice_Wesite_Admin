using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{
    public class Product_Images
    {
        [Key]
        public int p_img_id { get; set; }
        [Display(Name = "Product")]
        public virtual int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
        public string Images { get; set; }
    }
}
