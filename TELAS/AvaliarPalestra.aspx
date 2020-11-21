<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvaliarPalestra.aspx.cs" Inherits="TCCADS.TELAS.AvaliarPalestra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                        <asp:TextBox ID="txtNome" runat="server" TextMode="SingleLine" Enabled="False"></asp:TextBox>
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
        </div>
    </form>
</body>
</html>
