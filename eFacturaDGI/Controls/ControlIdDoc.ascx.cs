using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using ExcepcionesPersonalizadas;
using IdDoc;
namespace eFacturaDGI.Controls
{
    public partial class ControlIdDoc : System.Web.UI.UserControl
    {
        List<TipoDocumentoType> TiposDeDocumento = LTipoDocumentoType.ListarTipoDocumento();
        List<PaisType> Paises = LPaisType.ListarPaises();
        List <TipoCFEType> TiposDeCFE = LTipoCFEType.ListarTipoCFE();
        List<ModVentaType> ModalidadesDeVenta = LModVentaType.ListarModVenta();
        List<TipoTrasladoType> TiposDeTraslado = LTipoTraslado.ListarTipoTraslado();
        List<ViaTranspType> ViasDeTrasnporte = LViaTransp.ListarViaTransp();
        List<FormasDePagoType> FormasDePago = LFormasDePago.ListarFormasDePago();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPeriodoDesde.Text = DateTime.Today.ToString();
                txtPeriodoHasta.Text = DateTime.Today.ToString();
                txtFchVenc.Text = DateTime.Today.ToString();
                ddlTipoCFE.DataSource = TiposDeCFE;
                ddlTipoCFE.DataTextField = "Nombre";
                ddlTipoCFE.DataValueField = "Id";
                ddlTipoCFE.DataBind();

                ddlModVenta.DataSource = ModalidadesDeVenta;
                ddlModVenta.DataTextField = "Nombre";
                ddlModVenta.DataValueField = "Id";
                ddlModVenta.DataBind();

                ddlTipoTraslado.DataSource = FormasDePago;
                ddlTipoTraslado.DataTextField = "Nombre";
                ddlTipoTraslado.DataValueField = "Id";
                ddlTipoTraslado.DataBind();

                ddlViaTransp.DataSource = ViasDeTrasnporte;
                ddlViaTransp.DataTextField = "Nombre";
                ddlViaTransp.DataValueField = "Id";
                ddlViaTransp.DataBind();

                ddlFmaPago.DataSource = FormasDePago;
                ddlFmaPago.DataTextField = "Nombre";
                ddlFmaPago.DataValueField = "Id";
                ddlFmaPago.DataBind();

