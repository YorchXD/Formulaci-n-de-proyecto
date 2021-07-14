
var idSolicitud = 0;
var solicitud = null;
var showToastrs = false;

window.ParsleyValidator.setLocale('es'); 

document.onkeydown = function (e)
{
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 116)
    {
        if (confirm("Seguro que quieres refrescar la página ") == true)
        {
            location.reload(); 
            return true;
        }
        else
        {
            return false;
        }
    }
}

/*window.addEventListener('beforeunload', (event) =>
{
    event.returnValue = `Are you sure you want to leave?`;
});*/

/*document.onbeforeunload = function()
{
    if(/ firefox[\/\s](\d+)/.test(navigator.userAgent) && new Number(RegExp.$1) >= 4)
    {
        alert("Blah blah. You have to confirm you are leaving this page in the next dialogue.");
    }
return "Blah blah.";
}*/

/*window.onbeforeunload = function ()
{
    if (/firefox[\/\s](\d+)/.test(navigator.userAgent) && new Number(RegExp.$1) >= 4)
    {
        alert("Blah blah. You have to confirm you are leaving this page in the next dialogue.");
    }
    return "Blah blah.";
}*/


window.location.hash = "no-back-button";
window.location.hash = "Again-No-back-button";//esta linea es necesaria para chrome
window.onhashchange = function () { window.location.hash = "no-back-button"; }

/* Datos para las alertas temporales */
toastr.options = {
    "debug": false,
    "positionClass": "toast-bottom-right",
    "onclick": null,
    "fadeIn": 300,
    "fadeOut": 100,
    "timeOut": 5000,
    "extendedTimeOut": 1000
};

// Definimos los callback cuando el TOAST le da un fade in/out:
toastr.options.onFadeIn = function () {
    showToastrs = true;
};
toastr.options.onFadeOut = function () {
    showToastrs = false;
};

