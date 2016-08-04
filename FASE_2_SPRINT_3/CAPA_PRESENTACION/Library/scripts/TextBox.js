function AutoCompletar(txt, ddlTipoBien, ddlFormato, valorAuto) {
    var ddl1 = this.document.getElementById(ddlTipoBien);
    var ddl2 = this.document.getElementById(ddlFormato);
    var txt = this.document.getElementById(txt);

    var bandera = false;

    //VERIFICACION PARA LOS TIPOS DE BIENES 1 Y 2
    var textoTipoBien = ddl1.options[ddl1.selectedIndex].text.toString().substring(0,3);
    if (textoTipoBien == '1 -' || textoTipoBien == '2 -' || textoTipoBien == '9 -') {
        bandera = true;
    }

    //VERIFICACION PARA EL TIPO DE BIEN 10
    textoTipoBien = ddl1.options[ddl1.selectedIndex].text.toString().substring(0, 4);
    if (textoTipoBien == '10 -') {
        bandera = true;
    }

    //VERIFICACION PARA EL TIPO DE FORMATO NUMERICO 6 ENTEROS
    if (ddl2.value == 1) {
        bandera = true;
    }

    //SI LA BANDERA ES VERDADERA ENTONCES SE APLICA EL AUTOCOMPLETADO
    if (bandera) {
        var valor = txt.value.toString().replace(/_/g,'');
        var n = valor.length;
        var c = 6 - n;
        var resultado = '';

        for (var i = 0; i < c; i++) {
            resultado = resultado + valorAuto;
        }

        resultado = resultado + valor;
        txt.value = resultado;
        }
}


function CompletarCerosIzquierda(txt, maxleght) {
    var txt = this.document.getElementById(txt);
    var valor = txt.value.toString().replace(/_/g, '');

    var n = valor.length;
    var c = maxleght - n;
    var resultado = '';

    if (valor != '') {
        for (var i = 0; i < c; i++) {
            resultado = resultado + 0;
        }

        resultado = resultado + valor;
        txt.value = resultado;
    }
    else {
        txt.value = resultado;
    }
}


function Cero(txt) {
    var txt = this.document.getElementById(txt);
    var valor = txt.value.toString().replace(/_/g, '').replace(',','').replace('.','');
    valor = valor.replace('.', '');
    if (valor == '') {
        txt.value = '1';
    }
}