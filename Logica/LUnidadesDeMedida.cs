using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LUnidadesDeMedida
    {
        //Buscar
        public static UnidadesDeMedida BuscarUnidadDeMedida(int id)
        {
            UnidadesDeMedida m = PUnidadesDeMedida.BuscarUnidadDeMedida(id);
            if (m == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontraron Unidades de medida con ese identificador");
            }
            return m;
        }
        //Alta
        public static void AltaUnidadDeMedida(UnidadesDeMedida i, out int id)
        {
            ValidarUnidadDeMedida(i);
            int retorno = PUnidadesDeMedida.AltaUnidadDeMedida(i, out id);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de alta la unidad de medida, ya hay uno con el mismo identificador");
            }
        }
        //Baja
        public static void BajaUnidadDeMedida(int id)
        {
            int retorno = PUnidadesDeMedida.BajaUnidadDeMedida(id);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró una unidad de medida con ese identificador");
            }
        }
        //Modificar
        public static void ModificarUnidadDeMedida(UnidadesDeMedida i)
        {
            ValidarUnidadDeMedida(i);
            int retorno = PUnidadesDeMedida.ModificarUnidadDeMedida(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró una unidad de medida con ese identificador");
            }
        }

        public static List<UnidadesDeMedida> ListarUnidadesDeMedida()
        {
            List<UnidadesDeMedida> lista = PUnidadesDeMedida.ListarUnidadesDeMedida();
            if (lista == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se han encontrado unidades de medida para listar");
            }
            return lista;
        }
        //Listar

        public static void ValidarUnidadDeMedida(UnidadesDeMedida i)
        {
            if (i == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es una unidad de medida válida");
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
