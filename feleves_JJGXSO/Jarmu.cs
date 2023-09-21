using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    internal class Jarmu
    {
        public int SzalithatoTomeg { get; set; }

    }
    internal class Minibus : Jarmu
    {
        public Minibus()
        {
            SzalithatoTomeg = 10;
        }
    }

    internal class Transit : Jarmu
    {
        public Transit()
        {
            SzalithatoTomeg = 20;
        }
    }

    internal class Kamion : Jarmu
    {
        public Kamion()
        {
            SzalithatoTomeg = 30;
        }
    }
}
