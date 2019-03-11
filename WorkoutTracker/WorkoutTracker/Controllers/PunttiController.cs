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
        public List<Punttiennosto> Listaus3()
        {
            WorkoutTrackerContext context3 = new WorkoutTrackerContext();
            List<Punttiennosto> allResults3 = context3.Punttiennosto.ToList();

            return allResults3;
        }

        [HttpGet]
        [Route("{punttiID}")]
        public Punttiennosto Yksittäinen3(int punttiID)
        {
            WorkoutTrackerContext context3 = new WorkoutTrackerContext();
            Punttiennosto puntti = context3.Punttiennosto.Find(punttiID);

            return puntti;
        }

        [HttpPost]
        [Route("")]
        public bool Luonti3([FromBody] Punttiennosto uusi3)
        {
            WorkoutTrackerContext context3 = new WorkoutTrackerContext();
            context3.Punttiennosto.Add(uusi3);
            context3.SaveChanges();

            return true;
        }

        [HttpPut]
        [Route("{punttiID}")]
        public Punttiennosto Muokkaus3(int punttiID, [FromBody] Punttiennosto muutokset)
        {
            WorkoutTrackerContext context3 = new WorkoutTrackerContext();
            Punttiennosto puntti = context3.Punttiennosto.Find(punttiID);

            // löytyikö asiakas annetulla id:llä?
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

            context3.SaveChanges();

            return puntti;
        }


        [HttpDelete]
        [Route("{punttiID}")]
        public bool Poisto3(int punttiID)
        {
            WorkoutTrackerContext context3 = new WorkoutTrackerContext();
            Punttiennosto puntti = context3.Punttiennosto.Find(punttiID);

            if (puntti == null)
            {
                return false;
            }

            context3.Punttiennosto.Remove(puntti);
            context3.SaveChanges();

            return true;
        }
    }
}