/*Configuracion de los step del Wizard*/
$('#wizard6').steps({
    headerTag: 'h3',
    bodyTag: 'section',
    autoFocus: true,
    labels: {
        current: "Paso actual:",
        pagination: "Paginación",
        finish: "Finalizar",
        next: "Siguiente",
        previous: "Anterior",
        loading: "Cargando ..."
    },
    titleTemplate: '<span class="number">#index#</span> <span class="title">#title#</span>',
    onStepChanging: function (event, currentIndex, newIndex) {
        //console.log("evento: " + event);
        //console.log("concurrentIndex: " + currentIndex);
        //console.log("newIndex: " + newIndex);
        if (currentIndex < newIndex) 
        {
            // Step 1: creacion de los datos principales de la solicitud
            if (currentIndex === 0) {
                var nombreEvento = $('#nombreEvento').parsley();
                var lugarEvento = $('#lugarEvento').parsley();
                var monto = $('#monto').parsley();
                var fechaInicio = $('#fechaInicio').parsley();
                var fechaTermino = $('#fechaTermino').parsley();
                var responsable = $('#responsable').parsley();
                var tipoEvento = $('#tipoEvento').parsley();

                if (nombreEvento.isValid() && lugarEvento.isValid() && monto.isValid()
                    && fechaInicio.isValid() && fechaTermino.isValid() && responsable.isValid() && tipoEvento.isValid()) {
                    //console.log($("#monto").val().replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ""));
                    var datos = {
                        'NombreEvento': $("#nombreEvento").val(),
                        'LugarEvento': $("#lugarEvento").val(),
                        'Monto': $("#monto").val().replace(/\D/g, "")
                            .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ""),
                        'FechaInicio': $("#fechaInicio").val(),
                        'FechaTermino': $("#fechaTermino").val(),
                        'IdResponsable': $("#responsable").val(),
                        'TipoEvento': $("#tipoEvento").val(),
                    };

                    $.ajax({
                        url: "/Solicitud/GuardarDatosPrincipales",
                        method: "POST",
                        data: datos,
                        async: false,
                        success: function (respuesta) {
                            //console.log(respuesta);
                            if (respuesta.validacion == true)
                            {
                                toastr.success(respuesta.mensaje, 'Éxito');
                                solicitud = respuesta.solicitud;
                                if (solicitud.tipoEvento == 'Masiva') {
                                    $("#wizard6").steps('skip', 2);
                                }
                                else {
                                    $("#wizard6").steps('unskip', 2);
                                }
                                /*if ($("#tipoEvento").val() == "Masiva") {
                                    $(".step3").parent().attr("style", "display: block;");
                                }*/
                                
                            }
                            else
                            {
                                toastr.error(respuesta.mensaje, 'Error Critico!');
                            }
                        }
                    });
                    return true;
                }
                else {
                    nombreEvento.validate();
                    lugarEvento.validate();
                    monto.validate();
                    fechaInicio.validate();
                    fechaTermino.validate();
                    responsable.validate();
                    if (!responsable.isValid())
                    {
                        $('#responsable').addClass('is-invalid');
                    }
                    tipoEvento.validate();
                    if (!tipoEvento.isValid())
                    {
                        $('#tipoEvento').addClass('is-invalid');
                    }
                    /*$('#tipoEvento').change(function () {
                        $(this).parsley().validate();
                    });*/
                }
            }

            // Step 2: Se agregan las categorias de los gastos del evento
            if (currentIndex === 1) {
                var count = $('#tablaCategorias').DataTable().page.info().recordsTotal;
                if (count != 0)
                {
                    return true;
                }
                else
                {
                    toastr.error('No ha registrado ninguna categoría. Para continuar debe indicar en que se va a desembolsar los gastos del evento.', 'Error Critico!');
                }
            }

            // Step 3: Se agregan los participantes del evento en caso de que el evento sea grupal o para una persona en particular
            if (currentIndex === 2) {
                var count = $('#tablaParticipantes').DataTable().page.info().recordsTotal;
                if (count != 0) {
                    return true;
                }
                else {
                    toastr.error('No ha registrado ningun participante. Debe registrar a todos los participantes del evento debido a que usted seleccionó que la actividad es grupal.', 'Error Critico!');
                }
            }
            // Step 4: Muestra todos los datos ingresados para la solicitud y se podrá descargar y finalizar solicitud
            if (currentIndex === 3) {
                return true;
                /*var email = $('#email').parsley();
                if (email.isValid()) {
                    return true;
                } else { email.validate(); }*/
            }
            // Always allow step back to the previous step even if the current step is not valid.
        } else { return true; }
    },
    onStepChanged: function (event, currentIndex, newIndex) {
        if (currentIndex === 1) 
        {
            obtenerCategorias();
            obtenerCategoriasSeleccionadas();
        }
        if (currentIndex === 2)
        {
            obtenerParticipantes();
        }
        if (currentIndex === 3) {
            obtenerSolicitud();
        }
    },
    onFinished: function (event, currentIndex) {
        actualizarEstadoProceso();
    },
    saveState: true,
    cssClass: 'wizard wizard-style-2'
});


$('.fc-datepicker').datepicker({
    dateFormat: 'yy-mm-dd',
    showOtherMonths: true,
    selectOtherMonths: true,
    onClose: function () {
        $(this).parsley().validate();
    }
});

/*function valideKey(evt)
{
    var code = evt.which ? evt.which : evt.keyCode;
    if (code == 8)
    {
        //backspace
        return true;
    }
    else if (code >= 48 && code <= 57)
    {
        return true;
    }
    else
    {
        return false;
    }
}*/
//$(".numeric").numeric();

function obtenerResponsables()
{
    $.ajax({
        url: "/Solicitud/LeerRepresentantesHabilitados",
        method: "POST",
        data: {},
        success: function (respuesta) {
            for (var i = 0; respuesta != null && i < respuesta.length; i++)
            {
                $('#responsable').append("<option value='" + respuesta[i]["id"] + "'>" + respuesta[i]["nombre"] + "</option>");
            }
        }
    }); 
}

