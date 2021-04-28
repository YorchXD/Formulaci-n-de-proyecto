#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Solicitud\VerSolicitud.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbe1e669b9ee4edb28dab02c5c67b7fa30af34b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Solicitud_VerSolicitud), @"mvc.1.0.view", @"/Views/Solicitud/VerSolicitud.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbe1e669b9ee4edb28dab02c5c67b7fa30af34b6", @"/Views/Solicitud/VerSolicitud.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Solicitud_VerSolicitud : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Solicitud\VerSolicitud.cshtml"
  
    ViewData["Title"] = "Solicitud";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""br-pagetitle row"">
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <div class=""input-group-text wd-auto"" style=""border:none;"">
                <i class=""icon fas fa-clipboard-check""></i>
                <h4 style=""padding-left:5%"">Ver solicitud</h4>
            </div>
        </div>

    </div>
</div><!-- d-flex -->


<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">
        <div id=""accordion5"" class=""accordion accordion-head-colored accordion-inverse mg-t-20"" role=""tablist"" aria-multiselectable=""true"">
            <div class=""card"">
                <div class=""card-header"" role=""tab"" id=""headingOne5"">
                    <h6 class=""mg-b-0"">
                        <a data-toggle=""collapse"" data-parent=""#accordion5"" href=""#collapseOne5"" aria-expanded=""true"" aria-controls=""collapseOne5"">
                            Datos Principales
                        </a>
                    </h6>
                </div><!-- card-header");
            WriteLiteral(@" -->

                <div id=""collapseOne5"" class=""collapse show"" role=""tabpanel"" aria-labelledby=""headingOne5"">
                    <div class=""card-block pd-20"">
                        <div class=""form-group wd-auto"">
                            <label class=""form-control-label"">Nombre del evento:</label>
                            <div class=""input-group"">
                                <div class=""input-group-prepend"">
                                    <span class=""input-group-text""><i class=""fas fa-theater-masks tx-16 lh-0 op-6 fa-fw""></i></span>
                                </div>
                                <input name=""NombreEvento"" class=""form-control"" id=""verNombreEvento"" readonly type=""text"" placeholder=""Ingrese el nombre del evento"">
                            </div>
                        </div>

                        <div class=""row row-sm"">
                            <div class=""form-group wd-auto col-lg-6 col-md-12"">
                                <label clas");
            WriteLiteral(@"s=""form-control-label"">Lugar del evento:</label>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <div class=""input-group-text wd-xs-45"">
                                            <i class=""fas fa-map-marked-alt tx-16 lh-0 op-6 fa-fw""></i>
                                        </div>
                                    </div>
                                    <input name=""LugarEvento"" class=""form-control"" id=""verLugarEvento"" readonly type=""text"" placeholder=""¿Donde se realizará el evento?"">
                                </div>
                            </div>
                            <div class=""form-group wd-auto col-lg-6 col-md-12"">
                                <label class=""form-control-label"">Monto($): </label>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                      ");
            WriteLiteral(@"                  <div class=""input-group-text wd-xs-45"">
                                            <i class=""fa fa-money-bill-wave tx-16 lh-0 op-6 fa-fw""></i>
                                        </div>
                                    </div>
                                    <input name=""Monto"" class=""form-control"" id=""verMonto"" readonly type=""text"" placeholder=""¿Cuanto será el monto a solicitar?"">
                                </div>
                            </div>
                        </div>
                        <div class=""row row-sm"">
                            <div class=""form-group wd-auto col-lg-6 col-md-12"">
                                <label class=""form-control-label"">Fecha de inicio: </label>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <div class=""input-group-text wd-xs-45"">
                                            <i class=""fas fa-c");
            WriteLiteral(@"alendar-plus tx-16 lh-0 op-6 fa-fw"" style=""text-align: center;""></i>
                                        </div>
                                    </div>
                                    <input name=""FechaInicio"" type=""text"" class=""form-control fc-datepicker"" readonly placeholder=""¿Cuando inicia el evento?"" id=""verFechaInicio"">
                                </div>
                            </div>
                            <div class=""form-group wd-auto col-lg-6 col-md-12"">
                                <label class=""form-control-label"">Fecha de término: </label>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <div class=""input-group-text wd-xs-45"">
                                            <i class=""fas fa-calendar-check tx-16 lh-0 op-6 fa-fw""></i>
                                        </div>
                                    </div>
                       ");
            WriteLiteral(@"             <input name=""FechaTermino"" type=""text"" class=""form-control fc-datepicker"" readonly placeholder=""¿Cuando terminará el evento?"" id=""verFechaTermino"">
                                </div>
                            </div>
                        </div>
                        <div class=""row row-sm"">
                            <div class=""form-group wd-auto col-lg-6 col-md-12"">
                                <label class=""form-control-label"">Responsable: </label>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <div class=""input-group-text wd-xs-45"">
                                            <i class=""fa fa-user tx-16 lh-0 op-6 fa-fw""></i>
                                        </div>
                                    </div>
                                    <input name=""idResponsable"" class=""form-control"" id=""verResponsable"" readonly type=""text"" placeholder");
            WriteLiteral(@"=""¿Qué representante estará a cargo?"">
                                </div>
                            </div>
                            <div class=""form-group wd-auto col-lg-6 col-md-12"">
                                <label class=""form-control-label"">Tipo de actividad: </label>
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <div class=""input-group-text wd-xs-45"">
                                            <i class=""fas fa-tag tx-16 lh-0 op-6 fa-fw""></i>
                                        </div>
                                    </div>
                                    <input name=""TipoEvento"" class=""form-control"" id=""verTipoEvento"" readonly type=""text"" placeholder=""Seleccione el tipo de actividad"">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
     ");
            WriteLiteral(@"       </div>
            <div class=""card"" id=""cardCategorias"">
                <div class=""card-header"" role=""tab"" id=""headingTwo5"">
                    <h6 class=""mg-b-0"">
                        <a class=""collapsed transition"" data-toggle=""collapse"" data-parent=""#accordion5"" href=""#collapseTwo5"" aria-expanded=""false"" aria-controls=""collapseTwo5"">
                            Categorías de gastos del evento
                        </a>
                    </h6>
                </div>
                <div id=""collapseTwo5"" class=""collapse"" role=""tabpanel"" aria-labelledby=""headingTwo5"">
                    <div class=""card-block pd-20"">
                        <div class=""table-wrapper"">
                            <table id=""verTablaCategorias"" class=""table display responsive nowrap"" style=""width:100%"">
                                <thead class=""thead-colored thead-info"">
                                    <tr>
                                        <th class=""wd-auto"">Categoría</th>
   ");
            WriteLiteral(@"                                 </tr>
                                </thead>
                            </table>
                        </div><!-- table-wrapper -->
                    </div>
                </div>
            </div>
            <div class=""card"" id=""cardParticipantes"">
                <div class=""card-header"" role=""tab"" id=""headingThree5"">
                    <h6 class=""mg-b-0"">
                        <a class=""collapsed transition"" data-toggle=""collapse"" data-parent=""#accordion5"" href=""#collapseThree5"" aria-expanded=""false"" aria-controls=""collapseThree5"">
                            Participantes del evento
                        </a>
                    </h6>
                </div>
                <div id=""collapseThree5"" class=""collapse"" role=""tabpanel"" aria-labelledby=""headingThree5"">
                    <div class=""card-block pd-20"">
                        <div class=""table-wrapper"">
                            <table id=""verTablaParticipantes"" class=""table dis");
            WriteLiteral(@"play responsive nowrap"" style=""width:100%"">
                                <thead class=""thead-colored thead-info"">
                                    <tr>
                                        <th class=""wd-auto"">Nombre</th>
                                        <th class=""wd-auto"">RUN</th>
                                    </tr>
                                </thead>
                            </table>
                        </div><!-- table-wrapper -->
                    </div>
                </div><!-- collapse -->
            </div><!-- card -->
        </div><!-- accordion -->
        <div class=""card-footer bd bd-t-0"">
            <div class=""row"" id=""acciones"">

            </div>
        </div>
    </div>
    <!-- MODAL PREGUNTAR ELIMINAR SOLICITUD -->
    <div class=""modal fade"" id=""modal-confirmar-eliminar"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""moda");
            WriteLiteral(@"l-body tx-center pd-y-20 pd-x-20"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">×</span>
                    </button>
                    <i class=""ionicons ion-ios-help-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-danger mg-b-20"" id=""title-confirmar-eliminar""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-confirmar-eliminar""></p>
                    <button type=""button"" data-dismiss=""modal"" class=""btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Cancelar
                    </button>
                    <button type=""button"" id=""btnConfirmarEliminar"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div>
        </div>
    <");
            WriteLiteral(@"/div>

    <!-- MODAL INFORMACION -->
    <div id=""modal-informacion"" class=""modal fade"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""icon ion-ios-checkmark-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-success tx-semibold mg-b-20"" id=""title-informacion""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-informacion""></p>
                    <button type=""button"" id=""btnAceptarInformacion"" class=""btn btn-success tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
    <!-- MODAL ERROR -->
    <div id=""modal-alerta"" class=""modal fade"">
        <div");
            WriteLiteral(@" class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <i class=""icon icon ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-danger  tx-semibold mg-b-20"" id=""title-alerta""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-alerta""></p>
                    <button type=""button"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"" data-dismiss=""modal"" aria-label=""Close"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -");
            WriteLiteral("->\r\n\r\n\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var solicitud = """";
        $.extend($.fn.dataTable.defaults, {
            'destroy': true,
            'responsive': true,
            'dom': ""Bfrtip"",
            'searching': false,
            'ordering': true,
            'info': false,
            'autoWidth': true,
            'paging': true,
            'scrollX': false,
            'lengthChange': false,
            'processing': true,
            'iDisplayLength': 5,
            'language': {
                ""decimal"": """",
                ""emptyTable"": ""No hay información"",
                ""info"": ""Mostrando _START_ a _END_ de _TOTAL_ Entradas"",
                ""infoEmpty"": ""Mostrando 0 to 0 of 0 Entradas"",
                ""infoFiltered"": ""(Filtrado de _MAX_ total entradas)"",
                ""infoPostFix"": """",
                ""thousands"": "","",
                ""lengthMenu"": ""Mostrar _MENU_ Entradas"",
                ""loadingRecords"": ""Cargando..."",
                ""processing"": ""Procesando..."",
      ");
                WriteLiteral(@"          ""search"": ""Buscar:"",
                ""zeroRecords"": ""Sin resultados encontrados"",
                ""paginate"": {
                    ""first"": ""Primero"",
                    ""last"": ""Ultimo"",
                    ""next"": ""Siguiente"",
                    ""previous"": ""Anterior""
                }
            }
        });
        

        $(document).ready(function () {
            $('#verTablaCategorias').DataTable();
            $('#verTablaParticipantes').DataTable();
            obtenerSolicitud();

        });

        function obtenerSolicitud()
        {
            //console.log(solicitud);
            $.ajax({
                url: ""/Solicitud/LeerSolicitud"",
                method: ""POST"",
                async: ""false"",
                data: { 'idSolicitud': solicitud.id },
                success: function (respuesta) {
                    datosPrincipales(respuesta.solicitud);
                    

                    if (respuesta.solicitud.categorias!=null)
 ");
                WriteLiteral(@"                   {
                        categorias(respuesta.solicitud.categorias);
                    }
                    else
                    {
                        $(""#cardCategorias"").css(""display"", ""none"");
                    }

                    if (respuesta.solicitud.tipoEvento === ""Grupal"") 
                    {
                        if (respuesta.solicitud.participantes.length > 1)
                        {
                            participantes(respuesta.solicitud.participantes);
                        }
                        else
                        {
                            $(""#cardParticipantes"").css(""display"", ""none"");
                        }
                    }
                    else 
                    {
                        $(""#cardParticipantes"").css(""display"", ""none"");
                    }
                    verOpciones(respuesta.estado, respuesta.estadoFinal);
                }
            });
        }

        fu");
                WriteLiteral(@"nction verOpciones(estado, estadoFinal) {
            var acciones = '';
            if (estado == 1 && estadoFinal == 'Cerrado')
            {
                acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-arrow-alt-circle-left""></i> Volver a proceso</button> </div>' +
                    '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-arrow-alt-circle-left""></i> Volver a procesos</button> </div>';
            }
            else if (estado == 2 && estadoFinal == 'Abierto') 
            {
                acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-sitemap""></i> Volver a proceso</button> </div>' +
                    '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-");
                WriteLiteral(@"secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-clipboard-list""></i> Volver a procesos</button> </div>' +
                    '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-warning"" id = ""modificar"" style=""width:100%""><i class=""fas fa-pen-square""></i> Modificar</button> </div>' +
                    '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-danger"" id = ""eliminar"" style=""width:100%""><i class=""fas fa-trash""></i> Eliminar</button> </div>' +
                    '<div class=""form-group  col-lg-12 col-md-12 col-sm-12""><button class=""btn btn-info"" id = ""descargar"" style=""width:100%""><i class=""fas fa-download""></i> Descargar</button> </div>';
            }
            else 
            {
                acciones = '<div class=""form-group  col-lg-4 col-md-4 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-arrow-alt-circle-left""></i> Volver a proceso</button> </div>' +
        ");
                WriteLiteral(@"            '<div class=""form-group  col-lg-4 col-md-4 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-arrow-alt-circle-left""></i> Volver a procesos</button> </div>' +
                    '<div class=""form-group  col-lg-4 col-md-4 col-sm-12""><button class=""btn btn-info"" id = ""descargar"" style=""width:100%""><i class=""fas fa-download""></i> Descargar</button> </div>';
            }

            $('#acciones').append(acciones);

            $('#volverProcesos').click(function (e) {
                e.preventDefault();
                window.location.href = '/Proceso/Procesos/';
            });

            $('#volverProceso').click(function (e) {
                e.preventDefault();
                window.location.href = '/Proceso/VerProceso';
            });

            $('#descargar').click(function (e) {
                e.preventDefault();
                window.location.href = '/Solicitud/DescargarSolicitud';
            });

            ");
                WriteLiteral(@"$('#modificar').click(function (e) {
                e.preventDefault();
                window.location.href = '/Solicitud/ActualizarSolicitud';
            });

            $('#eliminar').click(function (e)
            {
                e.preventDefault();
                $('#title-confirmar-eliminar').text(""Eliminar solicitud"");
                $('#body-confirmar-eliminar').text(""¿Está seguro que desea eliminar la solicitud?"");
                $('#modal-confirmar-eliminar').modal('show');
            });
        }

        function datosPrincipales(solicitud) {
            $(""#verNombreEvento"").val(solicitud.nombreEvento);
            $(""#verLugarEvento"").val(solicitud.lugarEvento);
            $(""#verMonto"").val(formatoNumero(solicitud.monto));
            $(""#verFechaInicio"").val(solicitud.fechaInicioEvento.split(""T"")[0]);
            $(""#verFechaTermino"").val(solicitud.fechaTerminoEvento.split(""T"")[0]);
            $(""#verResponsable"").val(solicitud.nombreResponsable);
            $");
                WriteLiteral(@"(""#verTipoEvento"").val(solicitud.tipoEvento);
        }

        function categorias(categorias) {
            var resp = """";
            for (var i = 0; i < categorias.length; i++) {
                if (i === 0 || i % 2 === 0) {
                    resp += ""<tr class='odd'>"";
                }
                else {
                    resp += ""<tr>"";
                }
                resp += ""<td>"" + categorias[i].nombre + ""</td></tr>"";
            }
            $(""#verTablaCategorias > tbody"").empty();
            $(""#verTablaCategorias > tbody"").append(resp);
        }

        function participantes(participantes) {
            var resp = """";
            for (var i = 0; i < participantes.length; i++)
            {
                if (participantes[i].run != '-1')
                {
                    if (i === 0 || i % 2 === 0)
                    {
                        resp += ""<tr class='odd'>"";
                    }
                    else
                    {
      ");
                WriteLiteral(@"                  resp += ""<tr>"";
                    }
                    resp += ""<td>"" + participantes[i].nombre + ""</td>"" +
                        ""<td>"" + formatearRut(participantes[i].run) + ""</td></tr>"";
                }
            }
            $(""#verTablaParticipantes > tbody"").empty();
            $(""#verTablaParticipantes > tbody"").append(resp);

        }

        function formatoNumero(num) {
            return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, ""$1."")
        }

        $('#btnConfirmarEliminar').click(function ()
        {
            $.ajax({
                url: ""/Solicitud/EliminarSolicitud"",
                method: ""POST"",
                async: ""false"",
                data: """",
                success: function (respuesta)
                {
                    $('#modal-confirmar-eliminar').modal('hide');
                    console.log(respuesta)
                    if (respuesta.validar)
                    {
                        $('#ti");
                WriteLiteral(@"tle-informacion').text(respuesta.titulo);
                        $('#body-informacion').text(respuesta.msj);
                        $('#modal-informacion').modal('show');
                    }
                    else
                    {
                        $('#title-alerta').text(respuesta.titulo);
                        $('#body-alerta').text(respuesta.msj);
                        $('#modal-alerta').modal('show');
                    }
                }
            });
        }); 

        $('#btnAceptarInformacion').click(function ()
        {
            window.location.href = '/Proceso/Procesos';
        });

        function formatearRut(run)
        {
            let runAux = run.replace(/\./g, '').replace('-', '');

            if (runAux.match(/^(\d{2})(\d{3}){2}(\w{1})$/))
            {
                runAux = runAux.replace(/^(\d{2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4');
            }
            else if (runAux.match(/^(\d)(\d{3}){2}(\w{0,1})$/))
         ");
                WriteLiteral(@"   {
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
    </script>
");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
