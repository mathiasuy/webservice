using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class ProductoServicio
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public TipoMoneda Moneda { get; set; }
        public string Comentario { get; set; }
        public UnidadesDeMedida UniMed { get; set; }
        
        public int Stock { get; set; }

        public ProductoServicio(string Codigo, string Nombre, decimal Precio, TipoMoneda Moneda, string Comentario, int Stock, UnidadesDeMedida UniMed)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.Moneda = Moneda;
            this.Stock = Stock;
            this.Comentario = Comentario;
            this.UniMed = UniMed;
        }

        public void ReducirStock()
        {
            this.Stock -= 1;
        }

        public void AumentarStock()
        {
            this.Stock += 1;
        }

        public string ATexto
        {
            get
            {
                return this.ToString();
            }
        }

        public override string ToString()
        {
            return "Código: " + Codigo + " Nombre: " + Nombre + " Precio: " + Moneda.Simbolo + Precio + "Comentario: " + UniMed.ToString() +" " + Comentario;
        }
    }
}
