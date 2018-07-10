using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LTipoCFEType
    {
        //Buscar
        public static TipoCFEType BuscarTipoCFE(int id)
        {
            TipoCFEType r = PTipoCFEType.BuscarTipoCFEType(id);
            if (r == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el tipo de CFE  en la base de datos");
            }
            return r;
        }

        //Alta
        public static void AltaTipoCFE(TipoCFEType p)
        {
            ValidarTipoCFE(p);
            int r = PTipoCFEType.AltaTipoCFEType(p);
            vresp("alta", r);
        }
        //Baja
        public static void BajaTipoCFE(int id)
        {
            int r = PTipoCFEType.BajaTipoCFEType(id);
            vresp("baja", r);
        }
        //Modificar
        public static void ModificarPais(TipoCFEType p)
        {
            ValidarTipoCFE(p);
            int r = PTipoCFEType.ModificarTipoCFEType(p);
            vresp("modificar", r);
        }


        //Listar
        public static List<TipoCFEType> ListarTipoCFE()
        {
            List<TipoCFEType> l = PTipoCFEType.ListarTipoCFEType();
            if (l == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No hay tipos de CFE para listar");
            }
            return l;
        }

        public static void vresp(string accion, int r)
        {
            if (r == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de " + accion + " el tipo de CFE, ya hay uno con ese identificador en la base de datos");
            }
        }

        public static void ValidarTipoCFE(TipoCFEType p)
        {
            if (p == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un tipo de CFE válido.");
            }
            if (string.IsNullOrWhiteSpace(p.Nombre) || string.IsNullOrEmpty(p.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un nombre para el tipo de CFE");
            }
            if (string.IsNullOrWhiteSpace(p.Id.ToString()) || string.IsNullOrEmpty(p.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un identificador para el tipo de CFE");
            }
            if (string.IsNullOrWhiteSpace(p.IdNombre.ToString()) || string.IsNullOrEmpty(p.IdNombre.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un identificador para el XML del CFE");
            }
        }
    }
}
