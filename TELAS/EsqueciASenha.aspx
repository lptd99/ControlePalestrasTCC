<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EsqueciASenha.aspx.cs" Inherits="TCCADS.TELAS.EsqueciASenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Insira seu Email para receber uma nova senha
            <table>
                <tr>
                    <td>
                        RGM
                    </td>
                    <td>
                        <asp:TextBox ID="txtRGM" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
</body>
</html>
