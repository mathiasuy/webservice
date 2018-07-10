using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Receptores
{
    public class Receptor_Fact : Receptor
    {
        public Receptor_Fact(NumeroDocumento Documento, PaisType Pais, string RznSocRecep, string DirRecep, string CiudadRecep,
                        string DeptoRecep, string CP, string InfoAdicional, string LugarDestEnt, string CompraID)
            :base(Documento,Pais,RznSocRecep,DirRecep,CiudadRecep,DeptoRecep,CP,InfoAdicional,LugarDestEnt,CompraID)
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
