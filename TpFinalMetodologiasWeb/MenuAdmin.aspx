<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="TpFinalMetodologiasWeb.MenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        a {
            text-decoration: none;
            color: inherit;
        }

        .admin-panel {
            text-align: center;
            margin-top: 50px;
            color: #333;
        }

        .options-grid {
            display: flex;
            justify-content: space-around;
            flex-wrap: wrap;
        }

        .option-card {
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 10px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            padding: 20px;
            width: 200px;
            margin: 15px;
            cursor: pointer;
            transition: all 0.3s ease;
            text-align: center;
        }

            .option-card:hover {
                background-color: #f0f8ff;
                transform: scale(1.05);
            }

            .option-card i {
                font-size: 40px;
                color: #0056b3;
            }

            .option-card h3 {
                margin-top: 10px;
                font-size: 18px;
                color: #333;
            }
    </style>
    <div class="admin-panel">
        <h1>Panel de Administración</h1>
        <div class="options-grid">
            <a href="Bitacora.aspx" class="option-card">
                <i class="fa fa-book"></i>
                <h3>Bitácora</h3>
            </a>
            <a href="Productos.aspx" class="option-card">
                <i class="fa fa-box"></i>
                <h3>Agregar Producto</h3>
            </a>
            <a href="Opcion3.aspx" class="option-card">
                <i class="fa fa-question-circle"></i>
                <h3>Opción 3</h3>
            </a>
            <a href="Opcion4.aspx" class="option-card">
                <i class="fa fa-question-circle"></i>
                <h3>Opción 4</h3>
            </a>
        </div>
    </div>
</asp:Content>
