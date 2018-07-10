using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDoc_Fact_Exp : IdDoc_Fact
    {
        public string ClauVenta { get; set; }
        public ModVentaType ModVenta { get; set; }
        public ViaTranspType ViaTransp { get; set; }

        public IdDoc_Fact_Exp(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, FechaType PeriodoDesde, FechaType PeriodoHasta, bool MntBruto, FormasDePagoType FmaPago, FechaType FchVenc, string ClauVenta, ModVentaType ModVenta, ViaTranspType ViaTransp)
            : base(tipoCFE, SerieNumero, FchEmis, FmaPago,PeriodoDesde, PeriodoHasta, MntBruto, FchVenc)
        {
            this.ClauVenta = ClauVenta;
            this.ModVenta = ModVenta;
            this.ViaTransp = ViaTransp;
        }

        public IdDoc_Fact_Exp(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, FechaType PeriodoDesde, FechaType PeriodoHasta, bool MntBruto, FormasDePagoType FmaPago, FechaType FchVenc, string ClauVenta, ViaTranspType ViaTransp)
            : base(tipoCFE, SerieNumero, FchEmis, FmaPago, PeriodoDesde, PeriodoHasta, MntBruto, FchVenc)
        {
            this.ClauVenta = ClauVenta;
            this.ModVenta = null;
            this.ViaTransp = ViaTransp;
        }

        public override string ToString()
        {
            return base.ToString() + " " + ClauVenta + " " + (ModVenta == null ? "" : ModVenta.ToString()) + " " + ViaTransp.ToString();
        }
    }
}
