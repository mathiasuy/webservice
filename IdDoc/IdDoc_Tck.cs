using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDoc_Tck : IdDoc_Fact
    {
        public IdDoc_Tck(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, FechaType PeriodoDesde, FechaType PeriodoHasta, bool MntBruto, FormasDePagoType FmaPago, FechaType FchVenc)
            : base(tipoCFE, SerieNumero, FchEmis, FmaPago, PeriodoDesde, PeriodoHasta, MntBruto, FchVenc)
        {
        }

    }
}
