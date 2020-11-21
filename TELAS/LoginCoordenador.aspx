<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginCoordenador.aspx.cs" Inherits="TCCADS.TELAS.LoginCoordenador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login Coordenador
            <table>
                <tr>
                    <td>
                        RGM:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRGM" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Senha:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnEsqueciMinhaSenha" runat="server" Text="Esqueci minha senha" OnClick="btnEsqueciMinhaSenha_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
