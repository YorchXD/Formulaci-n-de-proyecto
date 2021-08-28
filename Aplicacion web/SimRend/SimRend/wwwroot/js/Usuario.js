var table;
var oes;

function obtenerDirectores()
{
    table = $('#tablaUsuarioDirector').DataTable({
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
            'url': "/Usuario/LeerDirectores",
            'method': "GET",
            'data': "",
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columnDefs': [{
            targets: 9,
            data: "estado",
            render: function (data, type, row)
            {
                var disabled = 'disabled=""';

                if (type === 'display')
                {
                    if (data)
                    {
                        return '<input id="toggleDirector" class="editor-active" type="checkbox" checked >';
                    }
                    return '<input id="toggleDirector" class="editor-active" type="checkbox" >';
                }
                return data;
            }
        }],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "sexo" },
            { "data": "email" },
            { "data": "organizacion.institucion.abreviacion" },
            { "data": "organizacion.campus.nombre"},
            { "data": "cargo" },
            { "data": "organizacion.nombre" },
            { "data": "fonoAnexo" },
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
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarDirector(' + id + ')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarDirector(' + id + ')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarDirector(' + id + ')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ],
        'rowCallback': function (row, data)
        {
            $('.editor-active', row).prop('checked', data.estado == 'Habilitado').bootstrapToggle({
                size: 'mini',
                on: 'Si',
                off: 'No',
                onstyle: 'success',
                offstyle: 'secondary'
            });
        },
    });
}

$(document).on("change", "#toggleDirector", function ()
{
    var checked = $(this).prop('checked');
    var estado;
    if (checked)
    {
        estado = 'Habilitado';
    }
    else
    {
        estado = 'Deshabilitado';
    }

    $.ajax({
        async: false,
        url: "/Usuario/HabilitarUsuarioDirector",
        method: "POST",
        data: {
            'Estado': estado,
            'IdUsuarioDirector': table.row($(this).parents('tr')).data().id
        },
        success: function (respuesta)
        {
            obtenerDirectores();
            $('#icon-delete').hide();
            $('#icon-delete-confirm').hide();
            $('#icon-delete-success').hide();
            $('#icon-problema').hide();

            $('#title-alerta-eliminar').hide();
            $('#title-alerta-problemas').hide();

            $('#body-alerta').hide();
            if (!respuesta)
            {
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para cambiar el estado del usuario director').show();
                $('#body-alerta').text("No se puede '"+ estado+"' al usuario director debido a que ha ocurrido un problema de conexión. Vuelva a intentarlo y si el persiste el conflicto, favor de ponerse en contacto con soporte.");
            
                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                $('#actions-alerta').empty().append(botonAceptar);
            }
        }
    });
});

