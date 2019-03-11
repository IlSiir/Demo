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

        public ActionResult EditA(int Id)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Aerobinenharjoitus aeroid = context1.Aerobinenharjoitus.Find(Id);

            return View(aeroid);
        }

        [HttpPost]
        public ActionResult EditA(int Id, [FromForm] Aerobinenharjoitus muutokset)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Aerobinenharjoitus aero = context1.Aerobinenharjoitus.Find(Id);

            if (aero == null)
            {
                return null;
            }

            // muokkaus
            aero.AeroID = muutokset.AeroID;
            aero.Päivämäärä = muutokset.Päivämäärä;
            aero.Lenkkeilymatka = muutokset.Lenkkeilymatka;
            aero.Lenkkeilyaika = muutokset.Lenkkeilyaika;
            aero.Pyöräilymatka = muutokset.Pyöräilymatka;
            aero.Pyöräilyaika = muutokset.Pyöräilyaika;
            aero.Hyppynaru = muutokset.Hyppynaru;
            aero.Nyrkkeilysäkkiaika = muutokset.Nyrkkeilysäkkiaika;

            context1.SaveChanges();

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

        public ActionResult EditPe(int Id)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Perusharjoitukset peruid = context1.Perusharjoitukset.Find(Id);

            return View(peruid);
        }

        [HttpPost]
        public ActionResult EditPe(int Id, [FromForm] Perusharjoitukset muutokset)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Perusharjoitukset perus = context1.Perusharjoitukset.Find(Id);

            if (perus == null)
            {
                return null;
            }

            // muokkaus
            perus.PerusID = muutokset.PerusID;
            perus.Päivämäärä = muutokset.Päivämäärä;
            perus.Vatsalihas = muutokset.Vatsalihas;
            perus.Etunojapunnerrus = muutokset.Etunojapunnerrus;
            perus.Selkälihas = muutokset.Selkälihas;
            perus.Jalkakyykky = muutokset.Jalkakyykky;

            context1.SaveChanges();

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

        public ActionResult EditPu(int Id)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Punttiennosto puntid = context1.Punttiennosto.Find(Id);

            return View(puntid);
        }

        [HttpPost]
        public ActionResult EditPu(int Id, [FromForm] Punttiennosto muutokset)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Punttiennosto puntti = context1.Punttiennosto.Find(Id);

            if (puntti == null)
            {
                return null;
            }

            // muokkaus
            puntti.PunttiID = muutokset.PunttiID;
            puntti.Päivämäärä = muutokset.Päivämäärä;
            puntti.Penkkipunnerruspaino = muutokset.Penkkipunnerruspaino;
            puntti.Penkkipunnerrustoistot = muutokset.Penkkipunnerrustoistot;
            puntti.Ylätaljapaino = muutokset.Ylätaljapaino;
            puntti.Ylätaljatoistot = muutokset.Ylätaljatoistot;
            puntti.Hauistankopaino = muutokset.Hauistankopaino;
            puntti.Hauistankotoistot = muutokset.Hauistankotoistot;
            puntti.Kyykkypaino = muutokset.Kyykkypaino;
            puntti.Kyykkytoistot = muutokset.Kyykkytoistot;
            puntti.Deadliftpaino = muutokset.Deadliftpaino;
            puntti.Deadlifttoistot = muutokset.Deadlifttoistot;
            puntti.Hauisvasenpaino = muutokset.Hauisvasenpaino;
            puntti.Hauisvasentoistot = muutokset.Hauisvasentoistot;
            puntti.Hauisoikeapaino = muutokset.Hauisoikeapaino;
            puntti.Hauisoikeatoistot = muutokset.Hauisoikeatoistot;

            context1.SaveChanges();

            return RedirectToAction("Puntit");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
