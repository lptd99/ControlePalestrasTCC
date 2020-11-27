<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginParticipante.aspx.cs" Inherits="TCCADS.TELAS.LoginParticipante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" runat="server">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login Participante</title>
    <link rel="stylesheet" href="../CSS/standard.css" />
    <link rel="stylesheet" href="../CSS/Login.css" />
</head>
<body class="text-center" runat="server">
<form id="form1" class="form-signin" runat="server">
    <img class="text-center" src="http://aluno.umc.br/imagens/logo.svg" width="140px" />

    <h1>UMC Palestras</h1>
    <h2>Portal do participante</h2>

    <div>
        <asp:TextBox ID="txtRGM" runat="server" Placeholder="RGM"></asp:TextBox>
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Placeholder="Senha"></asp:TextBox>      
    </div>
    <div>
        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastre-se" OnClick="btnCadastrar_Click" />
    </div>
    <asp:Button ID="btnEsqueciMinhaSenha"  runat="server" Text="Esqueci minha senha" OnClick="btnEsqueciMinhaSenha_Click" />
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
   
</form>
</body>
</html>
