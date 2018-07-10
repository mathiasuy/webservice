using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;
using Receptores;
using Items;

namespace eFacturaDGI
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            IdDoc.IdDoc_CompFisc IdDoc = ControlIdDoc1.IdDoc;

        }
    }
}