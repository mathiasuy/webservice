<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emisores.aspx.cs" Inherits="eFacturaDGI.Emisores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 186px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Agregar Emisor<br />
        <table style="width: 62%;">
            <tr>
                <td class="style1">
                    RUC</td>
                <td>
                    <asp:TextBox ID="txtRuc" runat="server" BackColor="#99CCFF" 
                        BorderColor="#3366FF" BorderStyle="Dotted" Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Id</td>
                <td>
                    <asp:TextBox ID="txtIdEmisor" runat="server" BackColor="#99CCFF" 
                        BorderColor="#3366FF" BorderStyle="Dotted" Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Razón Social</td>
                <td>
                    <asp:TextBox ID="txtRznSoc" runat="server" BackColor="#99CCFF" 
                        BorderColor="#3366FF" BorderStyle="Dotted" Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Código DGI Sucursal</td>
                <td>
                    <asp:TextBox ID="txtCodDGISuc" runat="server" BackColor="#99CCFF" 
                        BorderColor="#3366FF" BorderStyle="Dotted" Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Domicilio Fiscal</td>
                <td>
                    <asp:TextBox ID="txtDomFiscal" runat="server" BackColor="#99CCFF" 
                        BorderColor="#3366FF" BorderStyle="Dotted" Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Ciudad</td>
                <td>
                    <asp:TextBox ID="txtCiudad" runat="server" BackColor="#99CCFF" 
                        BorderColor="#3366FF" BorderStyle="Dotted" Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Departamento</td>
                <td>
                    <asp:TextBox ID="txtDepartamento" runat="server" BackColor="#99CCFF" 
                        BorderColor="#3366FF" BorderStyle="Dotted" Width="414px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:Button ID="agregarEmisor" runat="server" Text="Agregar" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
