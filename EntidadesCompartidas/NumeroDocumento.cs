using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class NumeroDocumento : TipoDocumentoType
    {
        public string Documento { get; set; }

        public NumeroDocumento(TipoDocumentoType TipoDocumento, string Documento)
            : base(TipoDocumento.Id, TipoDocumento.Nombre)
        {
            this.Documento = Documento;
        }

        public override string ToString()
        {
            return base.ToString() + " Número de Documento: " + Documento;
        }
    }
}
