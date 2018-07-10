using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Receptores
{
    public class Receptor_Resg : Receptor
    {
        public Receptor_Resg(NumeroDocumento Documento, PaisType Pais, string RznSocRecep, string DirRecep, string CiudadRecep,
                             string DeptoRecep, string CP, string InfoAdicional)
            : base(Documento, Pais, RznSocRecep, DirRecep, CiudadRecep, DeptoRecep, CP, InfoAdicional, "", "")
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
