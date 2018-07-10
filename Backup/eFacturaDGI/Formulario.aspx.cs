using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eFacturaDGI
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelReceptor.Visible = false;
                panelEmisor.Visible = false;
            }

            
        }


        protected void BotonDatosEmisor(object sender, EventArgs e)
        {
            panelReceptor.Visible = false;
            if (panelEmisor.Visible)
                panelEmisor.Visible = false;
            else panelEmisor.Visible = true;
        }

        protected void BotonDatosReceptor(object sender, EventArgs e)
        {
            panelEmisor.Visible = false;
            if (panelReceptor.Visible)
                panelReceptor.Visible = false;
            else panelReceptor.Visible = true;
        }
    }
}