using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using ExcepcionesPersonalizadas;

namespace eFacturaDGI.Controls
{
    public partial class ControlEmisor : System.Web.UI.UserControl 
    {
        TipoDocumentoType RUC = LTipoDocumentoType.BuscarTipoDocumento(2);
        protected void Page_Load(object sender, EventArgs e)
        {
        List<TipoDocumentoType> TiposDeDocumento = LTipoDocumentoType.ListarTipoDocumento();
        List<Emisor> ListaDeEmisores = LEmisor.ListarEmisor();
        List<PaisType> Paises = LPaisType.ListarPaises();
        List <TipoCFEType> TiposDeCFE = LTipoCFEType.ListarTipoCFE();
        List<ModVentaType> ModalidadesDeVenta = LModVentaType.ListarModVenta();
        List<TipoTrasladoType> TiposDeTraslado = LTipoTraslado.ListarTipoTraslado();
        List<ViaTranspType> ViasDeTrasnporte = LViaTransp.ListarViaTransp();
        List<FormasDePagoType> FormasDePago = LFormasDePago.ListarFormasDePago();

            if (!IsPostBack)
            {
                ddlEmisores.DataSource = ListaDeEmisores;
                ddlEmisores.DataTextField = "ATexto";
                ddlEmisores.DataValueField = "idEmisor";
                ddlEmisores.DataBind();

                CargarEmisor();
                panelEmisor.Visible = false;
            }
        }

        private void LimpiarEmisor()
        {
            txtRUCEmisor.Text = string.Empty;
            txtRznSoc.Text = string.Empty;
            txtCdgDGISucur.Text = string.Empty;
            txtDomFiscal.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtDepartamento.Text = string.Empty;
            txtNomComercial.Text = string.Empty;
            txtGiroEmis.Text = string.Empty;
            txtTelefono1.Text = string.Empty;
            txtCorreoEmisor.Text = string.Empty;
            txtEmiSucursal.Text = string.Empty;
        }

        private Emisor CargarEmisor()
        {
            Emisor emisor = LEmisor.BuscarEmisor(Convert.ToInt32(ddlEmisores.SelectedItem.Value));
            txtRUCEmisor.Text = emisor.RUCEmisor.Documento;
            lblIdEmisor.Text = emisor.IdEmisor.ToString();
            txtRznSoc.Text = emisor.RznSoc;
            txtCdgDGISucur.Text = emisor.CdgDGISuc.ToString();
            txtDomFiscal.Text = emisor.DomFiscal;
            txtCiudad.Text = emisor.Ciudad;
            txtDepartamento.Text = emisor.Departamento;
            txtNomComercial.Text = emisor.NomComercial;
            txtGiroEmis.Text = emisor.GiroEmis;
            txtTelefono1.Text = emisor.Telefono1;
            txtCorreoEmisor.Text = emisor.CorreoEmisor;
            txtEmiSucursal.Text = emisor.EmiSucursal;
            return emisor;
        }

        protected void BotonDatosEmisor(object sender, EventArgs e)
        {
            if (panelEmisor.Visible)
                panelEmisor.Visible = false;
            else
            {
                panelEmisor.Visible = true;
            }
        }


        protected void btnAgregarEmisor_Click(object sender, EventArgs e)
        {
            try
            {
                NumeroDocumento Documento = new NumeroDocumento(RUC, txtRUCEmisor.Text);
                Emisor emisorNuevo = new Emisor(Documento, txtRznSoc.Text, txtCdgDGISucur.Text, txtDomFiscal.Text, txtCiudad.Text, txtDepartamento.Text, txtNomComercial.Text, txtGiroEmis.Text, txtTelefono1.Text, txtCorreoEmisor.Text, txtEmiSucursal.Text);
                int id;
                LEmisor.DarAltaEmisor(emisorNuevo, out id);


                lblMensajeEmisor.Text = "Emisor Agregado con éxito con identificador: " + id;
            }
            catch (ExcepcionesPersonalizadas.Sistema ex)
            {
                lblMensajeEmisor.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensajeEmisor.Text = "¡Error! Ocurrió un error al cargar la página.";
            }
        }

        protected void btnModificarEmisor_Click(object sender, EventArgs e)
        {
            try
            {
                NumeroDocumento Documento = new NumeroDocumento(RUC, txtRUCEmisor.Text);
                Emisor emisorNuevo = new Emisor(Documento, txtRznSoc.Text, txtCdgDGISucur.Text, txtDomFiscal.Text, txtCiudad.Text, txtDepartamento.Text, txtNomComercial.Text, txtGiroEmis.Text, txtTelefono1.Text, txtCorreoEmisor.Text, txtEmiSucursal.Text);
                emisorNuevo.IdEmisor = Convert.ToInt32(lblIdEmisor.Text);
                LEmisor.ModificarEmisor(emisorNuevo);
                lblMensajeEmisor.Text = "Emisor modificado con éxito";
                CargarEmisor();

                lblIdEmisor2.Text = Convert.ToString(emisorNuevo.IdEmisor);
            }
            catch (ExcepcionesPersonalizadas.Sistema ex)
            {
                lblMensajeEmisor.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensajeEmisor.Text = "¡Error! Ocurrió un error al cargar la página.";
            }
        }

        protected void btnLimpiarEmisor_Click(object sender, EventArgs e)
        {
            LimpiarEmisor();
        }

        protected void CargarEmisor(object sender, EventArgs e)
        {
            CargarEmisor();
        }

    }
}