using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{
     public class TipoCFEType
    {
        public int Id {get;set;}
        public string Nombre{get;set;}
        public string IdNombre{get;set;} //Nombre para el XML

        public TipoCFEType(int Id, string Nombre, string IdNombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.IdNombre = IdNombre;
        }

        public override string ToString()
        {
            return base.ToString() + Id + ": " + Nombre + " " + IdNombre;
        }
        
    }
}
