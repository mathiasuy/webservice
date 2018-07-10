using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Items
{
    public class Item_Rem
    {
        public int NroLinDet { get; set; }
        public string CodItem { get; set; }
        public IndicadorFacturaType IndFact {get;set;}
        public string NomItem { get; set; }
        public string DscItem { get; set; }
        public int Cantidad { get; set; }
        public UnidadesDeMedida UniMed { get; set; }

        public Item_Rem(int NroLinDet,
                             string CodItem,
                             IndicadorFacturaType IndFact,
                             string NomItem,
                             string DscItem,
                             int Cantidad,
                             UnidadesDeMedida UniMed
                             )
        {
             this.NroLinDet = NroLinDet;
             this.CodItem = CodItem;
             this.IndFact = IndFact;
             this.NomItem = NomItem;
             this.DscItem = DscItem;
             this.Cantidad = Cantidad;
             this.UniMed = UniMed;
        }

        public override string ToString()
        {
            return base.ToString() + NroLinDet + " " + CodItem + " " + IndFact + " " +NomItem + " " + DscItem + " " + Cantidad + " " + UniMed;
        }

    }
}
