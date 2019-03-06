using System;
using System.Collections.Generic;

namespace WorkoutTracker.Database
{
    public partial class Punttiennosto
    {
        public DateTime Päivämäärä { get; set; }
        public string Kuukausi { get; set; }
        public int? Penkkipunnerruspaino { get; set; }
        public int? Penkkipunnerrustoistot { get; set; }
        public int? Ylätaljapaino { get; set; }
        public int? Ylätaljatoistot { get; set; }
        public int? Hauistankopaino { get; set; }
        public int? Hauistankotoistot { get; set; }
        public int? Kyykkypaino { get; set; }
        public int? Kyykkytoistot { get; set; }
        public int? Deadliftpaino { get; set; }
        public int? Deadlifttoistot { get; set; }
        public int? Hauisvasenpaino { get; set; }
        public int? Hauisvasentoistot { get; set; }
        public int? Hauisoikeapaino { get; set; }
        public int? Hauisoikeatoistot { get; set; }
    }
}
