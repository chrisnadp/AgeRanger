using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgeRangerAPI.Controllers
{
    public class HomeController : Controller
    {
        PeopleController peopleController = new PeopleController();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(peopleController.GetPeople());
        }
    }
}
