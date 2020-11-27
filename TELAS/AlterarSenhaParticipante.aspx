<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarSenhaParticipante.aspx.cs" Inherits="TCCADS.TELAS.AlterarSenhaParticipante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <main style="width: 600px">
            <h2>Alterar senha</h2>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtRGM" runat="server" Enabled="false" Placeholder="RGM"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSenhaAtual" runat="server" TextMode="Password"  Placeholder="Senha atual"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNovaSenha" runat="server" TextMode="Password" Placeholder="Nova Senha"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtConfirmarNovaSenha" runat="server" TextMode="Password"  Placeholder="Confirmar Nova Senha"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar Senha" OnClick="btnAlterar_Click" />
        </main>
    </form>
</body>
</html>
