using System;
using System.Collections.Generic;

namespace WorkoutTracker.Database
{
    public partial class Aerobinenharjoitus
    {
        public DateTime Päivämäärä { get; set; }
        public string Kuukausi { get; set; }
        public int? Lenkkeilymatka { get; set; }
        public int? Lenkkeilyaika { get; set; }
        public int? Pyöräilymatka { get; set; }
        public int? Pyöräilyaika { get; set; }
        public int? Hyppynaru { get; set; }
        public int? Nyrkkeilysäkkiaika { get; set; }
    }
}
