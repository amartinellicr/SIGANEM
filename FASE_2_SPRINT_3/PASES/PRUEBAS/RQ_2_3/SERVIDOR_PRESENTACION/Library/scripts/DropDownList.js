function fn_chg(control) {
//    var a = this.document.getElementById('ctl00_ContentPlaceHolder1_IdCalificacionEmpresaCalificadora');
    var a = this.document.getElementById(control);
    a.className = 'ctrDropDown';
}

function fn_moused(control) {
//    var a = this.document.getElementById('ctl00_ContentPlaceHolder1_IdCalificacionEmpresaCalificadora');
    var a = this.document.getElementById(control);    
    a.className = 'ctrDropDownClick';
}


function fn_blur(control) {
//    var a = this.document.getElementById('ctl00_ContentPlaceHolder1_IdCalificacionEmpresaCalificadora');
    var a = this.document.getElementById(control);
    a.className = 'ctrDropDown';
}