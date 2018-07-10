using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LProductoServicio
    {
        //Buscar
        public static ProductoServicio BuscarProductoServicio(string id)
        {
            ProductoServicio r = PProductoServicio.BuscarProductoServicio(id);
            if (r == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el producto o servicio  en la base de datos");
            }
            return r;
        }

        //Alta
        public static void AltaPais(ProductoServicio p)
        {
            ValidarProductoServicio(p);
            int r = PProductoServicio.AltaProductoServicio(p);
            vresp("alta", r);
        }
        //Baja
        public static void BajaProductoServicio(string id)
        {
            int r = PProductoServicio.BajaProductoServicio(id);
            vresp("baja", r);
        }
        //Modificar
        public static void ModificarPais(ProductoServicio p)
        {
            ValidarProductoServicio(p);
            int r = PProductoServicio.ModificarProductoServicio(p);
            vresp("modificar", r);
        }


        //Listar
        public static List<ProductoServicio> ListarProductoServicio()
        {
            List<ProductoServicio> l = PProductoServicio.ListarProductoServicio();
            if (l == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No hay productos o servicios para listar");
            }
            return l;
        }

        public static void vresp(string accion, int r)
        {
            if (r == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de " + accion + " el producto o servicio, ya hay uno con ese identificador en la base de datos");
            }
        }

        public static void ValidarProductoServicio(ProductoServicio p)
        {
            if (p == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un Prodcto o servicio válido.");
            }
            if (string.IsNullOrWhiteSpace(p.Nombre) || string.IsNullOrEmpty(p.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un nombre para el Prodcuto o servicio");
            }
            if (string.IsNullOrWhiteSpace(p.Precio.ToString()) || string.IsNullOrEmpty(p.Precio.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un precio para el producto o servicio");
            }
        }
    }
}
