using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    internal class TulNagyCsomagException :Exception
    {
        public TulNagyCsomagException(Kuldemeny csomag) : base($"Túl nagy a {csomag.csomagszam} csomagszámú csomag tömege.\nA tömeg: {csomag.Tomeg} ")
        { 

        }
    }
    internal class MindenFutarSzabadsagon : Exception
    {
        public MindenFutarSzabadsagon() : base($"Minden futár szabadságon van") 
        {
            
        }
    }
    internal class NemMegfeleloTipusException : Exception
    {
        public NemMegfeleloTipusException() : base($"Nem megfelelo tipus. Válassz a lehetőségek közül.")
        {

        }
    }
}
