<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlEmisor.ascx.cs" Inherits="eFacturaDGI.Controls.ControlEmisor" %>

        <style type="text/css">
            .style2
            {
                width: 584px;
            }
            .style3
            {
                width: 227px;
            }
            .style4
            {
                width: 173px;
            }
        </style>

        <asp:Button ID="datosEmisor" runat="server" onclick="BotonDatosEmisor" 
            Text="Datos Emisor" />
            <asp:DropDownList ID="ddlEmisores" runat="server" Height="16px" Width="311px" 
                AutoPostBack="True" 
                onselectedindexchanged="CargarEmisor"  >
            </asp:DropDownList>
        <asp:Panel ID="panelEmisor" runat="server">
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblRuc" runat="server" AssociatedControlID="txtRUCEmisor" 
                            Text="RUC"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtRUCEmisor" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblIdEmisor" runat="server" 
                            AssociatedControlID="lblIdEmisorMostrar" Text="Id"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Label ID="lblIdEmisorMostrar" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblRznSoc" runat="server" AssociatedControlID="txtRznSoc" 
                            Text="Razón Social"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtRznSoc" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblCodDGIDuc" runat="server" 
                            AssociatedControlID="txtCdgDGISucur" Text="Código DGI sucursal"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtCdgDGISucur" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblDomFiscal" runat="server" AssociatedControlID="txtDomFiscal" 
                            Text="Domicilio Fiscal"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtDomFiscal" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblCiudad" runat="server" AssociatedControlID="txtCiudad" 
                            Text="Ciudad"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtCiudad" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblDepartamento" runat="server" 
                            AssociatedControlID="txtDepartamento" Text="Departamento"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtDepartamento" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblNombreComercial" runat="server" 
                            AssociatedControlID="txtNomComercial" Text="NomComercial"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtNomComercial" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblGiroEmis" runat="server" AssociatedControlID="txtGiroEmis" 
                            Text="GiroEmis"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtGiroEmis" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblTelefono1" runat="server" AssociatedControlID="txtTelefono1" 
                            Text="Telefono1"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtTelefono1" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblCorreoEmisor" runat="server" 
                            AssociatedControlID="txtCorreoEmisor" Text="CorreoEmisor"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtCorreoEmisor" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblEmiSucursal" runat="server" 
                            AssociatedControlID="txtEmiSucursal" Text="EmiSucursal"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtEmiSucursal" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Button ID="btnLimpiarEmisor0" runat="server" 
                            onclick="btnLimpiarEmisor_Click" Text="Limpiar" />
                    </td>
                    <td style="text-align: right" class="style2">
                        &nbsp;<asp:Label ID="lblMensajeEmisor" runat="server"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnAgregarEmisor" runat="server" Height="23px" 
                            onclick="btnAgregarEmisor_Click" Text="Agregar" Width="85px" />
&nbsp;
                        <asp:Button ID="btnModificarEmisor" runat="server" 
                            onclick="btnModificarEmisor_Click" style="text-align: right" 
                            Text="Modificar" />
                        <asp:Label ID="lblIdEmisor2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>