
/*Declaracion de variables por defecto*/
var monto = 0;
var procedimiento;
var nombreOriginalArchivo;
var cambioArchivo = false;

(function ($)
{
    $.fn.alphanumeric = function (p)
    {
        var input = $(this),
            az = "abcdefghijklmnopqrstuvwxyz",
            options = $.extend({
                ichars: '!@#$%^&*()+=[]\\\';,/{}|":<>?~`.- _',
                nchars: '',
                allow: ''
            }, p),
            s = options.allow.split(''),
            i = 0,
            ch,
            regex;

        for (i; i < s.length; i++)
        {
            if (options.ichars.indexOf(s[i]) != -1)
            {
                s[i] = '\\' + s[i];
            }
        }

        if (options.nocaps)
        {
            options.nchars += az.toUpperCase();
        }
        if (options.allcaps)
        {
            options.nchars += az;
        }

        options.allow = s.join('|');

        regex = new RegExp(options.allow, 'gi');
        ch = (options.ichars + options.nchars).replace(regex, '');

        input.keypress(function (e)
        {
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);

            if (ch.indexOf(key) != -1 && !e.ctrlKey)
            {
                e.preventDefault();
            }
        });

        input.blur(function ()
        {
            var value = input.val(),
                j = 0;

            for (j; j < value.length; j++)
            {
                if (ch.indexOf(value[j]) != -1)
                {
                    input.val('');
                    return false;
                }
            }
            return false;
        });

        return input;
    };

})(jQuery);

$('#codigoDocumento').alphanumeric();

function formatoNumero(num)
{
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.")
}

$("#monto").on({
    "focus": function (event)
    {
        $(event.target).select();
    },
    "keyup": function (event)
    {
        $(event.target).val(function (index, value)
        {

            var montoAux = value.replace(/\D/g, "")
                .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, "");

            if (montoAux <= monto)
            {
                return value.replace(/\D/g, "")
                    .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ".");
            }

            $('#title-alerta').text('Error');
            $('#body-alerta').text('El monto del documento no debe superar el moto solicitado');
            $('#modal-alerta').modal('show');
            $("#monto").val('');
            $("#monto").parsley().validate();
        });
    }
});

$('#fechaDocumento').on('change', function ()
{
    var fecha = $(this).val();
    if (fecha == undefined || fecha == '')
    {
        if ($(this).hasClass("parsley-success"))
        {
            $(this).removeClass("parsley-success");
        }
    }
});


function ObtenerDatosPrincipales()
{
    $.ajax({
        async: false,
        url: "/DeclaracionGastos/ObtenerDatos",
        method: "POST",
        data: "",
        success: function (respuesta)
        {
            //console.log(respuesta);
            procedimiento = "creación";
            monto = respuesta.monto;
            InsertarCategorias(respuesta.categorias);
            InsertarFechaMinMax(respuesta.fechaInicio, respuesta.fechaTermino);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown)
        {
            $('#title-alerta').text(textStatus);
            $('#body-alerta').text(errorThrown);
            $('#modal-alerta').modal('show');
        } 
    });
}

function obtenerDatosDocumento()
{
    $.ajax({
        async: false,
        url: "/DeclaracionGastos/DatosDocumento",
        method: "POST",
        data: "",
        success: function (respuesta)
        {
            console.log(respuesta);
            procedimiento = "actualización";
            id = respuesta.id;
            $('#codigoDocumento').val(respuesta.documento.codigoDocumento);
            $('#proveedor').val(respuesta.documento.proveedor);
            $('#fechaDocumento').val(respuesta.documento.fechaDocumento.split("T")[0]);
            $('#monto').val(formatoNumero(respuesta.documento.monto));
            $('#descripcionDocumento').val(respuesta.documento.descripcionDocumento);
            $('#categoria').val(respuesta.documento.categoria.id);
            $('#tipoDocumento').val(respuesta.documento.tipoDocumento);
            var rutaDoc = respuesta.documento.copiaDoc.split("\\");
            $('#nombreArchivo').text(rutaDoc[rutaDoc.length - 1]);
            nombreOriginalArchivo = rutaDoc[rutaDoc.length - 1];
        },
        error: function (XMLHttpRequest, textStatus, errorThrown)
        {
            $('#title-alerta').text(textStatus);
            $('#body-alerta').text(errorThrown);
            $('#modal-alerta').modal('show');
        } 
    });
}

