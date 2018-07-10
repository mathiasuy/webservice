using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPersonalizadas
{
    public class Logica : Sistema
    {
        public Logica()
        {
        }

        public Logica(string mensaje)
            :base(mensaje)
        {
        }
    }
}
