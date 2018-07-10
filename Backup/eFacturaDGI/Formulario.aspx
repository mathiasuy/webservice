<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="eFacturaDGI.Formulario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 163px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 724px">
    
        <br />
        j<br />
        <asp:Button ID="datosEmisor" runat="server" onclick="BotonDatosEmisor" 
            Text="Datos Empresa" />
        <asp:Panel ID="panelEmisor" runat="server">
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="style1">
                        RUC</td>
                    <td>
                        <asp:TextBox ID="RUCEmisor" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Id</td>
                    <td>
                        <asp:TextBox ID="Idemisor" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Razón Social</td>
                    <td>
                        <asp:TextBox ID="RznSoc" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Código DGI sucursal</td>
                    <td>
                        <asp:TextBox ID="CdgDGISucur" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Domicilio Fiscal</td>
                    <td>
                        <asp:TextBox ID="DomFiscal" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Ciudad</td>
                    <td>
                        <asp:TextBox ID="Ciudad" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Departamento</td>
                    <td>
                        <asp:TextBox ID="Departamento" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="datosReceptor" runat="server" onclick="BotonDatosReceptor" 
            Text="Datos Receptor" />
        <asp:Panel ID="panelReceptor" runat="server">
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="style1">
                        Tipo doc. Receptor</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="218px">
                            <asp:ListItem Selected="True" Value="3">CI Uruguaya</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Documento</td>
                    <td>
                        <asp:TextBox ID="DocRecep" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Razón Social</td>
                    <td>
                        <asp:TextBox ID="RznSocRecep" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Dirección</td>
                    <td>
                        <asp:TextBox ID="direccion" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Ciudad</td>
                    <td>
                        <asp:TextBox ID="Ciudad0" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="datosFactura" runat="server" onclick="BotonDatosFactura" 
            Text="Datos Factura" />
        <asp:Panel ID="panelFactura" runat="server">
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="style1">
                        Tipo doc. Receptor</td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="218px">
                            <asp:ListItem Selected="True" Value="3">CI Uruguaya</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Documento</td>
                    <td>
                        <asp:TextBox ID="DocRecep0" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Razón Social</td>
                    <td>
                        <asp:TextBox ID="RznSoc1" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Domicilio Fiscal</td>
                    <td>
                        <asp:TextBox ID="DomFiscal1" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Ciudad</td>
                    <td>
                        <asp:TextBox ID="Ciudad1" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <br />
        j </form>
        </div>
</body>
</html>
