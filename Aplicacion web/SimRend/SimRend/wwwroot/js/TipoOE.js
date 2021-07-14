function obtenerTipoOE()
{
    $('#tablaTipoOE').DataTable({
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
            'url': "/TipoOE/LeerTipoOE",
            'method': "POST",
            'data': "",
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "nombreExtendido" },
            { "data": "estado" },
            {
                "data": null,
                "className": "center",
                "render": function (data, type, full, meta)
                {
                    var id = data.id;
                    var estadoEliminacion = data.estadoEliminacion;
                    var nombre = data.nombre;
                    var nombreExtendido = data.nombreExtendido;
                    var boton;
                    if (estadoEliminacion == 'HABILITADO')
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarTipoOE(' + id + ',\'' + nombre + '\',\'' + nombreExtendido + '\')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarTipoOE(' + id + ',\'' + nombreExtendido + '\')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarTipoOE(' + id + ',\'' + nombre + '\',\'' + nombreExtendido + '\')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ]
    });
}

function crearTipoOE()
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
    $('#formTipoOE').hide();

    $('#idTipoOE').hide();
    
    $('#icon-create').show();
    $('#title-alerta-crear').show();
    $('#nombreTipoOE').val('');
    $('#nombreExtendido').val('');
    $('#formTipoOE').show();
    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionCrear()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionCrear()
{
    $('#icon-create').hide();
    $('#formTipoOE').hide();
    var nombre = $('#nombreTipoOE').val();
    var nombreExtendido = $('#nombreExtendido').val();

    $.ajax({
        url: "/TipoOE/CrearTipoOE",
        method: "POST",
        data: {
            'Nombre': nombre,
            'NombreExtendido': nombreExtendido
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-create-success').show();
                $('#body-alerta').text(respuesta.msj).show();
                obtenerTipoOE();
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            else
            {
                $('#title-alerta-crear').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para crear tipo de O.E.').show();
                $('#body-alerta').text(respuesta.msj).show();
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}

function modificarTipoOE(id, nombre, nombreExtendido)
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
    $('#formTipoOE').hide();

    $('#idTipoOE').hide();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="preguntarEditar()">Aceptar</button>';
    $('#icon-set').show();
    $('#title-alerta-editar').show();
    $('#nombreTipoOE').val(nombre);
    $('#nombreExtendido').val(nombreExtendido);
    $('#idTipoOE').val(id);
    $('#formTipoOE').show();
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function preguntarEditar()
{
    $('#body-alerta').text("¿Esta seguro que desea modificar el tipo de O.E.?");

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEditar()">Aceptar</button>';

    $('#icon-set').hide();
    $('#formTipoOE').hide();
    $('#icon-set-confirm').show();
    $('#body-alerta').show();
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
}

function confirmacionEditar()
{
    $('#icon-set-confirm').hide();
    var nombre = $('#nombreTipoOE').val();
    var nombreExtendido = $('#nombreExtendido').val();
    var id = $('#idTipoOE').val();

    $.ajax({
        url: "/TipoOE/ActualizarTipoOE",
        method: "POST",
        data: {
            'IdTipoOE': id,
            'Nombre': nombre,
            'NombreExtendido': nombreExtendido
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-set-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerTipoOE();
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            else
            {
                $('#title-alerta-editar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para modificar el tipo de O.E.').show();
                $('#body-alerta').text(respuesta.msj);
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}

function eliminarTipoOE(id, nombre)
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
    $('#formTipoOE').hide();

    $('#idTipoOE').hide();

    $('#icon-delete').show();
    $('#title-alerta-eliminar').show();
    $('#body-alerta').text("¿Esta seguro que desea eliminar el tipo de O.E. " + nombre + "?");
    $('#body-alerta').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminar()">Aceptar</button>';

    $('#idTipoOE').val(id);
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionEliminar()
{
    $('#icon-delete').hide();
    var id = $('#idTipoOE').val();

    $.ajax({
        url: "/TipoOE/EliminarTipoOE",
        method: "DELETE",
        data: {
            'IdTipoOE': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerTipoOE();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar tipo de O.E.').show();
                $('#body-alerta').text(respuesta.msj);
            }
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}