function InsertarFechaMinMax(fechaInicio, fechaTermino)
{

    $('#fechaDocumento').mask('9999-99-99');
    $('#fechaDocumento').datepicker({
        dateFormat: 'yy-mm-dd',
        showOtherMonths: true,
        selectOtherMonths: true,
        minDate: fechaInicio.split("T")[0],
        maxDate: fechaTermino.split("T")[0],
        onClose: function ()
        {
            var fecha = $(this).parsley();
            fecha.validate();
            if ($(this).val() == "____-__-__")
            {
                $(this).val('');
                fecha.validate();
            }
            
        }
    });
}


function InsertarCategorias(categorias)
{
    $("#categoria").empty().append('<option selected disabled>Seleccione una categoría</option>');
    for (var i = 0; categorias != null && i < categorias.length; i++)
    {
        $('#categoria').append("<option value='" + categorias[i]["id"] + "'>" + categorias[i]["nombre"] + "</option>");
    }
}

// File type validation
$("#documento").on("change", function ()
{
    $(this).parsley().validate();
    if ($('#nombreArchivo').hasClass("bd-danger"))
    {
        $('#nombreArchivo').removeClass("bd-danger");
        $('#nombreArchivo').addClass("bd-success");
    }

    var file = this.files[0];
    var fileType = file.type;
    var match = ['application/pdf', 'image/jpeg', 'image/png', 'image/jpg'];
    //var match = 'application/pdf';

    for (var i = 0; i < match.length; i++)
    {
        if (fileType == match[i])
        {
            $("#documento").text(file.name);
            $("#nombreArchivo").text(file.name);
            $('#nombreArchivo').addClass("bd-success");
            cambioArchivo = true;
            return true;
        }
    }

    $('#title-alerta').text('Error');
    $('#body-alerta').text('Lo sentimos, solo se pueden subir archivos PDF, JPEG, PNG y JPG');
    $('#modal-alerta').modal('show');
    $("#documento").val('');
    $(this).parsley().validate();
    $('#nombreArchivo').addClass("bd-danger");
    $("#nombreArchivo").text("Seleccione un archivo PDF, JPEG, PNG o JPG");
    cambioArchivo = false;
    return false;
});

$('#guardar').click(function (e)
{
    var codigoDocumento = $('#codigoDocumento').parsley();
    var proveedor = $('#proveedor').parsley();
    var fechaDocumento = $('#fechaDocumento').parsley();
    var monto = $('#monto').parsley();
    var descripcionDocumento = $('#descripcionDocumento').parsley();
    var categoria = $('#categoria').parsley();
    var tipoDocumento = $('#tipoDocumento').parsley();
    var documento = $('#documento').parsley();
    var nombreResolucion = $('#nombreArchivo').text();

    /*Mensaje para actualizar los datos del documento*/
    if (codigoDocumento.isValid() && proveedor.isValid() && fechaDocumento.isValid()
        && monto.isValid() && descripcionDocumento.isValid() && categoria.isValid() && tipoDocumento.isValid() && procedimiento == "actualización" && nombreOriginalArchivo != undefined && (documento.isValid() || nombreOriginalArchivo == nombreResolucion))
    {
        e.preventDefault();
        $('#title-confirmar-guardar').text("Guardar datos");
        $('#body-confirmar-guardar').text("¿Está seguro que desea actualizar los datos del documento?");
        $('#modal-confirmar-guardar').modal('show');
    }
    /*Mensaje para crear los datos del documento*/
    else if (codigoDocumento.isValid() && proveedor.isValid() && fechaDocumento.isValid()
        && monto.isValid() && descripcionDocumento.isValid() && categoria.isValid() && tipoDocumento.isValid() && documento.isValid() && procedimiento == "creación")
    {
        e.preventDefault();
        $('#title-confirmar-guardar').text("Guardar datos");
        $('#body-confirmar-guardar').text("¿Está seguro que desea guardar los datos del documento?");
        $('#modal-confirmar-guardar').modal('show');
    }
    else
    {
        var accion;
        if (procedimiento == "creacion")
        {
            accion = "guardar";
        }
        else
        {
            accion = "modificar";
        }
        $('#title-alerta').text("Faltan Datos");
        $('#body-alerta').text("Lo sentimos, no se puede " + accion + " los datos del documento debido a que existen campos incompletos. Verifique que todos los campos esten completados y vuelva a intentarlo.");
        $('#modal-alerta').modal('show');
        codigoDocumento.validate();
        proveedor.validate();
        fechaDocumento.validate();
        monto.validate();
        descripcionDocumento.validate();

        categoria.validate();
        if (!categoria.isValid())
        {
            $('#categoria').addClass('is-invalid');
        }
        tipoDocumento.validate();
        if (!tipoDocumento.isValid())
        {
            $('#tipoDocumento').addClass('is-invalid');
        }


        if (procedimiento == "actualización" && nombreResolucion != nombreOriginalArchivo)
        {
            documento.validate();
            if (!rutaDoc.isValid())
            {
                $('#nombreArchivo').addClass('bd-danger');
            }
        }
        else
        {
            documento.validate();
            if (!documento.isValid())
            {
                $('#nombreArchivo').addClass('bd-danger');
            }
        }
        
    }
});

