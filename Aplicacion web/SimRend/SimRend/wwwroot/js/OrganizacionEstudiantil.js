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
            { "data": "campus" },
            { "data": "tipo" },
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
        url: "/OrganizacionEstudiantil/ObtenerDatosPrincipales",
        method: "GET",
        data: {},
        success: function (respuesta)
        {
            listarCampus(respuesta.campus);
            listarTipoOE(respuesta.tiposOE);
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

function crearCategoria()
{
    $('#icon-problema').hide();
    $('#icon-create').hide();
    $('#icon-create-success').hide();

    $('#title-alerta-problemas').hide();
    $('#title-alerta-crear').hide();

    $('#body-alerta').hide();

    $('#icon-create').show();
    $('#title-alerta-crear').show();

    $('#body-alerta').text('¿Esta seguro que desea guardar los datos?').show();

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

    if (nombreOE.isValid() && emailOE.isValid() && campus.isValid() && tiposOE.isValid())
    {
        var datos = {
            'Nombre': $("#nombreOE").val(),
            'Email': $("#emailOE").val(),
            'IdCampus': $("#campus").val(),
            'IdTipoOE': $("#tiposOE").val(),
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
                    //var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="redireccionar()">Aceptar</button>';
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
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

    $('#volverOES').click(function (e)
    {
        e.preventDefault();
        window.location.href = '/OrganizacionEstudiantil/OrganizacionesEstudiantiles';
    });
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
    $('#body-alerta').text("¿Esta seguro que desea eliminar la organización estudiantil?");
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
                $('#title-alerta-problemas').text('Problemas eliminar campus').show();
                $('#body-alerta').text(respuesta.msj);
            }
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}

function modificarOE(id)
{
    alert("Se modificará la OE con id " + id);
}