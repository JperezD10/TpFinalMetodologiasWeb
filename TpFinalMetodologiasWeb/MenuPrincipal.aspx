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
    
    <p style="font-size: 16px">Somos la Librería "El Libro Loco", tu destino para encontrar todo lo que
        necesitas para potenciar tu aprendizaje y creatividad. Ofrecemos una amplia variedad de productos de
        calidad, desde materiales de escritura hasta servicios de encuadernación y personalización. Con atención
        personalizada, beneficios exclusivos para clientes frecuentes y la comodidad de compras online con entrega a
        domicilio, nos esforzamos por ser tu aliado en el camino hacia el conocimiento y la expresión. ¡Descubre la locura
        de aprender con nosotros!</p>

     <%--mapa--%>
    <div style="margin-left:300px; margin-right:300px">
    <iframe id="mapa" style="width: 600px; height: 400px"></iframe>
        <script>
            navigator.geolocation.getCurrentPosition(localizame);

            function localizame(posicion) {
                const latitud = posicion.coords.latitude;
                const longitud = posicion.coords.longitude;
                document.getElementById('mapa').src = "http://maps.google.com/maps?q=@" + latitud + "," +
                    longitud + "&z=17&output=embed";
            }
        </script>
        </div>
    <%--fin mapa--%>
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

    <img alt="ImgLibreria" src="ImagenLibreria.jpg" style="width: 950px; height: 246px; margin-left: 110px" />
</asp:Content>
