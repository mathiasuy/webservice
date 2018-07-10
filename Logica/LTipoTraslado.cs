using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LTipoTraslado
    {
        //Buscar
        public static TipoTrasladoType BuscarTipoTraslado(int id)
        {
            TipoTrasladoType iva = PTipoTraslado.BuscarTipoTraslado(id);
            if (iva == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontraron tipos de traslado con ese identificador");
            }
            return iva;
        }
        //Alta
        public static void AltaTipoTraslado(TipoTrasladoType i)
        {
            ValidarTipoTraslado(i);
            int retorno = PTipoTraslado.AltaTipoTraslado(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se pudo dar de alta el tipo de traslado, ya hay uno con el mismo identificador");
            }
        }
        //Baja
        public static void BajaTipoTraslado(int id)
        {
            int retorno = PTipoTraslado.BajaTipoTraslado(id);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró un tipo de traslado con ese identificador");
            }
        }
        //Modificar
        public static void ModificarTipoTraslado(TipoTrasladoType i)
        {
            ValidarTipoTraslado(i);
            int retorno = PTipoTraslado.ModificarTipoTraslado(i);
            if (retorno == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró un tipo de traslado con ese identificador");
            }
        }

        public static List<TipoTrasladoType> ListarTipoTraslado()
        {
            List<TipoTrasladoType> lista = PTipoTraslado.ListarTipoTraslado();
            if (lista == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se han encontrado tipos de traslado para listar");
            }
            return lista;
        }
        //Listar

        public static void ValidarTipoTraslado(TipoTrasladoType i)
        {
            if (i == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("No es un tipo de traslado válido");
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
