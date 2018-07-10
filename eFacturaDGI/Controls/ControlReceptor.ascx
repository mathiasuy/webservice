<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlReceptor.ascx.cs" Inherits="eFacturaDGI.Controls.ControlReceptor" %>

        <style type="text/css">
            .style1
            {
                text-align: left;
                width: 162px;
            }
            .style2
            {
                width: 162px;
            }
        </style>

        <asp:Button ID="datos" runat="server" onclick="BotonDatos" 
            Text="Datos Receptor" />
            <asp:DropDownList ID="ddlReceptores" runat="server" Height="18px" Width="379px" 
                AutoPostBack="True" 
                onselectedindexchanged="CargarReceptor" >
            </asp:DropDownList>
        <asp:Panel ID="panel" runat="server">
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblIdReceptor" runat="server" Text="Receptor ID:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblVerIdReceptor" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblTipoDoc" runat="server" 
                            AssociatedControlID="ddlTipoDoc" Text="Tipo documento"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoDoc" runat="server" Height="16px" 
                            Width="218px">
                            <asp:ListItem Selected="True" Value="3">CI Uruguaya</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblDocumento" runat="server" 
                            AssociatedControlID="txtDoc" Text="Documento"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtDoc" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblRznSoc" runat="server" AssociatedControlID="txtRznSoc" 
                            Text="Razón Social"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRznSoc" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblPais" runat="server" AssociatedControlID="ddlPais" 
                            Text="País"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPais" runat="server" Height="16px" Width="219px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblCiudad" runat="server" 
                            AssociatedControlID="txtCiudad" Text="Ciudad"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCiudad" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblDirección" runat="server" 
                            AssociatedControlID="txtDireccion" Text="Dirección"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblDepto" runat="server" 
                            AssociatedControlID="txtDepartamento" Text="Departamento"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepartamento" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblCP" runat="server" AssociatedControlID="txtCP" Text="CP"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCP" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblInfoAdic" runat="server" 
                            AssociatedControlID="txtInformacionAdicional" Text="Información Adicional"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInformacionAdicional" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblLugarDest" runat="server" 
                            AssociatedControlID="txtLugarDestinatario" Text="Lugar Destinatario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLugarDestinatario" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblCompraID" runat="server" AssociatedControlID="txtCompraID" 
                            Text="Compra ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompraID" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                            onclick="btnLimpiar_Click" />
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        &nbsp;
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                            Width="107px" Height="25px" onclick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" 
                            onclick="btnModificar_Click" style="text-align: right" 
                            Text="Modificar" />
                    </td>
                </tr>
            </table>
        </asp:Panel>