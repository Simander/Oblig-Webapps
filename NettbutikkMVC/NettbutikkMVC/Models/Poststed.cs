using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikken.Models
{
    public class Poststed
    {
       [Key]
        public int PostNR { get; set; }

        public string PostSted { get; set; }
    }
}