<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="TpFinalMetodologiasWeb.Bitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card {
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            padding: 15px;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }

            .card:hover {
                transform: scale(1.05);
                box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
            }

        .card-header {
            background-color: #f8f9fa;
            color: #333;
            padding: 10px;
            font-weight: bold;
            border-bottom: 1px solid #ddd;
            display: flex;
            align-items: center;
        }

            .card-header i {
                font-size: 20px;
                color: #6c757d;
                margin-right: 10px;
            }

        .card-body {
            padding: 15px;
        }

            .card-body i {
                color: #007bff;
                margin-right: 5px;
            }

        .alert-success {
            background-color: #28a745;
            color: #ffffff;
            border-radius: 5px;
            padding: 10px;
            margin-bottom: 20px;
        }

            .alert-success i {
                margin-right: 8px;
                color: #ffffff;
            }

        .ml-2 {
            margin-left: 10px;
        }
    </style>
    <div class="container">
        <h3 class="text-center">Bitácora de Actividades</h3>

        <div class="row mb-4">
            <div class="col-md-12 text-right">
                <asp:Button ID="btnConnectWS" runat="server" CssClass="btn btn-primary" Text="Generar XML" OnClick="btnConnectWS_Click" />
            </div>
        </div>

        <% if (showMessage)
            { %>
        <div class="alert alert-success" role="alert">
            <i class="fa fa-check-circle"></i>Se ha generado un XML correctamente
           
        </div>
        <% } %>

        <div class="row">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card mb-4">
                            <div class="card-header bg-light text-dark">
                                <i class="fa fa-calendar-alt text-muted"></i><span class="ml-2"><strong>Fecha:</strong> <%# Eval("Fecha") %></span>
                            </div>
                            <div class="card-body">
                                <p><i class="fa fa-user"></i><strong>Usuario:</strong> <%# Eval("Usuario") %></p>
                                <p><i class="fa fa-exchange-alt"></i><strong>Movimiento:</strong> <%# Eval("Movimiento") %></p>
                                <p><i class="fa fa-cogs"></i><strong>Módulo:</strong> <%# Eval("Modulo") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
