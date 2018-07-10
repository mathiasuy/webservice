using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class CodRetType
    {
        public string Id { get; set; }
        public decimal Tasa { get; set; }

        public CodRetType(string Codigo, decimal Tasa)
        {
            this.Id = Codigo;
            this.Tasa = Tasa;
        }

        public override string ToString()
        {
            return Id + " - " + Tasa; 
        }
    }
}
