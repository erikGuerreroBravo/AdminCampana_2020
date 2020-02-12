$(document).ready(function () {

    $('#btnEnviar').click(function ()
    {
        toastr.success("Datos Guardados Correctamente.", "App-Campaña dice", { timeOut: 1000, closeButton: true });
    });

   

});