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
        public List<Perusharjoitukset> Listaus2()
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            List<Perusharjoitukset> allResults2 = context2.Perusharjoitukset.ToList();

            return allResults2;
        }

        [HttpGet]
        [Route("{perusID}")]
        public Perusharjoitukset Yksittäinen2(int perusID)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            Perusharjoitukset perus = context2.Perusharjoitukset.Find(perusID);

            return perus;
        }

        [HttpPost]
        [Route("")]
        public bool Luonti2([FromBody] Perusharjoitukset uusi2)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            context2.Perusharjoitukset.Add(uusi2);
            context2.SaveChanges();

            return true;
        }

        [HttpPut]
        [Route("{perusID}")]
        public Perusharjoitukset Muokkaus2(int perusID, [FromBody] Perusharjoitukset muutokset)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            Perusharjoitukset perus = context2.Perusharjoitukset.Find(perusID);

            // löytyikö asiakas annetulla id:llä?
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

            context2.SaveChanges();

            return perus;
        }


        [HttpDelete]
        [Route("{perusID}")]
        public bool Poisto2(int perusID)
        {
            WorkoutTrackerContext context2 = new WorkoutTrackerContext();
            Perusharjoitukset perus = context2.Perusharjoitukset.Find(perusID);

            if (perus == null)
            {
                return false;
            }

            context2.Perusharjoitukset.Remove(perus);
            context2.SaveChanges();

            return true;
        }
    }
}