                ControlItem_Fact.Visible = false;
                ControlItem_Det_Fact_Exp.Visible = false;
                ControlItem_Rem_Exp.Visible = false;
                ControlItem_Rem.Visible = false;
                ControlItemResg.Visible = false;
            }
            else
            {
                TipoCFEType tpoCFE = LTipoCFEType.BuscarTipoCFE(Convert.ToInt32(ddlTipoCFE.SelectedValue));
                SerieType serie = new SerieType(tpoCFE, "A", 1);
                IdDoc.IdDoc_CompFisc idDoc = new IdDoc.IdDoc_CompFisc(tpoCFE, serie);
                Session["IdDoc"] = idDoc;
            }
        }

        private void OcultarTodo()
        {
            ControlItem_Fact.Visible = false;
            ControlItem_Det_Fact_Exp.Visible = false;
            ControlItem_Rem_Exp.Visible = false;
            ControlItem_Rem.Visible = false;
            ControlItemResg.Visible = false;  
            calFchEmis.Visible = false;
            lblFchEmis.Visible = false;
            txtPeriodoDesde.Visible = false;
            lblPeriodoDesde.Visible = false;
            txtPeriodoHasta.Visible = false;
            lblPeriodoHasta.Visible = false;
            chkMntBruto.Visible = false;
            ddlFmaPago.Visible = false;
            lblFmaPago.Visible = false;
            txtFchVenc.Visible = false;
            lblFchVenc.Visible = false;
            lblFchEmis.Visible = false;
            calFchEmis.Visible = false;
            ddlTipoTraslado.Visible = false;
            lblTpoTraslado.Visible = false;

            txtClauVenta.Visible = false;
            lblClauVenta.Visible = false;
            ddlModVenta.Visible = false;
            lblModVenta.Visible = false;
            ddlViaTransp.Visible = false;
            lblViaTransp.Visible = false;
        }
        private void PedirSerieNumero()
        {
            txtSerie.Visible = true;
            txtNumero.Visible = true;
        }

        private void PedirDatosFactTck()
        {
            PedirSerieNumero();
            calFchEmis.Visible = true;
            lblFchEmis.Visible = true;
            txtPeriodoDesde.Visible = true;
            lblPeriodoDesde.Visible = true;
            txtPeriodoHasta.Visible = true;
            lblPeriodoHasta.Visible = true;
            chkMntBruto.Visible = true;
            ddlFmaPago.Visible = true;
            lblFmaPago.Visible = true;
            txtFchVenc.Visible = true;
            lblFchVenc.Visible = true;
        }

        private void PedirDatosExp()
        {
            txtClauVenta.Visible = true;
            lblClauVenta.Visible = true;
            ddlModVenta.Visible = true;
            lblModVenta.Visible = true;
            ddlViaTransp.Visible = true;
            lblViaTransp.Visible = true;
        }

        private void PedirResguardo()
        {
            PedirSerieNumero();
            calFchEmis.Visible = true;
            lblFchEmis.Visible = true;
        }

        private void PedirRemito()
        {
            PedirResguardo();
            ddlTipoTraslado.Visible = true;

            lblTpoTraslado.Visible = true;
        }



        protected void ddlTipoCFE_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarTodo();
 
            switch (ddlTipoCFE.SelectedValue)
            {
                case "101" :    PedirDatosFactTck();
                                ControlItem_Fact.Visible = true;
                                break;
                case "102": goto case "101";
                case "103": goto case "101";
                case "201": goto case "101";
                case "111": goto case "101";
                case "112": goto case "101";
                case "113": goto case "101";
                case "211": goto case "101";
                case "221": goto case "101";
                case "121": ControlItem_Det_Fact_Exp.Visible = true;
                                PedirDatosFactTck();
                                PedirDatosExp();
                                break;
                case "122": goto case "121";
                case "123": goto case "121";
                case "124": ControlItem_Rem_Exp.Visible = true;
                            PedirRemito();
                            PedirDatosExp();
                            break;
                case "224": goto case "124";
                case "181": ControlItem_Rem.Visible = true;
                                PedirRemito();
                                break;
                case "281": goto case "181";
                case "182": ControlItemResg.Visible = true;  
                                PedirResguardo();
                                break;
                case "282": goto case "182";

            }

        }

        public string TpoItem
        {
            get
            {
                return ddlTipoCFE.SelectedValue;
            }
        }

        public IdDoc.IdDoc_CompFisc IdDoc
        {
            get
            {
                IdDoc_CompFisc idDoc = (IdDoc_CompFisc)Session["IdDoc"];
                idDoc.FchEmis = new FechaType(calFchEmis.SelectedDate);
                idDoc.FmaPago = LFormasDePago.BuscarFormaDePago(Convert.ToInt32(ddlFmaPago.SelectedValue));
                idDoc.MntBruto = chkMntBruto.Checked;
                idDoc.PeriodoDesde = new FechaType(Convert.ToDateTime(txtPeriodoDesde.Text));
                idDoc.PeriodoHasta = new FechaType(Convert.ToDateTime(txtPeriodoHasta.Text));
                idDoc.FchVenc = new FechaType(Convert.ToDateTime(txtFchVenc.Text));
                idDoc.ViaTransp = LViaTransp.BuscarViaTransp(Convert.ToInt32(ddlViaTransp.SelectedValue));
                idDoc.TipoTraslado = LTipoTraslado.BuscarTipoTraslado(Convert.ToInt32(ddlTipoTraslado.SelectedValue));
                idDoc.ModVenta = LModVentaType.BuscarModVenta(Convert.ToInt32(ddlModVenta.SelectedValue));
                Session["IdDoc"] = idDoc; 

                return idDoc;
            }
        }

        public List<Items.Item_Det_Fact> ItemsFactura
        {
            get
            {
                return this.ControlItem_Fact.Items;
            }
        }

        public List<Items.Item_Det_Fact_Exp> ItemsFacturaExp
        {
            get
            {
                return this.ControlItem_Det_Fact_Exp.Items;
            }
        }

        public List<Items.Item_Rem> ItemRemito
        {
            get
            {
                return this.ControlItem_Rem.Items;
            }
        }

        public List<Items.Item_Rem_Exp> ItemRemitoExp
        {
            get
            {
                return this.ControlItem_Rem_Exp.Items;
            }
        }

        public List<RetencPercepType> ItemResguardo
        {
            get
            {
                return this.ControlItemResg.Retenciones;
            }
        }
    }
}