function obtenerCategorias()
{
    $.ajax({
        url: "/Solicitud/LeerCategorias",
        method: "POST",
        data: {},
        success: function (respuesta) {
            $("#categorias").empty().append('<option selected disabled>Seleccione una categoría</option>');
            for (var i = 0; respuesta != null && i < respuesta.length; i++)
            {
                $('#categorias').append("<option value='" + respuesta[i]["id"] + "'>" + respuesta[i]["nombre"] + "</option>");
            }
        }
    });
}


function obtenerCategoriasSeleccionadas()
{
    $('#tablaCategorias').DataTable({
        'ajax': {
            "url": "/Solicitud/LeerCategoriasSeleccionadas",
            "method": "POST",
            "data": "",
            "dataSrc": "",
        },
        'columns': [
            { "data": "nombre" },
            {
                "data": 'id',
                "render": function (data, type, row, meta) {
                    return '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarCategoria(' + data + ')"><div><i class="fas fa-trash"></i></div></button>'
                }
            }
        ]
    })
}

/*Evento para boton agregar categorias seleccionadas*/
$('#agregarCategoria').click( function (e) {
    e.preventDefault();
    var idCategoria = $('#categorias').val();
    var nombreCategoria = $('#categorias').find(":selected").text();
    if (idCategoria != "") {
        $.ajax({
            url: "/Solicitud/AgregarCategoria",
            method: "POST",
            data: {
                'IdCategoria': idCategoria,
                'NombreCategoria': nombreCategoria
            },
            success: function (respuesta) {
                if (respuesta == true) {
                    obtenerCategorias();
                    obtenerCategoriasSeleccionadas();
                    toastr.success('Se ha agregado la categoría satisfactoriamente.', 'Guardado existosa');
                }
                else {
                    toastr.error('No se ha agregado la categoría. Intentelo nuevamente.', 'Error Critico!');
                }
            }
        });
    }
});

function eliminarCategoria(id) {
    $.ajax({
        url: "/Solicitud/EliminarCategoria",
        method: "POST",
        data: { 'IdCategoria': id },
        success: function (respuesta) {
            if (respuesta == true) {
                obtenerCategorias();
                obtenerCategoriasSeleccionadas();
                toastr.success('Se ha eliminado la categoría satisfactoriamente.', 'Eliminación existosa');
            }
            else {
                toastr.error('No se ha eliminado la categoría. Intentelo nuevamente.', 'Error Critico!');
            }
        }
    });
}

function obtenerParticipantes()
{
    $('#tablaParticipantes').DataTable({
        'ajax': {
            "url": "/Solicitud/LeerParticipantes",
            "method": "POST",
            "data": "",
            "dataSrc": "",
        },
        'columns': [
            { "data": "nombre" },
            {
                "data": "run",
                "render": function (data, type, row, meta)
                {
                    return formatearRut(data);
                }
            },
            {
                "data": null,
                "render": function (data, type, row, meta)
                {
                    var nombre = data.nombre;
                    var run = data.run;
                    var accionesAux = "";
                    if (row.estadoEdicion == 1)
                    {
                        accionesAux = '<button class="btn btn-warning btn-icon rounded-circle mg-r-5 mg-b-10" onclick="modificarParticipante(\'' + nombre + '\',\'' + run + '\')"><div><i class="fas fa-pen-square"></i></div></button>' +
                            '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarParticipante(\'' + row.run.toString() +'\')"><div><i class="fas fa-trash"></i></div></button>';
                    }
                    else
                    {
                        accionesAux = '<button class="btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10" onclick="eliminarParticipante(\'' + row.run.toString() + '\')"><div><i class="fas fa-trash"></i></div></button>';
                    }

                    return accionesAux;
                }
            }
        ]
    })
}

