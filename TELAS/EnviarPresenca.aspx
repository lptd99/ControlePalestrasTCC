<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnviarPresenca.aspx.cs" Inherits="TCCADS.TELAS.EnviarPresenca" %>

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
                        ID Palestra:
                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" TextMode="Number" Enabled="False" Width="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nome Palestra:
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNome" runat="server" TextMode="SingleLine" Enabled="False" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Presentes:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPresentes" runat="server" TextMode="MultiLine" Height="200px" Width="150px"></asp:TextBox>
                    </td>
                    <td>
                        Digite os RGMs<br />de cada aluno que<br />participou desta reunião,<br />um por linha. <br />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" Width="75px" />
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
    </form>
</body>
</html>
