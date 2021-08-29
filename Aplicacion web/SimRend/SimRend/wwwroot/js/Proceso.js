function obtenerAniosProcesos()
{
    $.ajax({
        async: false,
        url: "/Proceso/LeerAniosProceso",
        method: "POST",
        data: "",
        success: function (respuesta)
        {
            $('#anio').empty().append("<option value='' disabled>Seleccione un año</option>");

            for (var i = 0; (respuesta!=null || respuesta.length>0) && i < respuesta.length; i++)
            {
                if (i == 0)
                {
                    $('#anio').append("<option value='" + respuesta[i] + "' selected>" + respuesta[i] + "</option>");
                }
                else
                {
                    $('#anio').append("<option value='" + respuesta[i] + "'>" + respuesta[i] + "</option>");
                }
            }

            obtenerProcesos();
        }
    });
}

function obtenerTipoProceso()
{
    $('#estadoProceso').empty().append("<option value='' disabled>Seleccione el estado de los procesos</option>");
    $('#estadoProceso').append("<option value='Abiertos' selected>Abiertos</option>");
    $('#estadoProceso').append("<option value='Cerrados' selected>Cerrados</option>");
    $('#estadoProceso').append("<option value='Todos' selected>Todos</option>");

    obtenerAniosProcesos();
}

$('#estadoProceso').on('change', function ()
{
    obtenerProcesos();
});

$('#anio').on('change', function ()
{
    obtenerProcesos();
});




function obtenerProcesos()
{
    var datos = {
        'Anio': $('#anio').val(),
        'TipoProceso': $('#estadoProceso').val()
    };
    $('#tablaSolicitudes').DataTable({
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
            'url': "/Proceso/LeerProcesos",
            'method': "POST",
            'data': datos,
            "dataSrc": "",
        },
        'order': [[0, 'desc']],
        'columns': [
            { "data": "solicitud.id" },
            { "data": "solicitud.nombreEvento" },
            { "data": "solicitud.monto", render: $.fn.dataTable.render.number('.', ',', 0, '$') },
            {
                "data": "solicitud.fechaInicioEvento", render: function (d, type, full, meta)
                {
                    var fecha = moment(new Date(d)).format('YYYY-MM-DD');
                    return fecha;
                }
            },
            {
                "data": "solicitud.fechaTerminoEvento", render: function (d, type, full, meta)
                {
                    var fecha = moment(new Date(d)).format('YYYY-MM-DD');
                    return fecha;
                }
            },
            { "data": "solicitud.lugarEvento" },
            { "data": "solicitud.lugarEvento" },
            { "data": "estadoFinal" },
            {
                "data": null,
                "className": "center",
                "render": function (data, type, full, meta)
                {
                    var idSolicitud = data.solicitud.id;
                    var idResolucion = data.resolucion.id;
                    var idDeclaracionGastos = data.declaracionGastos.id;
                    var idResponsable = data.responsable.id;
                    var estado = data.estado;
                    var estadoFinal = data.estadoFinal;
                    var fechaTerminoEvento = moment(new Date(data.solicitud.fechaTerminoEvento)).format('YYYY');
                    var boton;
                    if (estadoFinal == 'Abierto')
                    {
                        boton = '<button class="btn btn-success btn-icon rounded-circle mg-r-5 mg-b-10" onclick="ver(' + idSolicitud + ', ' + idResolucion + ', ' + idDeclaracionGastos + ', ' + idResponsable + ', ' + estado + ', \'' + estadoFinal + '\')"><div><i class="fas fa-eye"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminar(' + idSolicitud + ', ' + idResolucion + ', ' + idDeclaracionGastos + ', ' + fechaTerminoEvento +', \'' + estadoFinal + '\')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        boton = '<button class="btn btn-success btn-icon rounded-circle mg-r-5 mg-b-10" onclick="ver(' + idSolicitud + ', ' + idResolucion + ', ' + idDeclaracionGastos + ', ' + idResponsable + ', ' + estado + ', \'' + estadoFinal + '\')"><div><i class="fas fa-eye"></i></div></button>';
                    }

                    return boton;
                    
                }
            }
        ]

    });
}


