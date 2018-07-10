<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodRetenciones.aspx.cs" Inherits="eFacturaDGI.Forms.CodRetenciones" %>
<%@ Register src="../Controls/ControlsItem/ControlRetencionPercepcion.ascx" tagname="ControlRetencionPercepcion" tagprefix="uc1" %>

<form id="form1" runat="server">
<uc1:ControlRetencionPercepcion ID="ControlRetencionPercepcion1" 
    runat="server" />
<asp:Button ID="btnCerrar" runat="server" onclick="btnCerrar_Click" 
    Text="Cerrar" />
</form>

