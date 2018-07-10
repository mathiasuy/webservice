using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPersonalizadas
{
    public class Presentacion : Sistema
    {
        public Presentacion()
        {
        }

        public Presentacion(string mensaje)
            :base(mensaje)
        {
            
        }
    }
}
