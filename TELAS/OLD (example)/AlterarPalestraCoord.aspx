<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarPalestraCoord.aspx.cs" Inherits="TCCADS.AlterarPalestraCoord" %>

<!DOCTYPE html>

<html>
<head>
    <title>Alterando palestra</title>
    <meta charset="UTF-8">
    <link href="../css/standard.css" rel="stylesheet">
</head>
<body>
    <form class="main">
        <table>
            <tr>
                <td>
                    <label for="txtNome">Nome</label>
                </td>
                <td>
                    <input type="text" id="txtNome" name="txtNome">
                </td>
            </tr>
            <tr>
                <td><label for="txtDataInicio">Data início</label></td>
                <td>
                    <input type="date" id="txtDataInicio" name="txtDataInicio">
                    <input type="time" id="txtHoraInicio" name="txtHoraInicio">
                </td>
            </tr>
            <tr>
                <td><label for="txtDataFim">Data início</label></td>
                <td>
                    <input type="date" id="txtDataFim" name="txtDataFim">
                    <input type="time" id="txtHoraFim" name="txtHoraFim">
                </td>
            </tr>
            <tr>
                <td><label for="txtTipo">Tipo</label></td>
                <td>
                    <input type="text" id="txtTipo" name="txtTipo">
                </td>
            </tr>
            <tr>
                <td><label for="txtLocal">Local</label></td>
                <td>
                    <input type="text" id="txtLocal" name="txtLocal">
                </td>
            </tr>
            <tr>
                <td><label for="txtPalestrante">Palestrante</label></td>
                <td>
                    <input type="text" id="txtPalestrante" name="txtPalestrante">
                </td>
            </tr>
            <tr>
                <td><label for="txtQtd">Lotação máxima</label></td>
                <td>
                    <input type="text" id="txtQtd" name="txtQtd">
                </td>
            </tr>
        </table>
        <br />
        <button type="submit">Salvar alterações</button>
        <a class="aButton" href="TelaPalestrasCoord.aspx">Voltar</a>
    </form>
</body>
</html>