/*Evento para boton agregar participante*/
$('#agregarParticipante').click(function (e) {
    e.preventDefault();
    var run = $('#runParticipante').val();
    var nombre = $('#nombreParticipante').val();
    if (validarRUN(run) && nombre != "")
    {
        $.ajax({
            url: "/Solicitud/AgregarParticipante",
            method: "POST",
            data: {
                'RUN': run,
                'Nombre': nombre
            },
            success: function (respuesta)
            {
                if (respuesta.validacion == true)
                {
                    limpiarCamposParticipante();
                    obtenerParticipantes();
                    toastr.success(respuesta.mensaje, 'Guardado existosa');
                }
                else
                {
                    toastr.error(respuesta.mensaje, 'Error Critico!');
                }
            }
        });
    }
    else
    {
        $('#title-alerta').text("Alerta");
        $('#body-alerta').text('Exiten campos incompletos. Favor verificar que todos los campos esten completados y vuelva a intentarlo.');
        var boton = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20">Aceptar</button>';
        $('#actions-alerta').empty().append(boton);
        $('#modal-alerta').modal('show');
    }
});

function eliminarParticipante(run) {
    //alert("Se elimina el participante con el run" + run)
    $.ajax({
        url: "/Solicitud/EliminarParticipante",
        method: "POST",
        data: { 'IdParticipante': run },
        success: function (respuesta) {
            if (respuesta == true) {
                obtenerParticipantes();
                toastr.success('Se ha eliminado al participante satisfactoriamente.', 'Eliminación existosa');
            }
            else {
                toastr.error('No se ha eliminado al participante. Intentelo nuevamente.', 'Error Critico!');
            }
        }
    });
}

