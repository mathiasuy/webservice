using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Items;

namespace Totales
{
    public class Totales_Resg
    {
        public List<Item_Det_Fact> ListaDeItems { get; set; }
        public TipoMoneda Moneda { get; set; }
        public List<RetencPercepType> RetencPercep { get; set; }

        public Totales_Resg(TipoMoneda Moneda,
                        List<Item_Det_Fact> ListaDeItems, List<RetencPercepType> RetencPercep)
        {
            this.Moneda = Moneda;
            this.ListaDeItems = ListaDeItems;
            this.RetencPercep = RetencPercep;
        }

        public decimal MntTotRetenido
        {
                                        get {
                                            decimal suma = 0;
                                                for (int i = 1; i <= RetencPercep.Count; i++)
                                                {
                                                    suma += RetencPercep[i].ValRetPerc;
                                                }
                                                return suma;
                                            }
                                    }
        public int CantLinDet { get { return ListaDeItems.Count; } }

        public override string ToString()
        {
            return base.ToString() + "\nMonto Bruto: " + "\nMoneda: " + Moneda.ToString() + "\nIVA Otra Tasa: " + "\nCantidad de elementos en la lista de Retención Percepción: " + RetencPercep.Count +
                + MntTotRetenido + "\nCantidad de Ítems: " + CantLinDet;
        }
    }
}
