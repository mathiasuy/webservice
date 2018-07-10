using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using Items;

namespace eFacturaDGI.Controls.ControlsItem
{
    public partial class ControlItem_Rem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Item_Rem> ItemsRem = new List<Item_Rem>();
                Item_Rem Item = new Item_Rem(0, "", null, "", "", 0, null);
                ItemsRem.Add(Item);
                List<IndicadorFacturaType> ListaIndFact = LIndicadorFacturaType.ListarIndicadorFactura();
                List<UnidadesDeMedida> ListaUniMed = LUnidadesDeMedida.ListarUnidadesDeMedida();
                Session["ListaIndFact"] = ListaIndFact;
                Session["ItemsRem"] = ItemsRem;
                Session["ListaUniMed"] = ListaUniMed;
                BindData();
            }
        }

        public List<Item_Rem> Items
        {
            get
            {
                return (List<Item_Rem>)Session["ItemsRem"];
            }
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

                DropDownList ddlIndFact = GridView1.FooterRow.FindControl("ddlIndFact") as DropDownList;
                IndicadorFacturaType IndFact = LIndicadorFacturaType.BuscarIndicadorFactura(Convert.ToInt32(ddlIndFact.SelectedValue));
                DropDownList ddlUniMed = GridView1.FooterRow.FindControl("ddlUniMed") as DropDownList;
                UnidadesDeMedida UniMed = LUnidadesDeMedida.BuscarUnidadDeMedida(Convert.ToInt32(ddlUniMed.SelectedValue));
                Item_Rem Item = new Item_Rem(((List<Item_Rem>)Session["ItemsRem"]).Count + 1, CodItem, IndFact, NomItem, DscItem, Cantidad, UniMed);

                ((List<Item_Rem>)Session["ItemsRem"]).Add(Item);
                BindData();
            }
        }

        private void BindData()
        {
            GridView1.DataSource = ((List<Item_Rem>)Session["ItemsRem"]);
            GridView1.DataBind();
            TextBox txtCodItem = GridView1.FooterRow.FindControl("txtCodItem") as TextBox;
            if (txtCodItem != null)
            {
                TextBox txtNomItem = GridView1.FooterRow.FindControl("txtNomItem") as TextBox;
                TextBox txtDscItem = GridView1.FooterRow.FindControl("txtDscItem") as TextBox;
                TextBox txtCantidad = GridView1.FooterRow.FindControl("txtCantidad") as TextBox;

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
                foreach (Item_Rem t in (List<Item_Rem>)Session["ItemsRem"])
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
                DropDownList ddlIndFact = GridView1.Rows[e.RowIndex].FindControl("ddlIndFact") as DropDownList;
                IndicadorFacturaType IndFact = LIndicadorFacturaType.BuscarIndicadorFactura(Convert.ToInt32(ddlIndFact.SelectedValue));

                DropDownList ddlUniMed = GridView1.Rows[e.RowIndex].FindControl("ddlUniMed") as DropDownList;
                UnidadesDeMedida UniMed = LUnidadesDeMedida.BuscarUnidadDeMedida(Convert.ToInt32(ddlUniMed.SelectedValue));

                Label lblNroLinDet = GridView1.Rows[e.RowIndex].FindControl("lblNroLinDet") as Label;

                int NroLinDet = Convert.ToInt32(lblNroLinDet.Text);

                Item_Rem Item = new Item_Rem(NroLinDet, CodItem, IndFact, NomItem, DscItem, Cantidad, UniMed);

                ((List<Item_Rem>)Session["ItemsRem"])[e.RowIndex] = Item;
                GridView1.EditIndex = -1;
                BindData();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ((List<Item_Rem>)Session["ItemsRem"]).RemoveAt(e.RowIndex);
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

    }
}