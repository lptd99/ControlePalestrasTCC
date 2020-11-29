<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciarPalestrantes.aspx.cs" Inherits="TCCADS.TELAS.GerenciarPalestrantes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../CSS/standard.css" />
    <title>Controle de Palestras</title>
    <style type="text/css">
        .auto-style1 {
            width: 202px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="nav">
            <li><a href="GerenciarPalestras.aspx">Gerenciar Palestras</a></li>
            <li><a href="GerenciarEspacos.aspx">Gerenciar Espacos</a></li>
            <li><a class="active" href="#">Gerenciar Palestrantes</a></li>
            <li><a href="CadastrarCoordenador.aspx">Cadastrar Coordenador</a></li>
        </ul>
        <main>
            
            <h2>Controle de Palestrantes</h2>

            <asp:TextBox ID="txtID" runat="server" Enabled="False" TextMode="Number" Placeholder="ID"></asp:TextBox>
            <div>
                <asp:TextBox ID="txtNome" runat="server" Placeholder="Nome"></asp:TextBox>
                <asp:TextBox ID="txtRG" runat="server" Placeholder="RG"></asp:TextBox>
                <asp:TextBox ID="txtCPF" runat="server" Placeholder="CPF"></asp:TextBox>
            </div>

            <div>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Placeholder="E-mail"></asp:TextBox>
                <asp:TextBox ID="txtTelefone" runat="server" TextMode="Number" Placeholder="Telefone"></asp:TextBox>
            </div>

            <div>
                <asp:TextBox ID="txtFormacao" runat="server" placeholder="Formação"></asp:TextBox>
            </div>

            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            <div class="tb">
            <asp:GridView ID="gvPalestrantes" CssClass="tbPalestras" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvPalestrantes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                    <asp:BoundField DataField="telefone" HeaderText="Telefone" SortExpression="telefone" />
                    <asp:BoundField DataField="formacao" HeaderText="Formação" SortExpression="formacao" />
                    <asp:ButtonField ButtonType="Button" CommandName="carregar" Text="Carregar" />
                </Columns>
            </asp:GridView>
            </div>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
        </main>
    </form>
</body>
</html>
