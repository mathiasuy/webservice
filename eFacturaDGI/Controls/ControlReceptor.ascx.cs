using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using ExcepcionesPersonalizadas;
using Logica;
using Receptores;

namespace eFacturaDGI.Controls
{
    public partial class ControlReceptor : System.Web.UI.UserControl
    {
        List<TipoDocumentoType> TiposDeDocumento = LTipoDocumentoType.ListarTipoDocumento();
        List<Receptor> ListaDeReceptores = LReceptor.ListarReceptor();
        List<PaisType> Paises = LPaisType.ListarPaises();
        List<TipoCFEType> TiposDeCFE = LTipoCFEType.ListarTipoCFE();
        List<ModVentaType> ModalidadesDeVenta = LModVentaType.ListarModVenta();
        List<TipoTrasladoType> TiposDeTraslado = LTipoTraslado.ListarTipoTraslado();
        List<ViaTranspType> ViasDeTrasnporte = LViaTransp.ListarViaTransp();
        List<FormasDePagoType> FormasDePago = LFormasDePago.ListarFormasDePago();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                ddlPais.DataSource = Paises;
                ddlPais.DataTextField = "Nombre";
                ddlPais.DataValueField = "Id";
                ddlPais.DataBind();


                ddlTipoDoc.DataSource = TiposDeDocumento;
                ddlTipoDoc.DataTextField = "Nombre";
                ddlTipoDoc.DataValueField = "Id";
                ddlTipoDoc.DataBind();

                ddlReceptores.DataSource = ListaDeReceptores;
                ddlReceptores.DataTextField = "ATexto";
                ddlReceptores.DataValueField = "Id";
                ddlReceptores.DataBind();
                panel.Visible = true;
                CargarReceptor();
            }
        }



        private void LimpiarReceptor()
        {
            txtDoc.Text = string.Empty;
            txtRznSoc.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtDepartamento.Text = string.Empty;
            txtCP.Text = string.Empty;
            txtInformacionAdicional.Text = string.Empty;
            txtLugarDestinatario.Text = string.Empty;
            txtCompraID.Text = string.Empty;
        }


        private Receptor CargarReceptor()
        {
            Receptor receptor = LReceptor.BuscarReceptor(Convert.ToInt32(ddlReceptores.SelectedValue));
            ddlTipoDoc.SelectedValue = Convert.ToString(receptor.DocRecep.Id);
            txtDoc.Text = receptor.DocRecep.Documento;
            txtRznSoc.Text = receptor.RznSocRecep;
            ddlPais.SelectedValue = receptor.PaisRecep.Id;
            txtCiudad.Text = receptor.CiudadRecep;
            txtDireccion.Text = receptor.DirRecep;
            txtDepartamento.Text = receptor.DeptoRecep;
            txtCP.Text = receptor.CP;
            txtInformacionAdicional.Text = receptor.InfoAdicional;
            txtLugarDestinatario.Text = receptor.LugarDestEnt;
            txtCompraID.Text = receptor.CompraID;
            lblVerIdReceptor.Text = Convert.ToString(receptor.Id);
            return receptor;
        }


        protected void BotonDatos(object sender, EventArgs e)
        {
            if (panel.Visible)
                panel.Visible = false;
            else panel.Visible = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                NumeroDocumento Documento = new NumeroDocumento(TiposDeDocumento[Convert.ToInt32(ddlTipoDoc.SelectedValue) - 2], txtDoc.Text);
                PaisType pais = new PaisType(ddlPais.SelectedItem.Value, ddlPais.SelectedItem.Text);
                Receptor receptorNuevo = new Receptor(Documento, pais, txtRznSoc.Text, txtDireccion.Text, txtCiudad.Text, txtDepartamento.Text, txtCP.Text, txtInformacionAdicional.Text, txtLugarDestinatario.Text, txtCompraID.Text);
                int id;
                LReceptor.DarAltaReceptor(receptorNuevo, out  id);
                receptorNuevo.Id = id;
                lblVerIdReceptor.Text = Convert.ToString(id);
                lblMensaje.Text = "Receptor Agregado con éxito con identificador: " + id;
                CargarReceptor();
            }
            catch (ExcepcionesPersonalizadas.Sistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al cargar la página.";
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                NumeroDocumento Documento = new NumeroDocumento(TiposDeDocumento[Convert.ToInt32(ddlTipoDoc.SelectedValue) - 2], txtDoc.Text);
                PaisType pais = new PaisType(ddlPais.SelectedItem.Value, ddlPais.SelectedItem.Text);
                Receptor receptorNuevo = new Receptor(Documento, pais, txtRznSoc.Text, txtDireccion.Text, txtCiudad.Text, txtDepartamento.Text, txtCP.Text, txtInformacionAdicional.Text, txtLugarDestinatario.Text, txtCompraID.Text);
                receptorNuevo.Id = Convert.ToInt32(lblVerIdReceptor.Text);
                LReceptor.ModificarReceptor(receptorNuevo);
                lblMensaje.Text = "Receptor modificado con éxito";
                CargarReceptor();
            }
            catch (ExcepcionesPersonalizadas.Sistema ex)
            {
                lblMensaje.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "¡Error! Ocurrió un error al cargar la página.";
            }

        }


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarReceptor();
        }

        protected void CargarReceptor(object sender, EventArgs e)
        {
            CargarReceptor();
        }


    }
}