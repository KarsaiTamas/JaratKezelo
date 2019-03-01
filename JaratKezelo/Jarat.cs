using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezelo
{
    public class Jarat
    {
        public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas )
        {
            JaratSzam = jaratSzam;
            HonnanRepter = honnanRepter;
            HovaRepter = hovaRepter;
            Indulas = indulas;
            Keses = TimeSpan.Zero;
        }

        public string JaratSzam { get; set; }
        public string HonnanRepter { get; set; }
        public string HovaRepter { get; set; }
        public DateTime Indulas { get; set; }
        public TimeSpan Keses { get; set; }
    }
}
