using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Items;

namespace Totales
{
    public class Totales_Rem_Exp
    {
                public List<Item_Det_Fact> ListaDeItems { get; set; }
        public TipoMoneda Moneda { get; set; }

        public Totales_Rem_Exp(TipoMoneda Moneda, List<Item_Det_Fact> ListaDeItems)
        {
            this.Moneda = Moneda;
            this.ListaDeItems = ListaDeItems;
        }

        public decimal MntExpoyAsim
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 10) { suma += item.MontoItem; }
                                        }
                                        return suma;
                                    }
                                }

        public decimal MntTotal
        { 
                                    get
                                        { 
                                            return  MntExpoyAsim;
                                        }
                                }

        public int CantLinDet { get { return ListaDeItems.Count; } }

        public decimal MntPagar { get { return MntTotal; } }


        public override string ToString()
        {
            return base.ToString() + "\nMonto Bruto: " +  "\nMoneda: " + Moneda.ToString() + "\nIVA Otra Tasa: " + 
                "\nMonto No Gravado: " + MntExpoyAsim 
                + MntTotal 
                + "\nCantidad de Ítems: " + CantLinDet + "\nMonto a Pagar: " + MntPagar;
        }
    }
}