$('#btnConfirmarGuardar').click(function ()
{
    var datos = new FormData();
    datos.append('CodigoDocumento', $("#codigoDocumento").val());
    datos.append('Proveedor', $("#proveedor").val());
    datos.append('FechaDocumento', $("#fechaDocumento").val());
    datos.append('Monto', $("#monto").val().replace(/\D/g, "")
        .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ""));
    datos.append('DescripcionDocumento', $("#descripcionDocumento").val());
    datos.append('Categoria', $("#categoria").val());
    datos.append('TipoDocumento', $("#tipoDocumento").val());
    datos.append('Archivo', $('#documento')[0].files[0]);


    $('#modal-confirmar-guardar').modal("hide");
    var url;
    if (procedimiento == "actualización")
    {
        url = "/DeclaracionGastos/ModificarDocumento";
        datos.append('CambioArchivo', cambioArchivo);
    }
    else
    {
        url = "/DeclaracionGastos/CrearDeclaracionDocumento";
    }

    $.ajax({
        url: url,
        method: "POST",
        async: "false",
        data: datos,
        contentType: false,
        cache: false,
        processData: false,
        success: function (respuesta)
        {
            //alert("Se enviaron los datos");
            //console.log(respuesta);
            if (respuesta.validar)
            {
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
        },
        error: function (XMLHttpRequest, textStatus, errorThrown)
        {
            $('#title-alerta').text(textStatus);
            $('#body-alerta').text(errorThrown);
            $('#modal-alerta').modal('show');
        } 
    });
});

$('#btn-DocumentoCreado').click(function (e)
{
    e.preventDefault();
    $('#modal-informacion').modal("hide");
    window.location.href = '/DeclaracionGastos/Documentos';
})


$("#categoria").on("change", function ()
{
    $(this).parsley().validate();
    if ($(this).hasClass("is-invalid"))
    {
        $(this).removeClass("is-invalid");
        $(this).addClass("is-valid");
    }
});

$("#tipoDocumento").on("change", function ()
{
    $(this).parsley().validate();
    if ($(this).hasClass("is-invalid"))
    {
        $(this).removeClass("is-invalid");
        $(this).addClass("is-valid");
    }
});

$('#cancelarDocumento').click(function (e)
{
    e.preventDefault();
    $('#title-alerta-cancelar').text("Cancelar documento");
    $('#body-alerta-cancelar').text("¿Está seguro que desea cancelar la " + procedimiento + " el documento? Si lo hace, toda la información ingresada se perderá");
    $('#modal-alerta-cancelar').modal('show');
})

$('#btnConfirmarCancelar').click(function (e)
{
    e.preventDefault();
    $('#modal-alerta-cancelar').modal('hide');
    window.location.href = '/DeclaracionGastos/Documentos';
})