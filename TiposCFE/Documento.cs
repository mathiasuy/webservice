using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace TiposCFE
{
    public class Documento 
    {
        public int TipoCFE {get; set;}
        private FechaType _fecha = new FechaType(DateTime.Today);
        
        

        public string FechaEmision 
        {
            get
            {
                return _fecha.FechaTHora;
            }
            set
            {
                _fecha.Fecha = DateTime.Today;
            }
        }
        public int MntBruto { get; set; }



    }
}
