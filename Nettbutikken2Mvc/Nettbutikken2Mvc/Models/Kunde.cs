using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nettbutikken2Mvc.Models
{
    
    public class Kunde
    {
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis!")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig fornavn")]
        public string Fornavn { get; set; }
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig etternavn")]
        public string Etternavn { get; set; }
        [Display(Name = "Telefonnummer")]
        [RegularExpression(@"(^[0-9\+\(\)\s]{8,}$)", ErrorMessage = "Ugyldig telefonnummer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        public string Telefonnummer { get; set; }
        [Display(Name = "Adresse")]
        [RegularExpression(@"(^[a-zA-Z0-9æÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig adresse")]
        [Required(ErrorMessage = "Adresse må oppgis")]
        public string Adresse { get; set; }
        [Display(Name = "Postnummer")]
        [RegularExpression(@"(^[0-9]{4})", ErrorMessage = "Ugyldig postnummer")]
        [Required(ErrorMessage = "Postnummer må oppgis")]
        public string Postnummer { get; set; }
        [Display(Name = "Poststed")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ]+$)", ErrorMessage = "Ugyldig poststed")]
        [Required(ErrorMessage = "Poststed må oppgis")]
        public string Poststed { get; set; }
        [Display(Name = "Epost")]
        [Required(ErrorMessage = "Email må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]@[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$)", ErrorMessage = "Ugyldig email")]
        public string Epost { get; set; }
        [Display(Name = "Passord")]
        [RegularExpression(@"(^[a-zA-Z0-9æÆøØåÅ]{8,}$)", ErrorMessage = "Ugyldig passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public string Passord { get; set; }
        [Display(Name = "PassordKopi")]
        [RegularExpression(@"(^[a-zA-Z0-9æÆøØåÅ]{8,}$)", ErrorMessage = "Ugyldig passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public string PassordKopi { get; set; }


    }
    public class dbKunde
    {
        [Key]
        public int Kundenummer { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telefonnummer { get; set; }
        public string Adresse { get; set; }
        public dbPoststed Poststed { get; set; }
        public string Epost { get; set; }
        public byte[] Passord { get; set; }
    }
    public class dbPoststed
    {
        [Key]
        public string Poststed { get; set; }
        public string Postnummer { get; set; }
    }

    public class KundeContext : DbContext
    {
        public KundeContext()
            : base("name=Kunde")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<dbKunde> Kunder { get; set; }
        public DbSet<dbPoststed> Poststeder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

}