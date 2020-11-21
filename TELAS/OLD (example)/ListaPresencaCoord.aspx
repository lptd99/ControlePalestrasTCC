﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPresencaCoord.aspx.cs" Inherits="TCCADS.ListaPresencaCoord" %>

<!DOCTYPE html>

<html>
<head>
    <title>Lista de presença</title>
    <meta charset="UTF-8">
    <link href="standard.css" rel="stylesheet">
</head>
<body>
    <div class="main">
        <table class="tbPalestras">
            <thead>
            <th>Nome</th>
            <th>RGM</th>
            <th>Avaliação</th>
            <th>Presença</th>
            </thead>
            <tr>
                <td>José da Silva</td>
                <td>171911</td>
                <td>10/10</td>
                <td>
                    <input type="checkbox" id="cbPresenca" name="cbPresenca">
                </td>
            </tr>
            <tr>
                <td>Maria dos Rios</td>
                <td>191725</td>
                <td>8/10</td>
                <td>
                    <input type="checkbox" id="cbPresenca" name="cbPresenca">
                </td>
            </tr>
            <tr>
                <td>Pedro Alcântara</td>
                <td>192202</td>
                <td>9/10</td>
                <td>
                    <input type="checkbox" id="cbPresenca" name="cbPresenca">
                </td>
            </tr>
            <tr>
                <td>Antônio</td>
                <td>191106</td>
                <td>9/10</td>
                <td>
                    <input type="checkbox" id="cbPresenca" name="cbPresenca">
                </td>
            </tr>
        </table>
    </div>
</body>
</html>