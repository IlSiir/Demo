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
        public List<Aerobinenharjoitus> Listaus1()
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            List<Aerobinenharjoitus> allresults1 = context1.aerobinenharjoitus.ToList();

            return allresults1;
        }

        [HttpGet]
        [Route("{aeroID}")]
        public Aerobinenharjoitus Yksittäinen(int aeroId)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Aerobinenharjoitus aero = context1.aerobinenharjoitus.Find(aeroId);

            // LINQ
            //Customers asiakas2 = (from c in context.Customers
            //                      where c.CustomerId == asiakasId
            //                      select c).FirstOrDefault();

            return aero;
        }

        [HttpPost]
        [Route("")]
        public bool Luonti1([FromBody] Aerobinenharjoitus uusi1)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            context1.aerobinenharjoitus.Add(uusi1);
            context1.SaveChanges();

            return true;
        }

        [HttpPut]
        [Route("{aeroID}")]
        public Aerobinenharjoitus Muokkaus1(int aeroID, [FromBody] Aerobinenharjoitus muutokset)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Aerobinenharjoitus aero = context1.aerobinenharjoitus.Find(aeroID);

            // löytyikö asiakas annetulla id:llä?
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

            return aero;
        }


        [HttpDelete]
        [Route("{aeroID}")]
        public bool Poisto1(int AeroID)
        {
            WorkoutTrackerContext context1 = new WorkoutTrackerContext();
            Aerobinenharjoitus aero = context1.aerobinenharjoitus.Find(AeroID);

            if (aero == null)
            {
                return false;
            }

            context1.aerobinenharjoitus.Remove(aero);
            context1.SaveChanges();

            return true;
        }
    }
}