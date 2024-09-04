<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnauthorizatedAccess.aspx.cs" Inherits="TpFinalMetodologiasWeb.UnauthorizatedAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Unauthorizated</title>

</head>
<body>
    <style>
        html, body {
            height: 100%;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .container {
            text-align: center;
        }
}
    </style>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Usted no posee los permiso necesarios para acceder a la pagina.</h1>

            <img width="850" alt="No tiene permisos" src="https://i.kym-cdn.com/entries/icons/original/000/002/144/You_Shall_Not_Pass!_0-1_screenshot.jpg" />
        </div>
    </form>
</body>
</html>
