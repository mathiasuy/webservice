<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="eFacturaDGI.Formulario" %>
<%@ Register src="../Controls/ControlEmisor.ascx" tagname="ControlEmisor" tagprefix="uc1" %>
<%@ Register src="../Controls/ControlIdDoc.ascx" tagname="ControlIdDoc" tagprefix="uc2" %>
<%@ Register src="../Controls/ControlReceptor.ascx" tagname="ControlReceptor" tagprefix="uc3" %>
<%@ Register src="../Controls/ControlsItem/ControlFact.ascx" tagname="ControlFact" tagprefix="uc5" %>
<%@ Register src="../Controls/ControlsItem/ControlRetencionPercepcion.ascx" tagname="ControlRetencionPercepcion" tagprefix="uc6" %>
<%@ Register src="../Controls/ControlsItem/ControlItem_Det_Fact_Exp.ascx" tagname="ControlItem_Det_Fact_Exp" tagprefix="uc8" %>
<%@ Register src="../Controls/ControlsItem/ControlItem_Rem.ascx" tagname="ControlItem_Rem" tagprefix="uc4" %>
<%@ Register src="../Controls/ControlsItem/ControlItem_Rem_Exp.ascx" tagname="ControlItem_Rem_Exp" tagprefix="uc7" %>
<%@ Register src="../Controls/ControlsItem/ControlItem_Resg.ascx" tagname="ControlItem_Resg" tagprefix="uc9" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc1:ControlEmisor ID="ControlEmisor1" runat="server" />
    <br />
    <uc3:ControlReceptor ID="ControlReceptor1" runat="server" />
    <br />
    <br />
    <uc2:ControlIdDoc ID="ControlIdDoc1" runat="server" />
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnProcesar" runat="server" onclick="btnProcesar_Click" 
        Text="Procesar" />
    <br />
</form>
</body>
</html>
