using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Items
{
    public class Item_Det_Fact
    {
        public int NroLinDet { get; set; }
        public string CodItem { get; set; }
        public IndicadorFacturaType IndFact { get; set; }
        public string NomItem { get; set; }
        public string DscItem { get; set; }
        public int Cantidad { get; set; }
        public UnidadesDeMedida UniMed { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoItem
        {
            get
            {
                return PrecioUnitario * Cantidad;
            }
        }
        public Item_Det_Fact(int NroLinDet,
                             string CodItem,
                             IndicadorFacturaType IndFact,
                             string NomItem,
                             string DscItem,
                             int Cantidad,
                             UnidadesDeMedida UniMed,
                             decimal PrecioUnitario)
        {
             this.NroLinDet = NroLinDet;
             this.CodItem = CodItem;
             this.IndFact = IndFact;
             this.NomItem = NomItem;
             this.DscItem = DscItem;
             this.Cantidad = Cantidad;
             this.UniMed = UniMed;
             this.PrecioUnitario = PrecioUnitario;
        }

        public override string ToString()
        {
            return
                "<br/><br/>Numero de linea: " + NroLinDet + " " + "<br/>CodItem: " + CodItem + " " + "<br/>IndFact: " + IndFact + " " +
                "<br/>NomItem: " + NomItem + " " + "<br/>DscItem: " + DscItem + " " + "<br/>Cantidad: " + Cantidad + " " +
                "<br/>UniMed: " + UniMed + " " + "<br/>PrecioUnitario: " + PrecioUnitario + " " + "<br/>MontoItem: " + MontoItem;
        }
    }
}
