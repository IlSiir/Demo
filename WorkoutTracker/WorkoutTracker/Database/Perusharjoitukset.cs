﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Database
{
    public partial class Perusharjoitukset
    {
        public int PerusID { get; set; }
        [Display(Name = "Päivämäärä")]
        [DataType(DataType.Date)]
        public DateTime Päivämäärä { get; set; }
        public int? Vatsalihas { get; set; }
        public int? Etunojapunnerrus { get; set; }
        public int? Selkälihas { get; set; }
        public int? Jalkakyykky { get; set; }
    }
}
