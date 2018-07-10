using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Receptores
{
    public class Receptor
    {
        public int Id { get; set; }
        public NumeroDocumento DocRecep { get; set; }
        public PaisType PaisRecep { get; set; }
        public string RznSocRecep { get; set; }
        public string DirRecep { get; set; }
        public string CiudadRecep { get; set; }
        public string DeptoRecep { get; set; }
        public string CP { get; set; }
        public string InfoAdicional { get; set; }
        public string LugarDestEnt { get; set; }
        public string CompraID { get; set; }

        public Receptor(NumeroDocumento Documento, PaisType Pais, string RznSocRecep, string DirRecep, string CiudadRecep,
                        string DeptoRecep, string CP, string InfoAdicional, string LugarDestEnt, string CompraID)
        {
            this.DocRecep = Documento;
            this.PaisRecep = Pais;
            this.RznSocRecep = RznSocRecep;
            this.DirRecep = DirRecep;
            this.CiudadRecep = CiudadRecep;
            this.DeptoRecep = DeptoRecep;
            this.CP = CP;
            this.InfoAdicional = InfoAdicional;
            this.LugarDestEnt = LugarDestEnt;
            this.CompraID = CompraID;
        }

        public string ATexto { get { return this.ToString(); } }

        public override string ToString()
        {
            return Id + ": " +  DocRecep.ToString() + " " + PaisRecep.ToString() + " " + RznSocRecep + " " + DirRecep + " " + CiudadRecep 
                + " " + DeptoRecep + " " + CP + " " + InfoAdicional + " " + LugarDestEnt + " " + CompraID;
        }
    }
}
