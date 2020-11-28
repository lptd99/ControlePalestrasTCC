<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciarPalestras.aspx.cs" Inherits="TCCADS.TELAS.GerenciarPalestras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title>Controle de Palestras</title>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="nav">
            <li><a class="active" href="#">Gerenciar Palestras</a></li>
            <li><a href="GerenciarEspacos.aspx">Gerenciar Espacos</a></li>
            <li><a href="GerenciarPalestrantes.aspx">Gerenciar Palestrantes</a></li>
            <li><a href="CadastrarCoordenador.aspx">Cadastrar Coordenador</a></li>
        </ul>
        <main>
            <h2>Controle de Palestras</h2>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Enabled="False" TextMode="Number" Placeholder="ID"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlPalestrante" runat="server"  DataTextField="nome" DataValueField="id"></asp:DropDownList>
                        
                    </td>
                    <td>
                        Palestrante
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlCoordenador" runat="server"  DataTextField="nome" DataValueField="rgm"></asp:DropDownList>
                        
                    </td>
                    <td>
                        Coordenador
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server"  Placeholder="Nome"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDataHorarioInicio" runat="server" TextMode="DateTime" ToolTip="Exemplo: 2020-30-12 20:30:00"  Placeholder="Data e hora de início"></asp:TextBox>
                    </td>
                    <td>
                        Formato: aaaa-dd-MM hh:mm:ss <br /> a = Ano, M = Mês, d = Dia, h = Hora, m = Minuto, s = Segundo
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDataHorarioTermino" runat="server" TextMode="DateTime" ToolTip="Exemplo: 2020-30-12 21:30:00"  Placeholder="Data e hora de término"></asp:TextBox>
                    </td>
                    <td>
                        Formato: aaaa-dd-MM hh:mm:ss <br /> a = Ano, M = Mês, d = Dia, h = Hora, m = Minuto, s = Segundo
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCurso" runat="server"  Placeholder="Curso"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlEspaco" runat="server" DataTextField="nome" DataValueField="id"></asp:DropDownList>
                        
                    </td>
                    <td>
                        Espaço
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNota" runat="server" Enabled="False" TextMode="Number"  Placeholder="Nota"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtInscritos" runat="server" Enabled="False" TextMode="Number"  Placeholder="Inscritos"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            <asp:GridView ID="gvPalestras" CssClass="tbPalestras" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvPalestras_RowCommand">
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
                    <asp:ButtonField ButtonType="Button" CommandName="enviar_presenca" Text="Enviar Presença" />
                </Columns>
            </asp:GridView>
            
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
        </main>
    </form>
</body>
</html>
