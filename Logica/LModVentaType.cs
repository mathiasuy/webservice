using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LModVentaType
    {
        //Buscar
        public static ModVentaType BuscarModVenta(int id)
        {
            ModVentaType retorno = PModVentaType.BuscarModVentaType(id);
            if (retorno == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró esa modalidad de venta");
            }
            return retorno;
        }
        //Alta
        public static void AltaModVenta(ModVentaType m)
        {
            ValidarModVentaType(m);
            int e = PModVentaType.AltaModVentaType(m);
            if (e == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("Ya hay una modalidad de venta con ese identificador");
            }
            if (e == -3)
            {
                throw new ExcepcionesPersonalizadas.Logica("Ya hay una modalidad de venta con ese nombre");
            }
        }

        public static void BajaModVenta(int id)
        {
            int r = PModVentaType.BajaModVentaType(id);
            if (r == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No hay una modalidad de venta con ese id");
            }
        }

        public static void ModificarModVenta(ModVentaType m)
        {
            int r = PModVentaType.ModificarModVentaType(m);
            if (r == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No existe una modalidad de venta con ese identificador");
            }
        }

        public static List<ModVentaType> ListarModVenta()
        {
            List<ModVentaType> r = PModVentaType.ListarModVentaType();
            if (r == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo listar las modalidades de venta");
            }
            return r;
        }

        public static void ValidarModVentaType(ModVentaType m)
        {
            if (m == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es una modalidad de venta válida");
            }
            //if (!m.Habilitado)
            //{
            //    throw new ExcepcionesPersonalizadas.Logica("No está habilitada esa modalidad de venta");
            //}
            if (string.IsNullOrEmpty(m.Nombre.ToString()) || string.IsNullOrWhiteSpace(m.Nombre.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un Id Válido");
            }

        }
        //Baja
        //Modificar
        //Listar
    }
}