function checkRun(Run) {
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
    if (cuerpo.length < 7) { Run.setCustomValidity("RUN Incompleto"); return false; }

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
        if (multiplo < 7) {
            multiplo = multiplo + 1;
        }
        else {
            multiplo = 2;
        }
    }

    // Calcular Dígito Verificador en base al Módulo 11
    dvEsperado = 11 - (suma % 11);
    // Casos Especiales (0 y K)
    dv = (dv == 'K') ? 10 : dv;
    dv = (dv == 0) ? 11 : dv;
    // Validar que el Cuerpo coincide con su Dígito Verificador
    if (dvEsperado != dv) {
        Run.setCustomValidity("RUN Inválido");
        return false;
    }
    // Si todo sale bien, eliminar errores (decretar que es válido)
    Run.setCustomValidity('');
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
        if (multiplo < 7) {
            multiplo = multiplo + 1;
        }
        else {
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

function verificarExistenciaParticipante(run)
{
    var runAux = run.value;
    if (validarRUN(runAux))
    {
        $.ajax({
            url: "/Solicitud/LeerParticipante",
            method: "POST",
            data: { "RUN": runAux},
            success: function (respuesta)
            {
                console.log(respuesta.participante);
                if (respuesta.participante != null && !respuesta.exitPartSol)
                {
                    $('#nombreParticipante').prop('readonly', true).val(respuesta.participante.nombre);
                }
                else if (respuesta.participante != null && respuesta.exitPartSol)
                {
                    $('#title-alerta').text("Alerta");
                    $('#body-alerta').text('El participante de nombre ' + respuesta.participante.nombre + ', RUN ' + formatearRut(respuesta.participante.run) + ' ya se encuentra registrado en la solicitud.');
                    var boton = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20">Aceptar</button>';
                    $('#actions-alerta').empty().append(boton);
                    $('#modal-alerta').modal('show');
                    limpiarCamposParticipante();
                }
                else
                {
                    $('#nombreParticipante').prop('readonly', false).val('');
                }
            }
        });
    }
}

function formatearRut(run)
{
    let runAux = run.replace(/\./g, '').replace('-', '');

    if (runAux.match(/^(\d{2})(\d{3}){2}(\w{1})$/))
    {
        runAux = runAux.replace(/^(\d{2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4');
    }
    else if (runAux.match(/^(\d)(\d{3}){2}(\w{0,1})$/))
    {
        runAux = runAux.replace(/^(\d)(\d{3})(\d{3})(\w{0,1})$/, '$1.$2.$3-$4');
    }
    else if (runAux.match(/^(\d)(\d{3})(\d{0,2})$/))
    {
        runAux = runAux.replace(/^(\d)(\d{3})(\d{0,2})$/, '$1.$2.$3');
    }
    else if (runAux.match(/^(\d)(\d{0,2})$/))
    {
        runAux = runAux.replace(/^(\d)(\d{0,2})$/, '$1.$2');
    }
    return runAux;
};

function limpiarCamposParticipante()
{
    $('#runParticipante').val('');
    $('#nombreParticipante').val('');
}


function obtenerSolicitud() 
{
    $.ajax({
        url: "/Solicitud/LeerSolicitud",
        method: "POST",
        data: {},
        success: function (respuesta) {
            datosPrincipales(respuesta.solicitud);
            //categorias(respuesta.solicitud.categorias);

            if (respuesta.solicitud.categorias != null)
            {
                categorias(respuesta.solicitud.categorias);
            }
            else
            {
                $("#cardCategorias").css("display", "none");
            }

            if (respuesta.solicitud.tipoEvento === "Grupal")
            {
                if (respuesta.solicitud.participantes.length > 1 || (respuesta.solicitud.participantes.length == 1 && respuesta.solicitud.participantes[0].run != "-1"))
                {
                    participantes(respuesta.solicitud.participantes);
                }
                else
                {
                    $("#cardParticipantes").css("display", "none");
                }
            }
            else 
            {
                $("#cardParticipantes").css("display", "none"); 
            }
        }
    });
}

function datosPrincipales(solicitud) {
    console.log(solicitud);
    $("#verNombreEvento").val(solicitud.nombreEvento);
    $("#verLugarEvento").val(solicitud.lugarEvento);
    $("#verMonto").val(formatoNumero(solicitud.monto));
    $("#verFechaInicio").val(solicitud.fechaInicioEvento.split("T")[0]);
    $("#verFechaTermino").val(solicitud.fechaTerminoEvento.split("T")[0]);
    $("#verResponsable").val(solicitud.nombreResponsable);
    $("#verTipoEvento").val(solicitud.tipoEvento);
}

function categorias(categorias) {
    var resp = "";
    for (var i = 0; i < categorias.length; i++) {
        if (i === 0 || i % 2 === 0) {
            resp += "<tr class='odd'>";
        }
        else {
            resp += "<tr>";
        }
        resp += "<td>" + categorias[i].nombre + "</td></tr>";
    }
    $("#verTablaCategorias > tbody").empty();
    $("#verTablaCategorias > tbody").append(resp);
}

function participantes(participantes) {
    var resp = "";
    for (var i = 0; i < participantes.length; i++)
    {
        if (participantes[i].run!="-1")
        {
            if (i === 0 || i % 2 === 0)
            {
                resp += "<tr class='odd'>";
            }
            else
            {
                resp += "<tr>";
            }
            resp += "<td>" + participantes[i].nombre + "</td>" +
                "<td>" + formatearRut(participantes[i].run) + "</td></tr>";
        }
        
    }
    $("#verTablaParticipantes > tbody").empty();
    $("#verTablaParticipantes > tbody").append(resp);
}

function formatoNumero(num) {
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
            return value.replace(/\D/g, "")
                .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ".");
        });
    }
});


