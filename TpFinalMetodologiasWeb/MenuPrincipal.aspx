<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="TpFinalMetodologiasWeb.MenuPrincipal" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <h2 style="text-align: center">Líbreria "El Libro Loco"</h2>
    <br />
<br />
    <p>
        <% if (Session["Rol"] != null && Session["Rol"].ToString() == "web master") { %>
            <a href="Productos.aspx">Gestión de Productos</a>
        <% } else if (Session["Rol"] != null && Session["Rol"].ToString() == "cliente") { %>
            <a href="Compras.aspx">Realizar Compras</a>
        <% } %>
    </p>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre del producto que quiere comparar"></asp:Label>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Label ID="Label2" runat="server" Text="Ingrese Fecha que va a retirar:"></asp:Label>
      <asp:TextBox ID="TextBoxFecha" runat="server" OnTextChanged="TextBoxFecha_TextChanged"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnFecha" runat="server" Text="Seleccionar fecha" OnClick="btnfecha"  Width="171px"/>
    <br />
    <br />
    <%--calendario--%>
    <div style="margin-left:400px; margin-right:400px">
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    </div>
    <br />
    <%--fin calendario--%>
</asp:Content>
