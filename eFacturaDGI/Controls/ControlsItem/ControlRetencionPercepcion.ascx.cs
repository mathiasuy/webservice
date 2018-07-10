using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntidadesCompartidas;
using Logica;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace eFacturaDGI.Controls.ControlsItem
{
    public partial class ControlRetencionPercepcion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<RetencPercepType> Retenciones = new List<RetencPercepType>();
                List<CodRetType> Codigos = LCodRet.ListarCodRet();
                Session["Codigos"] = Codigos;
                Session["Retenciones"] = Retenciones;
                BindData();
            }
        }

        public List<RetencPercepType> Retenciones
        {
            get
            {
                return (List<RetencPercepType>)Session["Retenciones"];
            }
        }

        protected void btnAdd(object sender, EventArgs e)
        {
            Button btnAdd = GridView1.FooterRow.FindControl("btnAdd") as Button;
            if (btnAdd != null)
            {
                TextBox txtNewMonto = GridView1.FooterRow.FindControl("txtNewMonto") as TextBox;
                if (txtNewMonto != null)
                {
                    DropDownList ddlCodRetFoot = GridView1.FooterRow.FindControl("ddlCodRetFoot") as DropDownList;
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
                        List<RetencPercepType> Retenciones = (List<RetencPercepType>)Session["Retenciones"];

                        bool tiene = false;
                        foreach (RetencPercepType r in Retenciones)
                        {
                            if (r.CodRet.Id == id)
                            {
                                //throw new ExcepcionesPersonalizadas.Presentacion("");
                                tiene = true;
                            }
                        }
                        if (tiene)
                        {
                            Response.Write("  <script language='javascript'> window.alert('El Código de Retención ya fue agregado anteriormente'); </script>");
                        }
                        else
                        {
                            CodRetType cod = LCodRet.BuscarCodRet(id);
                            RetencPercepType ret = new RetencPercepType(cod, MontoNuevo);
                            ((List<RetencPercepType>)Session["Retenciones"]).Add(ret);
                            BindData();
                        }
                    }
                    
                    
                }
            }
        }

        private void BindData()
        {
            if (!IsPostBack)
            {
                RetencPercepType ret = new RetencPercepType(LCodRet.BuscarCodRet(((List<CodRetType>)Session["Codigos"])[1].Id), 1);
                ((List<RetencPercepType>)Session["Retenciones"]).Add(ret);

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, ret);
                stream.Close();
            }

            GridView1.DataSource = ((List<RetencPercepType>)Session["Retenciones"]);
            GridView1.DataBind();

            DropDownList ddlCodRetFoot = GridView1.FooterRow.FindControl("ddlCodRetFoot") as DropDownList;
            if (ddlCodRetFoot != null)
            {
                ddlCodRetFoot.DataSource = (List<CodRetType>)Session["Codigos"];
                ddlCodRetFoot.DataTextField = "Id";
                ddlCodRetFoot.DataValueField = "Tasa";
                ddlCodRetFoot.DataBind();
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
            ((List<RetencPercepType>)Session["Retenciones"])[e.RowIndex] = ret;
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