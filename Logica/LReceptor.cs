using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;
using Receptores;

namespace Logica
{
    public class LReceptor
    {
        //Buscar
        //Alta
        //Baja
        //Modificar
        //Listar
        private static string mensaje = "Receptor";

        public static Receptor BuscarReceptor(int id)
        {
            Receptor a = PReceptor.BuscarReceptor(id);
            if (a == null)
                throw new ExcepcionesPersonalizadas.Logica("No se encontró " + mensaje + ".");
            return a;
        }

        public static void DarAltaReceptor(Receptor a, out int id)
        {
            ValidarReceptor(a);

            if (PReceptor.AltaReceptor(a, out id) == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("El " + mensaje + " ya se encuentra en la BD.");
            }
        }

        public static void DarBajaReceptor(int id)
        {
            int resultado = PReceptor.BajaReceptor(id);
            if (resultado == -1)
                throw new ExcepcionesPersonalizadas.Logica("No se encontró ese " + mensaje + ".");
        }

        public static void ModificarReceptor(Receptor a)
        {
            ValidarReceptor(a);

            if (PReceptor.ModificarReceptor(a) == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el " + mensaje + ".");
            }
        }

        public static List<Receptor> ListarReceptor()
        {
            return PReceptor.ListarReceptores();
        }

        public static void ValidarReceptor(Receptor a)
        {
            if (string.IsNullOrEmpty(a.DocRecep.Documento) || string.IsNullOrWhiteSpace(a.DocRecep.Documento))
            {
                throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Documento y Tipo de documento del receptor");
            }
            if (a == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("El " + mensaje + " no tiene asignado un " + mensaje + ".");
            }
            ReceptorValidacion.ValidarReceptor(a);
        }
    }
}
