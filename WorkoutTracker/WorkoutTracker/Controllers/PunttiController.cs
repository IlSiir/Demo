using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTracker.Controllers
{
    [Route("api/puntti")]
    [ApiController]
    public class PunttiController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Punttiennosto> Listaus()
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            List<Punttiennosto> allCustomers = context.Punttiennosto.ToList();

            return allCustomers;
        }

        [HttpGet]
        [Route("{päivämäärä}")]
        public Punttiennosto Yksittäinen(string päivämäärä)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Punttiennosto asiakas = context.Punttiennosto.Find(päivämäärä);

            return asiakas;
        }

        [HttpPost]
        [Route("")]
        public bool Luonti([FromBody] Punttiennosto uusi)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            context.Punttiennosto.Add(uusi);
            context.SaveChanges();

            return true;
        }

        [HttpPut]
        [Route("{päivämäärä}")]
        public Punttiennosto Muokkaus(string päivämäärä, [FromBody] Punttiennosto muutokset)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Punttiennosto päivä = context.Punttiennosto.Find(päivämäärä);

            // löytyikö asiakas annetulla id:llä?
            if (päivä == null)
            {
                return null;
            }

            // muokkaus
            päivä.Päivämäärä = muutokset.Päivämäärä;
            päivä.Kuukausi = muutokset.Kuukausi;
            päivä.Penkkipunnerruspaino = muutokset.Penkkipunnerruspaino;
            päivä.Penkkipunnerrustoistot = muutokset.Penkkipunnerrustoistot;
            päivä.Ylätaljapaino = muutokset.Ylätaljapaino;
            päivä.Ylätaljatoistot = muutokset.Ylätaljatoistot;
            päivä.Hauistankopaino = muutokset.Hauistankopaino;
            päivä.Hauistankotoistot = muutokset.Hauistankotoistot;
            päivä.Kyykkypaino = muutokset.Kyykkypaino;
            päivä.Kyykkytoistot = muutokset.Kyykkytoistot;
            päivä.Deadliftpaino = muutokset.Deadliftpaino;
            päivä.Deadlifttoistot = muutokset.Deadlifttoistot;
            päivä.Hauisvasenpaino = muutokset.Hauisvasenpaino;
            päivä.Hauisvasentoistot = muutokset.Hauisvasentoistot;
            päivä.Hauisoikeapaino = muutokset.Hauisoikeapaino;
            päivä.Hauisoikeatoistot = muutokset.Hauisoikeatoistot;

            context.SaveChanges();

            return päivä;
        }


        [HttpDelete]
        [Route("{päivämäärä}")]
        public bool Poisto(string päivämäärä)
        {
            WorkoutTrackerContext context = new WorkoutTrackerContext();
            Punttiennosto päivä = context.Punttiennosto.Find(päivämäärä);

            if (päivä == null)
            {
                return false;
            }

            context.Punttiennosto.Remove(päivä);
            context.SaveChanges();

            return true;
        }
    }
}