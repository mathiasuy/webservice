using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Items
{
    public class Item_Resg
    {
        public int NroLinDet {get;set;}
        public IndicadorFacturaType IndFact { get; set; }
        public List<RetencPercepType> RetencPercep {get;set;}


        public Item_Resg(int NroLinDet, IndicadorFacturaType IndFact, List<RetencPercepType> retencPercep)
        {
            this.NroLinDet = NroLinDet;
            this.IndFact = IndFact;
            RetencPercep = retencPercep;
        }


        public override string ToString()
        {
            return NroLinDet + " " + IndFact + " " + RetencPercep.ToString();
        }
    }
}
