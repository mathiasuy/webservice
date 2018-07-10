using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Items
{
    public class Item_Det_Fact_Exp : Item_Det_Fact
    {
        public Item_Det_Fact_Exp(int NroLinDet,
                             string CodItem,
                             IndicadorFacturaType IndFact,
                             string NomItem,
                             string DscItem,
                             int Cantidad,
                             UnidadesDeMedida UniMed,
                             decimal PrecioUnitario)
            :base( NroLinDet, CodItem, IndFact, NomItem, DscItem, Cantidad, UniMed, PrecioUnitario)
        {
        }


    }
}
