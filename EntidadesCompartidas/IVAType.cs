using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class IVAType
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }

        public IVAType(int Id, string Nombre, decimal Valor)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Valor = Valor;
        }

        public override string ToString()
        {
            return base.ToString() + Id + ": " + Nombre + " %" + Valor;
        }
    }
}
