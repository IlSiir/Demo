using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Models;
using WorkoutTracker.Database;

namespace WorkoutTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }          

        public IActionResult Aerobinen()
        {
            ViewData["Message"] = "Aerobiset harjoitukset.";
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Database.Aerobinenharjoitus> allAerobinen = context.aerobinenharjoitus.ToList();

            return View(allAerobinen);
        }

        public IActionResult CreateA()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteA(int AeroID)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Database.Aerobinenharjoitus aeroid = context1.aerobinenharjoitus.Find(AeroID);
            context1.aerobinenharjoitus.Remove(aeroid);
            context1.SaveChanges();

            return RedirectToAction("Aerobinen");
        }

        [HttpPost]
        public IActionResult CreateA([FromForm] Database.Aerobinenharjoitus uusi2)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            context2.aerobinenharjoitus.Add(uusi2);
            context2.SaveChanges();

            return Redirect("Aerobinen");
        }

        public IActionResult Perus()
        {
            ViewData["Message"] = "Perus harjoitukset.";
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Database.Perusharjoitukset> allPerus = context.Perusharjoitukset.ToList();

            return View(allPerus);
        }

        public IActionResult CreatePe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePe([FromForm] Database.Perusharjoitukset uusi2)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            context2.Perusharjoitukset.Add(uusi2);
            context2.SaveChanges();

            return Redirect("Perus");
        }

        public IActionResult Puntit()
        {
            ViewData["Message"] = "Punttien nosto.";
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Database.Punttiennosto> allPuntit = context.Punttiennosto.ToList();

            return View(allPuntit);           
        }

        public IActionResult CreatePu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePu([FromForm] Database.Punttiennosto uusi2)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            context2.Punttiennosto.Add(uusi2);
            context2.SaveChanges();

            return Redirect("Puntit");
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
