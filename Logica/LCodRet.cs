using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LCodRet
    {
        //Buscar
        //Alta
        //Baja
        //Modificar
        //Listar

        private static string mensaje = "Código de Retención";

        public static CodRetType BuscarCodRet(string id)
        {
            CodRetType a = PCodRet.BuscarCodRetType(id);
            if (a == null)
                throw new ExcepcionesPersonalizadas.Logica("No se encontró " + mensaje + ".");
            return a;
        }

        public static void DarAltaCodRet(CodRetType a)
        {
            ValidarCodRet(a);

              if (PCodRet.AltaCodRetType(a) == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("El " + mensaje + " ya se encuentra en la BD.");
            }
        }

        public static void DarBajaCodRet(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ExcepcionesPersonalizadas.Logica("Olvidó el " + mensaje + ".");
            }
            int resultado = PCodRet.BajaCodRetType(id);
            if (resultado == -1)
                throw new ExcepcionesPersonalizadas.Logica("No se encontró ese " + mensaje + ".");
        }

        public static void ModificarCodRet(CodRetType a)
        {
            ValidarCodRet(a);
            if (string.IsNullOrWhiteSpace(a.Id))
            {
                throw new ExcepcionesPersonalizadas.Logica("Olvidó el " + mensaje + ".");
            }
            if (PCodRet.ModificarCodRetType(a) == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el " + mensaje + ".");
            }
        }

        public static List<CodRetType> ListarCodRet()
        {
            return PCodRet.ListarCodRetType();
        }

        public static void ValidarCodRet(CodRetType a)
        {
            if (a == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("El " + mensaje + " no tiene asignado un " + mensaje + ".");
            }


            if (string.IsNullOrWhiteSpace(a.Id))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe proporcionar un " + mensaje + ".");
            }

        }

    }
}
