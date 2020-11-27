<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TCCADS.TELAS.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title>Home - Palestras</title>
</head>

<body>
    <form id="form1" runat="server">
        <main>
            <h1>Projeto Web Palestras</h1>
            <h2>Versão alpha 1.0</h2>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnLoginCoordenador" runat="server" Text="Portal do Coordenador" OnClick="btnLoginCoordenador_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btnLoginParticipante" runat="server" Text="Portal do Participante" OnClick="btnLoginParticipante_Click"/>
                    </td>
                </tr>
            </table>
        </main>
    </form>
</body>
</html>
