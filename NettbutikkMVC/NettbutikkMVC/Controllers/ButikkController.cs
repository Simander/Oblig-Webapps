using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NettbutikkMVC.Controllers
{
    public class ButikkController : Controller
    {
        // GET: Butikk
        public ActionResult Index()
        {
            return View();
        }
    }
}