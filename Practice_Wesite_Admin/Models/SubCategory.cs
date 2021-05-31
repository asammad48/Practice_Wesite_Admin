
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{ 
    public class SubCategory
    {

        [Key]
        public int SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }
        public int Status { get; set; }

    }
}
