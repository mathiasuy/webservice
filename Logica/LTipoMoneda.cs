using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LTipoMoneda
    {
        //Buscar
        public static TipoMoneda BuscarTipoMoneda(string id)
        {
            TipoMoneda r = PTipoMoneda.BuscarTipoMoneda(id);
            if (r == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el tipo de moneda  en la base de datos");
            }
            return r;
        }

        //Alta
        public static void AltaTipoMoneda(TipoMoneda p)
        {
            ValidarTipoMoneda(p);
            int r = PTipoMoneda.AltaTipoMoneda(p);
            vresp("alta", r);
        }
        //Baja
        public static void BajaTipoMoneda(string id)
        {
            int r = PTipoMoneda.BajaTipoMoneda(id);
            vresp("baja", r);
        }
        //Modificar
        public static void ModificarTipoMoneda(TipoMoneda p)
        {
            ValidarTipoMoneda(p);
            int r = PTipoMoneda.ModificarTipoMoneda(p);
            vresp("modificar", r);
        }


        //Listar
        public static List<TipoMoneda> ListarTipoMoneda()
        {
            List<TipoMoneda> l = PTipoMoneda.ListarTipoMoneda();
            if (l == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No hay tipos de moneda para listar");
            }
            return l;
        }

        public static void vresp(string accion, int r)
        {
            if (r == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de " + accion + " el tipo de moneda, ya hay una con ese identificador en la base de datos");
            }
        }

        public static void ValidarTipoMoneda(TipoMoneda p)
        {
            if (p == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un tipo de moneda válido.");
            }
            if (string.IsNullOrWhiteSpace(p.Nombre) || string.IsNullOrEmpty(p.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un nombre para el tipo de moneda");
            }
            if (string.IsNullOrWhiteSpace(p.Id.ToString()) || string.IsNullOrEmpty(p.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un identificador para el tipo de moneda");
            }
            if (p.Cambio == 0 || p.Cambio < 0)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un cambio mayor que 0");
            }
            if (string.IsNullOrEmpty(p.Simbolo) || string.IsNullOrWhiteSpace(p.Simbolo))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un s{imbolo para la moneda");
            }
        }
    }
}
