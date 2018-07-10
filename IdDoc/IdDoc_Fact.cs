using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDoc_Fact : IdDoc_CompFisc
    {
        public FechaType FchEmis { get; set; }
        public FechaType PeriodoDesde { get; set;}
        public FechaType PeriodoHasta { get; set; }
        public bool MntBruto { get; set; }
        public FormasDePagoType FmaPago { get; set; }
        public FechaType FchVenc { get; set; }

        public IdDoc_Fact(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, FormasDePagoType FmaPago, FechaType PeriodoDesde, FechaType PeriodoHasta, bool MntBruto, FechaType FchVenc)
            : base(tipoCFE, SerieNumero)
        {
            this.FchEmis = FchEmis; 
            this.PeriodoDesde = PeriodoDesde;
            this.PeriodoHasta = PeriodoHasta;
            this.MntBruto = MntBruto;
            this.FmaPago = FmaPago;
            this.FchVenc = FchVenc;
        }

        public IdDoc_Fact(TipoCFEType tipoCFE, SerieType Serie, FechaType FchEmis, FormasDePagoType FmaPago)
            : this(tipoCFE, Serie, FchEmis, FmaPago,null, null, false, null)
        {}

        public override string ToString()
        {
            return tipoCFE.ToString() + " " + SerieNumero.ToString() + " " + FchEmis.ToString() + " " + (PeriodoDesde == null ? "" : PeriodoDesde.ToString()) + " " + (PeriodoHasta == null ? "" : PeriodoHasta.ToString()) + " " + MntBruto.ToString() + " " + FmaPago.ToString() + " " + (FchVenc == null ? "" : FchVenc.ToString());
        }
    }
}
