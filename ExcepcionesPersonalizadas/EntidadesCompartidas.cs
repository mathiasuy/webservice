using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPersonalizadas
{
    public class EntidadesCompartidas : Sistema
    {
            public EntidadesCompartidas()
            {
            }

            public EntidadesCompartidas(string mensaje)
                : base(mensaje)
            {
            }
    }
}
