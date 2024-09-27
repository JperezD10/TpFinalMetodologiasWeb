<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpFinalMetodologiasWeb.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login - Librería</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f4efe6; /* Un tono crema que evoca páginas de libro */
            font-family: 'Georgia', serif; /* Fuente clásica, elegante y literaria */
        }

        .login-container {
            max-width: 450px;
            margin: 100px auto;
            background-color: #fff7e1; /* Fondo suave amarillo pálido */
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.1);
            border: 2px solid #c7a17a; /* Un toque marrón claro */
        }

        h2, h3 {
            color: #8b4513; /* Marrón oscuro para darle ese toque de biblioteca */
            font-weight: bold;
        }

        .form-control {
            border-radius: 8px;
            padding: 10px;
            font-size: 1.1em;
            border: 1px solid #c7a17a; /* Bordes con tono marrón claro */
            background-color: #fff8e1; /* Fondo crema claro */
        }

        #btnIngresar {
            background-color: #8b4513; /* Botón marrón oscuro */
            border: none;
            padding: 10px;
            font-size: 1.1em;
            color: white;
            border-radius: 8px;
            width: 100%;
            font-weight: bold;
        }

        #btnIngresar:hover {
            background-color: #a0522d; /* Marrón más claro en hover */
        }

        #LBLError {
            color: red;
            font-size: 14px;
        }

        /* Extra: sombra sutil en los inputs para darle profundidad */
        .form-control:focus {
            box-shadow: 0 0 8px rgba(139, 69, 19, 0.5); /* Sombra marrón cuando se selecciona */
            border-color: #8b4513;
        }

        .login-container .text-center {
            margin-top: 15px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2 class="text-center">Bienvenido a El Libro Loco!</h2>
            <h3 class="text-center mb-4">Iniciar sesión:</h3>

            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario:</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtContraseña" class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>

            <div class="text-center mb-3">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"  CssClass="btn" />
            </div>

            <asp:Label ID="LBLError" runat="server" Text="Usuario o contraseña incorrectos." />
        </div>
    </form>
</body>
</html>
