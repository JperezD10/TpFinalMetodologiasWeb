<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TpFinalMetodologiasWeb.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        h1 {
            text-align: center;
        }

        .Tabla {
            background-color: lightblue;
            padding: 10px;
            width: 50%;
            height: 50%;
            margin-left: 290px;
        }
    </style>

    <h1>Realizar Compra</h1>
    <br />
    <br />
    <div class="Tabla">
        <div>
            <label for="ddlProductos">Seleccionar Producto:</label>
            <asp:DropDownList ID="ddlProductos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged" Style="width: 237px">
                <asp:ListItem Text="-- Seleccione un producto --" Value=""></asp:ListItem>
            </asp:DropDownList>

        </div>

        <div>
            <label for="txtPrecio">Precio Unitario:</label>
            <asp:TextBox ID="txtPrecio" runat="server" Enabled="false"></asp:TextBox>
        </div>

        <div>
            <label for="txtCantidad">Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="true" OnTextChanged="txtCantidad_TextChanged"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblTotal" runat="server" Text="Total a Pagar: $0.00"></asp:Label>
        </div>

        <div>
            <label for="ddlMetodoPago">Método de Pago:</label>
            <asp:DropDownList ID="ddlMetodoPago" runat="server" OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged">
                <asp:ListItem Text="Efectivo" Value="Efectivo"></asp:ListItem>
                <asp:ListItem Text="Transferencia" Value="Transferencia"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div>
            <asp:Button ID="btnPagar" runat="server" Text="Pagar" OnClick="btnPagar_Click" />
        </div>

        <div>
            <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        </div>
</asp:Content>
