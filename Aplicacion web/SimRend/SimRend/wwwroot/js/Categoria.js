function obtenerCategorias()
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
            'url': "/Categoria/LeerCategorias",
            'method': "POST",
            'data': "",
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            {
                "data": null,
                "className": "center",
                "render": function (data, type, full, meta)
                {
                    var id = data.id;
                    var estadoEliminacion = data.estadoEliminacion;
                    var nombreCategoria = data.nombre;
                    var boton;
                    if (estadoEliminacion == 'HABILITADO')
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarCategoria(' + id + ',\'' + nombreCategoria + '\')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarCategoria(' + id + ',\'' + nombreCategoria + '\')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarCategoria(' + id + ',\'' + nombreCategoria + '\')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ]
    });
}

function crearCategoria()
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
    $('#formCategoria').hide();

    $('#idCategoria').hide();
    
    $('#icon-create').show();
    $('#title-alerta-crear').show();
    $('#nombreCategoria').val('');
    $('#formCategoria').show();
    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionCrear()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionCrear()
{
    $('#icon-create').hide();
    $('#formCategoria').hide();
    var nombre = $('#nombreCategoria').val();

    $.ajax({
        url: "/Categoria/CrearCategoria",
        method: "POST",
        data: {
            'Nombre': nombre
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-create-success').show();
                $('#body-alerta').text(respuesta.msj).show();
                obtenerCategorias();
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            else
            {
                $('#title-alerta-crear').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para modificar categoría').show();
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



function modificarCategoria(id, nombreCategoria)
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
    $('#formCategoria').hide();

    $('#idCategoria').hide();
    

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="preguntarEditar()">Aceptar</button>';
    $('#icon-set').show();
    $('#title-alerta-editar').show();
    $('#nombreCategoria').val(nombreCategoria);
    $('#idCategoria').val(id);
    $('#formCategoria').show();
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function preguntarEditar()
{
    $('#body-alerta').text("¿Está seguro que desea modificar la categoría?");

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEditar()">Aceptar</button>';

    $('#icon-set').hide();
    $('#formCategoria').hide();
    $('#icon-set-confirm').show();
    $('#body-alerta').show();
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
}

function confirmacionEditar()
{
    $('#icon-set-confirm').hide();
    var nombre = $('#nombreCategoria').val();
    var id = $('#idCategoria').val();

    $.ajax({
        url: "/Categoria/ActualizarCategoria",
        method: "POST",
        data: {
            'IdCategoria': id,
            'Nombre': nombre
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-set-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerCategorias();
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            }
            else
            {
                $('#title-alerta-editar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para modificar categoría').show();
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



function eliminarCategoria(id, nombreCategoria)
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
    $('#formCategoria').hide();

    $('#idCategoria').hide();


    $('#icon-delete').show();
    $('#title-alerta-eliminar').show();
    $('#body-alerta').text("¿Está seguro que desea eliminar la categoría " + nombreCategoria + "?");
    $('#body-alerta').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminar()">Aceptar</button>';

    $('#idCategoria').val(id);
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionEliminar()
{
    $('#icon-delete').hide();
    var id = $('#idCategoria').val();

    $.ajax({
        url: "/Categoria/EliminarCategoria",
        method: "DELETE",
        data: {
            'IdCategoria': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerCategorias();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar categoría').show();
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