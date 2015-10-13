using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NettbutikkMVC.Models
{
    public class Poststed
    {
       [Key]
        public string PostNR { get; set; }

        public string PostSted { get; set; }
    }
}