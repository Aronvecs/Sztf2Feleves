using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    internal class KisCsomag : Kuldemeny
    {
        public KisCsomag() 
        {
            Prioritas = 5;
            Tomeg = 5;
        }
    }
    internal class NormalCsomag : Kuldemeny
    {
        public NormalCsomag()
        {
            Prioritas = 6;
            Tomeg = 10;
        }
    }
    internal class NagyCsomag : Kuldemeny
    {
        public NagyCsomag()
        {
            Prioritas = 7;
            Tomeg = 15;
        }
    }
    internal class Raklap : Kuldemeny
    {
        public Raklap()
        {
            Prioritas = 8;
            Tomeg = 20;
        }
    }
    internal class Kuldemeny : IKuldemeny 
    {
        Random r = new Random();
        public int csomagszam { get; private set; }
        public int Prioritas { get; set; }
        public int Tomeg { get; set; }
        public bool Kiosztva { get; set; }
        public Kuldemeny()
        {
            csomagszam = r.Next(1000000, 9999999);
            Kiosztva = false;
        }
        public Kuldemeny Kovetkezo { get; set; }
        public void KuldemenyAtmasolas(Kuldemeny uj)
        {
            this.Prioritas = uj.Prioritas;
            this.Tomeg = uj.Tomeg;
            this.Kiosztva = uj.Kiosztva;
        }
    }
}
