<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeParticipante.aspx.cs" Inherits="TCCADS.TELAS.HomeParticipante" %>

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
                        <asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click" />
                        <asp:Button ID="btnPalestras" runat="server" Text="Palestras" OnClick="btnPalestras_Click" />
                        <asp:Button ID="btnMinhasPalestras" runat="server" Text="Minhas Palestras" OnClick="btnMinhasPalestras_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
