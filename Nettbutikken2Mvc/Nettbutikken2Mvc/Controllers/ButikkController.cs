using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikken2Mvc.Controllers
{
    public class ButikkController : Controller
    {
        // GET: Butikk
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Butikk/Browse
        public ActionResult Browse()
        {
            return View();
        }

        // GET: /Butikk/Details
        public ActionResult Details()
        {
            return View();
        }
    }
}