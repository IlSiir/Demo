using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Controllers
{
    [Route("api/perus")]
    [ApiController]
    public class PerusController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Perusharjoitukset> Listaus()
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Perusharjoitukset> allCustomers = context.Perusharjoitukset.ToList();

            return allCustomers;
        }

        [HttpGet]
        [Route("{päivämäärä}")]
        public Perusharjoitukset Yksittäinen(string asiakasId)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Perusharjoitukset asiakas = context.Perusharjoitukset.Find(asiakasId);

            return asiakas;
        }

        [HttpPost]
        [Route("")]
        public bool Luonti([FromBody] Perusharjoitukset uusi)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            context.Perusharjoitukset.Add(uusi);
            context.SaveChanges();

            return true;
        }

        [HttpPut]
        [Route("{päivämäärä}")]
        public Perusharjoitukset Muokkaus(string päivämäärä, [FromBody] Perusharjoitukset muutokset)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Perusharjoitukset päivä = context.Perusharjoitukset.Find(päivämäärä);

            // löytyikö asiakas annetulla id:llä?
            if (päivä == null)
            {
                return null;
            }

            // muokkaus
            päivä.Päivämäärä = muutokset.Päivämäärä;
            päivä.Kuukausi = muutokset.Kuukausi;
            päivä.Vatsalihas = muutokset.Vatsalihas;
            päivä.Etunojapunnerrus = muutokset.Etunojapunnerrus;
            päivä.Selkälihas = muutokset.Selkälihas;
            päivä.Jalkakyykky = muutokset.Jalkakyykky;

            context.SaveChanges();

            return päivä;
        }


        [HttpDelete]
        [Route("{päivämäärä}")]
        public bool Poisto(string päivämäärä)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Perusharjoitukset päivä = context.Perusharjoitukset.Find(päivämäärä);

            if (päivä == null)
            {
                return false;
            }

            context.Perusharjoitukset.Remove(päivä);
            context.SaveChanges();

            return true;
        }
    }
}