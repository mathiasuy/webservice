using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LFormasDePago
    {
        //Buscar
        private static string mensaje = "Forma de Pago";

        public static FormasDePagoType BuscarFormaDePago(int id)
        {
            FormasDePagoType a = Persistencia.PFormasDePago.BuscarFormasDePago(id);
            if (a == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró esa forma de pago");
            }
            return a;
        }
        //Alta
        public static void AltaFormasDePago(FormasDePagoType f) 
        {
            ValidarFormasDePago(f);
            int resultado = PFormasDePago.AltaFormasDePago(f);

            if (resultado == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("Ya existe una forma de pago con ese identificador en la BD");
            }
            if (resultado == -3)
            {
                throw new ExcepcionesPersonalizadas.Logica("Ya existe una forma de pago con ese nombre en la BD");
            }
        }
        //Baja
        public static void BajaFormasDePago(int Id)
        {
            int retorno = PFormasDePago.BajaFormasDePago(Id);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No existe una forma de pago con ese Id");
            } if (retorno == -3)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se ha podido borrar, ¿la forma de pago está en uso?");
            }
        }

        //Modificar
        public static void ModificarFormasDePago(FormasDePagoType f)
        {
            ValidarFormasDePago(f);
            int retorno = PFormasDePago.ModificarFormasDePago(f);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No hay una forma de pago con ese identificador en la BD");
            }
        }

        //Listar
        public static List<FormasDePagoType> ListarFormasDePago()
        {
            List<FormasDePagoType> retorno =  PFormasDePago.ListarFormasDePago();
            if (retorno == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontraron formas de pago para listar");
            }
            return retorno;
        }

        public static void ValidarFormasDePago(FormasDePagoType f)
        {
            if (f == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar una forma de pago");
            }

            if (f.Habilitado)
            {
                throw new ExcepcionesPersonalizadas.Logica("La forma de pago está Habilitada!");
            }

            if (string.IsNullOrWhiteSpace(f.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un Id para la forma de pago");
            }

            if (string.IsNullOrEmpty(f.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un Id para la forma de pago");
            }

            if (string.IsNullOrEmpty(f.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un nombre  para la forma de pago");
            }

            if (string.IsNullOrWhiteSpace(f.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un nombre válido para la fomra de pago");
            }
        }

    }
}
