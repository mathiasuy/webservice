using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eFacturaDGI.Forms
{
    public partial class CodRetenciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ListaRetenciones"] = ControlRetencionPercepcion1.Retenciones;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Response.Write("javascript:window.Close()");
        }
    }
}