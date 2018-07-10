using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Linq;

using System.Web.UI.WebControls;
using System.IO;

using Logica;
using Totales;
using EntidadesCompartidas;
using Items;

using Logica;
using EntidadesCompartidas;

namespace eFacturaDGI.Forms
{
    public partial class Cargar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Variables para Items
            Item_Det_Fact item = null;
            int NroLinDet = 0;
            string CodItem = "";
            IndicadorFacturaType IndFact = null;
            string NomItem = "";
            string DscItem = "";
            int Cantidad = 0;
            UnidadesDeMedida UniMed = null;
            decimal PrecioUnitario = 0;
            decimal MontoItem = 0;
            #endregion
            #region Variables para Receptor
            string RutReceptor = "";
            string RUCEmisor = "";
            int Idemisor = 0;
            int CantCFE = 0;
            FechaType Fecha = null;
            string X509Certificate = "";
            #endregion

            lblMensaje.Text = Logica.XMLAcces.buscarEnXML("");
        }
    }
}