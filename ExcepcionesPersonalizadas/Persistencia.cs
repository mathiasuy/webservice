using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPersonalizadas
{
    public class Persistencia : Sistema
    {
            public Persistencia()
            {
            }

            public Persistencia(string mensaje)
                :base(mensaje)
            {
            }
    }
}
