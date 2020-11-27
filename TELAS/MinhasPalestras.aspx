﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MinhasPalestras.aspx.cs" Inherits="TCCADS.TELAS.MinhasPalestras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/standard.css" />
    <title>Minhas Palestras</title>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="nav">
            <li><a href="Palestras.aspx">Palestras</a></li>
            <li><a class="active" href="#">Minhas Palestras</a></li>
            <li><a href="AlterarSenhaParticipante.aspx">Alterar Senha</a></li>
        </ul>

        <main>


            <asp:GridView ID="gvMinhasPalestras" CssClass="tbPalestras" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvMinhasPalestras_RowCommand">
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
                    <asp:BoundField DataField="Sala" HeaderText="Sala" SortExpression="Sala" >
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
                    <asp:ButtonField ButtonType="Button" CommandName="avaliar" Text="Avaliar" />
                    <asp:ButtonField ButtonType="Button" CommandName="imprimirCertificado" Text="Imprimir Certificado" />
                </Columns>
            </asp:GridView>
            <!-- <asp:SqlDataSource ID="gvMinhasPalestrasDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:TCCADSConnectionString %>" SelectCommand= "SELECT [P].[id] as 'ID', [P].[nome] as 'Nome', [P].[dataHorarioInicio] as 'Data e Horário de Início', [P].[dataHorarioTermino] as 'Data e Horário de Término', [E].[nome] as 'Sala', [P].[curso] as 'Curso', [PL].[nome] as 'Palestrante', CONCAT(CONCAT([P].[inscritos], '/'), [E].[capacidade]) as 'Inscritos' FROM [Palestra] as P INNER JOIN [Espaco] as E ON E.id = P.idEspaco INNER JOIN [Palestrante] as PL ON PL.id = P.idPalestrante INNER JOIN [Inscricao] as I on P.id = I.idPalestra"></asp:SqlDataSource>
            -->
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </main>
    </form>
</body>
</html>
