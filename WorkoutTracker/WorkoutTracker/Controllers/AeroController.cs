using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Controllers
{
    [Route("api/aero")]
    [ApiController]
    public class AeroController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Aerobinenharjoitus> Listaus()
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Aerobinenharjoitus> allCustomers = context.Aerobinenharjoitus.ToList();

            return allCustomers;
        }

        [HttpGet]
        [Route("{päivämäärä}")]
        public Aerobinenharjoitus Yksittäinen(string asiakasId)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Aerobinenharjoitus asiakas = context.Aerobinenharjoitus.Find(asiakasId);

            // LINQ
            //Customers asiakas2 = (from c in context.Customers
            //                      where c.CustomerId == asiakasId
            //                      select c).FirstOrDefault();

            return asiakas;
        }

        [HttpPost]
        [Route("")]
        public bool Luonti([FromBody] Aerobinenharjoitus uusi)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            context.Aerobinenharjoitus.Add(uusi);
            context.SaveChanges();

            return true;
        }

        [HttpPut]
        [Route("{päivämäärä}")]
        public Aerobinenharjoitus Muokkaus(string päivämäärä, [FromBody] Aerobinenharjoitus muutokset)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Aerobinenharjoitus päivä = context.Aerobinenharjoitus.Find(päivämäärä);

            // löytyikö asiakas annetulla id:llä?
            if (päivä == null)
            {
                return null;
            }

            // muokkaus
            päivä.Päivämäärä = muutokset.Päivämäärä;
            päivä.Kuukausi = muutokset.Kuukausi;
            päivä.Lenkkeilymatka = muutokset.Lenkkeilymatka;
            päivä.Lenkkeilyaika = muutokset.Lenkkeilyaika;
            päivä.Pyöräilymatka = muutokset.Pyöräilymatka;
            päivä.Pyöräilyaika = muutokset.Pyöräilyaika;
            päivä.Hyppynaru = muutokset.Hyppynaru;
            päivä.Nyrkkeilysäkkiaika = muutokset.Nyrkkeilysäkkiaika;

            context.SaveChanges();

            return päivä;
        }


        [HttpDelete]
        [Route("{päivämäärä}")]
        public bool Poisto(string päivämäärä)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Aerobinenharjoitus päivä = context.Aerobinenharjoitus.Find(päivämäärä);

            if (päivä == null)
            {
                return false;
            }

            context.Aerobinenharjoitus.Remove(päivä);
            context.SaveChanges();

            return true;
        }
    }
}