using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    internal class Futar
    {

        public string Nev { get; }
        public DateTime SzuletesiEv { get; }
        public bool SzabadsagonVan { get; set; }
        public Jarmu jarmu { get; set; }
        public Kuldemenyek Csomagok { get; set; }

        public Futar(string Nev, Jarmu jarmu)
        {
            Csomagok = new Kuldemenyek();
            this.jarmu = jarmu;
            this.Nev = Nev;
            SzuletesiEv = DateTime.Now;
            SzabadsagonVan = false;
        }
    }
}
