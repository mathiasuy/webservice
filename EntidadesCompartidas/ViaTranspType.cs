﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class ViaTranspType
    {
       public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public ViaTranspType(int Id, string Nombre,bool Habilitado)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Habilitado = Habilitado;
        }

        public override string ToString()
        {
            return Id + ": " + Nombre + (Habilitado ? "Habilitado" : " Deshabilitado");
        }
    }
}
