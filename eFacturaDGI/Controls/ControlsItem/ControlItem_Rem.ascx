﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlItem_Rem.ascx.cs" Inherits="eFacturaDGI.Controls.ControlsItem.ControlItem_Rem" %>
<%@ Register src="ControlRetencionPercepcion.ascx" tagname="ControlRetencionPercepcion" tagprefix="uc1" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None"
AutoGenerateDeleteButton="true" DataKeyNames="NroLinDet"

onrowediting="GridView1_RowEditing" onrowcancelingedit="GridView1_RowCancelingEdit"
onRowDataBound="GridView1_RowDataBound"
onrowupdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" ShowFooter="True" > <RowStyle BackColor="#EFF3FB" />
<Columns>
    <asp:TemplateField  HeaderText="Linea">
           <ItemTemplate> 
            <asp:Label ID="lblNroLinDet" runat="server" Text='<%# Bind("NroLinDet") %>'></asp:Label> 
           </ItemTemplate>
    </asp:TemplateField>
</Columns>
<Columns>
    <asp:TemplateField  HeaderText="Codigo">
           <EditItemTemplate> 
            <asp:TextBox ID="txtCodItem" runat="server" Text='<%# Bind("CodItem") %>'></asp:TextBox> 
           </EditItemTemplate> 
           <FooterTemplate> 
            <asp:TextBox ID="txtCodItem" runat="server" ></asp:TextBox> 
           </FooterTemplate> 
           <ItemTemplate> 
            <asp:Label ID="lblCodItem" runat="server" Text='<%# Bind("CodItem") %>'></asp:Label> 
           </ItemTemplate>
    </asp:TemplateField>
</Columns>
<Columns>
    <asp:TemplateField  HeaderText="Indicador">
        <ItemTemplate>
            <asp:Label  ID="lblIndFact" runat="server" Text='<%# Bind("IndFact") %>'> ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:DropDownList DataField="IndFact" ID="ddlIndFact" runat="server" ></asp:DropDownList>
        </EditItemTemplate>
        <FooterTemplate> 
            <asp:DropDownList DataField="IndFact" ID="ddlIndFact" runat="server"></asp:DropDownList>
        </FooterTemplate> 
    </asp:TemplateField>
</Columns>
<Columns>
    <asp:TemplateField  HeaderText="Nombre">
           <EditItemTemplate> 
            <asp:TextBox ID="txtNomItem" runat="server" Text='<%# Bind("NomItem") %>'></asp:TextBox> 
           </EditItemTemplate> 
           <FooterTemplate> 
            <asp:TextBox ID="txtNomItem" runat="server" ></asp:TextBox> 
           </FooterTemplate> 
           <ItemTemplate> 
            <asp:Label ID="lblNomItem" runat="server" Text='<%# Bind("NomItem") %>'></asp:Label> 
           </ItemTemplate>
    </asp:TemplateField>
</Columns><Columns>
    <asp:TemplateField  HeaderText="Descripcion">
           <EditItemTemplate> 
            <asp:TextBox ID="txtDscItem" runat="server" Text='<%# Bind("DscItem") %>'></asp:TextBox> 
           </EditItemTemplate> 
           <FooterTemplate> 
            <asp:TextBox ID="txtDscItem" runat="server" ></asp:TextBox> 
           </FooterTemplate> 
           <ItemTemplate> 
            <asp:Label ID="lblDscItem" runat="server" Text='<%# Bind("DscItem") %>'></asp:Label> 
           </ItemTemplate>
    </asp:TemplateField>
</Columns><Columns>
    <asp:TemplateField  HeaderText="Cantidad">
           <EditItemTemplate> 
            <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox> 
           </EditItemTemplate> 
           <FooterTemplate> 
            <asp:TextBox ID="txtCantidad" runat="server" ></asp:TextBox> 
           </FooterTemplate> 
           <ItemTemplate> 
            <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label> 
           </ItemTemplate>
    </asp:TemplateField>
</Columns>
<Columns>
    <asp:TemplateField  HeaderText="Unidad">
        <ItemTemplate>
            <asp:Label  ID="lblUniMed" runat="server" Text='<%# Bind("UniMed") %>'> ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:DropDownList DataField="UniMed" ID="ddlUniMed" runat="server" ></asp:DropDownList>
        </EditItemTemplate>
        <FooterTemplate> 
            <asp:DropDownList DataField="UniMed" ID="ddlUniMed" runat="server"></asp:DropDownList>
        </FooterTemplate> 
    </asp:TemplateField>
</Columns>
<Columns>
    <asp:TemplateField  HeaderText="">
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