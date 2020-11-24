<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciarPalestras.aspx.cs" Inherits="TCCADS.TELAS.GerenciarPalestras" %>

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
                        ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Palestrante
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPalestrante" runat="server"  DataTextField="nome" DataValueField="id"></asp:DropDownList>
                        <!--<asp:SqlDataSource ID="sqlDSPalestrante" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand="SELECT [id], [nome] FROM [Palestrante]"></asp:SqlDataSource>
                        -->
                    </td>
                </tr>
                <tr>
                    <td>
                        Coordenador
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCoordenador" runat="server"  DataTextField="nome" DataValueField="rgm"></asp:DropDownList>
                        <!--<asp:SqlDataSource ID="sqlDSCoordenador" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand="SELECT [rgm], [nome] FROM [Coordenador]"></asp:SqlDataSource>
                    -->
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
                        Data e Horário Início
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataHorarioInicio" runat="server" TextMode="DateTime" ToolTip="Exemplo: 2020-30-12 20:30:00"></asp:TextBox>
                    </td>
                    <td>
                        Formato: aaaa-dd-MM hh:mm:ss <br /> a = Ano, M = Mês, d = Dia, h = Hora, m = Minuto, s = Segundo
                    </td>
                </tr>
                <tr>
                    <td>
                        Data e Horário Término
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataHorarioTermino" runat="server" TextMode="DateTime" ToolTip="Exemplo: 2020-30-12 21:30:00"></asp:TextBox>
                    </td>
                    <td>
                        Formato: aaaa-dd-MM hh:mm:ss <br /> a = Ano, M = Mês, d = Dia, h = Hora, m = Minuto, s = Segundo
                    </td>
                </tr>
                <tr>
                    <td>
                        Curso
                    </td>
                    <td>
                        <asp:TextBox ID="txtCurso" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Local
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEspaco" runat="server" DataTextField="nome" DataValueField="id"></asp:DropDownList>
                        <!--<asp:SqlDataSource ID="sqlDSEspaco" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand="SELECT [id], [nome], [capacidade] FROM [Espaco]"></asp:SqlDataSource>
                    -->
                    </td>
                </tr>
                <tr>
                    <td>
                        Nota
                    </td>
                    <td>
                        <asp:TextBox ID="txtNota" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Inscritos
                    </td>
                    <td>
                        <asp:TextBox ID="txtInscritos" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            <asp:GridView ID="gvPalestras" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvPalestras_RowCommand">
                <Columns >
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" >
                    <HeaderStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" >
                    <HeaderStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Data e Horário de Início" HeaderText="Data e Horário de Início" SortExpression="Data e Horário de Início" >
                    <HeaderStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Data e Horário de Término" HeaderText="Data e Horário de Término" SortExpression="Data e Horário de Término" >
                    <HeaderStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Local" HeaderText="Local" SortExpression="Local" >
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Curso" HeaderText="Curso" SortExpression="Curso" >
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Palestrante" HeaderText="Palestrante" SortExpression="Palestrante" >
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Inscritos" HeaderText="Inscritos" SortExpression="Inscritos" >
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="carregar" Text="Carregar" />
                </Columns>
            </asp:GridView>
            <!--<asp:SqlDataSource ID="gvPalestrasDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand="SELECT [P].[id] as 'ID', [P].[nome] as 'Nome', [P].[dataHorarioInicio] as 'Data e Horário de Início', [P].[dataHorarioTermino] as 'Data e Horário de Término', [E].[nome] as 'Local', [P].[curso] as 'Curso', [PL].[nome] as 'Palestrante', CONCAT(CONCAT([P].[inscritos], '/'), [E].[capacidade]) as 'Inscritos' FROM [Palestra] as P INNER JOIN [Espaco] as E ON E.id = P.idEspaco INNER JOIN [Palestrante] as PL ON PL.id = P.idPalestrante"></asp:SqlDataSource>
            -->
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
