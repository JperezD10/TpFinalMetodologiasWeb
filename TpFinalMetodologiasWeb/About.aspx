<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TpFinalMetodologiasWeb.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            background-color: #f9f9f9;
            font-family: 'Arial', sans-serif;
        }
        .about-section {
            background-color: #ffffff;
            border-radius: 15px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            padding: 40px;
            margin-top: 50px;
        }
        .about-section h1 {
            font-size: 2.5rem;
            color: #ff5722;
            margin-bottom: 30px;
            font-weight: bold;
        }
        .about-section p {
            font-size: 1.2rem;
            line-height: 1.8;
            color: #555;
            margin-bottom: 20px;
        }
        .about-section img {
            border-radius: 15px;
            margin-bottom: 30px;
            box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.1);
        }
        .btn-learn-more {
            background-color: #ff5722;
            color: white;
            padding: 10px 30px;
            font-size: 1.2rem;
            border-radius: 30px;
            transition: background-color 0.3s ease;
        }
        .btn-learn-more:hover {
            background-color: #e64a19;
        }
    </style>
    <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-10 about-section text-center">
                    <img alt="ImgLibreria" src="ImagenLibreria.jpg" class="img-fluid" />
                    <h1>Sobre Nosotros</h1>
                    <p>
                        Somos la Librería "El Libro Loco", tu destino para encontrar todo lo que necesitas para potenciar tu aprendizaje y creatividad. Ofrecemos una amplia variedad de productos de calidad, desde materiales de escritura hasta servicios de encuadernación y personalización.
                    </p>
                    <p>
                        Con atención personalizada, beneficios exclusivos para clientes frecuentes y la comodidad de compras online con entrega a domicilio, nos esforzamos por ser tu aliado en el camino hacia el conocimiento y la expresión. ¡Descubre la locura de aprender con nosotros!
                    </p>
                    <a href="Login.aspx" class="btn btn-learn-more">Ingresá</a>
                </div>
            </div>
        </div>
</asp:Content>
