

function toggleDisplay(id) {
    var x = document.getElementById(id);
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function toggleEsqueci() {
    toggleDisplay("frmSign");
    toggleDisplay("frmEsqueci");
}

var tr;

function pegarLinha(linha) {
    try {
        tr.style.backgroundColor = (linha % 2 == 0)? "#e8e8ff" : "#d0d0ff";
    } catch {}
    tr = document.getElementsByTagName("tr")[linha];
    tr.style.backgroundColor = "#004282"
}

function consultarPalestra() {
    toggleDisplay('frmConsulta');
    var td = tr.childNodes;
    var i = 1;
    if(!isNaN(parseInt(td[1].innerHTML))) {
        $("#codigo").apsx(td[1].innerHTML);
        i += 2;
    }
    $("#nome").html(td[i].innerHTML);
    i += 2;
    $("#local").html(td[i].innerHTML);
    i += 2;
    $("#data").html(td[i].innerHTML);
    i += 2;
    $("#avaliacao").html(td[i].innerHTML);
    i += 2;
    $("#lotacao").html(td[i].innerHTML);
    i += 2;
}