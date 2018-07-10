using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class FormasDePagoType
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
        public FormasDePagoType(int id, string nombre, bool Habilitado)
        {
            Id = id;
            Nombre = nombre;
            this.Habilitado = Habilitado;
        }

        public override string ToString()
        {
            return Id + ": " + Nombre;
        }
    }
}
