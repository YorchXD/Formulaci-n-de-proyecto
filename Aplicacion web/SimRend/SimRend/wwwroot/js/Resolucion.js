var cambioArchivo = false;
$('#volver').click(function (e)
{
    e.preventDefault();
    window.location.href = '/Proceso/VerProceso';
});

$('#volverProcesos').click(function (e)
{
    e.preventDefault();
    window.location.href = '/Proceso/Procesos/';
});

$('#guardar').click(function (e)
{
    var rutaDoc = $('#resolucion').parsley();
    var numResolucion = $("#numResolucion").parsley();
    var anioResolucion = $("#anioResolucion").parsley();

    //console.log(rutaDoc, numResolucion, anioResolucion);
    if (rutaDoc.isValid() && numResolucion.isValid() && anioResolucion.isValid())
    {
        e.preventDefault();
        $('#title-confirmar-guardar').text("Guardar datos");
        $('#body-confirmar-guardar').text("¿Está seguro que desea guardar los datos de la resolución?");
        $('#modal-confirmar-guardar').modal('show');
    }
    else
    {
        $('#title-alerta').text("Faltan Datos");
        $('#body-alerta').text("Lo sentimos, no se puede guardar los datos de la resulución debido a que existen campos incompletos. Verifique que todos los campos esten completados y vuelva a intentarlo.");
        $('#modal-alerta').modal('show');
        anioResolucion.validate();
        numResolucion.validate();
        rutaDoc.validate();
        if (!rutaDoc.isValid())
        {
            $('#nombreArchivo').addClass('bd-danger');
        }
    }
});

$('#btn-ResolucionCreada').click(function (e)
{
    e.preventDefault();
    window.location.href = '/Proceso/VerProceso/';
})

function obtenerSolicitud()
{
    $.ajax({
        url: "/Solicitud/LeerSolicitud",
        method: "POST",
        async: "false",
        data:"",
        success: function (respuesta)
        {
            datosPrincipalesSolicitud(respuesta.solicitud);
        }
    });
}

function obtenerResolucion()
{
    $.ajax({
        url: "/Resolucion/LeerResolucion",
        method: "POST",
        async: "false",
        data: "",
        success: function (respuesta)
        {
            datosResolucion(respuesta.resolucion);
        }
    });
}

function datosPrincipalesSolicitud(solicitud)
{
    //console.log(solicitud);
    document.getElementById("nombreEvento").innerHTML = solicitud.nombreEvento;
    document.getElementById("lugarEvento").innerHTML = solicitud.lugarEvento;
    document.getElementById("monto").innerHTML = '$' + formatoNumero(solicitud.monto);
    document.getElementById("fechaInicio").innerHTML = solicitud.fechaInicioEvento.split("T")[0];
    document.getElementById("fechaTermino").innerHTML = solicitud.fechaTerminoEvento.split("T")[0];
    document.getElementById("responsable").innerHTML = solicitud.nombreResponsable;
}

function datosResolucion(resolucion)
{
    var rutaDoc = resolucion.copiaDoc.split("\\");
    $("#numResolucion").val(resolucion.numResolucion);
    $("#anioResolucion").val(resolucion.anioResolucion);
    $("#nombreArchivo").text(rutaDoc[rutaDoc.length - 1]);
}

function formatoNumero(num)
{
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")
}

$(".numeric").numeric();


// File type validation
$("#resolucion").on("change",function ()
{
    $(this).parsley().validate();
    if ($('#nombreArchivo').hasClass("bd-danger"))
    {
        $('#nombreArchivo').removeClass("bd-danger");
        $('#nombreArchivo').addClass("bd-success");
    }

    var file = this.files[0];
    var fileType = file.type;
    /*var match = ['application/pdf', 'application/msword', 'application/vnd.ms-office', 'image/jpeg', 'image/png', 'image/jpg'];*/
    var match = 'application/pdf';
    if (fileType != match)
    {
        $('#title-alerta').text('Error');
        $('#body-alerta').text('Lo sentimos, solo se pueden subir archivos PDF');
        $('#modal-alerta').modal('show');
        $("#resolucion").val('');
        $(this).parsley().validate();
        $('#nombreArchivo').addClass("bd-danger");
        $("#nombreArchivo").text("Seleccione un archivo PDF");
        return false;
    }
    else
    {
        $("#resolucion").text(file.name);
        $("#nombreArchivo").text(file.name);
        cambioArchivo = true;
        ('#nombreArchivo').removeClass("bd-success");
        return true;
    } 
});



$('#btnConfirmarGuardar').click(function ()
{
    var datos = new FormData();
    datos.append('Archivo', $('#resolucion')[0].files[0]);
    datos.append('NumResolucion', $("#numResolucion").val());
    datos.append('AnioResolucion', $("#anioResolucion").val());

    $('#modal-confirmar-guardar').modal("hide");

    $.ajax({
        url: "/Resolucion/CrearResolucion",
        method: "POST",
        async: "false",
        data: datos,
        contentType: false,
        cache: false,
        processData: false,
        success: function (respuesta)
        {
            //console.log(respuesta);
            if (respuesta.validar)
            {
                obtenerSolicitud();
                $('#title-informacion').text(respuesta.titulo);
                $('#body-informacion').text(respuesta.msj);
                $('#modal-informacion').modal('show');
            }
            else
            {
                $('#title-alerta').text(respuesta.titulo);
                $('#body-alerta').text(respuesta.msj);
                $('#modal-alerta').modal('show');
            }
        }
    });
});