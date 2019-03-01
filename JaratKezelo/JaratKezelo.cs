using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezelo
{
    public class JaratKezelo
    {
        public List<Jarat> jaratok=new List<Jarat>();
       
        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            bool felvesz = true;
            foreach (var item in jaratok)
            {
                if (item.JaratSzam.Equals(jaratSzam))
                {
                    felvesz = false;
                    break;
                }
            }
            if (felvesz)
            {
            jaratok.Add(new Jarat(jaratSzam, repterHonnan, repterHova, indulas));
            }
            else
            {
                throw new ArgumentException(jaratSzam);
            }
        }
        public Jarat GetJarat(string jaratSzam)
        {
            foreach (var jarat in jaratok)
            {
                if (jarat.JaratSzam.Equals(jaratSzam))
                {
                    return jarat;
                }
            }
            throw new ArgumentException(jaratSzam);
        }
        public void Keses(string jaratSzam,int keses)
        {
            foreach (var jarat in jaratok)
            { int kes = 0;
                if (jarat.JaratSzam.Equals(jaratSzam))
                {
                    if ((kes + keses) < kes)
                    {
                        kes += keses;
                    }
                    else
                    {
                        throw new NegativKesesException(keses);
                    }
                    kes += keses;
                }
            }
        }
        public void Keses(string jaratSzam, TimeSpan keses)
        {
            foreach (var jarat in jaratok)
            {
                if (jarat.JaratSzam.Equals(jaratSzam))
                {
                    if((jarat.Keses + keses) >new TimeSpan(0,0,0))
                    { 
                        jarat.Keses+=keses;
                    }
                    else
                    {
                        throw new NegativKesesException(keses);
                    }
                }
            }
        }
        public DateTime MikorIndul(string jaratszam)
        {
            foreach (var jarat in jaratok)
            {
                if (jarat.JaratSzam.Equals(jaratszam))
                {
                    return jarat.Indulas+jarat.Keses;
                }
                
            }
            throw new ArgumentException(jaratszam);
        }
        public List<string>JaratokRepuloterrol(string repter)
        {
            List<string> repulok = new List<string>();
            bool nincs_ilyen_repter=true;
            foreach (var jarat in jaratok)
            {
                if (jarat.HonnanRepter.Equals(repter))
                {
                    repulok.Add(jarat.JaratSzam);
                    nincs_ilyen_repter = false;
                }
            }
            if (nincs_ilyen_repter)
            {
                throw new ArgumentException(repter);
            }
            return repulok;
        }

    }
}
