<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Palestras.aspx.cs" Inherits="TCCADS.TELAS.Palestras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvPalestras" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvPalestras_RowCommand">
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
            <!--<asp:SqlDataSource ID="gvPalestrasDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand="SELECT [P].[id] as 'ID', [P].[nome] as 'Nome', [P].[dataHorarioInicio] as 'Data e Horário de Início', [P].[dataHorarioTermino] as 'Data e Horário de Término', [E].[nome] as 'Local', [P].[curso] as 'Curso', [PL].[nome] as 'Palestrante', CONCAT(CONCAT([P].[inscritos], '/'), [E].[capacidade]) as 'Inscritos' FROM [Palestra] as P INNER JOIN [Espaco] as E ON E.id = P.idEspaco INNER JOIN [Palestrante] as PL ON PL.id = P.idPalestrante where dataHorarioInicio > GETDATE()"></asp:SqlDataSource>
            -->
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
</body>
</html>
