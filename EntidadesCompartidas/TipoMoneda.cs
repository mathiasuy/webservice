using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class TipoMoneda
    {
        public string Nombre {get; set;}
        public string Id { get; set; }
        public double Cambio { get; set; }
        public bool Habilitado { get; set; }

        public string Simbolo { get; set; }

        public bool Nacional { get; set; }

        public TipoMoneda(string id, string nombre, double cambio, string Simbolo, bool Nacional, bool Habilitado)
        {
            Nombre = nombre;
            Id = id;
            Cambio = cambio;
            this.Simbolo = Simbolo;
            this.Nacional = Nacional;
            this.Habilitado = Habilitado;
        }

        public override string ToString()
        {
            return Id + ": " + Nombre + " " + (Habilitado ? "Habilitado" : "Dehabilitado");
        }

    }
}
