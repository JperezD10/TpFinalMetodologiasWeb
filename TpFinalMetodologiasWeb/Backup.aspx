<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="TpFinalMetodologiasWeb.Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Backups realizados:</h1>
    <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    <br />
    <br />
    <br />
    <p>¿Desea realizar un Backup?</p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click2" Text="Realizar backup" Style="background-color: Highlight; border: hidden; font-size: 15px; color: white; margin: 10px;" />
</asp:Content>
