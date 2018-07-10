using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class RetencPercepType
    {
        public CodRetType CodRet { get; set; }
        public decimal MntSujetoaRet { get; set; }
        public decimal ValRetPerc { get { return MntSujetoaRet * CodRet.Tasa / 100; } }

        public RetencPercepType(CodRetType CodRet, decimal MntSujetoaRet)
        {
          this.CodRet = CodRet;
          this.MntSujetoaRet = MntSujetoaRet;
        }

        public override string ToString()
        {
            return CodRet.ToString() + " " +  " " + MntSujetoaRet + " " + ValRetPerc;
        }
    }
}
