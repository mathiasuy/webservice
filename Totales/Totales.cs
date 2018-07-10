using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Items;

namespace Totales
{
    public class Totales
    {
        private bool MntBruto { get;set; }
        public List<Item_Det_Fact> ListaDeItems { get; set; }
        public TipoMoneda Moneda { get; set; }

        private IVAType IVAOtraTasa { get; set; }

        private IVAType IVATasaMin { get; set; }
        private IVAType IVATasaBasica { get; set; }

        public List<RetencPercepType> RetencPercep { get; set; }

        public Totales(bool MntBruto, TipoMoneda Moneda, IVAType IVAOtraTasa, IVAType IVATasaBasica, IVAType IVATasaMin,
                        List<Item_Det_Fact> ListaDeItems, List<RetencPercepType> RetencPercep)
        {
            this.MntBruto = MntBruto;
            this.Moneda = Moneda;
            this.IVAOtraTasa = IVAOtraTasa;
            this.IVATasaBasica = IVATasaBasica;
            this.IVATasaMin = IVATasaMin;
            this.ListaDeItems = ListaDeItems;
            this.RetencPercep = RetencPercep;
        }

        public decimal MntNoGrv 
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 1) { suma += item.MontoItem; }
                                        }
                                        return suma;
                                    }
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
        public decimal MntImpuestoPerc
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 11) { suma += item.MontoItem; }
                                        }
                                        return suma;
                                    }
                                }
        public decimal MntIVaenSusp
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 12) { suma += item.MontoItem; }
                                        }
                                        return suma;
                                    }
                                }
        public decimal MntNetoIvaTasaMin
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 2) { suma += item.MontoItem; }
                                        }
                                        return suma;
                                    }
                                }
        public decimal MntNetoIVATasaBasica
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 3) { suma += item.MontoItem; }
                                        }
                                        return suma;
                                    }
                                }
        public decimal MntNetoIVAOtra
                                {
                                    get
                                    {
                                        decimal suma = 0;
                                        foreach (Item_Det_Fact item in ListaDeItems)
                                        {
                                            if (item.IndFact.Id == 4) { suma += item.MontoItem; }
                                        }
                                        return suma;
                                    }
                                }

        public decimal MntIVATasaMin { get { return MntNetoIvaTasaMin * IVATasaMin.Valor; } }
        public decimal MntIVATasaBasica { get { return MntNetoIVATasaBasica * IVATasaBasica.Valor; } }
        public decimal MntIVAOtra { get { return MntNetoIVAOtra * IVAOtraTasa.Valor; } }
        public decimal MntTotal
        { 
                                    get{ 
                                            return 
            
                                            MntIVAOtra 
                                            + MntIVATasaBasica
                                            + MntIVATasaMin
                                            + MntNetoIVAOtra 
                                            + MntNetoIVATasaBasica 
                                            + MntNetoIvaTasaMin 
                                            + MntIVaenSusp 
                                            + MntImpuestoPerc 
                                            + MntExpoyAsim
                                            + MntNoGrv;
                                        }
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
        public decimal MntPagar { get { return MntTotal + MontoNF + MntTotRetenido; } }


        public override string ToString()
        {
            return base.ToString() + "\nMonto Bruto: " + (MntBruto ? "IVA Inc." : "Sin IVA Inc") + "\nMoneda: " + Moneda.ToString() + "\nIVA Otra Tasa: " + IVAOtraTasa.ToString() + "\nIVA Minimo: " + IVATasaMin + "\nIVA Básico: " + IVATasaBasica + "\nCantidad de elementos en la lista de Retención Percepción: " + RetencPercep.Count +
                "\nMonto No Gravado: " + MntNoGrv + "\nMonto Exportación y Asimiladas: " + MntExpoyAsim + "\nMonto Impuesto Percibido: " + MntImpuestoPerc + "\nMonto IVA en Suspenso: " + MntIVaenSusp
                + MntNetoIvaTasaMin + "\nMonto Neto IVA Tasa Mínima: " + MntNetoIvaTasaMin + "\nMonto Neto IVA Tasa Básica: " + MntNetoIVATasaBasica + "\nMonto Neto IVA Otra" + MntNetoIVAOtra
                + "\nMonto IVA Tasa Mínima: " + MntIVATasaMin + "\nMonto IVA Tasa Basica: " + MntIVATasaBasica + "\nMonto IVA Otra: " + MntIVAOtra + "\nMonto Total: " + MntTotal + "\nMonto Total Retenido: " + MntTotRetenido
                + "\nCantidad de Ítems: " + CantLinDet + "\nMonto No Facturable: " + MontoNF + "\nMonto a Pagar: " + MntPagar;
        }
    }


}
