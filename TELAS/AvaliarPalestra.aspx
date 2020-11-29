<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvaliarPalestra.aspx.cs" Inherits="TCCADS.TELAS.AvaliarPalestra" %>

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
        <main>
            <table>
                <tr>
                    <td>
                        RGM Usuário:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRGM" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        ID Palestra:
                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nome Palestra:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nota:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNota" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAvaliar" runat="server" Text="Avaliar" OnClick="btnAvaliar_Click" />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </main>
    </form>
</body>
</html>
