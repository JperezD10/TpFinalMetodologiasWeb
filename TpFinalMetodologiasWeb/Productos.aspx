<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TpFinalMetodologiasWeb.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .productos-form {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
        }

        #MainContent h1, #MainContent h2 {
            color: #007bff;
            font-weight: bold;
            text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.1);
        }

        #MainContent label {
            font-size: 1.2em;
            color: #333;
        }

        #MainContent .form-control {
            border-radius: 8px;
            border: 1px solid #ced4da;
        }

        #MainContent #ButtonSubmit {
            background-color: #007bff;
            border: none;
            padding: 12px;
            font-size: 1.2em;
        }

            #MainContent #ButtonSubmit:hover {
                background-color: #0056b3;
            }

        .productos-registrados h2 {
            font-size: 1.8em;
        }

        .table {
            border-radius: 8px;
            overflow: hidden;
        }

            .table thead {
                background-color: #f8f9fa;
            }

        .text-danger {
            font-weight: bold;
            font-size: 1.1em;
        }
    </style>
    <div class="container my-5 productos-form">
        <h1 class="text-center mb-4">Registrar Productos</h1>

        <div class="row mb-4">
            <div class="col-md-6 form-group">
                <label for="txtnombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control shadow-sm"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 form-group">
                <label for="txtcategoria" class="form-label">Categoría:</label>
                <asp:TextBox ID="txtcategoria" runat="server" CssClass="form-control shadow-sm"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 form-group">
                <label for="txtprecio" class="form-label">Precio:</label>
                <asp:TextBox ID="txtprecio" runat="server" CssClass="form-control shadow-sm"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6">
                <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-primary w-100 shadow-lg" Text="Registrar" OnClick="ButtonSubmit_Click" />
            </div>
        </div>

        <div class="productos-registrados mt-5">
            <h2 class="mb-4">Productos Registrados</h2>
            <table class="table table-bordered shadow-sm">
                <thead class="table-light">
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Categoría</th>
                        <th>Precio</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterProductos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("_idproducto") %></td>
                                <td><%# Eval("_nombre") %></td>
                                <td><%# Eval("_categoria") %></td>
                                <td><%# Eval("_precio") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <asp:Label ID="lblError" runat="server" Text="Label" CssClass="text-danger mt-3"></asp:Label>
    </div>

</asp:Content>

