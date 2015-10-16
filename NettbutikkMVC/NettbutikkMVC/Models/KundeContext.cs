using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using NettbutikkMVC.Models;

namespace NettbutikkMVC.Models
{
    public class KundeContext : DbContext
    {
        public KundeContext()
            : base("name=Kunde")
        {
          //  Database.CreateIfNotExists();
        }
        public DbSet<Kunde> Kunder { get; set; }
       // public DbSet<Poststed> Poststeder { get; set; }
    }
   
}