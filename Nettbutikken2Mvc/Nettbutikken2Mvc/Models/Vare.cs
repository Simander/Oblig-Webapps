using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nettbutikken2Mvc.Models
{
    public class Vare
    {
        [Display(Name = "Varenummer")]
        public int Varenummer { get; set; }
        public string Kategori { get; set; }
        public string Navn { get; set; }
       
        public int kvantitet { get; set; }
        public string Pris { get; set; }
        public string Produsent { get; set; }
        public string beskrivelse { get; set; }

        public string VareBildeUrl { get; set; }
    }
    public class dbVare
    {
        [Key]
        public int Varenummer { get; set; }

        public string Kategori { get; set; }
        public string Navn { get; set; }
        public int kvantitet { get; set; }
        public decimal Pris { get; set; }

        public string Produsent { get; set; }
        public string beskrivelse { get; set; }
        
        public string VareBildeUrl { get; set; }
    }

    public class VareContext : DbContext
    {
        public VareContext()
            : base("name=Vare")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<dbVare> Varer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }


}