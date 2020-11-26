<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeCoordenador.aspx.cs" Inherits="TCCADS.TELAS.HomeCoordenador" %>

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
                        <asp:Button ID="btnGerenciarPalestras" runat="server" Text="Gerenciar Palestras" OnClick="btnGerenciarPalestras_Click" />
                        <asp:Button ID="btnGerenciarEspacos" runat="server" Text="Gerenciar Espaços" OnClick="btnGerenciarEspacos_Click" />
                        <asp:Button ID="btnGerenciarPalestrantes" runat="server" Text="Gerenciar Palestrantes" OnClick="btnGerenciarPalestrantes_Click" />
                        <asp:Button ID="btnCadastrarCoordenador" runat="server" Text="Cadastrar Coordenador" OnClick="btnCadastrarCoordenador_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
