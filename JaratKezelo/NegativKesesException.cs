using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezelo
{
    class NegativKesesException:Exception
    {
        public NegativKesesException(TimeSpan time)
            : base("Nem lehet negatív a végleges késés:"+ time.ToString())
        {

        }
        public NegativKesesException(int time)
            : base("Nem lehet negatív a végleges késés:" + time.ToString())
        {

        }
    }
}
