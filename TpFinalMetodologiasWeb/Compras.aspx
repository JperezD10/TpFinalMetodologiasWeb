<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TpFinalMetodologiasWeb.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .compras-form {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
        }

        #MainContent h1 {
            color: #007bff;
            font-weight: bold;
            text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.1);
        }

        #MainContent label {
            font-size: 1.2em;
            color: #333;
        }

        #MainContent .form-control, #MainContent .form-select {
            border-radius: 8px;
            border: 1px solid #ced4da;
        }

        #MainContent .form-control-plaintext {
            font-size: 1.5em;
        }

        #MainContent #btnPagar {
            background-color: #28a745;
            border: none;
            padding: 12px;
            font-size: 1.2em;
        }

            #MainContent #btnPagar:hover {
                background-color: #218838;
            }
    </style>
    <div class="container my-5 compras-form">
        <h1 class="text-center mb-4">Realizar Compra</h1>

        <div class="row mb-4">
            <div class="col-md-6 form-group">
                <label for="ddlProductos" class="form-label">Seleccionar Producto:</label>
                <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-select shadow-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged">
                    <asp:ListItem Text="-- Seleccione un producto --" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 form-group">
                <label for="txtPrecio" class="form-label">Precio Unitario:</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control shadow-sm" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 form-group">
                <label for="txtCantidad" class="form-label">Cantidad:</label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control shadow-sm" AutoPostBack="true" OnTextChanged="txtCantidad_TextChanged"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6">
                <label class="form-label">Total a Pagar:</label>
                <asp:Label ID="lblTotal" runat="server" CssClass="form-control-plaintext text-success fw-bold fs-5" Text="Total a Pagar: $0.00"></asp:Label>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 form-group">
                <label for="ddlMetodoPago" class="form-label">Método de Pago:</label>
                <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="form-select shadow-sm" OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged">
                    <asp:ListItem Text="Efectivo" Value="Efectivo"></asp:ListItem>
                    <asp:ListItem Text="Transferencia" Value="Transferencia"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6">
                <asp:Button ID="btnPagar" runat="server" CssClass="btn btn-success w-100 shadow-lg" Text="Pagar" OnClick="btnPagar_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <asp:Literal ID="litMessage" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
