using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Items
{
    public class Item_Rem_Exp : Item_Rem
    {
        public decimal PrecioUnitario { get; set; }
        public decimal MontoItem
        {
            get
            {
                return PrecioUnitario * Cantidad;
            }
        }

        public Item_Rem_Exp(int NroLinDet,
                            string CodItem,
                            IndicadorFacturaType IndFact,
                            string NomItem,
                            string DscItem,
                            int Cantidad,
                            UnidadesDeMedida UniMed,
                            decimal PrecioUnitario)
            : base(NroLinDet, CodItem, IndFact, NomItem, DscItem, Cantidad, UniMed)
        {
            this.PrecioUnitario = PrecioUnitario;
        }

        public override string ToString()
        {
            return base.ToString() + " $" + PrecioUnitario + " $" + MontoItem;
        }
    }
}
