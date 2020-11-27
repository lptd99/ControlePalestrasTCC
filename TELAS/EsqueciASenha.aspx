<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EsqueciASenha.aspx.cs" Inherits="TCCADS.TELAS.EsqueciASenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Esqueci a senha</title>
    <link rel="stylesheet" href="../CSS/standard.css" />
</head>
<body>
<form id="form1" runat="server">
    <main style="max-width: 400px">
        <p>
            Insira seu RGM para receber uma nova senha
        </p>
        <asp:TextBox ID="txtRGM" runat="server" TextMode="Number" Placeholder="RGM"></asp:TextBox>
        <div>
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />

        </div>
    </main>
</form>
</body>
</html>
