using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Items;

namespace Totales
{
    public class Totales_Fact_Exp
    {
        public List<Item_Det_Fact> ListaDeItems { get; set; }
        public TipoMoneda Moneda { get; set; }

        public Totales_Fact_Exp(TipoMoneda Moneda, List<Item_Det_Fact> ListaDeItems)
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

        public decimal MontoNF
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 6) { suma += item.MontoItem; }
                                        }
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 7) { suma -= item.MontoItem; }
                                        }
                                        return suma;
                                    }
                                }
        public decimal MntPagar { get { return MntTotal + MontoNF; } }


        public override string ToString()
        {
            return base.ToString() + "\nMonto Bruto: " +  "\nMoneda: " + Moneda.ToString() + "\nIVA Otra Tasa: " + 
                "\nMonto No Gravado: " + MntExpoyAsim 
                + MntTotal 
                + "\nCantidad de Ítems: " + CantLinDet + "\nMonto No Facturable: " + MontoNF + "\nMonto a Pagar: " + MntPagar;
        }
    }
}
