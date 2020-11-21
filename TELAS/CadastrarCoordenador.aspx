<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarCoordenador.aspx.cs" Inherits="TCCADS.TELAS.CadastrarCoordenador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastrar Coordenador</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta charset="UTF-8"/>
    <style>
        .auto-style1 {
            width: 130px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            CADASTRAR COORDENADOR
            <table>
                <tr>
                    <td class="auto-style1">
                        RGM
                    </td>
                    <td>
                        <asp:TextBox ID="txtRGM" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        E-mail
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Senha
                    </td>
                    <td>
                        <asp:TextBox ID="pwdSenha" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirme sua senha
                    </td>
                    <td>
                        <asp:TextBox ID="pwdConfirma" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nome
                    </td>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        Data de nascimento
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataNasc" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        RG
                    </td>
                    <td>
                        <asp:TextBox ID="txtRG" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        CPF
                    </td>
                    <td>
                        <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnCadastrarCoord" runat="server" Text="Cadastrar" OnClick="btnCadastrarCoord_Click" />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
</body>
</html>
