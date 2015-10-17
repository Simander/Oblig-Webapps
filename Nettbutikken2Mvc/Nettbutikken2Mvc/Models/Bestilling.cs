using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikken2Mvc.Models
{
    public class Bestilling
    {
        public string OrdreNummer { get; set; } 
        
    }
    public class dbBestilling
    {
        [Key]
        public int OrdreNR { get; set; }
        public Kunde Kunde { get; set; }
        public List<Vare> Varer { get; set; }
    }
    public class Handlevogn
    {

        public string Antall { get; set; }

    }
    public class HandlevognItem
    {
        public dbVare Vare { get; set; }
        public  int Antall { get; set; }
    }

    public class dbHandlevogn
    {
        [Key]
        public int HandlevognID { get; set; }
        public Kunde Kunde { get; set; }
        public LinkedList<HandlevognItem> Varer { get; set; }

        
           

        }
    }
