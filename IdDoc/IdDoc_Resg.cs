using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDoc_Resg : IdDoc_CompFisc
    {
        public FechaType FchEmis { get; set; }

        public IdDoc_Resg(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis)
            :base(tipoCFE,SerieNumero)
        {
            this.FchEmis = FchEmis;
        }

        public override string ToString()
        {
            return base.ToString() + " " + tipoCFE + " " + SerieNumero + " " + FchEmis;
        }


    }
}
