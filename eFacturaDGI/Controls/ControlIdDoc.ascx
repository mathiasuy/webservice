<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlIdDoc.ascx.cs" Inherits="eFacturaDGI.Controls.ControlIdDoc" %>
<%@ Register src="ControlsItem/ControlFact.ascx" tagname="ControlFact" tagprefix="uc1" %>
<%@ Register src="ControlsItem/ControlItem_Det_Fact_Exp.ascx" tagname="ControlItem_Det_Fact_Exp" tagprefix="uc2" %>
<%@ Register src="ControlsItem/ControlItem_Rem.ascx" tagname="ControlItem_Rem" tagprefix="uc3" %>
<%@ Register src="ControlsItem/ControlItem_Rem_Exp.ascx" tagname="ControlItem_Rem_Exp" tagprefix="uc4" %>
<%@ Register src="ControlsItem/ControlItem_Resg.ascx" tagname="ControlItem_Resg" tagprefix="uc5" %>

<%@ Register src="ControlsItem/ControlRetencionPercepcion.ascx" tagname="ControlRetencionPercepcion" tagprefix="uc6" %>

<style type="text/css">

        .style6
        {
            width: 18px;
        }
        .style7
        {
            width: 18px;
            height: 70px;
        }
        .style8
        {
            height: 70px;
        }
    </style>

        <asp:Panel ID="panelFactura" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblTipoCFE" runat="server" AssociatedControlID="ddlTipoCFE" 
                            Text="Tipo de CFE"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="ddlTipoCFE" runat="server" Height="16px" 
                            AutoPostBack="True" onselectedindexchanged="ddlTipoCFE_SelectedIndexChanged" 
                             Width="232px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblSerie" runat="server" AssociatedControlID="txtSerie" 
                            Text="Serie"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtSerie" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="33px"></asp:TextBox>
                        Nro:
                        <asp:TextBox ID="txtNumero" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="151px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblFchEmis" runat="server" AssociatedControlID="calFchEmis" 
                            Text="Fecha de emisión"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:Calendar ID="calFchEmis" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblPeriodoDesde" runat="server" 
                            AssociatedControlID="txtPeriodoDesde" Text="Periodo Desde"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtPeriodoDesde" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblPeriodoHasta" runat="server" 
                            AssociatedControlID="txtPeriodoHasta" Text="Periodo Hasta"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtPeriodoHasta" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        </td>
                    <td class="style8">
                        <asp:CheckBox ID="chkMntBruto" runat="server" Text="Monto Bruto" />
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblFmaPago" runat="server" AssociatedControlID="ddlFmaPago" 
                            Text="Forma de pago"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="ddlFmaPago" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblFchVenc" runat="server" AssociatedControlID="txtFchVenc" 
                            Text="Fecha de vencimiento"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtFchVenc" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblClauVenta" runat="server" AssociatedControlID="txtClauVenta" 
                            Text="Clausula de venta"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtClauVenta" runat="server" BorderColor="#6699FF" 
                            BorderStyle="Dotted" Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblModVenta" runat="server" AssociatedControlID="ddlModVenta" 
                            Text="Modalidad de venta"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="ddlModVenta" runat="server" Height="16px" Width="240px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblViaTransp" runat="server" AssociatedControlID="ddlViaTransp" 
                            Text="Vía de transporte"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="ddlViaTransp" runat="server" Height="28px" Width="238px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;<asp:Label ID="lblTpoTraslado" runat="server" 
                            AssociatedControlID="ddlTipoTraslado" Text="Tipo Traslado"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="ddlTipoTraslado" runat="server" Height="16px" 
                            Width="238px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
<br />
<uc1:ControlFact                ID="ControlItem_Fact"               runat="server" />
<uc2:ControlItem_Det_Fact_Exp   ID="ControlItem_Det_Fact_Exp"       runat="server" />
<uc3:ControlItem_Rem            ID="ControlItem_Rem"                runat="server" />
<uc4:ControlItem_Rem_Exp        ID="ControlItem_Rem_Exp"            runat="server" />
<uc6:ControlRetencionPercepcion ID="ControlItemResg"    runat="server" />
        </asp:Panel>
        



        



        



        

