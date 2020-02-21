$('#N, #AP, #AM, #Dir').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ., /]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('<p>Ingresa un valor valido</p>', 'Campaña 2020 dice', { timeOut: 1000, closeButton: true });
    }
})

$('#Tel').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[0-9]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('Ingresa un valor valido', 'Campaña 2020 dice', { timeOut: 1000, closeButton: true });
    }
})

$('#Curp').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[A-Z0-9]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('Ingresa un valor valido', 'Campaña 2020 dice', { timeOut: 1000, closeButton: true });
    }
})

$('#NumExt, #NumInt').keypress(function (e) {
    let data = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    let regExp = new RegExp("^[a-záéíóúñA-ZÁÉÍÓÚÑ., /0-9]+$");

    if (!regExp.test(data)) {
        e.preventDefault();
        toastr.warning('<p>Ingresa un valor valido</p>', 'Campaña 2020 dice', { timeOut: 1000, closeButton: true });
    }
})