function ver(idSolicitud, idResolucion, idDeclaracionGastos, idResponsable , estado, estadoFinal)
{
    //console.log(idSolicitud + ", " + idResolucion + ", " + idDeclaracionGastos);
    $.ajax({
        async: false,
        url: "/Proceso/GuardarId",
        method: "POST",
        data: {
            'IdSolicitud': idSolicitud,
            'IdResolucion': idResolucion,
            'IdDeclaracionGastos': idDeclaracionGastos,
            'IdResponsable': idResponsable,
            'Estado': estado,
            'EstadoFinal': estadoFinal,
        },
        success: function (respuesta){
            window.location.href = '/Proceso/VerProceso';
        }
    });
    
}

function eliminar(idSolicitud, idResolucion, idDeclaracionGastos, fechaTerminoEvento, estadoFinal)
{
    /*Eliminará todo el proceso*/
    //alert("Eliminar proceso que tiene la solicitud: " + idSolicitud + " con id de resolucion: " + idResolucion + " con id de DG: " + idDeclaracionGastos + " con año de la fecha de termino del evento: " + fechaTerminoEvento + " y estado final del proceso: " + estadoFinal);

    $('#idSolicitud').val(idSolicitud);
    $('#idResolucion').val(idResolucion);
    $('#idDeclaracionGastos').val(idDeclaracionGastos);
    $('#fechaTerminoEvento').val(fechaTerminoEvento);
    $('#estadoFinal').val(estadoFinal);


    $('#title-alerta-eliminar-proceso').text("Eliminar proceso");
    $('#body-alerta-eliminar-proceso').text("¿Está seguro que desea eliminar el proceso?");

    var botonCancelar = '<button type="button" data-dismiss="modal" class="btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5">Cancelar</button >';
    var botonAceptar = '<button type="button" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5" onclick="confirmarEliminarProceso()">Aceptar</button>';

    $('#actions-alerta-eliminar-proceso').empty().append(botonCancelar);
    $('#actions-alerta-eliminar-proceso').append(botonAceptar);
    $('#modal-alerta-eliminar-proceso').modal('show');
}

function confirmarEliminarProceso()
{
    $.ajax({
        url: "/Proceso/EliminarPoceso",
        method: "POST",
        async: "false",
        data: {
            'IdSolicitud': $('#idSolicitud').val(),
            'IdResolucion': $('#idResolucion').val(),
            'IdDeclaracionGastos': $('#idDeclaracionGastos').val(),
            'FechaTerminoEvento': $('#fechaTerminoEvento').val(),
            'EstadoFinal': $('#estadoFinal').val(),
        },
        success: function (respuesta)
        {
            $('#modal-alerta-eliminar-proceso').modal('hide');
            //console.log(respuesta)
            if (respuesta.validar)
            {
                $('#title-informacion-eliminacion').text(respuesta.titulo);
                $('#body-informacion-eliminacion').text(respuesta.msj);
                $('#modal-informacion-eliminacion').modal('show');
            }
            else
            {
                $('#title-alerta').text(respuesta.titulo);
                $('#body-alerta').text(respuesta.msj);
                $('#modal-alerta').modal('show');
            }
        }
    });
}

$('#btn-Proceso-Eliminado').click(function ()
{
    window.location.href = '/Proceso/Procesos';
});

function obtenerOE()
{
    $('#tablaOrganizaciones').DataTable({
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
            'url': "/Proceso/LeerOrganizacionesVicerector",
            'method': "GET",
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
                    return '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="verOE(' + id + ')"><div><i class="fas fa-eye"></i></div></button>';
                }
            }
        ]
    });
}


function verOE(id)
{
    $.ajax({
        url: "/Proceso/GuardarIDOrganizacion",
        method: "POST",
        async: "false",
        data: {
            'Id': id
        },
        success: function (respuesta)
        {
            window.location.href = '/Proceso/Procesos';
        }
    });
}