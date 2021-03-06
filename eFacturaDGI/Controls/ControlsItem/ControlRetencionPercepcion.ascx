﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlRetencionPercepcion.ascx.cs" Inherits="eFacturaDGI.Controls.ControlsItem.ControlRetencionPercepcion" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"

AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None"
AutoGenerateDeleteButton="true"
DataKeyNames="CodRet"

onrowediting="GridView1_RowEditing"

onrowcancelingedit="GridView1_RowCancelingEdit"

onrowupdating="GridView1_RowUpdating"

OnRowDeleting="GridView1_RowDeleting"

ShowFooter="True"


>



<RowStyle BackColor="#EFF3FB" />

<Columns>
    <asp:TemplateField  HeaderText="Monto">
           <EditItemTemplate> 
            <asp:TextBox ID="txtMonto" runat="server" Text='<%# Bind("MntSujetoaRet") %>'></asp:TextBox> 
           </EditItemTemplate> 
           <FooterTemplate> 
            <asp:TextBox ID="txtNewMonto" runat="server" ></asp:TextBox> 
           </FooterTemplate> 
           <ItemTemplate> 
            <asp:Label ID="lblMonto" runat="server" Text='<%# Bind("MntSujetoaRet") %>'></asp:Label> 
           </ItemTemplate>
    </asp:TemplateField>
</Columns>
<Columns>
    <asp:TemplateField  HeaderText="Codigo de Retencion">
        <ItemTemplate>
            <asp:Label  ID="lblCodRet" runat="server" Text='<%# Bind("CodRet") %>'> ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:DropDownList DataField="CodRet" ID="ddlCodRet" runat="server" ></asp:DropDownList>
        </EditItemTemplate>
        <FooterTemplate> 
            <asp:DropDownList DataField="CodRet" ID="ddlCodRetFoot" runat="server"></asp:DropDownList>
        </FooterTemplate> 
    </asp:TemplateField>
</Columns>
<Columns>
    <asp:TemplateField HeaderText="Valor del Monto">
        <ItemTemplate>
            <asp:Label ID="lblValorMonto" runat="server" Text='<%# Bind("ValRetPerc") %>'> ></asp:Label>
        </ItemTemplate>
        <FooterTemplate> 
            <asp:Button ID="btnAdd" runat="server" Text="+" onclick="btnAdd" ></asp:Button> 
        </FooterTemplate> 
    </asp:TemplateField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

<EditRowStyle BackColor="#2461BF" />

<AlternatingRowStyle BackColor="White" />

</asp:GridView>

