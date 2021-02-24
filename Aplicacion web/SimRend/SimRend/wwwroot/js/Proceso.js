function obtenerProcesos()
{
    /*var fecha = new Date();
    var anio = fecha.getFullYear();
    var mes = fecha.getMonth();

    var datos = {
        'anio': anio,
        'mes': mes
    };*/
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
            /*'data': datos,*/
            'data':"",
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
            { "data": "solicitud.nombreResponsable" },
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

                    return '<button class="btn btn-success btn-icon rounded-circle mg-r-5 mg-b-10" onclick="ver(' + idSolicitud + ', ' + idResolucion + ', ' + idDeclaracionGastos + ', ' + idResponsable + ', ' + estado+ ')"><div><i class="fas fa-eye"></i></div></button>' +
                        //'<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificar(' + idSolicitud + ', ' + idResolucion + ', ' + idDeclaracionGastos +')"><div><i class="fas fa-edit"></i></div></button>' +
                        '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminar(' + idSolicitud + ', ' + idResolucion + ', ' + idDeclaracionGastos + ')"><div><i class="fas fa-trash"></i></div></button>'
                }
            }
        ]

    });
}


function ver(idSolicitud, idResolucion, idDeclaracionGastos, idResponsable , estado)
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
        },
        success: function (respuesta){
            window.location.href = '/Proceso/VerProceso';
        }
    });
    
}

function modificar(idSolicitud, idResolucion, idDeclaracionGastos)
{

    alert("Actualizar el proceso que tiene por id de solicitud el numero " + idSolicitud);
    /*
    $.ajax({
        async: false,
        url: "/Proceso/GuardarId",
        method: "POST",
        data: { 'IdSolicitud': idSolicitud },
    });
    window.location.href = '/Solicitud/ActualizarSolicitud';*/
}

function eliminar(idSolicitud, idResolucion, idDeclaracionGastos)
{
    /*Eliminará todo el proceso*/
    alert("Eliminar la solicitud " + idSolicitud);
}