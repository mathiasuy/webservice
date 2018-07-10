using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class PaisType
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public PaisType(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Id + ": " + Nombre;
        }
    }
}
