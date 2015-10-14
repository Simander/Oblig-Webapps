using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NettbutikkMVC.Models
{
    public class Handlevogn
    {
        public Kunde kunde { get; set; }
        public LinkedList<Vare> varer { get; set; }

        public bool addToCart(Vare v)
        {
            varer.AddLast(v);
            return true;
        }

    }
}