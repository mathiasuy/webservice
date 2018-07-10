using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Persistencia;

namespace Logica
{
    public class LEmisor
    {
        //Buscar
        //Alta
        //Baja
        //Modificar
        //Listar
        private static string mensaje = "Emisor";

        public static Emisor BuscarEmisor(int id)
        {
            Emisor a = PEmisor.BuscarEmisor(id);
            if (a == null)
                throw new ExcepcionesPersonalizadas.Logica("No se encontró " + mensaje + ".");
            return a;
        }

        public static void DarAltaEmisor(Emisor a, out int id)
        {
            ValidarEmisor(a);

            if (PEmisor.AltaEmisor(a, out id) == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("El " + mensaje + " ya se encuentra en la BD.");
            }
        }

        public static void DarBajaEmisor(int id)
        {
            int resultado = PEmisor.BajaEmisor(id);
            if (resultado == -1)
                throw new ExcepcionesPersonalizadas.Logica("No se encontró ese " + mensaje + ".");
        }

        public static void ModificarEmisor(Emisor a)
        {
            ValidarEmisor(a);
            
            if (PEmisor.ModificarEmisor(a) == -1)
            {
                throw new ExcepcionesPersonalizadas.Logica("No se encontró el " + mensaje + ".");
            }
            if (PEmisor.ModificarEmisor(a) == -2)
            {
                throw new ExcepcionesPersonalizadas.Logica("Ocurrió un error en el " + mensaje + ".");
            }
        }

        public static List<Emisor> ListarEmisor()
        {
            return PEmisor.ListarEmisor();
        }

        public static void ValidarEmisor(Emisor a)
        {
            
            if (a == null)
            {
                throw new ExcepcionesPersonalizadas.Logica("El " + mensaje + " no tiene asignado un " + mensaje + ".");
            }

            if (string.IsNullOrWhiteSpace(a.Ciudad))
            {
                
                throw new ExcepcionesPersonalizadas.Logica("Debe proporcionar la ciudad del emisor.");
            }

            if (string.IsNullOrWhiteSpace(a.DomFiscal) || string.IsNullOrEmpty(a.DomFiscal))
            {
                throw new ExcepcionesPersonalizadas.Logica("El campo Domicilio Fiscal no debe estar vacío");
            }

            if (string.IsNullOrWhiteSpace(a.Departamento) || string.IsNullOrEmpty(a.Departamento))
            {
                throw new ExcepcionesPersonalizadas.Logica("El campo Departamento no debe estar vacío");
            }

            if (a.RUCEmisor.Documento == "" || a.RUCEmisor.Documento == "")
            {
                throw new ExcepcionesPersonalizadas.Logica("El RUC no debe estar vacío");
            }

            if (string.IsNullOrWhiteSpace(a.RznSoc) || string.IsNullOrEmpty(a.RznSoc))
            {
                throw new ExcepcionesPersonalizadas.Logica("La Razon Social no debe estar vacío");
            }
        }
    }
}
