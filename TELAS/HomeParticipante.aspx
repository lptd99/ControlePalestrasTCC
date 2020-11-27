<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeParticipante.aspx.cs" Inherits="TCCADS.TELAS.HomeParticipante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title>Home - Participante</title>
</head>
<body>
<form id="form1" runat="server">
    
    <ul class="nav">
        <li><asp:Button ID="btnPalestras" runat="server" Text="Palestras" OnClick="btnPalestras_Click" /></li>
        <li><asp:Button ID="btnMinhasPalestras" runat="server" Text="Minhas Palestras" OnClick="btnMinhasPalestras_Click" /></li>
        <li><asp:Button ID="btnAlterarSenha" runat="server" Text="Alterar Senha" OnClick="btnAlterarSenha_Click" /></li>
        <li><asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click" /></li>
    </ul>
        
    <main>
        <h2>Bem vindo(a)</h2>
    </main>
</form>
</body>
</html>
