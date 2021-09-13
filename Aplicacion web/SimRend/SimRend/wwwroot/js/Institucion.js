function obtenerInstituciones()
{
    $('#tablaInstituciones').DataTable({
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
            'url': "/Institucion/LeerInstituciones",
            'method': "POST",
            'data': "",
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columns': [
            { "data": "id" },
            { "data": "abreviacion" },
            { "data": "nombre" },
            { "data": "estado" },
            {
                "data": null,
                "className": "center",
                "render": function (data, type, full, meta)
                {
                    var id = data.id;
                    var estadoEliminacion = data.estadoEliminacion;
                    var abreviacion = data.abreviacion;
                    var nombre = data.nombre;
                    var boton;
                    if (estadoEliminacion == 'HABILITADO')
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarInstitucion(' + id + ',\'' + abreviacion + '\',\'' + nombre + '\')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarInstitucion(' + id + ',\'' + nombre + '\')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarInstitucion(' + id + ',\'' + abreviacion + '\',\'' + nombre + '\')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ]
    });
}

function crearInstitucion()
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-set').hide();
    $('#icon-set-confirm').hide();
    $('#icon-set-success').hide();
    $('#icon-problema').hide();
    $('#icon-create').hide();
    $('#icon-create-success').hide();

    $('#title-alerta-eliminar').hide();
    $('#title-alerta-editar').hide();
    $('#title-alerta-problemas').hide();
    $('#title-alerta-crear').hide();

    $('#body-alerta').hide();
    $('#formInstitucion').hide();

    $('#idInstitucion').hide();
    
    $('#icon-create').show();
    $('#title-alerta-crear').show();
    $('#abreviacion').val('');
    $('#nombre').val('');
    $('#formInstitucion').show();
    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionCrear()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionCrear()
{
    $('#icon-create').hide();
    $('#formInstitucion').hide();
    var abreviacion = $('#abreviacion').val();
    var nombre = $('#nombre').val();

    $.ajax({
        url: "/Institucion/CrearInstitucion",
        method: "POST",
        data: {
            'Abreviacion': abreviacion,
            'Nombre': nombre
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-create-success').show();
                $('#body-alerta').text(respuesta.msj).show();
                obtenerInstituciones();
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            else
            {
                $('#title-alerta-crear').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para crear la institución').show();
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
}

function modificarInstitucion(id, abreviacion, nombre)
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-set').hide();
    $('#icon-set-confirm').hide();
    $('#icon-set-success').hide();
    $('#icon-problema').hide();
    $('#icon-create').hide();
    $('#icon-create-success').hide();

    $('#title-alerta-eliminar').hide();
    $('#title-alerta-editar').hide();
    $('#title-alerta-problemas').hide();
    $('#title-alerta-crear').hide();

    $('#body-alerta').hide();
    $('#formInstitucion').hide();

    $('#idInstitucion').hide();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="preguntarEditar()">Aceptar</button>';
    $('#icon-set').show();
    $('#title-alerta-editar').show();
    $('#abreviacion').val(abreviacion);
    $('#nombre').val(nombre);
    $('#idInstitucion').val(id);
    $('#formInstitucion').show();
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function preguntarEditar()
{
    $('#body-alerta').text("¿Está seguro que desea modificar la institución?");

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEditar()">Aceptar</button>';

    $('#icon-set').hide();
    $('#formInstitucion').hide();
    $('#icon-set-confirm').show();
    $('#body-alerta').show();
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
}

function confirmacionEditar()
{
    $('#icon-set-confirm').hide();
    var abreviacion = $('#abreviacion').val();
    var nombre = $('#nombre').val();
    var id = $('#idInstitucion').val();

    $.ajax({
        url: "/Institucion/ActualizarInstitucion",
        method: "POST",
        data: {
            'IdInstitucion': id,
            'Abreviacion': abreviacion,
            'Nombre': nombre
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-set-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerInstituciones();
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            else
            {
                $('#title-alerta-editar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para modificar la institución').show();
                $('#body-alerta').text(respuesta.msj);
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            $('#actions-alerta').empty().append(botonAceptar);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown)
        {
            $('#title-alerta-editar').hide();
            $('#icon-problema').show();
            $('#title-alerta').text(textStatus);
            $('#body-alerta').text(errorThrown);
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
            $('#modal-alerta').modal('show');
        }
    });
}

function eliminarInstitucion(id, nombre)
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-set').hide();
    $('#icon-set-confirm').hide();
    $('#icon-set-success').hide();
    $('#icon-problema').hide();
    $('#icon-create').hide();
    $('#icon-create-success').hide();

    $('#title-alerta-eliminar').hide();
    $('#title-alerta-editar').hide();
    $('#title-alerta-problemas').hide();
    $('#title-alerta-crear').hide();

    $('#body-alerta').hide();
    $('#formInstitucion').hide();

    $('#idInstitucion').hide();

    $('#icon-delete').show();
    $('#title-alerta-eliminar').show();
    $('#body-alerta').text("¿Está seguro que desea eliminar la institución " + nombre + "?");
    $('#body-alerta').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminar()">Aceptar</button>';

    $('#idInstitucion').val(id);
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionEliminar()
{
    $('#icon-delete').hide();
    var id = $('#idInstitucion').val();

    $.ajax({
        url: "/Institucion/EliminarInstitucion",
        method: "DELETE",
        data: {
            'IdInstitucion': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerInstituciones();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar la institución').show();
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

function mayus(e)
{
    e.value = e.value.toUpperCase();
}