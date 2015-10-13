using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NettbutikkMVC.Models
{
    public class Logikk
    {
        public static byte[] hashPword(string innPword)
        {
            var algoritme = System.Security.Cryptography.SHA512.Create();
            byte[] inndata, utdata;
            inndata = System.Text.Encoding.ASCII.GetBytes(innPword);
            utdata = algoritme.ComputeHash(inndata);
            return utdata;


        }

        public static bool isLoggedIn(string usrname, string pword)
        {
            try
            {
                using (var db = new KundeContext())
                {
                    var funnetBruker = db.Kunder
                       .FirstOrDefault(p => p.Epost == usrname );
                    if (funnetBruker == null) //fant ikke poststed, må legge inn et nytt
                    {
                        return false;
                    }
                    else
                    {
                        if (funnetBruker.Passord == hashPword(pword))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                       
                    }
                    
                }
               
            }
            catch (Exception feil)
            {
                return false;
            }
                    
        }

    }
}