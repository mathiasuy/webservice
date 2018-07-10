using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LPaisType
    {
        //Buscar
        public static PaisType BuscarPais(string id)
        {
            PaisType r = PPaisType.BuscarPaisType(id);
            if (r == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el país  en la base de datos");
            }
            return r;
        }

        //Alta
        public static void AltaPais(PaisType p)
        {
            ValidarPais(p);
            int r = PPaisType.AltaPaisType(p);
            vresp("alta", r);
        }
        //Baja
        public static void BajaPais(string id)
        {
            int r = PPaisType.BajaPaisType(id);
            vresp("baja", r);
        }
        //Modificar
        public static void ModificarPais(PaisType p)
        {
            ValidarPais(p);
            int r = PPaisType.ModificarPaisType(p);
            vresp("modificar", r);
        }


        //Listar
        public static List<PaisType> ListarPaises()
        {
            List<PaisType> l = PPaisType.ListarPaisType();
            if (l == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No hay países para listar");
            }
            return l;
        }

        public static void vresp(string accion, int r)
        {
            if (r == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de " + accion + " el país, ya hay un País con ese identificador en la base de datos");
            }
        }

        public static void ValidarPais(PaisType p)
        {
            if (p == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un país válido.");
            }
            if (string.IsNullOrWhiteSpace(p.Nombre) || string.IsNullOrEmpty(p.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un nombre para el pais");
            }
            if (string.IsNullOrWhiteSpace(p.Id) || string.IsNullOrEmpty(p.Id))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un identificador para el pais de hasta 4 caracteres");
            }
        }
    }
}
