using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDoc_Rem_Exp : IdDoc_Rem
    {

        public string ClauVenta { get; set; }
        public ModVentaType ModVenta { get; set; }
        public ViaTranspType ViaTrasnp { get; set; }

        public IdDoc_Rem_Exp(TipoCFEType tipoCFE, SerieType SerieNumero, FechaType FchEmis, TipoTrasladoType TipoTraslado, string ClauVenta, ModVentaType ModVenta, ViaTranspType ViaTrasnp)
        :base(tipoCFE,SerieNumero,FchEmis,TipoTraslado)
        {
            this.ClauVenta = ClauVenta;
            this.ModVenta = ModVenta;
            this.ViaTrasnp = ViaTrasnp;
        }


        public override string ToString()
        {
            return base.ToString() + ClauVenta + " " + ModVenta.ToString() + ViaTrasnp.ToString();
        }
    }
}