/*Completar datos para vista actualizar*/
function ingresarDatos() {
    $.ajax({
        url: "/Solicitud/LeerSolicitud",
        method: "POST",
        data: "",
        async: false,
        success: function (respuesta) {
            console.log(respuesta);
            solicitud = respuesta.solicitud;
            $("#nombreEvento").val(solicitud.nombreEvento);
            $("#lugarEvento").val(solicitud.lugarEvento);
            $("#monto").val(formatoNumero(solicitud.monto));

            /*Registrando minimo y maximo de fechas*/
            var fecha = solicitud.fechaInicioEvento.split("T")[0];
            var fechaAux = fecha.split("-");
            var minDateInicio = fechaInicio(fechaAux);
            var maxDate = moment((parseInt(fechaAux[0], 10) + 1).toString() + "1231").format('YYYY-MM-DD');
            $('#fechaInicio').datepicker('option', 'minDate', minDateInicio);
            $('#fechaInicio').datepicker('option', 'maxDate', maxDate);
            $("#fechaInicio").val(solicitud.fechaInicioEvento.split("T")[0]);

            $('#fechaTermino').datepicker('option', 'minDate', fecha);
            $('#fechaTermino').datepicker('option', 'maxDate', maxDate);
            $("#fechaTermino").val(solicitud.fechaTerminoEvento.split("T")[0]);
            /*Fin de registro minimo y maximo de fechas*/

            obtenerResponsablesActualizar(respuesta.idResponsable);
            $('#tipoEvento > option[value="' + solicitud.tipoEvento + '"]').attr('selected', 'selected');
            
            /*if (solicitud.tipoEvento == 'Grupal') {
                obtenerParticipantes();
            }*/
            if (solicitud.tipoEvento == 'Masiva')
            {
                $("#wizard6").steps('skip', 2);
            }
            else
            {
                $("#wizard6").steps('unskip', 2);
            }

        }
    });
    //$("#tipoEvento").val();
}

/**
 * Seleccionando fecha mínima para fecha de inicio para la vista actualizar datos
 * @param {any} fecha
 * Devuelve la fecha mínima a seleccionar en el datepicker de fechaInicio
 */
function fechaInicio(fecha)
{
    var fechaAux = moment(fecha[0].toString() + fecha[1].toString() + fecha[2].toString());
    var fechaActual = moment();

    if (fechaActual < fechaAux)
    {
        return moment().format("YYYY-MM-DD");
    }

    return fechaAux.subtract(1, 'months').format("YYYY-MM-DD");
}

function obtenerResponsablesActualizar(idResponsable) {
    $.ajax({
        url: "/Solicitud/LeerRepresentantesHabilitadosActualizar",
        method: "POST",
        data: { 'idResponsable': idResponsable},
        success: function (respuesta) {
            for (var i = 0; respuesta != null && i < respuesta.length; i++) {
                if (respuesta[i]["id"] == idResponsable) {
                    $('#responsable').append("<option value='" + respuesta[i]["id"] + "' selected>" + respuesta[i]["nombre"] + "</option>");
                }
                else
                {
                    $('#responsable').append("<option value='" + respuesta[i]["id"] + "'>" + respuesta[i]["nombre"] + "</option>");
                }
                
            }
        }
    });
}

function actualizarEstadoProceso() {
    $.ajax({
        url: "/Solicitud/ActualizarEstadoProceso",
        method: "POST",
        data: {},
        success: function (respuesta) {
            window.location.href = "/Solicitud/VerSolicitud";
            //window.location.href = "/Proceso/Procesos";
        }
    });
}

$("#tipoEvento").on('change', function ()
{
    $(this).parsley().validate();
    if ($(this).hasClass("is-invalid"))
    {
        $(this).removeClass("is-invalid");
        $(this).addClass("is-valid");
    }
});
$("#responsable").on('change', function ()
{
    $(this).parsley().validate();
    if ($(this).hasClass("is-invalid"))
    {
        $(this).removeClass("is-invalid");
        $(this).addClass("is-valid");
    }
});

/*Inicializacion y validacion de fechas */
var minDateInicio = moment().format('YYYY-MM-DD');
var date = new Date();
var maxDateInicio = moment((date.getFullYear() + 1).toString() + "1231").format('YYYY-MM-DD');
$('#fechaInicio').datepicker('option', 'minDate', minDateInicio);
$('#fechaInicio').datepicker('option', 'maxDate', maxDateInicio);
$('#fechaInicio').mask('9999-99-99');

