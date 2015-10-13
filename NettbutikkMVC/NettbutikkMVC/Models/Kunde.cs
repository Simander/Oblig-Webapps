using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NettbutikkMVC.Models
{
    public class Kunde
    {
        [Key]
        public int KundeNR { get; set; }
      
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }

        public int TelefonNR { get; set; }

        public string Adresse { get; set; }
        public Poststed Poststed { get; set; }

        public string Epost { get; set; }
        public byte[] Passord { get; set; }

    }
}