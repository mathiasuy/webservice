using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{
    public class SerieType
    {
        public TipoCFEType CFE {get;set;}
        public string Serie { get; set; }
        public int Numero { get; set; }

        public SerieType(TipoCFEType TipoCFE, string Serie, int Numero)
        {
            this.CFE = TipoCFE;
            this.Serie = Serie;
            this.Numero = Numero;
        }

        public override string ToString()
        {
            return Serie + Numero;
        }

    }
}
