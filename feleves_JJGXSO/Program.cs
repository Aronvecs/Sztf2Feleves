using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    internal class Program
    {
        static void Napok(int i)
        {
            switch (i) 
            { 
                case 1:
                default:
                    Console.WriteLine("Hetfő".ToUpper());
                    break;
                case 2:
                    Console.WriteLine("Kedd".ToUpper());
                    break;
                case 3:
                    Console.WriteLine("Szerda".ToUpper());
                    break;
                case 4:
                    Console.WriteLine("Csütörtök".ToUpper());
                    break;
                case 5:
                    Console.WriteLine("Péntek".ToUpper());
                    break;
                case 6:
                    Console.WriteLine("Szombat".ToUpper());
                    break;
                case 7:
                    Console.WriteLine("Vasárnap".ToUpper());
                    break;
            }
        }
        static void Torles(Kuldemenyek csomagok)
        {
            Kuldemeny p = csomagok.fej;
            Kuldemeny e = null;
            while (p != null)
            {
                if (p.Kiosztva)
                {
                    Console.WriteLine($"Csomag szama: {p.csomagszam}\n" +
                    $"Prioritas: {p.Prioritas}\n" +
                    $"Tomeg: {p.Tomeg}\n");
                    if (e == null)
                    {
                        csomagok.fej = p.Kovetkezo;
                        p = csomagok.fej;
                    }
                    else
                    {
                        e.Kovetkezo = p.Kovetkezo;
                        p = e.Kovetkezo;
                    }
                }
                else
                {
                    e = p;
                    p = p.Kovetkezo; 
                }
            }
        }

        static bool TulNagyCsomag(Kuldemeny csomag)
        {
            bool ervenyes = false;
            for (int i = 0; i < futarok.Length; i++)
            {
                if (futarok[i].jarmu.SzalithatoTomeg >= csomag.Tomeg)
                {
                    ervenyes = true;
                }
            }
            return ervenyes;
        }

        static void CsomagFelvetel()
        {
            string kilepes = "";
            Kuldemeny k;

            int i = 1;
            while (kilepes != "N")
            {
                Console.WriteLine($"{i}. CSOMAG");
                Console.Write("Add meg a csomag tipusát (lehetőségek: 'KisCsomag', 'NormalCsomag', 'NagyCsomag', 'Raklap'): ");
                string csomagtipus = Console.ReadLine();
                switch (csomagtipus.ToLower())
                {
                    case "kiscsomag":
                        k = new KisCsomag();
                        break;
                    case "normalcsomag":
                        k = new NormalCsomag();
                        break;
                    case "nagycsomag":
                        k = new NagyCsomag();
                        break;
                    case "raklap":
                        k = new Raklap();
                        break;
                    default:
                        throw new NemMegfeleloTipusException();
                }

                csomagok.UjCsomag(k);
                if (i >= 3)
                {
                    Console.Write("Szeretnél még csomagot feltölteni? Irj 'N'-t ha befejezted: ");
                    kilepes = Console.ReadLine();
                }
                Console.Clear();
                i++;
            }
            
        }
        static void FutarFelvetel()
        {
            Futar F;
            Console.Write("Hány darab futar dolgozzon?: ");
            int futarokSzama = Convert.ToInt32(Console.ReadLine());
            futarok = new Futar[futarokSzama];

            Jarmu jarmu;
            int i = 0;
            while (i < futarokSzama)
            {
                Console.Write("Futar Neve: ");
                string nev = Console.ReadLine();

                Console.Write("Add meg a jarmu tipusát (lehetőségek: 'Minibus', 'Transit', 'Kamion'): ");
                string jarm = Console.ReadLine();
                switch (jarm.ToUpper())
                {
                    case "MINIBUS":
                        jarmu = new Minibus();
                        break;
                    case "TRANSIT":
                        jarmu = new Transit();
                        break;
                    case "KAMION":
                        jarmu = new Kamion();
                        break;
                    default:
                        throw new NemMegfeleloTipusException();
                }
                F = new Futar(nev, jarmu);

                futarok[i] = F;

                i++;
            }
            Console.Clear();
        }
        static Futar[] futarok;
        static Kuldemenyek csomagok = new Kuldemenyek();
        static void Main(string[] args)
        {
            csomagok.ervenyesCsomag += TulNagyCsomag;
            try
            {
                Console.WriteLine("--Futarfelvétel--".ToUpper());
                FutarFelvetel();
                Console.WriteLine("--Csomagfelvétel--".ToUpper());
                CsomagFelvetel();

                Beosztas b = new Beosztas(futarok, csomagok);
                b.nap += Napok;
                b.torles += Torles;
                b.MindenCsomagKiosztasa();
            }
            catch (NemMegfeleloTipusException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MindenFutarSzabadsagon e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TulNagyCsomagException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e.Message); 
            }

            Console.ReadKey();
        }
    }
}
