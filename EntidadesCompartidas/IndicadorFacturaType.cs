using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class IndicadorFacturaType
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public IndicadorFacturaType(int id, string nombre, bool Habilitado)
        {
            Id = id;
            Nombre = nombre;
            this.Habilitado = Habilitado;
        }

        public string ATexto
        {
            get
            {
                return Id + ": " + Nombre;
            }
        }

        public override string ToString()
        {
            return Id + ": " + Nombre + " tipo habilitado: " + (Habilitado ? "si":"no");
        }
    }
}
