using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NettbutikkMVC.Models
{
    public class Vare
    {
        [Key]
        public int VareNR { get; set; }

        public string Kategori { get; set; }
        public string Navn { get; set; }
        public decimal Pris { get; set; }
    }
}