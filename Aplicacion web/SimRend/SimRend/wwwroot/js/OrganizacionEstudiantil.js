function obtenerOE()
{
    $('#tablaCategoria').DataTable({
        'destroy': true,
        'bLengthChange': false,
        'searching': false,
        'dom': "Bfrtip",
        'responsive': true,
        'language': {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ".",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        'ajax': {
            'url': "/OrganizacionEstudiantil/LeerOrganizaciones",
            'method': "POST",
            'data': "",
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "email" },
            { "data": "campus.nombre" },
            { "data": "tipoOE.nombre" },
            { "data": "estado" },
            {
                "data": null,
                "className": "center",
                "render": function (data, type, full, meta)
                {
                    var id = data.id;
                    var estadoEliminacion = data.estadoEliminacion;
                    var boton;
                    if (estadoEliminacion == 'HABILITADO')
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarOE(' + id + ')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarOE(' + id + ')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarOE(' + id + ')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ]
    });
}

function obtenerDatos()
{
    $.ajax({
        async: false,
        url: "/OrganizacionEstudiantil/ObtenerDatosPrincipales",
        method: "GET",
        data: {},
        success: function (respuesta)
        {
            listarCampus(respuesta.campus);
            listarTipoOE(respuesta.tiposOE);
            listarInstituciones(respuesta.instituciones);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown)
        {
            $('#icon-problema').hide();
            $('#icon-create').hide();
            $('#icon-create-success').hide();

            $('#title-alerta-problemas').hide();
            $('#title-alerta-crear').hide();

            $('#body-alerta').hide();

            $('#icon-problema').show();
            $('#title-alerta').text(textStatus);
            $('#body-alerta').text(errorThrown);
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
            $('#modal-alerta').modal('show');
        } 
    });
}

function listarTipoOE(tiposOE)
{
    $("#tiposOE").empty().append('<option selected disabled>Seleccione el tipo de O.E.</option>');
    for (var i = 0; tiposOE != null && i < tiposOE.length; i++)
    {
        $('#tiposOE').append("<option value='" + tiposOE[i]["id"] + "'>" + tiposOE[i]["nombre"] + "</option>");
    }
}

function listarCampus(campus)
{
    $("#campus").empty().append('<option selected disabled>Seleccione el campus al que pertenece la O.E.</option>');
    for (var i = 0; campus != null && i < campus.length; i++)
    {
        $('#campus').append("<option value='" + campus[i]["id"] + "'>" + campus[i]["nombre"] + "</option>");
    }
}

function listarInstituciones(instituciones)
{
    console.log(instituciones);
    $("#institucion").empty().append('<option selected disabled>Seleccione el campus al que pertenece la O.E.</option>');
    for (var i = 0; instituciones != null && i < instituciones.length; i++)
    {
        $('#institucion').append("<option value='" + instituciones[i]["id"] + "'>" + instituciones[i]["nombre"] + "</option>");
    }
}

function crearOE()
{
    $('#icon-problema').hide();
    $('#icon-create').hide();
    $('#icon-create-success').hide();

    $('#title-alerta-problemas').hide();
    $('#title-alerta-crear').hide();

    $('#body-alerta').hide();

    $('#icon-create').show();
    $('#title-alerta-crear').show();

    $('#body-alerta').text('¿Está seguro que desea guardar los datos?').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionCrear()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionCrear()
{
    $('#icon-create').hide();

    var nombreOE = $('#nombreOE').parsley();
    var emailOE = $('#emailOE').parsley();
    var campus = $('#campus').parsley();
    var tiposOE = $('#tiposOE').parsley();
    var institucion = $('#institucion').parsley();

    if (nombreOE.isValid() && emailOE.isValid() && campus.isValid() && tiposOE.isValid() && institucion.isValid())
    {
        var datos = {
            'Nombre': $("#nombreOE").val(),
            'Email': $("#emailOE").val(),
            'IdCampus': $("#campus").val(),
            'IdTipoOE': $("#tiposOE").val(),
            'IdInstitucion': $('#institucion').val()
        };

        $.ajax({
            url: "/OrganizacionEstudiantil/RegistrarOE",
            method: "POST",
            data: datos,
            async: false,
            success: function (respuesta)
            {
                var botonAceptar;
                if (respuesta.validar)
                {
                    $('#icon-create-success').show();
                    $('#body-alerta').text(respuesta.msj).show();
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverOEs()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-crear').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para crear la organización estudiantil').show();
                    $('#body-alerta').text(respuesta.msj).show();
                    botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                }
                $('#actions-alerta').empty().append(botonAceptar);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown)
            {
                $('#title-alerta-crear').hide();
                $('#icon-problema').show();
                $('#title-alerta').text(textStatus);
                $('#body-alerta').text(errorThrown);
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                $('#actions-alerta').empty().append(botonAceptar);
                $('#modal-alerta').modal('show');
            } 
        });
        //return true;
    }
    else
    {
        nombreOE.validate();
        emailOE.validate();

        campus.validate();
        if (!campus.isValid())
        {
            $('#campus').addClass('is-invalid');
        }

        tiposOE.validate();
        if (!tiposOE.isValid())
        {
            $('#tiposOE').addClass('is-invalid');
        }

        $('#title-alerta-crear').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para crear la organización estudiantil').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}


function eliminarOE(id)
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-problema').hide();

    $('#title-alerta-eliminar').hide();
    $('#title-alerta-problemas').hide();

    $('#body-alerta').hide();

    $('#idOE').hide();

    $('#icon-delete').show();
    $('#title-alerta-eliminar').show();
    $('#body-alerta').text("¿Está seguro que desea eliminar la organización estudiantil?");
    $('#body-alerta').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminar()">Aceptar</button>';

    $('#idOE').val(id);
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionEliminar()
{
    $('#icon-delete').hide();
    var id = $('#idOE').val();

    $.ajax({
        url: "/OrganizacionEstudiantil/EliminarOE",
        method: "DELETE",
        data: {
            'IdOE': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerOE();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar la organizacioón estudiantil').show();
                $('#body-alerta').text(respuesta.msj);
            }
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown)
        {
            $('#title-alerta-eliminar').hide();
            $('#icon-problema').show();
            $('#title-alerta').text(textStatus);
            $('#body-alerta').text(errorThrown);
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
            $('#modal-alerta').modal('show');
        } 
    });
}

function modificarOE(idOE)
{
    $.ajax({
        async: false,
        url: "/OrganizacionEstudiantil/GuardarIdOE",
        method: "POST",
        data: {
            'IdOE': idOE,
        },
        success: function (respuesta)
        {
            window.location.href = '/OrganizacionEstudiantil/ActualizarOE';
        }
    });
}

function obtenerDatosOE()
{
    $.ajax({
        async: false,
        url: "/OrganizacionEstudiantil/LeerOE",
        method: "GET",
        data: {},
        success: function (respuesta)
        {
            $('#idOE').val(respuesta.id).hide();
            $('#nombreOE').val(respuesta.nombre);
            $('#emailOE').val(respuesta.email);
            $('#campus').val(respuesta.campus.id);
            $('#tiposOE').val(respuesta.tipoOE.id);
            $('#institucion').val(respuesta.institucion.id);
        }
    });
}


async function main()
{
    try
    {
        await obtenerDatos();
        await obtenerDatosOE();
    }
    catch (e)
    {
        console.log(e);
    }
}


function actualizarOE()
{
    $('#icon-problema').hide();
    $('#icon-modificar').hide();
    $('#icon-modificar-success').hide();

    $('#title-alerta-problemas').hide();
    $('#title-alerta-modificar').hide();

    $('#body-alerta').hide();

    $('#icon-modificar').show();
    $('#title-alerta-modificar').show();

    $('#body-alerta').text('¿Está seguro que desea modificar los datos?').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionActualizar()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionActualizar()
{
    $('#icon-modificar').hide();

    var nombreOE = $('#nombreOE').parsley();
    var emailOE = $('#emailOE').parsley();
    var campus = $('#campus').parsley();
    var tiposOE = $('#tiposOE').parsley();
    var institucion = $('#institucion').parsley();

    if (nombreOE.isValid() && emailOE.isValid() && campus.isValid() && tiposOE.isValid() && institucion.isValid())
    {
        var datos = {
            'Nombre': $("#nombreOE").val(),
            'Email': $("#emailOE").val(),
            'IdCampus': $("#campus").val(),
            'IdTipoOE': $("#tiposOE").val(),
            'IdOE': $("#idOE").val(),
            'IdInstitucion': $('#institucion').val()
        };

        $.ajax({
            url: "/OrganizacionEstudiantil/ModificarOE",
            method: "POST",
            data: datos,
            async: false,
            success: function (respuesta)
            {
                var botonAceptar;
                if (respuesta.validar)
                {
                    $('#icon-modificar-success').show();
                    $('#body-alerta').text(respuesta.msj).show();
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverOEs()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-modificar').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para modificar la organización estudiantil').show();
                    $('#body-alerta').text(respuesta.msj).show();
                    botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                }
                $('#actions-alerta').empty().append(botonAceptar);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown)
            {
                $('#title-alerta-modificar').hide();
                $('#icon-problema').show();
                $('#title-alerta').text(textStatus);
                $('#body-alerta').text(errorThrown);
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                $('#actions-alerta').empty().append(botonAceptar);
                $('#modal-alerta').modal('show');
            } 
        });
    }
    else
    {
        nombreOE.validate();
        emailOE.validate();

        campus.validate();
        if (!campus.isValid())
        {
            $('#campus').addClass('is-invalid');
        }

        tiposOE.validate();
        if (!tiposOE.isValid())
        {
            $('#tiposOE').addClass('is-invalid');
        }

        $('#title-alerta-modificar').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para modificar la organización estudiantil').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}

function volverOEs()
{
    window.location.href = '/OrganizacionEstudiantil/OrganizacionesEstudiantiles';
}
