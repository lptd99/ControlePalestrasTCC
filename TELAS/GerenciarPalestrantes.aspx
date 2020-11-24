<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciarPalestrantes.aspx.cs" Inherits="TCCADS.TELAS.GerenciarPalestrantes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 202px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tbForm">
                <tr class="auto-style1">
                    <td>
                        ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr class="auto-style1">
                    <td>
                        Nome
                    </td>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
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
                <tr>
                    <td>
                        E-mail
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr class="auto-style1">
                    <td>
                        Telefone
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefone" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Formação
                    </td>
                    <td>
                        <asp:TextBox ID="txtFormacao" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            <asp:GridView ID="gvPalestrantes" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvPalestrantes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                    <asp:BoundField DataField="telefone" HeaderText="Telefone" SortExpression="telefone" />
                    <asp:BoundField DataField="formacao" HeaderText="Formação" SortExpression="formacao" />
                    <asp:ButtonField ButtonType="Button" CommandName="carregar" Text="Carregar" />
                </Columns>
            </asp:GridView>
            <!--<asp:SqlDataSource ID="gvPalestrantesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand="SELECT [id], [nome], [email], [telefone], [formacao] FROM [Palestrante]"></asp:SqlDataSource>
            --><asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
        </div>
    </form>
</body>
</html>
