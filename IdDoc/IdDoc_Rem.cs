using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDoc_Rem : IdDoc_CompFisc
    {
        public FechaType FchEmis { get; set; }
        public TipoTrasladoType TipoTraslado { get; set; }

        public IdDoc_Rem(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, TipoTrasladoType TipoTraslado)
            :base(tipoCFE,SerieNumero)
        {
            this.FchEmis = FchEmis;
            this.TipoTraslado = TipoTraslado;
        }

        public override string ToString()
        {
            return base.ToString() + " " +   tipoCFE.ToString() + " " + SerieNumero.ToString() + " " + FchEmis.ToString() + " " + TipoTraslado.ToString();
        }

    }
}
