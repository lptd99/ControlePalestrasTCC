<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciarEspacos.aspx.cs" Inherits="TCCADS.TELAS.GerenciarEspacos" %>

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
                <tr class="auto-style1">
                    <td>
                        ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>
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
                        Capacidade
                    </td>
                    <td>
                        <asp:TextBox ID="txtCapacidade" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            <asp:GridView ID="gvEspacos" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvEspacos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
                    <asp:BoundField DataField="capacidade" HeaderText="capacidade" SortExpression="capacidade" />
                    <asp:ButtonField ButtonType="Button" CommandName="carregar" Text="Carregar" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="gvEspacosDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand="SELECT [id], [nome], [capacidade] FROM [Espaco]"></asp:SqlDataSource>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
        </div>
    </form>
</body>
</html>
