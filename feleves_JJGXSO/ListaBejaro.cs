using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_JJGXSO
{
    internal class ListaBejaro : IEnumerator
    {
        Kuldemeny fej;
        Kuldemeny aktualis;
        public ListaBejaro(Kuldemeny fej)
        {
            this.fej = fej;
            aktualis = new Kuldemeny();
            aktualis.Kovetkezo = fej;
        }
        public object Current
        {
            get
            {
                return aktualis;
            }
        }

        public bool MoveNext()
        {
            aktualis = aktualis.Kovetkezo;
            return aktualis != null;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
