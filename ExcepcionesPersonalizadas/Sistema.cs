using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPersonalizadas
{
    public class Sistema : ApplicationException
    {
        public Sistema()
        {
        }

        public Sistema(string mensaje)
            : base(mensaje)
        {
        }
    }
}
