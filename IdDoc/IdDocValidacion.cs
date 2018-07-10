using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace IdDoc
{
    public class IdDocValidacion
    {
        public static void ValidarIdDoc_Fact(IdDoc.IdDoc_Fact d)
        {
            if (!(d.FmaPago == null))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la forma de pago");
            }
            if (d.FchEmis == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Fecha de emisión");
            }
            if (d.SerieNumero == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar el número de serie");
            }
        }

        public static void ValidarIdDoc_Fact_Exp(IdDoc.IdDoc_Fact_Exp d)
        {
            if (!(d.FmaPago == null))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la forma de pago");
            }
            if (d.FchEmis == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Fecha de emisión");
            }
            if (d.SerieNumero == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar el número de serie");
            }
            if (string.IsNullOrEmpty(d.ClauVenta) || string.IsNullOrWhiteSpace(d.ClauVenta))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Clausula de venta");
            }
            if (d.ViaTransp == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Via de transporte");
            }
        }

        public static void ValidarIdDoc_Rem(IdDoc.IdDoc_Rem d)
        {
            if (d.FchEmis == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Fecha de emisión");
            }
            if (d.SerieNumero == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar el número de serie");
            }
            if (d.TipoTraslado == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Via de transporte");
            }
        }

        public static void ValidarIdDoc_Rem_Exp(IdDoc.IdDoc_Rem_Exp d)
        {
            if (!(d.TipoTraslado == null))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar el tipo de traslado");
            }
            if (d.FchEmis == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Fecha de emisión");
            }
            if (d.SerieNumero == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar el número de serie");
            }
            if (string.IsNullOrEmpty(d.ClauVenta) || string.IsNullOrWhiteSpace(d.ClauVenta))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Clausula de venta");
            }
            if (d.ModVenta == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Modalidad de venta");
            }
            if (d.ViaTrasnp == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Via de transporte");
            }
        }

        public static void ValidarIdDoc_Resg(IdDoc.IdDoc_Resg d)
        {
            if (d.FchEmis == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Fecha de emisión");
            }
            if (d.SerieNumero == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar el número de serie");
            }
        }

        public static void ValidarIdDoc_Tck(IdDoc.IdDoc_Tck d)
        {
            if (!(d.FchEmis == null))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Fecha de emisión");
            }
            if (d.SerieNumero == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar el número de serie");
            }
            if (d.FmaPago == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar la Via de transporte");
            }
        }
    }
}
