<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TpFinalMetodologiasWeb.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">




    <style type="text/css">
        .container {
            display: flex;
            justify-content: flex-start;
            align-items: flex-start;
            gap: 20px;
        }

        h1 {
            text-align: center;
        }

        .Registro {
            display: flex;
            flex-direction: column;
            background-color: lightpink;
            text-align: left;
            width: 50%;
            padding: 10px;
        }

        .Tabla {
            display: flex;
            flex-direction: column;
            background-color: lightyellow;
            padding: 10px;
            width: 50%;
        }
    </style>




    <div class="container">
        <div class="Registro">
            <h1>Registrar Productos</h1>
            <p>
                Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
            </p>
            <p>
                &nbsp;Categoria: 
                <asp:TextBox ID="txtcategoria" runat="server"></asp:TextBox>
            </p>
            <p>
                Precio:
                <asp:TextBox ID="txtprecio" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Registrar" OnClick="ButtonSubmit_Click" />
            </p>
        </div>

        <div class="Tabla">
            <h2>Productos Registrados</h2>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Categoria</th>
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
    </div>


</asp:Content>

