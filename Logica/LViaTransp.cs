using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LViaTransp
    {
        //Buscar
        public static ViaTranspType BuscarViaTransp(int id)
        {
            ViaTranspType iva = PViaTransp.BuscarViaTransp(id);
            if (iva == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontraron Vias de transporte con ese identificador");
            }
            return iva;
        }
        //Alta
        public static void AltaViaTransp(ViaTranspType i)
        {
            ValidarViaTransp(i);
            int retorno = PViaTransp.AltaViaTransp(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de alta la Via de transporte, ya hay uno con el mismo identificador");
            }
        }
        //Baja
        public static void BajaViaTransp(int id)
        {
            int retorno = PViaTransp.BajaViaTransp(id);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró una Via de transporte con ese identificador");
            }
        }
        //Modificar
        public static void ModificarViaTransp(ViaTranspType i)
        {
            ValidarViaTransp(i);
            int retorno = PViaTransp.ModificarViaTransp(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró una Via de transporte con ese identificador");
            }
        }

        public static List<ViaTranspType> ListarViaTransp()
        {
            List<ViaTranspType> lista = PViaTransp.ListarViaTransp();
            if (lista == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se han encontrado Vias de transporte para listar");
            }
            return lista;
        }
        //Listar

        public static void ValidarViaTransp(ViaTranspType i)
        {
            if (i == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es una Via de transporte válido");
            }
            if (string.IsNullOrEmpty(i.Id.ToString()) || string.IsNullOrWhiteSpace(i.Id.ToString()))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un identificador");
            }
            if (string.IsNullOrWhiteSpace(i.Nombre) || string.IsNullOrEmpty(i.Nombre))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe indicar un Nombre");
            }
        }
    }
}
