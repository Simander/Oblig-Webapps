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

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis!")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig fornavn")]
        public string Fornavn { get; set; }

        [Display(Name = "Etternavn!")]
        [Required(ErrorMessage = "Etternavn må oppgis!")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig etternavn")]
        public string Etternavn { get; set; }

        [Display(Name = "Telefonnummer")]
        [RegularExpression(@"(^[0-9\+\(\)\s]{8,}$)", ErrorMessage = "Ugyldig telefonnummer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis!")]
        public int TelefonNR { get; set; }

        [Display(Name = "Adresse")]
        [RegularExpression(@"(^[a-zA-Z0-9æÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig adresse")]
        [Required(ErrorMessage = "Adresse må oppgis!")]
        public string Adresse { get; set; }

    

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email må oppgis!")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]@[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$)", ErrorMessage = "Ugyldig email")]
        public string Epost { get; set; }


        public byte[] Passord { get; set; }
        public Poststed Poststed { get; set; }


    }
}