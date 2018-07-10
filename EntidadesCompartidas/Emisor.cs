using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{
    public class Emisor
    {
        public int IdEmisor { get; set;}
        public NumeroDocumento RUCEmisor { get; set; }
        public string RznSoc {get; set;}
        public string NomComercial { get; set; }
        public string GiroEmis { get; set; } //Giro Comercial del Emisor Relevante para el CFE
        public string Telefono1 { get; set; }
        public string CorreoEmisor { get; set; }
        public string EmiSucursal { get; set; }
        public string CdgDGISuc {get; set;}
        public string DomFiscal {get; set;}
        public string Ciudad {get; set;}
        public string Departamento { get; set; }

        public Emisor(NumeroDocumento rUCEmisor, string RznSoc, string CdgDGISuc, string DomFiscal, string Ciudad, string Departamento,
            string NomComercial, string GiroEmis, string Telefono1, string CorreoEmisor, string EmiSucursal)
        {
            RUCEmisor = rUCEmisor;
            this.RznSoc = RznSoc;
            this.NomComercial = NomComercial;
            this.GiroEmis = GiroEmis;
            this.Telefono1 = Telefono1;
            this.CorreoEmisor = CorreoEmisor;
            this.EmiSucursal = EmiSucursal;
            this.CdgDGISuc = CdgDGISuc;
            this.DomFiscal = DomFiscal;
            this.Ciudad = Ciudad;
            this.Departamento = Departamento;
        }

        public string ATexto { get { return this.ToString(); } }

        public override string ToString()
        {
            return IdEmisor + " " + RUCEmisor.ToString() + RznSoc + " " + CdgDGISuc + " " + DomFiscal + " " + Ciudad + " " + Departamento;
        }
    }
}
