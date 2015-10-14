﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NettbutikkMVC.Models;
using System.Data.Entity;

namespace NettbutikkMVC.Controllers
{
    public class BrukerController : Controller
    {
        // GET: Bruker
        public ActionResult Index()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            return View();
        }


        // GET: /Bruker/LoggUt
        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            Session["Bruker"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: /Bruker/LoggInn
        public ActionResult LoggInn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoggInn(FormCollection innListe)
        {
            var brukernavn = innListe["usrname"];
            var passord = Logikk.hashPword(innListe["pword"]);
            try
            {
                using (var db = new KundeContext())
                {
                    
                    var funnetBruker = db.Kunder
                       .FirstOrDefault(k => k.Epost == brukernavn);
                    if (funnetBruker == null) //fant ikke poststed, må legge inn et nytt
                    {
                        return View();
                    }
                    else
                    {
                        if (funnetBruker.Passord.SequenceEqual( passord))
                        {
                            Session["LoggetInn"] = true;
                            Session["Bruker"] = funnetBruker;
                            return RedirectToAction("Index", "Home");
                            // return "Kundenr: " + ((Kunde)Session["Bruker"]).KundeNR + " | Brukernavn: " + ((Kunde)Session["Bruker"]).Epost + " er logget inn!";
                        }
                        //return "funnetBruker.Passord: " + funnetBruker.Passord + " | innskrevet hash: " + passord;
                    }
                }
                return View();
            }
            catch(Exception feil) { 

                return View(feil) ;
            }
        }
        //GET: /Bruker/CreateNyKunde
        public ActionResult NyKunde()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NyKunde(FormCollection innListe)
        {

            Console.WriteLine("In the mucK");
            try
            {
                using (var db = new Models.KundeContext())
                {
                    var nyKunde = new Models.Kunde();
                    nyKunde.Fornavn = innListe["Fornavn"];
                    nyKunde.Etternavn = innListe["Etternavn"];
                    nyKunde.Adresse = innListe["Adresse"];
                    nyKunde.TelefonNR = int.Parse(innListe["Telefon"]);
                    nyKunde.Epost = innListe["Epost"];
                    if (innListe["Passord"].Equals(innListe["PassordKopi"]))
                    {
                        nyKunde.Passord = Logikk.hashPword(innListe["Passord"]);
                    }
                    //Kan ikke bruke dette array i LINQ nedenfor
                    string innPostNr = innListe["Postnr"];
                    var funnetPoststed = db.Poststeder
                        .FirstOrDefault(p => p.PostNR == innPostNr);
                    if(funnetPoststed == null) //fant ikke poststed, må legge inn et nytt
                    {
                        var nyttPoststed = new Models.Poststed();

                        nyttPoststed.PostNR = innListe["Postnr"];
                        nyttPoststed.PostSted = innListe["Poststed"];
                        db.Poststeder.Add(nyttPoststed);
                        //det nye poststedet legges i den nye brukeren
                        nyKunde.Poststed = nyttPoststed;
                    }
                    else
                    {
                        //fant poststedet, legger det inn på bruker
                        nyKunde.Poststed = funnetPoststed;
                    }
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                    return RedirectToAction("RegistrertKundeOK");

                }
            }
            catch(Exception feil)
            {
                return View();
            }
            
        }
        public ActionResult RegistrertKundeOK()
        {
            var db = new Models.KundeContext();
            List<Models.Kunde> listeAvKunder = db.Kunder.ToList();
            return View(listeAvKunder);
        } 




    }
}