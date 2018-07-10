using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LIVAType
    {
        //Buscar
        public static IVAType BuscarIVA(int id)
        {
            IVAType iva = PIVAType.BuscarIVAType(id);
            if (iva == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontraron IVAs con ese identificador");
            }
            return iva;
        }
        //Alta
        public static void AltaIVA(IVAType i)
        {
            ValidarIVA(i);
            int retorno = PIVAType.AltaIVAType(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de alta el IVA, ya hay uno con el mismo identificador");
            }
       }
        //Baja
        public static void BajaIVA(int id)
        {
            int retorno = PIVAType.BajaIVAType(id);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró un IVA con ese identificador");
            }
        }
        //Modificar
        public static void ModificarIVA(IVAType i)
        {
            ValidarIVA(i);
            int retorno = PIVAType.ModificarIVAType(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró un IVA con ese identificador");
            }
        }

        public static List<IVAType> ListarIVAs()
        {
            List<IVAType> lista = PIVAType.ListarIVAType();
            if (lista == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se han encontrado IVAs para listar");
            }
            return lista;
        }
        //Listar

        public static void ValidarIVA(IVAType i)
        {
            if (i == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un IVA válido");
            }
            if (string.IsNullOrEmpty(i.Id.ToString()) || string.IsNullOrWhiteSpace(i.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un identificador");
            }
            if (string.IsNullOrWhiteSpace(i.Nombre) || string.IsNullOrEmpty(i.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un Nombre");
            }
            if (i.Valor == 0)
            {
                throw new ExcepcionesPersonalizadas.Logica("No Debe indicar un valor nulo para el iva ¿Quiere deshabilitarlo?");
            }
            if (string.IsNullOrEmpty(i.Valor.ToString()) || string.IsNullOrWhiteSpace(i.Valor.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicarle un valor al iva.");
            }
        }
    }
}
