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
        [Display(Name = "Postnummer")]
        [RegularExpression(@"(^[0-9]{4})", ErrorMessage = "Ugyldig postnummer")]
        [Required(ErrorMessage = "Postnummer må oppgis!")]
        public string PostNR { get; set; }
        [Display(Name = "Poststed")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ]+$)", ErrorMessage = "Ugyldig poststed")]
        [Required(ErrorMessage = "Poststed må oppgis!")]
        public string PostSted { get; set; }
    }
}