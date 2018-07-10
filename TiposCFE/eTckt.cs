using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Items;


namespace TiposCFE
{
    class eTckt : Documento
    {
        public FechaType TmstFirma { get; set; }
        //IDdoc

        public SerieType Serie { get; set; }
        public int Numero { get; set; }
        public FechaType FchEmis { get; set; }

        public FormasDePagoType FmaPago { get; set; }





    }
}
