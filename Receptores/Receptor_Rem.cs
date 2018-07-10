using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Receptores
{
    public class Receptor_Rem : Receptor
    {


        public Receptor_Rem(NumeroDocumento Documento, PaisType Pais, string RznSocial, string Direccion, string Ciudad)
            :base(Documento,Pais,RznSocial,Direccion,Ciudad,"","","","","")
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
