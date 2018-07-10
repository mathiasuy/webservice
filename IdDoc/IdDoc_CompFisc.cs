using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDoc_CompFisc
    {
        public TipoCFEType tipoCFE { get; set; }
        public SerieType SerieNumero { get; set; }
        public FechaType FchEmis { get; set; }
        public FechaType PeriodoDesde { get; set;}
        public FechaType PeriodoHasta { get; set; }
        public FechaType FchVenc { get; set; }
        public bool MntBruto { get; set; }
        public ModVentaType ModVenta { get; set; }
        public FormasDePagoType FmaPago { get; set; }
        public TipoTrasladoType TipoTraslado { get; set; }
        public string ClauVenta { get; set; }
        public ViaTranspType ViaTransp { get; set; }


        public IdDoc_CompFisc(TipoCFEType TipoCFE, SerieType SerieNumero)
        {
            this.tipoCFE = TipoCFE;
            this.SerieNumero = SerieNumero;
        }

        public IdDoc_CompFisc(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis)
            :this(tipoCFE,SerieNumero)
        {
            this.FchEmis = FchEmis;
        }

        public IdDoc_CompFisc(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, FormasDePagoType FmaPago, FechaType PeriodoDesde, FechaType PeriodoHasta, bool MntBruto, FechaType FchVenc)
            :this(tipoCFE, SerieNumero)
        {
            this.FchEmis = FchEmis; 
            this.PeriodoDesde = PeriodoDesde;
            this.PeriodoHasta = PeriodoHasta;
            this.MntBruto = MntBruto;
            this.FmaPago = FmaPago;
            this.FchVenc = FchVenc;
        }

        public IdDoc_CompFisc(TipoCFEType tipoCFE, SerieType Serie, FechaType FchEmis, FormasDePagoType FmaPago)
            : this(tipoCFE, Serie, FchEmis, FmaPago,null, null, false, null)
        {}

        public IdDoc_CompFisc(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, FechaType PeriodoDesde, FechaType PeriodoHasta, bool MntBruto, FormasDePagoType FmaPago, FechaType FchVenc, string ClauVenta, ModVentaType ModVenta, ViaTranspType ViaTransp)
            : this(tipoCFE, SerieNumero, FchEmis, FmaPago,PeriodoDesde, PeriodoHasta, MntBruto, FchVenc)
        {
            this.ClauVenta = ClauVenta;
            this.ModVenta = ModVenta;
            this.ViaTransp = ViaTransp;
        }

        public IdDoc_CompFisc(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, FechaType PeriodoDesde, FechaType PeriodoHasta, bool MntBruto, FormasDePagoType FmaPago, FechaType FchVenc, string ClauVenta, ViaTranspType ViaTransp)
            : this(tipoCFE, SerieNumero, FchEmis, FmaPago, PeriodoDesde, PeriodoHasta, MntBruto, FchVenc)
        {
            this.ClauVenta = ClauVenta;
            this.ModVenta = null;
            this.ViaTransp = ViaTransp;
        }


        public IdDoc_CompFisc(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, TipoTrasladoType TipoTraslado)
            : this(tipoCFE, SerieNumero)
        {
            this.FchEmis = FchEmis;
            this.TipoTraslado = TipoTraslado;
        }

        public IdDoc_CompFisc(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, TipoTrasladoType TipoTraslado, string ClauVenta, ModVentaType ModVenta, ViaTranspType ViaTrasnp)
            : this(tipoCFE, SerieNumero, FchEmis, TipoTraslado)
        {
            this.ClauVenta = ClauVenta;
            this.ModVenta = ModVenta;
            this.ViaTransp = ViaTrasnp;
        }



        public override string ToString()
        {
            return tipoCFE.ToString() + " " + SerieNumero.ToString() + " " + FchEmis.ToString() + " " + (PeriodoDesde == null ? "" : PeriodoDesde.ToString()) + " " + (PeriodoHasta == null ? "" : PeriodoHasta.ToString()) + " " + MntBruto.ToString() + " " + FmaPago.ToString() + " " + (FchVenc == null ? "" : FchVenc.ToString()) + " " + ClauVenta + " " + (ModVenta == null ? "" : ModVenta.ToString()) + " " + ViaTransp.ToString() + " " +   tipoCFE.ToString() + " " + SerieNumero.ToString() + " " + FchEmis.ToString() + " " + TipoTraslado.ToString() + ClauVenta + " " + ModVenta.ToString() + ViaTransp.ToString() + " " + tipoCFE + " " + SerieNumero + " " + FchEmis;
        }



    }
}
