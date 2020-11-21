<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TCCADS.TELAS.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Home
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
        </div>
    </form>
</body>
</html>
