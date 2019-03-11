using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models
{
    public class Aerobinenharjoit
    {
        public int AeroID { get; set; }
        [Display(Name = "Päivämäärä")]
        [DataType(DataType.Date)]
        public DateTime Päivämäärä { get; set; }
        public int? Lenkkeilymatka { get; set; }
        public int? Lenkkeilyaika { get; set; }
        public int? Pyöräilymatka { get; set; }
        public int? Pyöräilyaika { get; set; }
        public int? Hyppynaru { get; set; }
        public int? Nyrkkeilysäkkiaika { get; set; }
    }
}
