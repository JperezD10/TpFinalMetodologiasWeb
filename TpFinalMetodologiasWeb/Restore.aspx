<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="TpFinalMetodologiasWeb.Restore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="text-align:center">
        <h3>Restaurar base de datos</h3>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <h5>Seleccione un archivo .bak que desea restaurar y luego 'Restaurar'</h5>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left:440px"/>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Restaurar" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </div>
</asp:Content>