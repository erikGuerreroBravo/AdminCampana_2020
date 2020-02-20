$('#Letras').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ., ]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
    }
})

$('#Num').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[1-9]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
    }
})

$('#Curp').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[A-Z1-9]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
    }
})

$('#Curp').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[A-Z1-9]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('Solo se Permiten Cadenas de Texto', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
    }
})