$("#fechaInicio").on('change', function ()
{
    var fechaInicio = $(this).val();
    var minFechaInicio = $("#fechaInicio").datepicker("option", "minDate");
    var maxFechaInicio = $("#fechaInicio").datepicker("option", "maxDate");

    if (!validarFecha(fechaInicio, minFechaInicio, maxFechaInicio))
    {
        $(this).val('');
        $(this).parsley().validate();
        $('#fechaTermino').val(''); 
        $('#fechaTermino').parsley().validate();
        activadorFechas();
    }
    else
    {
        activadorFechas();
        var minFecha = $(this).datepicker('getDate');
        var minDate = moment(minFecha).format('YYYY-MM-DD');
        console.log(minDate);
        var maxDate = moment((minFecha.getFullYear() + 1).toString() + "1231").format('YYYY-MM-DD');
        $("#fechaTermino").datepicker("option", "minDate", minDate);
        $("#fechaTermino").datepicker("option", "maxDate", maxDate);
    }
});

$('#fechaTermino').mask('9999-99-99');
$("#fechaTermino").on("change", function ()
{
    var fecha = $(this).val();
    var minFecha = $("#fechaTermino").datepicker("option", "minDate");
    var maxFecha = $("#fechaTermino").datepicker("option", "maxDate");

    if (!validarFecha(fecha, minFecha, maxFecha))
    {
        $(this).val('');
        $(this).parsley().validate();
    }
});

function validarFecha(fecha, minFecha, maxFecha)
{
    if (fecha == undefined || minFecha == undefined || maxFecha == undefined)
    {
        return false;
    }

    var parmsMinFecha = minFecha.split(/[\.\-\/]/);
    var minFecha = new Date(parmsMinFecha[0], parmsMinFecha[1] - 1, parmsMinFecha[2]);

    var parmsMaxFecha = maxFecha.split(/[\.\-\/]/);
    var maxFecha = new Date(parmsMaxFecha[0], parmsMaxFecha[1] - 1, parmsMaxFecha[2]);

    var parmsFecha = fecha.split(/[\.\-\/]/);
    var yyyy = parseInt(parmsFecha[0], 10);

    if (yyyy < minFecha.getFullYear())
    {
        return false;
    }

    var mm = parseInt(parmsFecha[1], 10);

    if (mm < 1 || mm > 12)
    {
        return false;
    }

    var dd = parseInt(parmsFecha[2], 10);
    if (dd < 1 || dd > 31)
    {
        return false;
    }

    var dateCheck = new Date(yyyy, mm - 1, dd);

    if (dateCheck.getTime() < minFecha.getTime() || dateCheck.getTime() > maxFecha.getTime())
    {
        return false;
    }
    return (dateCheck.getDate() === dd && (dateCheck.getMonth() === mm - 1) && dateCheck.getFullYear() === yyyy);

};

function activadorFechas()
{
    var fechaInicio = $("#fechaInicio").parsley();
    if (!fechaInicio.isValid())
    {
        $("#fechaTermino").datepicker("option", "disabled", true);
    }
    else
    {
        $("#fechaTermino").datepicker("option", "disabled", false);
    }
}

//Funciones para la etapa de mdificacion del nombre del participante (en caso de que el run sea incorrecto simplemente debe borrar al participante)
var cambioNombreParticipante;
function modificarParticipante(nombre, run) 
{
    $('#RUNParticipanteModal').val(formatearRut(run));
    $('#nombreParticipanteModal').val(nombre);
    cambioNombreParticipante = 0;
    $('#modal-modificar').modal('show');
}

$('#nombreParticipanteModal').on('change', function ()
{
    cambioNombreParticipante = 1;
});

