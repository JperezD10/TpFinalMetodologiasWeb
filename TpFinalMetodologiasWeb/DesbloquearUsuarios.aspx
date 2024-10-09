<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DesbloquearUsuarios.aspx.cs" Inherits="TpFinalMetodologiasWeb.DesbloquearUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        body {
            background-color: #f4f6f9;
        }

        .user-card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: 0.3s;
            border-radius: 10px;
            margin-bottom: 20px;
            padding: 20px;
            background-color: #2c3e50;
            color: #ecf0f1;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            text-align: center;
        }

        .user-card:hover {
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

        .user-icon {
            font-size: 40px;
            margin-bottom: 15px;
        }

        .user-name {
            font-size: 22px;
            font-weight: bold;
        }

        .unlock-button {
            background-color: #e74c3c;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 10px 15px;
            cursor: pointer;
            margin-top: 15px;
            transition: background-color 0.3s ease;
        }

        .unlock-button:hover {
            background-color: #c0392b;
        }

        .col-md-4 {
            display: flex;
            justify-content: center;
        }
    </style>
    <div class="container">
        <h2 class="my-4 text-center text-dark">Usuarios Bloqueados</h2>
        <div class="row">
            <asp:Repeater ID="rptUsuariosBloqueados" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="user-card">
                            <i class="fas fa-user-lock user-icon"></i>
                            <div class="user-name"><%# Eval("Usuario") %></div>
                            <button class="unlock-button" runat="server" onserverclick="DesbloquearUsuario" data-usuario='<%# Eval("Usuario") %>'>
                                <i class="fas fa-unlock"></i> Desbloquear
                            </button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
