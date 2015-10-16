using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikken2Mvc.Models
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
    }
}