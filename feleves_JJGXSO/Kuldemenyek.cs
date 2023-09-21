using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    delegate bool ErvenyesCsomag(Kuldemeny csomag);
    internal class Kuldemenyek
    {
        public ErvenyesCsomag ervenyesCsomag;
        public Kuldemeny fej { get; set; }
        public Kuldemeny CSomagKereses(int id)
        {
            Kuldemeny p = fej;
            while (p != null && p.csomagszam != id)
            {
                p = p.Kovetkezo;
            }
            if (p == null)
            {
                return null;
            }
            return p;
        }
        public void UjCsomagVegere(Kuldemeny uj)
        {
            Kuldemeny p = fej;
            if (p == null)
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else
            {
                while (p.Kovetkezo != null)
                {
                    p = p.Kovetkezo;
                }
                p.Kovetkezo = uj;
            }

        }
        public void UjCsomag(Kuldemeny uj)
        {
            if (!ervenyesCsomag(uj))
            {
                throw new TulNagyCsomagException(uj);
            }
            Kuldemeny p = fej;
            Kuldemeny e = null;
            while (p != null && p.Prioritas > uj.Prioritas)
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (e == null)
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else
            {
                e.Kovetkezo = uj;
                uj.Kovetkezo = p;
            }
        }
    }
}
