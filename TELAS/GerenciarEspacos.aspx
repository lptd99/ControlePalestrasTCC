<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciarEspacos.aspx.cs" Inherits="TCCADS.TELAS.GerenciarEspacos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title>Controle de Espaços</title>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="nav">
            <li><a href="GerenciarPalestras.aspx">Gerenciar Palestras</a></li>
            <li><a class="active" href="#">Gerenciar Espacos</a></li>
            <li><a href="GerenciarPalestrantes.aspx">Gerenciar Palestrantes</a></li>
            <li><a href="CadastrarCoordenador.aspx">Cadastrar Coordenador</a></li>
        </ul>
        <main>
            <table>
                <tr class="auto-style1">
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Enabled="False" TextMode="Number" Placeholder="ID"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server" Placeholder="Nome"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCapacidade" runat="server" TextMode="Number" Placeholder="Capacidade"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            
            <div class="tb">
            <asp:GridView ID="gvEspacos" CssClass="tbPalestras" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvEspacos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
                    <asp:BoundField DataField="capacidade" HeaderText="capacidade" SortExpression="capacidade" />
                    <asp:ButtonField ButtonType="Button" CommandName="carregar" Text="Carregar" />
                </Columns>
            </asp:GridView>
            </div>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
        </main>
    </form>
</body>
</html>