$('#modificar').on('click', function ()
{
    var icono = '<i class="icon ion-ios-help-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block"></i>';
    var boton = '<button type="button" class="btn btn-secondary pd-y-12 pd-x-25 mg-b-20 mg-r-5 tx-transform-none" data-dismiss="modal">Cancelar</button><button id="confirmacionModificarParticipante" type="button" class="btn btn-success pd-y-12 pd-x-25 mg-b-20 mg-l-5 tx-transform-none" onclick="confirmacionModificarParticipante()">Aceptar</button>';
    $('#modal-icon-consulta-confirmacion').empty().append(icono);
    $('#title-consulta-confirmacion').text("Alerta");
    $('#body-consulta-confirmacion').text('¿Está seguro(a) de modificar el nombre del participante?');
    $('#actions-consulta-confirmacion').empty().append(boton);
    $('#modal-consulta-confirmacion').modal('show');
});

function confirmacionModificarParticipante()
{
    var nombre = $('#nombreParticipanteModal').val();
    var run = $('#RUNParticipanteModal').val().replaceAll('.', '');
    if (cambioNombreParticipante && nombre.replaceAll(' ', '') !='')
    {
        $('#modal-modificar').modal('hide');
        $.ajax({
            url: "/Solicitud/ActualizarParticipante",
            method: "POST",
            data: {
                'Run': run,
                'Nombre': nombre
            },
            success: function (respuesta)
            {
                if (respuesta)
                {
                    var icono = '<i class="icon ion-ios-checkmark-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block"></i>';
                    var boton = '<button type="button" class="btn btn-success pd-y-12 pd-x-25 mg-b-20 mg-r-5 tx-transform-none" data-dismiss="modal">Aceptar</button>';
                    $('#modal-icon-consulta-confirmacion').empty().append(icono);
                    $('#title-consulta-confirmacion').text("Confirmación");
                    $('#body-consulta-confirmacion').text('Se ha modificado el nombre del participante.');
                    $('#actions-consulta-confirmacion').empty().append(boton);
                    obtenerParticipantes();
                }
                else
                {
                    $('#modal-consulta-confirmacion').modal('hide');
                    $('#nombreParticipanteModal').val('');
                    $('#title-alerta').text("Alerta");
                    $('#body-alerta').text('No se ha guardado los cambios. Esto puede ser debido a que se ha perdido la conexión de internet o el participante ya no se encuentre registrado en el sistema. En el caso de haber pedido la conexión de internet vuelva a intentarlo, en caso cotrario, registre al participante nuevamente.');
                    var boton = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20">Aceptar</button>';
                    $('#actions-alerta').empty().append(boton);
                    $('#modal-alerta').modal('show');
                    
                }
            }
        });
    }
    else if (cambioNombreParticipante && nombre.replaceAll(' ', '') == '')
    {
        $('#modal-consulta-confirmacion').modal('hide');
        $('#nombreParticipanteModal').val('');
        $('#title-alerta').text("Alerta");
        $('#body-alerta').text('No se ha guardado los cambios debido a que el campo nombre se encuentra vacio. Favor verificar los datos e intentelo nuevamente.');
        var boton = '<button type="button" data-dismiss="modal" class="btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20">Aceptar</button>';
        $('#actions-alerta').empty().append(boton);
        $('#modal-alerta').modal('show');
    }
    else
    {
        $('#modal-modificar').modal('hide');
        var icono = '<i class="icon ion-ios-checkmark-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block"></i>';
        var boton = '<button type="button" class="btn btn-success pd-y-12 pd-x-25 mg-b-20 mg-r-5 tx-transform-none" data-dismiss="modal">Aceptar</button>';
        $('#modal-icon-consulta-confirmacion').empty().append(icono);
        $('#title-consulta-confirmacion').text("Confirmación");
        $('#body-consulta-confirmacion').text('No existen cambios en el nombre del participante');
        $('#actions-consulta-confirmacion').empty().append(boton);
    }
    
}

//Fin funciones para la etapa de mdificacion del nombre del participante