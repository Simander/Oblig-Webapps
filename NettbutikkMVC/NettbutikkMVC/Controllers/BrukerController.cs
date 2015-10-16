using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NettbutikkMVC.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
            if (ModelState.IsValid)
            {
               /* return "Fornavn: " + innListe["Fornavn"] + "\nEtternavn: " + innListe["Etternavn"] + "\nAdresse: " + innListe["Adresse"] +
                    "\nTelefonnr: " + innListe["Telefonnummer"] + "\nEpost: " + innListe["Epost"] + "\nPassord: " + innListe["Passord"] +
                    "\nPoststed: " + innListe["Poststed"] + "\nPostnr: " + innListe["Postnummer"];
               */ Console.WriteLine("In the mucK");
                 try
                 {
                     using (var db = new Models.KundeContext())
                     {

                         var nyKunde = new Models.Kunde();
                         nyKunde.Fornavn = innListe["Fornavn"];
                         nyKunde.Etternavn = innListe["Etternavn"];
                         nyKunde.Adresse = innListe["Adresse"];
                         nyKunde.TelefonNR = innListe["Telefonnummer"];
                         nyKunde.Epost = innListe["Epost"];
                         if (innListe["Passord"].Equals(innListe["PassordKopi"]))
                         {
                             nyKunde.Passord = Logikk.hashPword(innListe["Passord"]);
                         }
                        nyKunde.PostSted = innListe["Poststed"];
                        nyKunde.PostNR = innListe["Postnummer"];
                       /*  //Kan ikke bruke dette array i LINQ nedenfor
                         string innPostNr = innListe["Postnummer"];
                         var funnetPoststed = db.Poststeder
                             .FirstOrDefault(p => p.PostNR == innPostNr);
                         if (funnetPoststed == null) //fant ikke poststed, må legge inn et nytt
                         {
                             var nyttPoststed = new Models.Poststed();

                             nyttPoststed.PostNR = innListe["Postnummer"];
                             nyttPoststed.PostSted = innListe["Poststed"];
                             db.Poststeder.Add(nyttPoststed);
                             //det nye poststedet legges i den nye brukeren
                             nyKunde.Poststed = nyttPoststed;
                         }
                         else
                         {
                             //fant poststedet, legger det inn på bruker
                             nyKunde.Poststed = funnetPoststed;
                         }*/
                         db.Kunder.Add(nyKunde);
                         db.SaveChanges();
                         return RedirectToAction("RegistrertKundeOK");

                     }
                 }
                 catch (DbEntityValidationException e)
                 {

            
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            else return View();
        }
        public ActionResult RegistrertKundeOK()
        {
            var db = new Models.KundeContext();
            List<Models.Kunde> listeAvKunder = db.Kunder.ToList();
            return View(listeAvKunder);
        } 




    }
}