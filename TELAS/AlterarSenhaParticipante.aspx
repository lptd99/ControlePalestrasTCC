<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarSenhaParticipante.aspx.cs" Inherits="TCCADS.TELAS.AlterarSenhaParticipante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ALTERAR SENHA PARTICIPANTE
            <table>
                <tr>
                    <td>
                        RGM:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRGM" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Senha Atual:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSenhaAtual" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nova Senha:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNovaSenha" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirmar Nova Senha:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmarNovaSenha" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar Senha" OnClick="btnAlterar_Click" />
        </div>
    </form>
</body>
</html>
