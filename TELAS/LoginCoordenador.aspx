<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginCoordenador.aspx.cs" Inherits="TCCADS.TELAS.LoginCoordenador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    <link rel="stylesheet" href="../CSS/standard.css" />
    <style>
    body {
        background: url("http://teatroumc.com.br/wp-content/uploads/2012/03/teatro2.jpg")
        no-repeat;
        background-size: cover;
        height: 100%;
        width: 100%/*calc(1920 - 50%)*/;
        overflow: hidden;
    }

    .aspNetHidden {
        display: none;
    }

    .form-signin {
        position: relative;
        text-align: center;
        background-color: white;
        width: 100%;
        max-width: 440px;
        min-height: 440px;
        margin: 10%;
        padding: 40px;
        float: right;
    }



    .form-signin input[type="text"] {
        position: relative;
        margin: auto;
        width: 70%;
        border-bottom-left-radius: 0px;
        border-bottom-right-radius: 0px;
    }

    .form-signin input[type="password"] {
        position: relative;
        margin: auto;
        width: 70%;
        border-top-left-radius: 0px;
        border-top-right-radius: 0px;
    }
    </style>
</head>
<body>
<form id="form1" class="form-signin" runat="server">
<div>
    <asp:TextBox ID="txtRGM" runat="server" Placeholder="RGM"></asp:TextBox>
    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Placeholder="Senha"></asp:TextBox>      
</div>
            
    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
    <asp:Button ID="btnEsqueciMinhaSenha" runat="server" Text="Esqueci minha senha" OnClick="btnEsqueciMinhaSenha_Click" />
            
    <!-- <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
    -->        
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
</form>
</body>
</html>
