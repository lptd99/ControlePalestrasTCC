<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificado.aspx.cs" Inherits="TCCADS.TELAS.Certificado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgLogoUMC" runat="server" BorderStyle="Dashed" ImageAlign="Right" ImageUrl="~/MISC/LogoUMC.png" Width="300px" />
                    
            <asp:Label ID="lblTitulo" runat="server" Text="C E R T I F I C A D O" Font-Size="XX-Large" Font-Names="Arial"></asp:Label> <br />

            <asp:Label ID="lblTexto" runat="server" Text="Certificamos que o aluno [NOME_USUARIO], do curso [CURSO_USUARIO], participou do evento [NOME_PALESTRA], ministrado pelo Prof. [NOME_PALESTRANTE] no dia [DATA_INICIO_PALESTRA], com carga horária total de [TIMESPAN_HORAS] hora(s) e [TIMEPSAN_MINUTOS] minuto(s)." Font-Names="Arial"></asp:Label>
        </div>
    </form>
</body>
</html>
