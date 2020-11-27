<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeCoordenador.aspx.cs" Inherits="TCCADS.TELAS.HomeCoordenador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title>Home - Coordenador</title>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="nav">
            <li><asp:Button ID="btnGerenciarPalestras" runat="server" Text="Gerenciar Palestras" OnClick="btnGerenciarPalestras_Click" /></li>
            <li><asp:Button ID="btnGerenciarEspacos" runat="server" Text="Gerenciar Espaços" OnClick="btnGerenciarEspacos_Click" /></li>
            <li><asp:Button ID="btnGerenciarPalestrantes" runat="server" Text="Gerenciar Palestrantes" OnClick="btnGerenciarPalestrantes_Click" /></li>
            <li><asp:Button ID="btnCadastrarCoordenador" runat="server" Text="Cadastrar Coordenador" OnClick="btnCadastrarCoordenador_Click" /></li>
            <li><asp:Button ID="btnAlterarSenha" runat="server" Text="Alterar Senha" OnClick="btnAlterarSenha_Click" /></li>
            <li><asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click" /></li>
        </ul>
        <main>
            <h2>Bem vindo(a)</h2>
            <p style="height: 3000px">

        </p>
        </main>
    </form>
</body>
</html>
