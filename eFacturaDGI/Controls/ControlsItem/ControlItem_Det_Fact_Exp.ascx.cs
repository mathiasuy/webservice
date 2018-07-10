using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using Items;

using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace eFacturaDGI.Controls.ControlsItem
{
    public partial class ControlItem_Det_Fact_Exp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Item_Det_Fact_Exp> ItemsFactExp = new List<Item_Det_Fact_Exp>();
                Item_Det_Fact_Exp Item = new Item_Det_Fact_Exp(0, "", null, "", "", 0, null, 0);
                ItemsFactExp.Add(Item);
                List<IndicadorFacturaType> ListaIndFact = LIndicadorFacturaType.ListarIndicadorFactura();
                List<UnidadesDeMedida> ListaUniMed = LUnidadesDeMedida.ListarUnidadesDeMedida();
                Session["ListaIndFact"] = ListaIndFact;
                Session["ItemsFactExp"] = ItemsFactExp;
                Session["ListaUniMed"] = ListaUniMed;
                BindData();
            }
        }

        public List<Item_Det_Fact_Exp> Items
        {
            get
            {
                return (List<Item_Det_Fact_Exp>)Session["ItemsFactExp"];
            }
        }

        protected void ClickbtnRet(object sender, EventArgs e)
        {
            string dir = string.Format("<script language='JavaScript'>window.open('CodRetenciones.aspx?id={0}','MyPage','width=510, Height=550')</script>", 0);
            this.Response.Write(dir);
        }

        protected void btnAdd(object sender, EventArgs e)
        {
            Button btnAdd = GridView1.FooterRow.FindControl("btnAdd") as Button;
            if (btnAdd != null)
            {
                TextBox txtCodItem = GridView1.FooterRow.FindControl("txtCodItem") as TextBox;
                string CodItem = txtCodItem.Text;
                TextBox txtNomItem = GridView1.FooterRow.FindControl("txtNomItem") as TextBox;
                string NomItem = txtNomItem.Text;
                TextBox txtDscItem = GridView1.FooterRow.FindControl("txtDscItem") as TextBox;
                string DscItem = txtDscItem.Text;
                TextBox txtCantidad = GridView1.FooterRow.FindControl("txtCantidad") as TextBox;
                int Cantidad = 0;
                try
                {
                    Cantidad = Convert.ToInt32(txtCantidad.Text);
                }
                catch (ExcepcionesPersonalizadas.Presentacion ex)
                {
                    throw new ExcepcionesPersonalizadas.Presentacion("Debe indicar la cantidad de elementos del item");
                }
                TextBox txtPrecioUnitario = GridView1.FooterRow.FindControl("txtPrecioUnitario") as TextBox;
                decimal PrecioUnitario = 0;
                try
                {
                    PrecioUnitario = Convert.ToInt32(txtPrecioUnitario.Text);
                }
                catch (ExcepcionesPersonalizadas.Presentacion ex)
                {
                    throw new ExcepcionesPersonalizadas.Presentacion("Debe indicar el Precio de el elemento del item");
                }

                DropDownList ddlIndFact = GridView1.FooterRow.FindControl("ddlIndFact") as DropDownList;
                IndicadorFacturaType IndFact = LIndicadorFacturaType.BuscarIndicadorFactura(Convert.ToInt32(ddlIndFact.SelectedValue));
                DropDownList ddlUniMed = GridView1.FooterRow.FindControl("ddlUniMed") as DropDownList;
                UnidadesDeMedida UniMed = LUnidadesDeMedida.BuscarUnidadDeMedida(Convert.ToInt32(ddlUniMed.SelectedValue));
                Item_Det_Fact_Exp Item = new Item_Det_Fact_Exp(((List<Item_Det_Fact_Exp>)Session["ItemsFactExp"]).Count + 1, CodItem, IndFact, NomItem, DscItem, Cantidad, UniMed, PrecioUnitario);

                ((List<Item_Det_Fact_Exp>)Session["ItemsFactExp"]).Add(Item);
                BindData();
            }
        }

        private void BindData()
        {
            GridView1.DataSource = ((List<Item_Det_Fact_Exp>)Session["ItemsFactExp"]);
            GridView1.DataBind();
            TextBox txtCodItem = GridView1.FooterRow.FindControl("txtCodItem") as TextBox;
            if (txtCodItem != null)
            {
                TextBox txtNomItem = GridView1.FooterRow.FindControl("txtNomItem") as TextBox;
                TextBox txtDscItem = GridView1.FooterRow.FindControl("txtDscItem") as TextBox;
                TextBox txtCantidad = GridView1.FooterRow.FindControl("txtCantidad") as TextBox;
                TextBox txtPrecioUnitario = GridView1.FooterRow.FindControl("txtPrecioUnitario") as TextBox;

                DropDownList ddlIndFact = GridView1.FooterRow.FindControl("ddlIndFact") as DropDownList;
                if (ddlIndFact != null)
                {
                    ddlIndFact.DataSource = (List<IndicadorFacturaType>)Session["ListaIndFact"];
                    ddlIndFact.DataValueField = "Id";
                    ddlIndFact.DataTextField = "Nombre";
                    ddlIndFact.DataBind();
                }

                DropDownList ddlUniMed = GridView1.FooterRow.FindControl("ddlUniMed") as DropDownList;
                if (ddlUniMed != null)
                {
                    ddlUniMed.DataSource = (List<UnidadesDeMedida>)Session["ListaUniMed"];
                    ddlUniMed.DataValueField = "Id";
                    ddlUniMed.DataTextField = "Nombre";
                    ddlUniMed.DataBind();
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            DropDownList ddlIndFact = GridView1.Rows[e.NewEditIndex].FindControl("ddlIndFact") as DropDownList;
            if (ddlIndFact != null)
            {
                ddlIndFact.DataSource = (List<IndicadorFacturaType>)Session["ListaIndFact"];
                ddlIndFact.DataValueField = "Id";
                ddlIndFact.DataTextField = "Nombre";
                ddlIndFact.DataBind();
            }

            //Button btnRet = GridView1.Rows[e.NewEditIndex].FindControl("btnRet") as Button;
            //"<script language='JavaScript'>window.open('CodRetenciones.aspx?id={0}','MyPage','width=390, Height=150')</script>", Convert.ToInt32(e.NewEditIndex)

            //string dir = string.Format("javascript:windows.alert('message')");
            //btnRet.Attributes.Add("OnClick", VerRet(Convert.ToInt32(e.NewEditIndex)));


            DropDownList ddlUniMed = GridView1.Rows[e.NewEditIndex].FindControl("ddlUniMed") as DropDownList;
            if (ddlUniMed != null)
            {
                ddlUniMed.DataSource = (List<UnidadesDeMedida>)Session["ListaUniMed"];
                ddlUniMed.DataValueField = "Id";
                ddlUniMed.DataTextField = "Nombre";
                ddlUniMed.DataBind();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblNroLinDet = (Label)e.Row.FindControl("lblNroLinDet");
                int NroLin = (e.Row.RowIndex + 1) + (GridView1.PageIndex * GridView1.PageSize);
                lblNroLinDet.Text = NroLin.ToString();
                int cont = 0;
                foreach (Item_Det_Fact_Exp t in (List<Item_Det_Fact_Exp>)Session["ItemsFactExp"])
                {
                    cont++;
                    t.NroLinDet = cont;
                }
            }
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtCodItem = GridView1.Rows[e.RowIndex].FindControl("txtCodItem") as TextBox;
            if (txtCodItem != null)
            {
                string CodItem = txtCodItem.Text;
                TextBox txtNomItem = GridView1.Rows[e.RowIndex].FindControl("txtNomItem") as TextBox;
                string NomItem = txtNomItem.Text;
                TextBox txtDscItem = GridView1.Rows[e.RowIndex].FindControl("txtDscItem") as TextBox;
                string DscItem = txtDscItem.Text;
                TextBox txtCantidad = GridView1.Rows[e.RowIndex].FindControl("txtCantidad") as TextBox;
                int Cantidad = 0;
                try
                {
                    Cantidad = Convert.ToInt32(txtCantidad.Text);
                }
                catch (ExcepcionesPersonalizadas.Presentacion ex)
                {
                    throw new ExcepcionesPersonalizadas.Presentacion("Debe indicar la cantidad de elementos del item");
                }
                TextBox txtPrecioUnitario = GridView1.Rows[e.RowIndex].FindControl("txtPrecioUnitario") as TextBox;
                decimal PrecioUnitario = 0;
                try
                {
                    PrecioUnitario = Convert.ToInt32(txtPrecioUnitario.Text);
                }
                catch (ExcepcionesPersonalizadas.Presentacion ex)
                {
                    throw new ExcepcionesPersonalizadas.Presentacion("Debe indicar el Precio de el elemento del item");
                }

                DropDownList ddlIndFact = GridView1.Rows[e.RowIndex].FindControl("ddlIndFact") as DropDownList;
                IndicadorFacturaType IndFact = LIndicadorFacturaType.BuscarIndicadorFactura(Convert.ToInt32(ddlIndFact.SelectedValue));

                DropDownList ddlUniMed = GridView1.Rows[e.RowIndex].FindControl("ddlUniMed") as DropDownList;
                UnidadesDeMedida UniMed = LUnidadesDeMedida.BuscarUnidadDeMedida(Convert.ToInt32(ddlUniMed.SelectedValue));

                Label lblNroLinDet = GridView1.Rows[e.RowIndex].FindControl("lblNroLinDet") as Label;

                int NroLinDet = Convert.ToInt32(lblNroLinDet.Text);

                Item_Det_Fact_Exp Item = new Item_Det_Fact_Exp(NroLinDet, CodItem, IndFact, NomItem, DscItem, Cantidad, UniMed, PrecioUnitario);

                ((List<Item_Det_Fact_Exp>)Session["ItemsFactExp"])[e.RowIndex] = Item;
                GridView1.EditIndex = -1;
                BindData();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ((List<Item_Det_Fact_Exp>)Session["ItemsFactExp"]).RemoveAt(e.RowIndex);
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
    }
}