<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpFinalMetodologiasWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #DivLogin {
           font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            font-size: 16px;
            background-color: lightsteelblue;
            width: 300px;
            height: 290px ;
            text-align: center;
            margin: 20px auto;
        }

        #DivInicial {
            background-color: lightblue;
            margin: 100px auto;
        }

        body {
            background-color: lightblue;
        }

        #btnIngresar{
            background-color:Highlight;
            border: hidden;
            font-size: 15px;
            color:white;
            margin: 10px;
        }
        #DivBtnIngresar{
            margin-left: 66px;
            margin-right: 66px;
            background-color:Highlight
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="DivInicial">
            <div id="DivLogin">
                <br />
                <h2 id="Bienvenido">Bienvenido!</h2>
                <h3>Iniciar sesión:</h3>
                <br />
                Usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                <br />
                <br />
                Contraseña:&nbsp;
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <br />
                <div id="DivBtnIngresar">
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" style="height: 23px" />
                    </div>
                <br />
                <asp:Label ID="LBLError"   font-size="13px" forecolor="red" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>