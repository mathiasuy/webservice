using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Receptores;
using EntidadesCompartidas;

namespace Logica
{
    public class ReceptorValidacion
    {
        public static void ValidarReceptor(Receptor r)
        {
            if (r is Receptor_Fact)
            {
                if (string.IsNullOrEmpty(r.DocRecep.Documento) || string.IsNullOrWhiteSpace(r.DocRecep.Documento))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Documento y Tipo de documento del receptor");
                }
                if (r.PaisRecep == null)
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe indicar el país del receptor");
                }
                if (string.IsNullOrEmpty(r.RznSocRecep) || string.IsNullOrWhiteSpace(r.RznSocRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Razón Social del receptor");
                }
                if (string.IsNullOrEmpty(r.DirRecep) || string.IsNullOrWhiteSpace(r.DirRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Dirección del Receptor");
                }
                if (string.IsNullOrEmpty(r.CiudadRecep) || string.IsNullOrWhiteSpace(r.CiudadRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Ciudad del Receptor");
                }
            }
            else if (r is Receptor_Fact_Exp)
            {
                if (r.PaisRecep == null)
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe indicar el país del receptor");
                }
                if (string.IsNullOrEmpty(r.RznSocRecep) || string.IsNullOrWhiteSpace(r.RznSocRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Razón Social del receptor");
                }
                if (string.IsNullOrEmpty(r.DirRecep) || string.IsNullOrWhiteSpace(r.DirRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Dirección del Receptor");
                }
                if (string.IsNullOrEmpty(r.CiudadRecep) || string.IsNullOrWhiteSpace(r.CiudadRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Ciudad del Receptor");
                }
                if (string.IsNullOrEmpty(r.DeptoRecep) || string.IsNullOrWhiteSpace(r.DeptoRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Departamento del Receptor");
                }
                if (r.PaisRecep == null)
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo País del Receptor");
                }
                if (string.IsNullOrEmpty(r.CP) || string.IsNullOrWhiteSpace(r.CP))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo CP del Receptor");
                }
            }
            else if (r is Receptor_Rem)
            {
                if (string.IsNullOrEmpty(r.RznSocRecep) || string.IsNullOrWhiteSpace(r.RznSocRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Razón Social del receptor");
                }
                if (string.IsNullOrEmpty(r.DirRecep) || string.IsNullOrWhiteSpace(r.DirRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Dirección del Receptor");
                }
                if (string.IsNullOrEmpty(r.CiudadRecep) || string.IsNullOrWhiteSpace(r.CiudadRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Ciudad del Receptor");
                }
            }
            else if (r is Receptor_Rem_Exp)
            {
                if (string.IsNullOrEmpty(r.RznSocRecep) || string.IsNullOrWhiteSpace(r.RznSocRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Razón Social del receptor");
                }
                if (string.IsNullOrEmpty(r.DirRecep) || string.IsNullOrWhiteSpace(r.DirRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Dirección del Receptor");
                }
                if (string.IsNullOrEmpty(r.CiudadRecep) || string.IsNullOrWhiteSpace(r.CiudadRecep))
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Ciudad del Receptor");
                }
                if (r.PaisRecep == null)
                {
                    throw new ExcepcionesPersonalizadas.Logica("Debe completar el campo Ciudad del Receptor");
                }
            }

        }
    }
}
