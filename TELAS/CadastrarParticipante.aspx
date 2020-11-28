﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarParticipante.aspx.cs" Inherits="TCCADS.TELAS.CadastrarParticipante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastrar Participante</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<link rel="stylesheet" href="../CSS/standard.css" />
    <meta charset="UTF-8"/>
    <style>
        .auto-style1 {
            width: 130px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <main style="width: 600px">
            <h2>Cadastro de participante</h2>
            <table>
                <tr class="auto-style1">
                    <td>
                        <asp:TextBox ID="txtRGM" runat="server" Placeholder="RGM"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"  Placeholder="E-mail"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="pwdSenha" runat="server" TextMode="Password" Placeholder="Senha"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="pwdConfirma" runat="server" TextMode="Password" Placeholder="Confirme sua senha"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server" Placeholder="Nome"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDataNasc" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                    <td>
                        Data de nascimento
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtRG" runat="server" Placeholder="RG"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCPF" runat="server" Placeholder="CPF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCurso" runat="server" Placeholder="Curso"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnCadastrarPart" runat="server" Text="Cadastrar" OnClick="btnCadastrarPart_Click" />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </main>
    </form>
</body>
</html>