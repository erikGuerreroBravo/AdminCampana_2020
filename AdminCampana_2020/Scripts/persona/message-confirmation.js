$(document).ready(function () {

    $('#btnEnviar').click(function ()
    {
        toastr.success("Datos Guardados Correctamente.", "App-2020 dice", { timeOut: 1000, closeButton: true });
        //window.location.replace("http://localhost:51085/Home/Index");
    });

   

});