function eliminarDirector(id)
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-problema').hide();

    $('#title-alerta-eliminar').hide();
    $('#title-alerta-problemas').hide();

    $('#body-alerta').hide();

    $('#idDirector').hide();

    $('#icon-delete').show();
    $('#title-alerta-eliminar').show();
    $('#body-alerta').text("¿Está seguro que desea eliminar al usuario director? Recuerde que si elimina al usuario director, la O.E. no podrá crear solicitudes hasta crear o habilitar a otro usuario director.");
    $('#body-alerta').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminarDirector()">Aceptar</button>';

    $('#idDirector').val(id);
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionEliminarDirector()
{
    $('#icon-delete').hide();
    var id = $('#idDirector').val();

    $.ajax({
        url: "/Usuario/EliminarDirector",
        method: "DELETE",
        data: {
            'idDirector': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerDirectores();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar al director').show();
                $('#body-alerta').text(respuesta.msj);
            }
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}

function obtenerCampus()
{
    $.ajax({
        async: false,
        url: "/Usuario/ObtenerCampus",
        method: "GET",
        data: {},
        success: function (respuesta)
        {
            var accion = window.location.pathname.split("/")[2];

            if (accion === 'CrearUsuarioRepresentante')
            {
                $("#campus").empty().append('<option selected disabled>Seleccione el campus al que pertenece el usuario representante</option>');
            }
            else
            {
                $("#campus").empty().append('<option selected disabled>Seleccione el campus al que pertenece el usuario director</option>');
            }

            for (var i = 0; respuesta != null && i < respuesta.length; i++)
            {
                $('#campus').append("<option value='" + respuesta[i]["id"] + "'>" + respuesta[i]["nombre"] + "</option>");
            }

            $('#oe').attr('disabled', 'disabled');
        }
    });
}

function obtenerOEs()
{
    var idCampus = $('#campus').val();

    $.ajax({
        async: false,
        url: "/Usuario/ObtenerOEs",
        method: "GET",
        data: {
            'IdCampus': idCampus
        },
        success: function (respuesta)
        {
            console.log(respuesta);
            var accion = window.location.pathname.split("/")[2];

            if (accion === 'CrearUsuarioRepresentante')
            {
                $("#oe").empty().append('<option selected disabled>Seleccione la O.E. a la que pertenece el usuario representante</option>');
                oes = respuesta;
            }
            else if (accion === 'CrearUsuarioDirector')
            {
                $("#oe").empty().append('<option selected disabled>Seleccione la O.E. a la que pertenece el usuario director</option>');
                oes = respuesta.filter(oe => oe.tipoOE.nombre === 'CAA');
            }
            else
            {
                /*Aun no esta creado*/
                console.log("Vicerector");
                oes = respuesta;
            }
           
            if (respuesta != null && respuesta.length > 0 && accion != 'ActualizarUsuarioRepresentante')
            {
                $('#oe').removeAttr('disabled');
            }
            else
            {
                $('#oe').attr('disabled', 'disabled');
            }

            for (var i = 0; oes != null && i < oes.length; i++)
            {
                $('#oe').append("<option value='" + oes[i]["id"] + "'>" + oes[i]["nombre"] + "</option>");
            }
        }
    });
}

function volverDirectores()
{
    window.location.href = '/Usuario/UsuariosDirectores';
}

function crearUsuarioDirector()
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

    var nombre = $('#nombre').parsley();
    var email = $('#email').parsley();
    var clave = $('#clave').parsley();
    var sexo = $('#sexo').parsley();
    var cargo = $('#cargo').parsley();
    var fonoAnexo = $('#fonoAnexo').parsley();
    var idCampus = $('#campus').parsley();
    var idOE = $('#oe').parsley();

    if (nombre.isValid() && email.isValid() && clave.isValid() && sexo.isValid() && cargo.isValid() && fonoAnexo.isValid() && idCampus.isValid() && idOE.isValid())
    {
        var datos = {
            'Nombre': $("#nombre").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'Cargo': $("#cargo").val(),
            'FonoAnexo': $("#fonoAnexo").val(),
            'IdOE': $("#oe").val()
        };

        $.ajax({
            url: "/Usuario/RegistrarUsuarioDirector",
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
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverDirectores()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-crear').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para crear al usuario director').show();
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
        nombre.validate();
        email.validate();
        clave.validate();
        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }

        cargo.validate();
        fonoAnexo.validate();
        idCampus.validate();
        if (!idCampus.isValid())
        {
            $('#campus').addClass('is-invalid');
        }

        idOE.validate();
        if (!idOE.isValid())
        {
            $('#oe').addClass('is-invalid');
        }

        $('#title-alerta-crear').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para crear al usuario director').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}

$("#sexo, #campus, #oe, #rol, #institucion").on("change", function ()
{
    $(this).parsley().validate();
    if ($(this).hasClass("is-invalid"))
    {
        $(this).removeClass("is-invalid");
        $(this).addClass("is-valid");
    }
});

function modificarDirector(id)
{
    $.ajax({
        async: false,
        url: "/Usuario/GuardarIdUsuarioDirector",
        method: "POST",
        data: {
            'Id': id,
        },
        success: function (respuesta)
        {
            window.location.href = '/Usuario/ActualizarUsuarioDirector';
        }
    });
}

function obtenerDirector()
{
    $.ajax({
        async: false,
        url: "/Usuario/LeerUsuarioDirector",
        method: "GET",
        data: {},
        success: function (respuesta)
        {
            $('#id').val(respuesta.id).hide();
            $('#idOE').val(respuesta.idOrganizacionEstudiantil).hide();
            $('#nombre').val(respuesta.nombre);
            $('#email').val(respuesta.email);
            $('#clave').val(respuesta.clave);
            $('#sexo').val(respuesta.sexo);
            $('#cargo').val(respuesta.cargo);
            $('#fonoAnexo').val(respuesta.fonoAnexo);
        }
    });
}

function modificarUsuarioDirector()
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
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionModificar()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionModificar()
{
    $('#icon-modificar').hide();

    var nombre = $('#nombre').parsley();
    var email = $('#email').parsley();
    var sexo = $('#sexo').parsley();
    var cargo = $('#cargo').parsley();
    var fonoAnexo = $('#fonoAnexo').parsley();

    if (nombre.isValid() && email.isValid() && sexo.isValid() && cargo.isValid() && fonoAnexo.isValid())
    {
        var datos = {
            'Id': $("#id").val(),
            'IdOE': $("#idOE").val(),
            'Nombre': $("#nombre").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'Cargo': $("#cargo").val(),
            'FonoAnexo': $("#fonoAnexo").val(),
        };

        $.ajax({
            url: "/Usuario/ActualizarUsuarioDirector",
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
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverDirectores()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-modificar').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para modificar al usuario director').show();
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
        nombre.validate();
        email.validate();
        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }
        cargo.validate();
        fonoAnexo.validate();

        $('#title-alerta-modificar').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para modificar al usuario director').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}

function obtenerRepresentantes()
{
    table = $('#tablaUsuarioRepresentante').DataTable({
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
            'url': "/Usuario/LeerRepresentantes",
            'method': "GET",
            'data': {
                'IdCampus': $('#campusSelect').val(),
                'IdOE': $('#oeSelect').val(),
                'IdRol': $('#rolSelect').val(),
            },
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columnDefs': [{
            targets: 8,
            data: "estado",
            render: function (data, type, row)
            {
                var disabled = 'disabled=""';

                if (type === 'display')
                {
                    if (data)
                    {
                        return '<input id="toggleRepresentante" class="editor-active" type="checkbox" checked >';
                    }
                    return '<input id="toggleRepresentante" class="editor-active" type="checkbox" >';
                }
                return data;
            }
        }],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "matricula" },
            { "data": "email" },
            { "data": "institucion.abreviacion" },
            { "data": "organizacion.campus.nombre" },
            { "data": "organizacion.nombre" },
            { "data": "rol.nombre" },
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
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarRepresentante(' + id + ')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarRepresentante(' + id + ')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarRepresentante(' + id + ')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ],
        'rowCallback': function (row, data)
        {
            $('.editor-active', row).prop('checked', data.estado == 'Habilitado').bootstrapToggle({
                size: 'mini',
                on: 'Si',
                off: 'No',
                onstyle: 'success',
                offstyle: 'secondary'
            });
        },
    });
}

$(document).on("change", "#toggleRepresentante", function ()
{
    var checked = $(this).prop('checked');
    var estado;
    if (checked)
    {
        estado = 'Habilitado';
    }
    else
    {
        estado = 'Deshabilitado';
    }

    $.ajax({
        async: false,
        url: "/Usuario/HabilitarUsuarioRepresentante",
        method: "POST",
        data: {
            'Estado': estado,
            'IdUsuarioRepresentante': table.row($(this).parents('tr')).data().id
        },
        success: function (respuesta)
        {
            obtenerRepresentantes();
            $('#icon-delete').hide();
            $('#icon-delete-confirm').hide();
            $('#icon-delete-success').hide();
            $('#icon-problema').hide();

            $('#title-alerta-eliminar').hide();
            $('#title-alerta-problemas').hide();

            $('#body-alerta').hide();
            if (!respuesta)
            {
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para cambiar el estado del usuario representante').show();
                $('#body-alerta').text("No se puede '" + estado + "' al usuario representante debido a que ha ocurrido un problema de conexión. Vuelva a intentarlo y si el persiste el conflicto, favor de ponerse en contacto con soporte.");

                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                $('#actions-alerta').empty().append(botonAceptar);
            }
        }
    });
});

function obtenerRolesSelect()
{
    $.ajax({
        async: false,
        url: "/Usuario/LeerRolesRepresentantes",
        method: "GET",
        data: "",
        success: function (respuesta)
        {
            $("#rolSelect").empty().append('<option disabled>Seleccione un rol</option>');
            $('#rolSelect').append("<option value = 0 selected>Todos los roles</option>");

            for (var i = 0; (respuesta != null || respuesta.length > 0) && i < respuesta.length; i++)
            {
                $('#rolSelect').append("<option value='" + respuesta[i].id + "'>" + respuesta[i].nombre + "</option>");
            }
        }
    });
}

function obtenerCampusSelect()
{
    $.ajax({
        async: false,
        url: "/Usuario/LeerCampusRepresentantes",
        method: "GET",
        data: "",
        success: function (respuesta)
        {
            $("#campusSelect").empty().append('<option disabled>Seleccione un campus</option>');
            $('#campusSelect').append("<option value = 0 selected>Todos los campus</option>");

            for (var i = 0; (respuesta != null || respuesta.length > 0) && i < respuesta.length; i++)
            {
                $('#campusSelect').append("<option value='" + respuesta[i].id + "'>" + respuesta[i].nombre + "</option>");
            }
        }
    });
}

function obtenerOEsVistaListarRepresentante()
{
    var idCampus = $('#campusSelect').val();
    $.ajax({
        async: false,
        url: "/Usuario/ObtenerOEs",
        method: "GET",
        data: { 'IdCampus': idCampus},
        success: function (respuesta)
        {
            $("#oeSelect").empty().append('<option disabled>Seleccione una O.E.</option>');
            $('#oeSelect').append("<option value = 0 selected>Todas las O.E.</option>");

            for (var i = 0; (respuesta != null || respuesta.length > 0) && i < respuesta.length; i++)
            {
                if (idCampus == 0)
                {
                    $('#oeSelect').append("<option value='" + respuesta[i].id + "'>" + respuesta[i].nombre + " (" + respuesta[i].campus.nombre + ")</option>");
                }
                else
                {
                    $('#oeSelect').append("<option value='" + respuesta[i].id + "'>" + respuesta[i].nombre + "</option>");
                }
                
            }
        }
    });
}

async function main()
{
    try
    {
        await obtenerCampusSelect();
        await obtenerOEsVistaListarRepresentante();
        await obtenerRolesSelect();
        await obtenerRepresentantes();
    }
    catch (e)
    {
        console.log(e);
    }
}

$("#campusSelect").on("change", async function ()
{
    await obtenerOEsVistaListarRepresentante();
    await obtenerRepresentantes();                  

});

$("#oeSelect, #rolSelect").on("change", function ()
{
    obtenerRepresentantes();
});

function obtenerRoles()
{
    $.ajax({
        async: false,
        url: "/Usuario/LeerRolesRepresentantes",
        method: "GET",
        data: "",
        success: function (respuesta)
        {
            $("#rol").empty().append('<option selected disabled>Seleccione el rol del usuario representantre</option>');

            for (var i = 0; (respuesta != null || respuesta.length > 0) && i < respuesta.length; i++)
            {
                $('#rol').append("<option value='" + respuesta[i].id + "'>" + respuesta[i].nombre + "</option>");
            }
        }
    });
}

function volverRepresentantes()
{
    window.location.href = '/Usuario/UsuariosRepresentantes';
}

function checkRun(Run)
{
    // Despejar Puntos
    var valor = Run.value.replaceAll('.', '');
    // Despejar Guión
    valor = valor.replaceAll('-', '');
    // Aislar Cuerpo y Dígito Verificador
    cuerpo = valor.slice(0, -1);
    dv = valor.slice(-1).toUpperCase();
    // Formatear RUN
    Run.value = cuerpo + '-' + dv

    // Si no cumple con el mínimo ej. (n.nnn.nnn)
    if (cuerpo.length < 7)
    {
        Run.setCustomValidity("RUN Incompleto");
        $('#run').parsley().removeError("customValidationId");
        $('#run').parsley().addError("customValidationId", { message: "Run incompleto" });
        return false;
    }

    // Calcular Dígito Verificador
    suma = 0;
    multiplo = 2;

    // Para cada dígito del Cuerpo
    for (i = 1; i <= cuerpo.length; i++) 
    {
        // Obtener su Producto con el Múltiplo Correspondiente
        index = multiplo * valor.charAt(cuerpo.length - i);
        // Sumar al Contador General
        suma = suma + index;

        // Consolidar Múltiplo dentro del rango [2,7]
        if (multiplo < 7)
        {
            multiplo = multiplo + 1;
        }
        else
        {
            multiplo = 2;
        }
    }

    // Calcular Dígito Verificador en base al Módulo 11
    dvEsperado = 11 - (suma % 11);
    // Casos Especiales (0 y K)
    dv = (dv == 'K') ? 10 : dv;
    dv = (dv == 0) ? 11 : dv;
    // Validar que el Cuerpo coincide con su Dígito Verificador
    if (dvEsperado != dv)
    {
        Run.setCustomValidity("RUN Inválido");
        $('#run').parsley().removeError("customValidationId");
        $('#run').parsley().addError("customValidationId", { message: "Run invalido" });
        return false;
    }
    // Si todo sale bien, eliminar errores (decretar que es válido)
    Run.setCustomValidity('');
    $('#run').parsley().removeError("customValidationId");
}


function validarRUN(run)
{
    // Despejar Puntos
    var valor = run.replaceAll('.', '');
    // Despejar Guión
    valor = valor.replaceAll('-', '');
    // Aislar Cuerpo y Dígito Verificador
    cuerpo = valor.slice(0, -1);
    dv = valor.slice(-1).toUpperCase();
    // Formatear RUN
    run = cuerpo + '-' + dv

    // Si no cumple con el mínimo ej. (n.nnn.nnn)
    if (cuerpo.length < 7)
    {
        return false;
    }

    // Calcular Dígito Verificador
    suma = 0;
    multiplo = 2;

    // Para cada dígito del Cuerpo
    for (i = 1; i <= cuerpo.length; i++) 
    {
        // Obtener su Producto con el Múltiplo Correspondiente
        index = multiplo * valor.charAt(cuerpo.length - i);
        // Sumar al Contador General
        suma = suma + index;

        // Consolidar Múltiplo dentro del rango [2,7]
        if (multiplo < 7)
        {
            multiplo = multiplo + 1;
        }
        else
        {
            multiplo = 2;
        }
    }

    // Calcular Dígito Verificador en base al Módulo 11
    dvEsperado = 11 - (suma % 11);

    // Casos Especiales (0 y K)
    dv = (dv == 'K') ? 10 : dv;
    dv = (dv == 0) ? 11 : dv;

    // Validar que el Cuerpo coincide con su Dígito Verificador
    if (dvEsperado != dv)
    {
        return false;
    }

    return true;
}

function eliminarRepresentante(id)
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-problema').hide();

    $('#title-alerta-eliminar').hide();
    $('#title-alerta-problemas').hide();

    $('#body-alerta').hide();

    $('#idDirector').hide();

    $('#icon-delete').show();
    $('#title-alerta-eliminar').show();
    $('#body-alerta').text("¿Está seguro que desea eliminar al usuario representante? Recuerde que si elimina al usuario representante, es probable que la O.E. no podrá crear solicitudes hasta crear o habilitar a otro usuario representante.");
    $('#body-alerta').show();

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminarRepresentante()">Aceptar</button>';

    $('#idDirector').val(id);
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionEliminarRepresentante()
{
    $('#icon-delete').hide();
    var id = $('#idDirector').val();

    $.ajax({
        url: "/Usuario/EliminarRepresentante",
        method: "DELETE",
        data: {
            'idRepresentante': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerRepresentantes();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar al representante').show();
                $('#body-alerta').text(respuesta.msj);
            }
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}

function crearUsuarioRepresentante()
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
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionCrearRepresentante()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionCrearRepresentante()
{
    $('#icon-create').hide();

    var nombre = $('#nombre').parsley();
    var run = $('#run').parsley();
    var matricula = $('#matricula').parsley();
    var email = $('#email').parsley();
    var clave = $('#clave').parsley();
    var sexo = $('#sexo').parsley();
    var rol = $('#rol').parsley();
    var idCampus = $('#campus').parsley();
    var idOE = $('#oe').parsley();
    var idInstitucion = $('#institucion').parsley();

    if (nombre.isValid() && run.isValid() && matricula.isValid() && email.isValid() && clave.isValid() && sexo.isValid() && rol.isValid() && idCampus.isValid() && idOE.isValid() && idInstitucion.isValid())
    {
        var datos = {
            'Nombre': $("#nombre").val(),
            'Run': $("#run").val(),
            'Matricula': $("#matricula").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'IdRol': $("#rol").val(),
            'IdOE': $("#oe").val(),
            'IdInstitucion': $("#institucion").val()
        };

        $.ajax({
            url: "/Usuario/RegistrarUsuarioRepresentante",
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
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverRepresentantes()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-crear').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para crear al usuario representante').show();
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
        nombre.validate();
        run.validate();
        matricula.validate();
        email.validate();
        clave.validate();

        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }

        rol.validate();
        if (!rol.isValid())
        {
            $('#rol').addClass('is-invalid');
        }

        idCampus.validate();
        if (!idCampus.isValid())
        {
            $('#campus').addClass('is-invalid');
        }

        idOE.validate();
        if (!idOE.isValid())
        {
            $('#oe').addClass('is-invalid');
        }

        idInstitucion.validate();
        if (!idInstitucion.isValid())
        {
            $('#institucion').addClass('is-invalid');
        }

        $('#title-alerta-crear').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para crear al usuario representante').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}

function obtenerInstitucion()
{
    var idOE = $('#oe').val();
    var idCampus = $('#campus').val()
    var organizacionEstudiantil = oes.find(organizacion => organizacion.id == idOE);

    var accion = window.location.pathname.split("/")[2];

    if (accion === 'CrearUsuarioRepresentante')
    {
        $("#institucion").empty().append('<option selected disabled>Seleccione la institución a la que pertenece el usuario representante</option>');
    }
    else
    {
        $("#institucion").empty().append('<option selected disabled>Seleccione la institucion a la que pertenece el usuario director</option>');
    }

    if (organizacionEstudiantil.tipoOE.nombre == 'CAA')
    {
        $('#institucion').attr('disabled', 'disabled');
        $('#institucion').append("<option value='" + organizacionEstudiantil.institucion.id + "' selected>" + organizacionEstudiantil.institucion.nombre + "</option>");
    }
    else
    {
        $.ajax({
            async: false,
            url: "/Usuario/LeerInstituciones",
            method: "GET",
            data: "",
            success: function (respuesta)
            {
                respuesta = respuesta.filter(inst => inst.abreviacion != 'DAAE')


                if (respuesta != null && respuesta.length > 0)
                {
                    $('#institucion').removeAttr('disabled');
                }
                else
                {
                    $('#institucion').attr('disabled', 'disabled');
                }

                for (var i = 0; respuesta != null && i < respuesta.length; i++)
                {
                    $('#institucion').append("<option value='" + respuesta[i]["id"] + "'>" + respuesta[i]["nombre"] + "</option>");
                }
            }
        });
    }
}

async function mainActualizar()
{
    try
    {
        var representante = await obtenerUsuario();
        console.log(representante);
        $('#id').val(representante.id).hide();
        $('#nombre').val(representante.nombre);
        $('#run').val(representante.run);
        $('#matricula').val(representante.matricula);
        $('#email').val(representante.email);
        $('#sexo').val(representante.sexo);
        $('#rol').append("<option value='" + representante.rol.id + "' selected>" + representante.rol.nombre + "</option>");
        $('#campus').append("<option value='" + representante.organizacion.campus.id + "' selected>" + representante.organizacion.campus.nombre + "</option>");
        await obtenerOEs();
        $('#oe').val(representante.organizacion.id);
        await obtenerInstitucion();
        $('#institucion').val(representante.institucion.id);

    }
    catch (e)
    {
        console.log(e);
    }
}

function obtenerUsuario()
{
    var representante;
    $.ajax({
        async: false,
        url: "/Usuario/LeerRepresentante",
        method: "GET",
        data: "",
        success: function (respuesta)
        {
            representante = respuesta;
        }
    });
    return representante;
}

function modificarRepresentante(id)
{
    $.ajax({
        async: false,
        url: "/Usuario/GuardarIdRepresentante",
        method: "POST",
        data: {
            'Id': id,
        },
        success: function (respuesta)
        {
            window.location.href = '/Usuario/ActualizarUsuarioRepresentante';
        }
    });
}

function modificarUsuarioRepresentante()
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
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionModificarRepresentante()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionModificarRepresentante()
{
    $('#icon-modificar').hide();

    var nombre = $('#nombre').parsley();
    var run = $('#run').parsley();
    var matricula = $('#matricula').parsley();
    var email = $('#email').parsley();
    var sexo = $('#sexo').parsley();
    var rol = $('#rol').parsley();
    var campus = $('#campus').parsley();
    var organizacion = $('#oe').parsley();
    var institucion = $('#institucion').parsley();

    if (nombre.isValid() && run.isValid() && matricula.isValid() && email.isValid())
    {
        var datos = {
            'Id': $("#id").val(),
            'Nombre': $("#nombre").val(),
            'RUN': $("#run").val(),
            'Matricula': $("#matricula").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'IdRol': $("#rol").val(),
            'IdCampus': $("#campus").val(),
            'IdOE': $("#oe").val(),
            'IdInstitucion': $("#institucion").val(),
        };

        $.ajax({
            url: "/Usuario/ActualizarUsuarioRepresentante",
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
                    var botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverRepresentantes()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-modificar').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para modificar al usuario representante').show();
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
        nombre.validate();
        run.validate();
        matricula.validate();
        email.validate();
        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }
        rol.validate();
        if (!rol.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }
        campus.validate();
        if (!campus.isValid())
        {
            $('#campus').addClass('is-invalid');
        }
        organizacion.validate();
        if (!organizacion.isValid())
        {
            $('#oe').addClass('is-invalid');
        }
        institucion.validate();
        if (!institucion.isValid())
        {
            $('#institucion').addClass('is-invalid');
        }

        $('#title-alerta-modificar').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para modificar al usuario representante').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}

function obtenerVicerectores()
{
    table = $('#tablaUsuarioVicerector').DataTable({
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
            'url': "/Usuario/LeerVicerectores",
            'method': "GET",
            'data': "",
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columnDefs': [{
            targets: 7,
            data: "estado",
            render: function (data, type, row)
            {
                var disabled = 'disabled=""';

                if (type === 'display')
                {
                    if (data)
                    {
                        return '<input id="toggleVicerector" class="editor-active" type="checkbox" checked >';
                    }
                    return '<input id="toggleVicerector" class="editor-active" type="checkbox" >';
                }
                return data;
            }
        }],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "sexo" },
            { "data": "email" },
            { "data": "institucion.abreviacion" },
            { "data": "cargo" },
            { "data": "fonoAnexo" },
            { "data": "estado" },
            {
                "data": null,
                "className": "center",
                "render": function (data, type, full, meta)
                {
                    var id = data.id;
                    var estadoEliminacion = data.estadoEliminacion;
                    var estado = data.estado;
                    var boton;
                    if (estadoEliminacion == 'HABILITADO')
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarVicerector(' + id + ')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarVicerector(' + id + ', \'' + estado + '\')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarVicerector(' + id + ')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ],
        'rowCallback': function (row, data)
        {
            $('.editor-active', row).prop('checked', data.estado == 'Habilitado').bootstrapToggle({
                size: 'mini',
                on: 'Si',
                off: 'No',
                onstyle: 'success',
                offstyle: 'secondary'
            });
        },
    });
}

$(document).on("change", "#toggleVicerector", function ()
{
    var checked = $(this).prop('checked');
    var estado;
    if (checked)
    {
        estado = 'Habilitado';
    }
    else
    {
        estado = 'Deshabilitado';
    }

    $.ajax({
        async: false,
        url: "/Usuario/HabilitarUsuarioVicerector",
        method: "POST",
        data: {
            'Estado': estado,
            'IdUsuarioVicerector': table.row($(this).parents('tr')).data().id
        },
        success: function (respuesta)
        {
            obtenerVicerectores();
            $('#icon-delete').hide();
            $('#icon-delete-confirm').hide();
            $('#icon-delete-success').hide();
            $('#icon-problema').hide();

            $('#title-alerta-eliminar').hide();
            $('#title-alerta-problemas').hide();

            $('#body-alerta').hide();
            if (!respuesta)
            {
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas para cambiar el estado del usuario vicerector').show();
                $('#body-alerta').text("No se puede '" + estado + "' al usuario vicerector debido a que ha ocurrido un problema de conexión. Vuelva a intentarlo y si el persiste el conflicto, favor de ponerse en contacto con soporte.");

                botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                $('#actions-alerta').empty().append(botonAceptar);
            }
        }
    });
});

function eliminarVicerector(id, estado)
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-problema').hide();

    $('#title-alerta-eliminar').hide();
    $('#title-alerta-problemas').hide();

    $('#body-alerta').hide();

    $('#idVicerector').hide();

    $('#icon-delete').show();
    

    if (estado === 'Deshabilitado')
    {
        $('#title-alerta-eliminar').show();
        $('#body-alerta').text("¿Está seguro que desea eliminar al usuario vicerector? Recuerde que si elimina al usuario vicerector, las O.E. no podrá crear solicitudes hasta crear o habilitar a otro usuario vicerector.");

        var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
        var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminarVicerector()">Aceptar</button>';
        $('#idVicerector').val(id);
        $('#actions-alerta').empty().append(botonCancelar);
        $('#actions-alerta').append(botonAceptar);
    }
    else
    {
        $('#title-alerta-problemas').text('Problemas eliminar al vicerector').show();
        $('#body-alerta').text("No se puede eliminar al usuario vicerector porque se encuentra habilitado.");
        var botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
        
    }
    $('#body-alerta').show();
    $('#modal-alert').modal('show');
}

function confirmacionEliminarVicerector()
{
    $('#icon-delete').hide();
    var id = $('#idVicerector').val();

    $.ajax({
        url: "/Usuario/EliminarVicerector",
        method: "DELETE",
        data: {
            'IdVicerector': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerVicerectores();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar al vicerector').show();
                $('#body-alerta').text(respuesta.msj);
            }
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}

function volverVicerectores()
{
    window.location.href = '/Usuario/UsuariosVicerectores';
}

function crearUsuarioVicerector()
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
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionCrearVicerector()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionCrearVicerector()
{
    $('#icon-create').hide();

    var nombre = $('#nombre').parsley();
    var email = $('#email').parsley();
    var clave = $('#clave').parsley();
    var sexo = $('#sexo').parsley();
    var cargo = $('#cargo').parsley();
    var fonoAnexo = $('#fonoAnexo').parsley();

    if (nombre.isValid() && email.isValid() && clave.isValid() && sexo.isValid() && cargo.isValid() && fonoAnexo.isValid() )
    {
        var datos = {
            'Nombre': $("#nombre").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'Cargo': $("#cargo").val(),
            'FonoAnexo': $("#fonoAnexo").val(),
        };

        $.ajax({
            url: "/Usuario/RegistrarUsuarioVicerector",
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
                    var botonAceptar = '<button type="button" id="volverVicerectores" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverVicerectores()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-crear').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para crear al usuario vicerector').show();
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
        nombre.validate();
        email.validate();
        clave.validate();
        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }

        cargo.validate();
        fonoAnexo.validate();

        $('#title-alerta-crear').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para crear al usuario vicerector').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}

function modificarVicerector(id)
{
    $.ajax({
        async: false,
        url: "/Usuario/GuardarIdUsuarioVicerector",
        method: "POST",
        data: {
            'Id': id,
        },
        success: function (respuesta)
        {
            window.location.href = '/Usuario/ActualizarUsuarioVicerector';
        }
    });
}

function obtenerVicerector()
{
    $.ajax({
        async: false,
        url: "/Usuario/LeerUsuarioVicerector",
        method: "GET",
        data: {},
        success: function (respuesta)
        {
            $('#id').val(respuesta.id).hide();
            $('#nombre').val(respuesta.nombre);
            $('#email').val(respuesta.email);
            $('#clave').val(respuesta.clave);
            $('#sexo').val(respuesta.sexo);
            $('#cargo').val(respuesta.cargo);
            $('#fonoAnexo').val(respuesta.fonoAnexo);
        }
    });
}

function modificarUsuarioVicerector()
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
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionModificarVicerector()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionModificarVicerector()
{
    $('#icon-modificar').hide();

    var nombre = $('#nombre').parsley();
    var email = $('#email').parsley();
    var sexo = $('#sexo').parsley();
    var cargo = $('#cargo').parsley();
    var fonoAnexo = $('#fonoAnexo').parsley();

    if (nombre.isValid() && email.isValid() && sexo.isValid() && cargo.isValid() && fonoAnexo.isValid())
    {
        var datos = {
            'Id': $("#id").val(),
            'IdOE': $("#idOE").val(),
            'Nombre': $("#nombre").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'Cargo': $("#cargo").val(),
            'FonoAnexo': $("#fonoAnexo").val(),
        };

        $.ajax({
            url: "/Usuario/ActualizarUsuarioVicerector",
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
                    var botonAceptar = '<button type="button" id="volverVicerectores" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverVicerectores()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-modificar').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para modificar al usuario vicerector').show();
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
        nombre.validate();
        email.validate();
        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }
        cargo.validate();
        fonoAnexo.validate();

        $('#title-alerta-modificar').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para modificar al usuario vicerector').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}

function obtenerAdministradores()
{
    table = $('#tablaUsuarioAdministrador').DataTable({
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
            'url': "/Usuario/LeerAdministradores",
            'method': "GET",
            'data': "",
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "sexo" },
            { "data": "email" },
            { "data": "campus.nombre" },
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
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarAdministrador(' + id + ')"><div><i class="fas fa-edit"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarAdministrador(' + id + ')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarAdministrador(' + id + ')"><div><i class="fas fa-edit"></i></div></button>';
                    }
                    return boton;
                }
            }
        ],
    });
}

function eliminarAdministrador(id)
{
    $('#icon-delete').hide();
    $('#icon-delete-confirm').hide();
    $('#icon-delete-success').hide();
    $('#icon-problema').hide();
    $('#title-alerta-eliminar').hide();
    $('#title-alerta-problemas').hide();
    $('#body-alerta').hide();
    $('#idAdministrador').hide();

    $('#icon-delete').show();

    $('#title-alerta-eliminar').show();
    $('#body-alerta').text("¿Está seguro que desea eliminar al usuario administrador?");

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" id="btnConfirmarEliminar" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionEliminarAdministrador()">Aceptar</button>';
    $('#idAdministrador').val(id);
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);

    $('#body-alerta').show();
    $('#modal-alert').modal('show');
}

function confirmacionEliminarAdministrador()
{
    $('#icon-delete').hide();
    var id = $('#idAdministrador').val();

    $.ajax({
        url: "/Usuario/EliminarAdministrador",
        method: "DELETE",
        data: {
            'IdAdministrador': id
        },
        success: function (respuesta)
        {
            var botonAceptar;
            if (respuesta.validar)
            {
                $('#icon-delete-success').show();
                $('#body-alerta').text(respuesta.msj);
                obtenerAdministradores();
            }
            else
            {
                $('#title-alerta-eliminar').hide();
                $('#icon-problema').show();
                $('#title-alerta-problemas').text('Problemas eliminar al administrador').show();
                $('#body-alerta').text(respuesta.msj);
            }
            botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
            $('#actions-alerta').empty().append(botonAceptar);
        }
    });
}

function volverAdministradores()
{
    window.location.href = '/Usuario/UsuariosAdministradores';
}

function crearUsuarioAdministrador()
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
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionCrearAdministrador()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionCrearAdministrador()
{
    $('#icon-create').hide();

    var nombre = $('#nombre').parsley();
    var email = $('#email').parsley();
    var clave = $('#clave').parsley();
    var sexo = $('#sexo').parsley();
    var idCampus = $('#campus').parsley();


    if (nombre.isValid() && email.isValid() && clave.isValid() && sexo.isValid() && idCampus.isValid())
    {
        var datos = {
            'Nombre': $("#nombre").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'Campus': $("#campus").val()
        };

        $.ajax({
            url: "/Usuario/RegistrarUsuarioAdministrador",
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
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-info tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverAdministradores()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-crear').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para crear al usuario administrador').show();
                    $('#body-alerta').text(respuesta.msj).show();
                    botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
                }
                $('#actions-alerta').empty().append(botonAceptar);
            }
        });
    }
    else
    {
        nombre.validate();
        email.validate();
        clave.validate();
        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }

        idCampus.validate();
        if (!idCampus.isValid())
        {
            $('#campus').addClass('is-invalid');
        }

        $('#title-alerta-crear').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para crear al usuario administrador').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}



function modificarAdministrador(id)
{
    $.ajax({
        async: false,
        url: "/Usuario/GuardarIdUsuarioAdministrador",
        method: "POST",
        data: {
            'Id': id,
        },
        success: function (respuesta)
        {
            window.location.href = '/Usuario/ActualizarUsuarioAdministrador';
        }
    });
}

function obtenerAdministrador()
{
    var administrador;
    $.ajax({
        async: false,
        url: "/Usuario/LeerUsuarioAdministrador",
        method: "GET",
        data: "",
        success: function (respuesta)
        {
            administrador = respuesta;
        }
    });
    return administrador;
}

async function mainActualizarAdministrador()
{
    try
    {
        var administrador = await obtenerAdministrador();
        console.log(administrador);
        $('#id').val(administrador.id).hide();
        $('#nombre').val(administrador.nombre);
        $('#email').val(administrador.email);
        $('#clave').val(administrador.clave);
        $('#sexo').val(administrador.sexo);
        await obtenerCampus();
        $('#campus').val(administrador.campus.id);
    }
    catch (e)
    {
        console.log(e);
    }
}










function modificarUsuarioAdministrador()
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
    var botonAceptar = '<button type="button" id="btnConfirmar" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmacionModificarAdministrador()">Aceptar</button>';
    $('#actions-alerta').empty().append(botonCancelar);
    $('#actions-alerta').append(botonAceptar);
    $('#modal-alert').modal('show');
}

function confirmacionModificarAdministrador()
{
    $('#icon-modificar').hide();

    var nombre = $('#nombre').parsley();
    var email = $('#email').parsley();
    var sexo = $('#sexo').parsley();
    var campus = $('#campus').parsley();

    if (nombre.isValid() && email.isValid() && sexo.isValid() && campus.isValid())
    {
        var datos = {
            'Id': $("#id").val(),
            'Nombre': $("#nombre").val(),
            'Email': $("#email").val(),
            'Clave': $("#clave").val(),
            'Sexo': $("#sexo").val(),
            'Campus': $("#campus").val(),
        };

        $.ajax({
            url: "/Usuario/ActualizarUsuarioAdministrador",
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
                    var botonAceptar = '<button type="button" id="volverOES" data-dismiss="modal" class="btn btn-warning tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5" onclick="volverAdministradores()">Aceptar</button >';
                }
                else
                {
                    $('#title-alerta-modificar').hide();
                    $('#icon-problema').show();
                    $('#title-alerta-problemas').text('Problemas para modificar al usuario administrador').show();
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
        nombre.validate();
        email.validate();
        sexo.validate();
        if (!sexo.isValid())
        {
            $('#sexo').addClass('is-invalid');
        }

        campus.validate();
        if (!campus.isValid())
        {
            $('#campus').addClass('is-invalid');
        }

        $('#title-alerta-modificar').hide();
        $('#icon-problema').show();
        $('#title-alerta-problemas').text('Problemas para modificar al usuario administrador').show();
        $('#body-alerta').text("Existen campos incompletos. Favor verificar que todos los campos esten con datos y vuelva a intentarlo.").show();
        botonAceptar = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Aceptar</button >';
        $('#actions-alerta').empty().append(botonAceptar);
    }
}
