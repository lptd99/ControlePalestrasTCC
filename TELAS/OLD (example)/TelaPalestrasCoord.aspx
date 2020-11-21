<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaPalestrasCoord.aspx.cs" Inherits="TCCADS.TelaPalestrasCoord" %>

<!DOCTYPE html>

<html>
<head>
    <title>Controle das palestras</title>
    <meta charset="UTF-8">
    <link href="../css/standard.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

</head>
<body>
    <main>
        <ul class="nav">
            <li>
                <a id="home" href="HomeCoord.apsx">Início</a>
            </li>
            <li>
                <a id="ativo" href="#ativo">Controle de palestras</a>
            </li>
            <li title="Por hora desativado">
                <a id="controle" style="cursor: not-allowed" href="javascript:void(0)"
                   onclick="toggleDisplay('frmCadastro')">Cadastrar palestrante</a>
            </li>

            <li>
                <a id="sair" href="LoginCoord.apsx">Sair</a>
            </li>
        </ul>
        <table class="tbPalestras">
            <thead>
            <th>Código</th>
            <th>Nome</th>
            <th>Local</th>
            <th>Data</th>
            <th>Avaliação</th>
            <th>Nº de participantes presentes/total</th>
            </thead>
            <tr onclick="pegarLinha(1)">
                <td>123</td>
                <td>Power BI – Gerenciamento de informações eficiente</td>
                <td>Auditorio</td>
                <td>22/06</td>
                <td>9/10</td>
                <td>25/40</td>
            </tr>
            <tr onclick="pegarLinha(2)">
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr onclick="pegarLinha(2)">
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <br />

        <button id="btnConsulta" onclick="consultarPalestra()">Informacões da palestra</button>
        <a class="button" href="IncluirPalestraCoord.apsx">Incluir</a>
        <a class="button" href="AlterarPalestraCoord.apsx">Alterar</a>
        <button onclick="confirm('Excluindo palestra, tem certeza?')">Excluir</button>
        <button onclick="toggleDisplay('frmLista')">Lista de presença</button>
        <a class="button" href="../MISC/ModeloCertificadoCoord.pdf">Exibir certificado</a>

        <a class="button" href="HomeCoord.apsx" style="float: right">Voltar</a>

        <div id="frmConsulta">
            <table>
                <tr>
                    <td>Codigo</td>
                    <td id="codigo">1234</td>
                </tr>
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
        <iframe id="frmLista" src="listaPresenca.apsx"></iframe>
    </main>
    <script src="../js/telaPalestras.js"></script>
</body>
</html>