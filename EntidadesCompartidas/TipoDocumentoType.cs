using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class TipoDocumentoType
    {
        //DOCUMENTO RUC,CI URUGUAYA, PASAPORTE, ETC...
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoDocumentoType(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Id + ": " + Nombre + " ";
        }
    }
}
