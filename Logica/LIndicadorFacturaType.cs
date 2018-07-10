using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LIndicadorFacturaType
    {
        //Buscar
        public static IndicadorFacturaType BuscarIndicadorFactura(int id)
        {
            IndicadorFacturaType retorno  = PIndicadorFacturaType.BuscarIndicadorFacturaType(id);
            if (retorno == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el indicador de facturación");
            }
            return retorno;
        }

        //Alta
        public static void AltaIndicadorFactura(IndicadorFacturaType i)
        {
            ValidarIndicadorFactura(i);
            int retorno = PIndicadorFacturaType.AltaIndicadorFacturaType(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("Ya hay un indicador con ese identificador");
            }
        }

        public static void BajaIndicadorFactura(int id)
        {
            int retorno = PIndicadorFacturaType.BajaIndicadorFacturaType(id);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró ese indicador de facturación");
            }
        }

        public static void ModificarIndicadorFactura(IndicadorFacturaType i)
        {
            ValidarIndicadorFactura(i);
            int retorno = PIndicadorFacturaType.ModificarIndicadorFacturaType(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se ha podido modificar, no existe un indicador de factura con es eidentificador");
            }
        }

        public static List<IndicadorFacturaType> ListarIndicadorFactura()
        {
            List<IndicadorFacturaType> l = PIndicadorFacturaType.ListarIndicadorFacturaType();
            if (l == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontraron indicadores de facturación para listar");
            }
            return l;
        }

        public static void ValidarIndicadorFactura(IndicadorFacturaType i)
        {
            if (i == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un indicador de facturación válido.");
            }

            if (i.Habilitado)
            {
                throw new ExcepcionesPersonalizadas.Logica("El indicador de facturación está deshabilitado");
            }

            if (string.IsNullOrWhiteSpace(i.Nombre) || string .IsNullOrEmpty(i.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("El nombre del indicador de facturación no puede quedar vacío");
            }

            if (string.IsNullOrWhiteSpace(i.Id.ToString()) || string.IsNullOrEmpty(i.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("El nombre del indicador de facturación no puede quedar vacío");
            }
        }
        //Baja
        //Modificar
        //Listar
    }
}
