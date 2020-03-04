$(document).ready(function () {
      
    $('#btnEnviar').click(function (e)
    {
        
            toastr.success("Datos Guardados Correctamente.", "App-2020 dice", { timeOut: 1000, closeButton: true });
            //window.location.replace("http://localhost:51085/Home/Index");
            return true;         

        //Validación de correo electrónico
        //var correoI = $('#Correo').val();

        //var regex = new RegExp("^[a-zA-Z0-9._-]{3,25}[@]{1}(hotmail|gmail|outlook|yahoo){1}[.]{1}(com|mx|net|es){1}$");
        
        //if (!regex.test(correoI)) {
        //    e.preventDefault();
        //    toastr.warning('Ingresa un valor valido', 'Campaña 2020 dice', { timeOut: 1000, closeButton: true });
        //    return false;
        //} else {
        //    toastr.success("Datos Guardados Correctamente.", "App-2020 dice", { timeOut: 1000, closeButton: true });
        ////window.location.replace("http://localhost:51085/Home/Index");
        //    return true;
        //}       
    });
});