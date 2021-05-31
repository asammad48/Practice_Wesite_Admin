using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{
    public class SubSubCategory
    {
        [Key]
        public int SubSubCategoryID { get; set; }

        public string SubsUBCategoryName { get; set; }
        public int Status { get; set; }

    }
}
