<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="TpFinalMetodologiasWeb.Bitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3 class="text-center">Bitácora de Actividades</h3>

        <div class="row mb-4">
            <div class="col-md-12 text-right">
                <asp:Button ID="btnConnectWS" runat="server" CssClass="btn btn-primary" Text="Generar XML" OnClick="btnConnectWS_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                        <asp:BoundField DataField="Movimiento" HeaderText="Movimiento" SortExpression="Movimiento" />
                        <asp:BoundField DataField="Modulo" HeaderText="Módulo" SortExpression="Modulo" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
