using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    delegate void ListaElemTorles(Kuldemenyek csomagok);
    delegate void Napok(int i);

    internal class Beosztas
    {
        public ListaElemTorles torles;
        public Napok nap;
        public Kuldemenyek csomagok { get; set; }
        Futar[] futarok;
        public Beosztas(Futar[] futarok, Kuldemenyek csomagok)
        {
            this.futarok = futarok;
            this.csomagok = csomagok;
            MindenFutarSzabadsagon();
        }
        
        void MindenFutarSzabadsagon()
        {
            bool van = false;
            for (int i = 0; i < futarok.Length; i++)
            {
                if (!futarok[i].SzabadsagonVan)
                {
                    van = true;
                }
            }
            if (!van)
            {
                throw new MindenFutarSzabadsagon();
            }
        }
        public void BeosztasKeszites()
        {
            Kuldemeny p;
            int ossz;
            for (int i = 0; i < futarok.Length; i++)
            {
                if (!futarok[i].SzabadsagonVan)
                {
                    p = csomagok.fej;
                    ossz = 0;
                    while (p != null)
                    {
                        if (!p.Kiosztva && ossz + p.Tomeg <= futarok[i].jarmu.SzalithatoTomeg)
                        {
                            ossz += p.Tomeg;
                            p.Kiosztva = true;
                            Kuldemeny p2 = new Kuldemeny();
                            p2.KuldemenyAtmasolas(p);
                            futarok[i].Csomagok.UjCsomagVegere(p2);
                        }
                        p = p.Kovetkezo;
                    }
                }
            }
            KiNemosztottCsomagokNovelese();
        }
        int napok = 0;
        public void MindenCsomagKiosztasa()
        {
            
            while (VanMegKiNemOsztottCsomag())
            {
                BeosztasKeszites();
                napok++;
                if (napok == 8)
                {
                    napok = 1;
                }
                if (nap != null && torles != null)
                {
                    nap(napok);
                    torles(csomagok);
                }
            }
        }
        bool VanMegKiNemOsztottCsomag()
        {
            Kuldemeny p = csomagok.fej;
            while (p != null && p.Kiosztva)
            {
                p = p.Kovetkezo;
            }
            if (p == null)
            {
                return false;
            }
            return true;
        }
        void KiNemosztottCsomagokNovelese()
        {
            Kuldemeny p = csomagok.fej;
            while (p != null)
            {
                if (!p.Kiosztva)
                {
                    p.Prioritas++;
                }
                p = p.Kovetkezo;
            }
        }
        
    }
}
