#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\DeclaracionGastos\DocumentacionPersonas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b378b6f075001099f66c694cd56173822d17d6b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DeclaracionGastos_DocumentacionPersonas), @"mvc.1.0.view", @"/Views/DeclaracionGastos/DocumentacionPersonas.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b378b6f075001099f66c694cd56173822d17d6b6", @"/Views/DeclaracionGastos/DocumentacionPersonas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_DeclaracionGastos_DocumentacionPersonas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/toastr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.numeric.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\DeclaracionGastos\DocumentacionPersonas.cshtml"
  
    ViewData["Title"] = "Documentación";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""br-pagetitle row"">
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <div class=""input-group-text wd-auto"" style=""border:none;"">
                <i class=""icon fas fa-plus-square""></i>
                <h4 style=""padding-left:5%"">Documentación</h4>
            </div>
        </div>

    </div>
</div><!-- d-flex -->

<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">

        <div class=""row row-sm mg-b-20"">
            <div class=""col-sm-12 col-lg-6"">
                <div class=""bg-white rounded shadow-base overflow-hidden"">
                    <div class=""pd-x-20 pd-t-20 pd-b-20 d-flex align-items-center"">
                        <i class=""ion ion-earth tx-80 lh-0 tx-primary op-5""></i>
                        <div class=""mg-l-20"">
                            <p class=""tx-10 tx-spacing-1 tx-mont tx-semibold tx-uppercase mg-b-10"">Total monto documentación</p>
                            <p class=""tx-32 tx-inverse tx-lato tx-black ");
            WriteLiteral(@"mg-b-0 lh-1"" id=""montoDocs""></p>
                            <span class=""tx-12 tx-roboto tx-gray-600""><span id=""porcentDocs""></span>% del monto solicitado</span>
                        </div>
                    </div>
                </div>
            </div><!-- col-6 -->

            <div class=""col-sm-12 col-lg-6 mg-t-20 mg-lg-t-0"">
                <div class=""bg-white rounded shadow-base overflow-hidden"">
                    <div class=""pd-x-20 pd-t-20 pd-b-20 d-flex align-items-center"">
                        <i class=""ion ion-bag tx-80 lh-0 tx-purple op-5""></i>
                        <div class=""mg-l-20"">
                            <p class=""tx-10 tx-spacing-1 tx-mont tx-semibold tx-uppercase mg-b-10"">Total monto docs. rendido</p>
                            <p class=""tx-32 tx-inverse tx-lato tx-black mg-b-0 lh-1"" id=""montoDocsSelecTotal""></p>
                            <span class=""tx-12 tx-roboto tx-gray-600""><span id=""porcentDocsSelecTotal""></span>% del monto solicitado</span>
 ");
            WriteLiteral(@"                       </div>
                    </div>
                </div>
            </div><!-- col-6 -->
        </div><!-- row -->

        <div class=""table-wrapper"">
            <table id=""tablaParticipantes"" class=""table display responsive nowrap"" width=""100%"">
                <thead class=""thead-colored thead-info"">
                    <tr>
                        <th class=""wd-auto"">Participantes</th>
                        <th class=""wd-auto"">Monto documentación($)</th>
                        <th class=""wd-auto"">Monto rendido($)</th>
                        <th class=""wd-auto"">Acción</th>
                    </tr>
                </thead>
            </table>
        </div><!-- table-wrapper -->

        <div class=""row mg-t-50"" id=""acciones"">

        </div>
    </div><!-- br-section-wrapper -->
    <!-- MODAL ELIMINAR DOCUMENTO -->
    <div id=""modal-alerta-eliminar-documento"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal");
            WriteLiteral(@"-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""ionicons ion-ios-help-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-danger  tx-semibold mg-b-20"" id=""title-alerta-eliminar-documento""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-alerta-eliminar-documento""></p>

                    <div id=""actions-alerta-eliminar-documento"">

                    </div>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
    <!-- MODAL INFORMACION ELIMINACION -->
    <div id=""modal-informacion-eliminacion"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div ");
            WriteLiteral(@"class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""icon ion-ios-checkmark-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-success tx-semibold mg-b-20"" id=""title-informacion-eliminacion""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-informacion-eliminacion""></p>
                    <button type=""button"" id=""btn-DocumentosEliminados"" class=""btn btn-success tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"" data-dismiss=""modal"" aria-label=""Close"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
    <!-- MODAL ALERTA -->
    <div id=""modal-alerta"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
              ");
            WriteLiteral(@"  <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""icon icon ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-danger  tx-semibold mg-b-20"" id=""title-alerta""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-alerta""></p>
                    <div id=""actions-alerta"">

                    </div>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div><!-- br-pagebody -->


");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b378b6f075001099f66c694cd56173822d17d6b610371", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <!--script src=""http://codeseven.github.com/toastr/toastr.js""></script-->
    <script src=""../lib/jquery-steps/build/jquery.steps.js""></script>
    <!--script src=""../lib/jquery-steps/build/jquery.steps.min.js""></script-->
    <script src=""../lib/parsleyjs/parsley.min.js""></script>
    <script src=""../lib/parsleyjs/i18n/es.js""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b378b6f075001099f66c694cd56173822d17d6b611828", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""../lib/jquery.maskedinput/jquery.maskedinput.js""></script>

    <div>
        <script>
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
             ");
                WriteLiteral(@"       ""lengthMenu"": ""Mostrar _MENU_ Entradas"",
                    ""loadingRecords"": ""Cargando..."",
                    ""processing"": ""Procesando..."",
                    ""search"": ""Buscar:"",
                    ""zeroRecords"": ""Sin resultados encontrados"",
                    ""paginate"": {
                        ""first"": ""Primero"",
                        ""last"": ""Ultimo"",
                        ""next"": ""Siguiente"",
                        ""previous"": ""Anterior""
                    }
                }
            });

            $(document).ready(function ()
            {
                $('#tablaParticipantes').DataTable();
                obtenerDatos();
            });

            var IdParticipante;

            function obtenerDatos()
            {
                $.ajax({
                    async: false,
                    url: ""/DeclaracionGastos/LeerParticipantes"",
                    method: ""POST"",
                    data: """",
                    success: functio");
                WriteLiteral(@"n (respuesta)
                    {
                        participantes(respuesta.participantes, respuesta.estado);
                        indicadores(respuesta);
                        insertarAcciones(respuesta.estado, respuesta.estadoFinal);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown)
                    {
                        $('#title-alerta').text(textStatus);
                        $('#body-alerta').text(errorThrown);
                        var boton = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">Aceptar</button>';
                        $('#actions-alerta').empty().append(boton);
                        $('#modal-alerta').modal('show');
                    } 
                });
            }

            function participantes(datosParticipantes, estadoProceso)
            {
                $('#tablaParticipantes').DataTable({
      ");
                WriteLiteral(@"              'data': datosParticipantes,
                    'columns': [
                        { ""data"": ""nombre"" },
                        {
                            ""data"": 'documentos',
                            ""render"": function (data, type, row, meta)
                            {
                                var monto = 0;
                                for (var index = 0; data != null && index < data.length; index++)
                                {
                                    monto += data[index].monto;
                                }
                                return formatoNumero(monto);
                            }
                        },
                        {
                            ""data"": 'documentos',
                            ""render"": function (data, type, row, meta)
                            {
                                var monto = 0;
                                for (var index = 0; data != null && index < data.length");
                WriteLiteral(@"; index++)
                                {
                                    if (data[index].estado)
                                    {
                                        monto += data[index].monto;
                                    }
                                }
                                return formatoNumero(monto);
                            }
                        },
                        {
                            ""data"": 'run',
                            ""render"": function (data, type, row, meta)
                            {
                                if (estadoProceso == 4)
                                {
                                    return '<button class=""btn btn-success btn-icon rounded-circle mg-r-5 mg-b-10"" onclick=""ver(\'' + data.toString() + '\')""><div><i class=""fas fa-eye""></i></div></button>' +
                                        '<button class=""btn btn-danger btn-icon rounded-circle mg-r-5 mg-b-10"" onclick=""eliminar(\'' + dat");
                WriteLiteral(@"a.toString() + '\')""><div><i class=""fas fa-trash""></i></div></button>';
                                }
                                return '<button class=""btn btn-success btn-icon rounded-circle mg-r-5 mg-b-10"" onclick=""ver(\'' + data.toString() + '\')""><div><i class=""fas fa-eye""></i></div></button>';
                            }
                        }
                    ]
                });

            }

            function indicadores(datos)
            {
                //console.log(datos);
                var montoDocs = 0;
                var montoDocsSelec = 0;
                var cantParticipantes = datos.participantes.length;

                for (var i = 0; i < cantParticipantes; i++)
                {
                    if (datos.participantes[i].documentos != null)
                    {
                        var cantDocumentos = datos.participantes[i].documentos.length;
                        for (var j = 0; j < cantDocumentos; j++)
                       ");
                WriteLiteral(@" {
                            montoDocs += datos.participantes[i].documentos[j].monto;
                            if (datos.participantes[i].documentos[j].estado)
                            {
                                montoDocsSelec += datos.participantes[i].documentos[j].monto
                            }
                        }
                    }
                    
                }
                var porcentajeDocumentos = (montoDocs / datos.montoSolicitado) * 100;

                $('#montoDocs').text('$' + formatoNumero(montoDocs));
                $('#porcentDocs').text(redondearDecimales(porcentajeDocumentos, 2));


                var porcentajeDocsSelec = (montoDocsSelec / datos.montoSolicitado) * 100;
                $('#montoDocsSelecTotal').text('$' + formatoNumero(montoDocsSelec));
                $('#porcentDocsSelecTotal').text(redondearDecimales(porcentajeDocsSelec, 2));
            }

            function insertarAcciones(estado, estadoFinal)
          ");
                WriteLiteral(@"  {
                if (estado == 4 && estadoFinal == ""Abierto"")
                {
                    var volver = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""> <button class=""btn btn-secondary""  style=""width:100%"" onclick=""volver()""><i class=""fas fa-arrow-circle-left""></i> Volver</button></div>';
                    var eliminar = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""modal-effect btn btn-danger tx-transform-none""  data-effect=""effect-just-me"" style=""width:100%"" onclick=""eliminarDocumentosDG()""><i class=""fas fa-trash""></i> Eliminar documentación</button></div>';

                    $('#acciones').empty().append(volver);
                    $('#acciones').append(eliminar);
                }
                else
                {
                    var volver = '<div class=""form-group  col-lg-12 col-md-12 col-sm-12""> <button class=""btn btn-secondary"" style=""width:100%"" onclick=""volver()""><i class=""fas fa-arrow-circle-left"" ></i> Volver</button></div>';
   ");
                WriteLiteral(@"                 $('#acciones').empty().append(volver);
                }
            }

            function redondearDecimales(numero, decimales)
            {
                numeroRegexp = new RegExp('\\d\\.(\\d){' + decimales + ',}');   // Expresion regular para numeros con un cierto numero de decimales o mas
                if (numeroRegexp.test(numero))
                {         // Ya que el numero tiene el numero de decimales requeridos o mas, se realiza el redondeo
                    return Number(numero.toFixed(decimales));
                } else
                {
                    return Number(numero.toFixed(decimales)) === 0 ? 0 : numero;  // En valores muy bajos, se comprueba si el numero es 0 (con el redondeo deseado), si no lo es se devuelve el numero otra vez.
                }
            }

            function ver(idParticipante)
            {
                $.ajax({
                    async: false,
                    url: ""/DeclaracionGastos/GuardarIdParticipante");
                WriteLiteral(@""",
                    method: ""POST"",
                    data: {
                        'IdParticipante': idParticipante,
                    },
                    success: function (respuesta)
                    {
                        window.location.href = '/DeclaracionGastos/Documentos';
                    }
                });

            }

            function volver()
            {
                window.location.href = '/DeclaracionGastos/VerDeclaracionGastos';
            }

            function formatoNumero(num)
            {
                return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, ""$1."")
            }

            function eliminar(idParticipante)
            {
                IdParticipante = idParticipante;
                $('#title-alerta-eliminar-documento').text(""Eliminar documentos"");
                $('#body-alerta-eliminar-documento').text(""¿Está seguro que desea eliminar todos los documento?"");

                var botonCancelar = '<b");
                WriteLiteral(@"utton type=""button"" data-dismiss=""modal"" class=""btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5"">Cancelar</button >';
                var botonAceptar = '<button type=""button"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5"" onclick=""confirmarEliminarDocumentos()"">Aceptar</button>';

                $('#actions-alerta-eliminar-documento').empty().append(botonCancelar);
                $('#actions-alerta-eliminar-documento').append(botonAceptar);
                $('#modal-alerta-eliminar-documento').modal('show');

            }

            function confirmarEliminarDocumentos()
            {
                $('#modal-alerta-eliminar-documento').modal('hide');
                console.log(IdParticipante);
                $.ajax({
                    async: false,
                    url: ""/DeclaracionGastos/EliminarDocumentosPaticipante"",
                    method: ""POST"",
                    data: {
            ");
                WriteLiteral(@"            'IdParticipante': IdParticipante,
                    },
                    success: function (respuesta)
                    {
                        if (respuesta == ""1"")
                        {
                            $('#title-informacion-eliminacion').text(""Eliminacion exitosa"");
                            $('#body-informacion-eliminacion').text(""Se eliminaron todos los documentos y la carpeta del participante"");
                            $('#modal-informacion-eliminacion').modal('show');
                        }
                        else if (respuesta == ""0"")
                        {
                            $('#title-alerta').text(""Alerta"");
                            $('#body-alerta').text(""No se eliminaron los documentos debido a que no existen."");
                            var boton = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">Aceptar</button>';
                      ");
                WriteLiteral(@"      $('#actions-alerta').empty().append(boton);
                            $('#modal-alerta').modal('show');
                        }
                        else
                        {
                            $('#title-alerta').text(""Alerta"");
                            $('#body-alerta').text(""No se eliminaron los documentos debido a que ha ocurrido un problema de conexión. Favor de volver a intentarlo y si el problema persiste contactar a soporte"");
                            var boton = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">Aceptar</button>';
                            $('#actions-alerta').empty().append(boton);
                            $('#modal-alerta').modal('show');
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown)
                    {
                        var boton = '<button type=""button"" data-dismiss=");
                WriteLiteral(@"""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">Aceptar</button>';
                        $('#actions-alerta').empty().append(boton);
                        $('#title-alerta').text(textStatus);
                        $('#body-alerta').text(errorThrown);
                        $('#modal-alerta').modal('show');
                    } 
                });
            }

            function eliminarDocumentosDG()
            {
                $('#title-alerta-eliminar-documento').text(""Eliminar documentos"");
                $('#body-alerta-eliminar-documento').text(""¿Está seguro que desea eliminar todos los documento de la declaracion de gasto?"");

                var botonCancelar = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5"">Cancelar</button >';
                var botonAceptar = '<button type=""button"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-2");
                WriteLiteral(@"5 tx-mont tx-medium mg-b-20 mg-l-5"" onclick=""confirmarEliminarDocumentosDG()"">Aceptar</button>';

                $('#actions-alerta-eliminar-documento').empty().append(botonCancelar);
                $('#actions-alerta-eliminar-documento').append(botonAceptar);
                $('#modal-alerta-eliminar-documento').modal('show');
            }
            
            function confirmarEliminarDocumentosDG()
            {
                $('#modal-alerta-eliminar-documento').modal('hide');
                $.ajax({
                    async: false,
                    url: ""/DeclaracionGastos/EliminarDocumentosDG"",
                    method: ""POST"",
                    data: """",
                    success: function (respuesta)
                    {
                        if (respuesta == ""1"")
                        {
                            $('#title-informacion-eliminacion').text(""Eliminacion exitosa"");
                            $('#body-informacion-eliminacion').text(""Se elimina");
                WriteLiteral(@"ron todos los documentos y la carpeta de la declaración de gastos."");
                            $('#modal-informacion-eliminacion').modal('show');
                        }
                        else if (respuesta == ""0"")
                        {
                            $('#title-alerta').text(""Alerta"");
                            $('#body-alerta').text(""No se eliminaron los documentos de la declaración de gastos debido a que no existen."");
                            var boton = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">Aceptar</button>';
                            $('#actions-alerta').empty().append(boton);
                            $('#modal-alerta').modal('show');
                        }
                        else
                        {
                            $('#title-alerta').text(""Alerta"");
                            $('#body-alerta').text(""No se eliminaron los documentos debido");
                WriteLiteral(@" a que ha ocurrido un problema de conexión. Favor de volver a intentarlo y si el problema persiste contactar a soporte"");
                            var boton = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">Aceptar</button>';
                            $('#actions-alerta').empty().append(boton);
                            $('#modal-alerta').modal('show');
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown)
                    {
                        $('#title-alerta').text(textStatus);
                        $('#body-alerta').text(errorThrown);
                        var boton = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">Aceptar</button>';
                        $('#actions-alerta').empty().append(boton);
                        $('#modal-alerta').moda");
                WriteLiteral(@"l('show');
                    } 
                });
            }

            $('#btn-DocumentosEliminados').click(function (e)
            {
                e.preventDefault();
                $('#modal-informacion-eliminacion').modal('hide');
                window.location.href = '/DeclaracionGastos/DocumentacionPersonas';
            });
        </script>
    </div>
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