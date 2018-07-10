using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LTipoDocumentoType
    {
        //Buscar
        public static TipoDocumentoType BuscarTipoDocumento(int id)
        {
            TipoDocumentoType a = PTipoDocumentoType.BuscarTipoDocumento(id);
            if (a == null)
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el Tipo de documento.");
            return a;
        }


        //Alta
        public static void AltaTipoDocumento(TipoDocumentoType p)
        {
            ValidarTipoDocumento(p);
            int r = PTipoDocumentoType.AltaTipoDocumento(p);
            vresp("alta", r);
        }
        //Baja
        public static void BajaTipoDocumento(int id)
        {
            int r = PTipoDocumentoType.BajaTipoDocumento(id);
            vresp("baja", r);
        }
        //Modificar
        public static void ModificarTipoDocumento(TipoDocumentoType p)
        {
            ValidarTipoDocumento(p);
            int r = PTipoDocumentoType.ModificarTipoDocumento(p);
            vresp("modificar", r);
        }


        //Listar
        public static List<TipoDocumentoType> ListarTipoDocumento()
        {
            List<TipoDocumentoType> l = PTipoDocumentoType.ListarTipoDocumentoType();
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
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de " + accion + " el tipo de documento, ya hay uno con ese identificador en la base de datos");
            }
        }

        public static void ValidarTipoDocumento(TipoDocumentoType p)
        {
            if (p == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un tipo de documento válido.");
            }
            if (string.IsNullOrWhiteSpace(p.Nombre) || string.IsNullOrEmpty(p.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un nombre para el tipo de documento");
            }
            if (string.IsNullOrWhiteSpace(p.Id.ToString()) || string.IsNullOrEmpty(p.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un identificador para el tipo de documento");
            }
        }

    }
}
