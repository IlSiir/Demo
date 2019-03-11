using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Models;
using WorkoutTracker.Database;
using Microsoft.AspNetCore.Http;

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
            List<Aerobinenharjoitus> allAerobinen = context.Aerobinenharjoitus.ToList();

            return View(allAerobinen);
        }

        public IActionResult CreateA()
        {
            return View();
        }

        
        public ActionResult DeleteA(int Id)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Aerobinenharjoitus aeroid = context1.Aerobinenharjoitus.Find(Id);

            return View(aeroid);
        }

        [HttpPost]
        public ActionResult DeleteA(int Id, IFormCollection form)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Aerobinenharjoitus aero = context1.Aerobinenharjoitus.Find(Id);

            if (aero != null)
            {
                context1.Aerobinenharjoitus.Remove(aero);
                context1.SaveChanges();
            }

            return RedirectToAction("Aerobinen");
        }
        

        [HttpPost]
        public IActionResult CreateA([FromForm] Aerobinenharjoitus uusi2)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            context2.Aerobinenharjoitus.Add(uusi2);
            context2.SaveChanges();

            return RedirectToAction("Aerobinen");
        }

        public IActionResult Perus()
        {
            ViewData["Message"] = "Perus harjoitukset.";
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Perusharjoitukset> allPerus = context.Perusharjoitukset.ToList();

            return View(allPerus);
        }

        public IActionResult CreatePe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePe([FromForm] Perusharjoitukset uusi2)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            context2.Perusharjoitukset.Add(uusi2);
            context2.SaveChanges();

            return RedirectToAction("Perus");
        }

        public ActionResult DeletePe(int Id)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Perusharjoitukset peruid = context1.Perusharjoitukset.Find(Id);

            return View(peruid);
        }

        [HttpPost]
        public ActionResult DeletePe(int Id, IFormCollection form)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Perusharjoitukset peru = context1.Perusharjoitukset.Find(Id);

            if (peru != null)
            {
                context1.Perusharjoitukset.Remove(peru);
                context1.SaveChanges();
            }

            return RedirectToAction("Perus");
        }

        public IActionResult Puntit()
        {
            ViewData["Message"] = "Punttien nosto.";
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Punttiennosto> allPuntit = context.Punttiennosto.ToList();

            return View(allPuntit);           
        }

        public IActionResult CreatePu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePu([FromForm] Punttiennosto uusi2)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            context2.Punttiennosto.Add(uusi2);
            context2.SaveChanges();

            return RedirectToAction("Puntit");
        }

        public ActionResult DeletePu(int Id)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Punttiennosto puntid = context1.Punttiennosto.Find(Id);

            return View(puntid);
        }

        [HttpPost]
        public ActionResult DeletePu(int Id, IFormCollection form)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Punttiennosto punt = context1.Punttiennosto.Find(Id);

            if (punt != null)
            {
                context1.Punttiennosto.Remove(punt);
                context1.SaveChanges();
            }

            return RedirectToAction("Puntit");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
