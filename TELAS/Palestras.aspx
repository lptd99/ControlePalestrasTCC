<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Palestras.aspx.cs" Inherits="TCCADS.TELAS.Palestras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title>Palestras</title>
</head>
<body>
<form id="form1" runat="server">
    <ul class="nav">
        <li><a class="active" href="#">Palestras</a></li>
        <li><a href="MinhasPalestras.aspx">Minhas Palestras</a></li>
        <li><a href="AlterarSenhaParticipante.aspx">Alterar Senha</a></li>
    </ul>
    <main>
        <div class="tb">
        <asp:GridView ID="gvPalestras" CssClass="tbPalestras" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvPalestras_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Data e Horário de Início" HeaderText="Data e Horário de Início" SortExpression="Data e Horário de Início" />
                <asp:BoundField DataField="Data e Horário de Término" HeaderText="Data e Horário de Término" SortExpression="Data e Horário de Término" />
                <asp:BoundField DataField="Local" HeaderText="Local" SortExpression="Local" />
                <asp:BoundField DataField="Curso" HeaderText="Curso" SortExpression="Curso" />
                <asp:BoundField DataField="Palestrante" HeaderText="Palestrante" SortExpression="Palestrante" />
                <asp:BoundField DataField="Inscritos" HeaderText="Inscritos" SortExpression="Inscritos" />
                <asp:ButtonField ButtonType="Button" CommandName="inscrever" Text="Inscrever-se" />
            </Columns>
        </asp:GridView>
        </div>
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
    </main>
</form>
</body>
</html>
