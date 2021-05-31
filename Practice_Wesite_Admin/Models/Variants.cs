using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Wesite_Admin.Models
{
    public class Variants
    {
        [Key]
        public int VariantID { get; set; }
        public string VariantName { get; set; }
        public int status { get; set; }

    }
}
