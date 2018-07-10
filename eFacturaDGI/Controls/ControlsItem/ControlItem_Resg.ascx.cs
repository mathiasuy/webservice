using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using Items;

using System.Data;
using EntidadesCompartidas;
using Logica;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace eFacturaDGI.Controls.ControlsItem
{
    public partial class ControlItem_Resg : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Item_Resg> Resguardos = new List<Item_Resg>();
                List<RetencPercepType> Retenciones = new List<RetencPercepType>();
                Item_Resg dummie = new Item_Resg(0, null, Retenciones);

                Resguardos.Add(dummie);
                Session["ItemsRes"] = Resguardos;
                BindData();
            }
        }

        public List<Item_Resg> Items
        {
            get
            {
                return (List<Item_Resg>)Session["Retenciones"];
            }
        }

        protected void btnAdd(object sender, EventArgs e)
        {
            Button btnAdd = GridView1.FooterRow.FindControl("btnAdd") as Button;
            if (btnAdd != null)
            {
                TextBox txtNewMonto = GridView1.FooterRow.FindControl("txtMonto") as TextBox;
                if (txtNewMonto != null)
                {
                    DropDownList ddlCodRetFoot = GridView1.FooterRow.FindControl("ddlCodRet") as DropDownList;
                    if (ddlCodRetFoot != null)
                    {
                        string id = ddlCodRetFoot.SelectedItem.Text;
                        decimal MontoNuevo;
                        try
                        {
                            MontoNuevo = Convert.ToInt32(txtNewMonto.Text);
                        }
                        catch (ExcepcionesPersonalizadas.Presentacion ex)
                        {
                            throw new ExcepcionesPersonalizadas.Presentacion("Debe ingresar el monto nuevo");
                        }
                        DropDownList ddlIndFact = GridView1.FooterRow.FindControl("ddlIndFact") as DropDownList;

                        int idInd = Convert.ToInt32(ddlIndFact.SelectedValue);
                        IndicadorFacturaType IndFact = LIndicadorFacturaType.BuscarIndicadorFactura(idInd);
                        CodRetType cod = LCodRet.BuscarCodRet(id);
                        RetencPercepType ret = new RetencPercepType(cod, MontoNuevo);
                        List<RetencPercepType> l = new List<EntidadesCompartidas.RetencPercepType>();
                        l.Add(ret);
                        Item_Resg item = new Item_Resg(((List<Item_Resg>)Session["ItemsRes"]).Count,IndFact,l);
                        BindData();
                    }


                }
            }
        }

        private void BindData()
        {
            GridView1.DataSource = (List<Item_Resg>)Session["ItemsRes"];
            GridView1.DataBind();

            DropDownList ddlIndFact = GridView1.FooterRow.FindControl("ddlIndFact") as DropDownList;
            ddlIndFact.DataSource = LIndicadorFacturaType.ListarIndicadorFactura();
            ddlIndFact.DataValueField = "Id";
            ddlIndFact.DataTextField = "Nombre";
            ddlIndFact.DataBind();

            TextBox txtMonto = GridView1.FooterRow.FindControl("txtMonto") as TextBox;

            DropDownList ddlCodRet = GridView1.FooterRow.FindControl("ddlCodRet") as DropDownList;
            ddlCodRet.DataSource = LCodRet.ListarCodRet();
            ddlCodRet.DataValueField = "Tasa";
            ddlCodRet.DataTextField = "Id";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblNroLinDet = (Label)e.Row.FindControl("lblNroLinDet");
                int NroLin = (e.Row.RowIndex + 1) + (GridView1.PageIndex * GridView1.PageSize);
                lblNroLinDet.Text = NroLin.ToString();
                int cont = 0;
                foreach (Item_Resg t in (List<Item_Resg>)Session["ItemsRes"])
                {
                    cont++;
                    t.NroLinDet = cont;
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();

            BindData();

            DropDownList ddlCodRet = GridView1.Rows[e.NewEditIndex].FindControl("ddlCodRet") as DropDownList;

            if (ddlCodRet != null)
            {
                ddlCodRet.DataSource = LCodRet.ListarCodRet();
                ddlCodRet.DataTextField = "Id";
                ddlCodRet.DataValueField = "Tasa";
                ddlCodRet.DataBind();
            }

            ddlCodRet.SelectedValue = id.ToString();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtMonto = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMonto");
            DropDownList ddlCodRet = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlCodRet") as DropDownList;
            decimal Monto;
            try
            {
                Monto = Convert.ToDecimal(txtMonto.Text);
            }
            catch (ExcepcionesPersonalizadas.Presentacion ex)
            {
                throw new ExcepcionesPersonalizadas.Presentacion("Debe ingresar el monto");
            }

            CodRetType cod = LCodRet.BuscarCodRet(ddlCodRet.SelectedItem.Text);
            RetencPercepType ret = new RetencPercepType(cod, Monto);

            DropDownList ddlIndFact = GridView1.Rows[e.RowIndex].FindControl("ddlIndFact") as DropDownList;
            int idInd = Convert.ToInt32(ddlIndFact.SelectedValue);
            IndicadorFacturaType IndFact = LIndicadorFacturaType.BuscarIndicadorFactura(idInd);
            List<RetencPercepType> l = new List<EntidadesCompartidas.RetencPercepType>();
            l.Add(ret);
            Item_Resg item = new Item_Resg(((List<Item_Resg>)Session["ItemsRes"]).Count,IndFact,l);

            GridView1.EditIndex = -1;
            BindData();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ((List<RetencPercepType>)Session["Retenciones"]).RemoveAt(e.RowIndex);
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }


    }
}