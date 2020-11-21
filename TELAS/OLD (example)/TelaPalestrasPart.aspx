<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaPalestrasPart.aspx.cs" Inherits="TCCADS.TelaPalestrasPart" %>

<!DOCTYPE html>

<html>
<head>
    <title>Exibição das palestras</title>
    <meta charset="UTF-8">
    <link href="../css/standard.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
</head>
<body>
    <main>
        <table class="tbPalestras">
            <thead>
            <th>Nome</th>
            <th>Local</th>
            <th>Data</th>
            <th>Avaliação</th>
            </thead>
            <tr onclick="pegarLinha(1)">
                <td>Power BI – Gerenciamento de informações eficiente</td>
                <td>Auditorio</td>
                <td>22/06</td>
                <td>9/10</td>
            </tr>
            <tr onclick="pegarLinha(2)">
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <br />
        <button onclick="consultarPalestra()">Informacões da palestra</button>
        <button onclick="confirm('Confirmar inscrição?')">Inscrever-se na palestra selecionada</button>
        <button onclick="prompt('Digite um número de 0 a 10')">Avaliar</button>
        <a class="aButton" href="LoginPart.apsx" style="float: right">Sair</a>
        <!--

        <iframe id="frmConsulta" src="consultarPalestraPart.apsx"></iframe>
        -->
        <div id="frmConsulta" style="display: none;">
            <table>
                <tr>
                    <td>Nome</td>
                    <td id="nome">xxxx</td>
                </tr>
                <tr>
                    <td>Data início</td>
                    <td id="data">dd/MM/aaaa hh:mm</td>
                </tr>
                <tr>
                    <td>Data fim</td>
                    <td>dd/MM/aaaa hh:mm</td>
                </tr>
                <tr>
                    <td>Tipo</td>
                    <td>yyyy</td>
                </tr>
                <tr>
                    <td>Local</td>
                    <td id="local">Auditrio</td>
                </tr>
                <tr>
                    <td>Palestrante</td>
                    <td>João da Silva</td>
                </tr>
                <tr>
                    <td>Lotacao Máxima</td>
                    <td id="lotacao">40</td>
                </tr>
                <tr>
                    <td>Avaliação</td>
                    <td id="avaliacao">9/10</td>
                </tr>
            </table>
        </div>
    </main>
    <script src="../js/telaPalestras.js"></script>
</body>
</html>