<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificado.aspx.cs" Inherits="TCCADS.TELAS.Certificado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link rel="stylesheet" href="../CSS/Certificado.css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <title>Certificado</title>
</head>
<body>
<form id="form1" runat="server">
    <main>
        <div style="float: right">
            <asp:Image ID="imgLogoUMC" runat="server" ImageUrl="~/MISC/LogoUMC.png" />
        </div>            
        <h1>C E R T I F I C A D O</h1>

        <asp:Label ID="lblTexto" runat="server" Text="Certificamos que o aluno [NOME_USUARIO], do curso [CURSO_USUARIO], participou do evento [NOME_PALESTRA], ministrado pelo Prof. [NOME_PALESTRANTE] no dia [DATA_INICIO_PALESTRA], com carga horária total de [TIMESPAN_HORAS] hora(s) e [TIMESPAN_MINUTOS] minuto(s)." Font-Names="Arial"></asp:Label>
        <div>
            <p class="data">
            </p>
        </div>
    </main>
    <button onclick="print()">Imprimir</button>
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
    <script>
        var mes = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];
        var d = new Date();
        $(".data").html("São Paulo, " + d.getDate() + " de " + mes[d.getMonth()] + " de " + d.getFullYear());
    </script>
</form>
</body>
</html>
