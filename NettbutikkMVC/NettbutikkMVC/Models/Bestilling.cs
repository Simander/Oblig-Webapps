using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NettbutikkMVC.Models
{
    public class Bestilling
    {
        [Key]
        public int OrdreNR { get; set; }
        public List<Vare> Varer { get; set; }
    }
}