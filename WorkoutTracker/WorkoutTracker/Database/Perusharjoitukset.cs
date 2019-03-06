using System;
using System.Collections.Generic;

namespace WorkoutTracker.Database
{
    public partial class Perusharjoitukset
    {
        public DateTime Päivämäärä { get; set; }
        public string Kuukausi { get; set; }
        public int? Vatsalihas { get; set; }
        public int? Etunojapunnerrus { get; set; }
        public int? Selkälihas { get; set; }
        public int? Jalkakyykky { get; set; }
    }
}
