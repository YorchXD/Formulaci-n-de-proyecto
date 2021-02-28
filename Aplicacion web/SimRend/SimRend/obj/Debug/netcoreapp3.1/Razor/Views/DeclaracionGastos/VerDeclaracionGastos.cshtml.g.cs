#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\DeclaracionGastos\VerDeclaracionGastos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57b3f9637c8cd4f000dff73e06a543de18a8f9f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DeclaracionGastos_VerDeclaracionGastos), @"mvc.1.0.view", @"/Views/DeclaracionGastos/VerDeclaracionGastos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57b3f9637c8cd4f000dff73e06a543de18a8f9f8", @"/Views/DeclaracionGastos/VerDeclaracionGastos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_DeclaracionGastos_VerDeclaracionGastos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\DeclaracionGastos\VerDeclaracionGastos.cshtml"
  
    ViewData["Title"] = "Ver Declaración de gastos";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""br-pagetitle row"">
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <div class=""input-group-text wd-auto"" style=""border:none;"">
                <!--i class=""icon fas fa-sitemap""></i-->
                <i class=""icon fas fa-file-invoice-dollar""></i>
                <h4 style=""padding-left:5%"">Ver declaración de gastos</h4>
            </div>
        </div>
    </div>
</div><!-- d-flex -->

<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">
        <div class=""card bd-0"">
            <div class=""card-header bg-teal-info bd bd-0 tx-white-8"">
                Resumen de la declaración de gastos
            </div><!-- card-header -->

            <div class=""card-body bd bd-t-0 rounded-bottom-0"">
                <div class=""row row-sm"">
                    <div class=""form-group wd-auto col-lg-4 col-md-12"">
                        <label class=""form-control-label"">Número de resolucion:</label>
                        <div class=""inp");
            WriteLiteral(@"ut-group"">
                            <div class=""input-group-prepend"">
                                <span class=""input-group-text""><i class=""fas fa-fingerprint tx-16 lh-0 op-6 fa-fw""></i></span>
                            </div>
                            <input name=""numeroResolucion"" class=""form-control"" id=""numeroResolucion"" readonly type=""text"" placeholder=""Numero de resolución"">
                        </div>
                    </div>
                    <div class=""form-group wd-auto col-lg-4 col-md-12"">
                        <label class=""form-control-label"">Fecha límite para declarar gastos: </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fa fa-calendar-alt tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <inp");
            WriteLiteral(@"ut name=""fechaLimite"" class=""form-control"" id=""fechaLimite"" readonly type=""text"" placeholder=""Fecha límite"">
                        </div>
                    </div>
                    <div class=""form-group wd-auto col-lg-4 col-md-12"">
                        <label class=""form-control-label"">Días restante: </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fa fa-calendar-alt tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""diasRestantes"" class=""form-control"" id=""diasRestantes"" readonly type=""text"" placeholder=""Dias restantes"">
                        </div>
                    </div>
                </div>

                <div class=""row row-sm"">
                    <div class=""form-group wd-auto col-lg-4 col-m");
            WriteLiteral(@"d-12"">
                        <label class=""form-control-label"">Monto total solicitado($): </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fa fa-money-bill-wave tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""totaLSolicitado"" class=""form-control"" id=""totalSolicitado"" readonly type=""text"" placeholder=""Monto total solicitado"">
                        </div>
                    </div>
                    <div class=""form-group wd-auto col-lg-4 col-md-12"">
                        <label class=""form-control-label"">Monto total documentos($): </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-tex");
            WriteLiteral(@"t wd-xs-45"">
                                    <i class=""fa fa-money-bill-wave tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""totalDocumentos"" class=""form-control"" id=""totalDocumentos"" readonly type=""text"" placeholder=""Monto total documentos"">
                        </div>
                    </div>
                    <div class=""form-group wd-auto col-lg-4 col-md-12"">
                        <label class=""form-control-label"">Monto total rendido($): </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fa fa-money-bill-wave tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""totalRendido"" class=""form-control"" id=""totalRendido");
            WriteLiteral(@""" readonly type=""text"" placeholder=""Monto total rendido"">
                        </div>
                    </div>
                </div>

                <div class=""row row-sm"">
                    <div class=""form-group wd-auto col-lg-12 col-md-12"">
                        <label class=""form-control-label"">Unidad:</label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fas fa-building  tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""unidad"" class=""form-control"" id=""unidad"" readonly type=""text"" placeholder=""Unidad"">
                        </div>
                    </div>
                </div>
                <div class=""row row-sm"">
                    <div class=""form-group wd-auto col-lg-6 col-md-12"">
        ");
            WriteLiteral(@"                <label class=""form-control-label"">Nombre jefe directo: </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fa fa-user tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""jefeDirecto"" class=""form-control"" id=""jefeDirecto"" readonly type=""text"" placeholder=""Nombre jefe directo"">
                        </div>
                    </div>

                    <div class=""form-group wd-auto col-lg-6 col-md-12"">
                        <label class=""form-control-label"">Fono anexo: </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i clas");
            WriteLiteral(@"s=""fas fa-phone tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""fonoAnexo"" class=""form-control"" id=""fonoAnexo"" readonly type=""text"" placeholder=""Fono anexo"">
                        </div>
                    </div>
                </div>


                <div class=""row row-sm"">
                    <div class=""form-group wd-auto col-lg-6 col-md-12"">
                        <label class=""form-control-label"">Responsable del fondo: </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fa fa-user tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""responsable"" type=""text"" class=""form-control"" readonly placeholder=""Responsable del");
            WriteLiteral(@" fondo"" id=""responsable"">
                        </div>
                    </div>
                    <div class=""form-group wd-auto col-lg-6 col-md-12"">
                        <label class=""form-control-label"">RUN Responsable: </label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fas fa-address-card tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""runResponsable"" type=""text"" class=""form-control"" readonly placeholder=""RUN del responsable"" id=""runResponsable"">
                        </div>
                    </div>
                </div>
                <div class=""row row-sm"">
                    <div class=""form-group wd-auto col-lg-12 col-md-12"">
                        <label class=""form-control-label"">Email: <");
            WriteLiteral(@"/label>
                        <div class=""input-group"">
                            <div class=""input-group-prepend"">
                                <div class=""input-group-text wd-xs-45"">
                                    <i class=""fas fa-at tx-16 lh-0 op-6 fa-fw""></i>
                                </div>
                            </div>
                            <input name=""emailResponsable"" class=""form-control"" id=""emailResponsable"" readonly type=""text"" placeholder=""Email responsable"">
                        </div>
                    </div>
                </div>
            </div>
            <div class=""card-footer bd bd-t-0"">
                <div class=""row"" id=""acciones"">

                </div>
            </div>
        </div>
    </div><!-- br-section-wrapper -->
    <!-- MODAL ELIMINAR DOCUMENTO -->
    <div id=""modal-alerta-eliminar-documento"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal-dialog modal-dialog-centered"" ");
            WriteLiteral(@"role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""icon icon ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
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
                <div class=""modal-body tx-center p");
            WriteLiteral(@"d-y-20 pd-x-20"">
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
                <div class=""modal-body tx-c");
            WriteLiteral(@"enter pd-y-20 pd-x-20"">
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
                WriteLiteral(@" 
    <script>
        $(document).ready(function ()
        {
            obtenerDatos();
        });

        var procesoAux;

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



        function obtenerDatos(");
                WriteLiteral(@")
        {
            $.ajax({
                url: ""/DeclaracionGastos/LeerDeclaracionGastos"",
                method: ""POST"",
                data: {},
                success: function (respuesta)
                {
                    //console.log(respuesta); //se debe eliminar
                    procesoAux = respuesta;
                    var fecha1 = moment();
                    var fecha2 = moment(respuesta.proceso.declaracionGastos.fechaLimite.split('T')[0]);
                    $('#numeroResolucion').val(respuesta.proceso.resolucion.numResolucion);
                    $('#fechaLimite').val(respuesta.proceso.declaracionGastos.fechaLimite.split('T')[0]);
                    $('#diasRestantes').val(fecha2.diff(fecha1, 'days'));
                    $('#totalSolicitado').val(formatoNumero(respuesta.proceso.solicitud.monto));
                    $('#totalDocumentos').val(formatoNumero(respuesta.proceso.declaracionGastos.totalDocumentacion));
                    $('#totalRendido').val(f");
                WriteLiteral(@"ormatoNumero(respuesta.proceso.declaracionGastos.totalRendido));
                    $('#unidad').val(respuesta.proceso.direccion.nombreInstitucion);
                    $('#jefeDirecto').val(respuesta.proceso.direccion.nombre);
                    $('#fonoAnexo').val(respuesta.proceso.direccion.fonoAnexo);
                    $('#responsable').val(respuesta.proceso.responsable.nombre);
                    $('#runResponsable').val(formatearRut(respuesta.proceso.responsable.run));
                    $('#emailResponsable').val(respuesta.proceso.responsable.email);
                    verOpciones(respuesta.proceso.estado, respuesta.proceso.estadoFinal);
                }
            }); 
            
        }

        function formatoNumero(num)
        {
            return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, ""$1."")
        }

        function verOpciones(estado, estadoFinal)
        {
            var acciones = """";
            if (estadoFinal == ""Abierta"")
            {
  ");
                WriteLiteral(@"              switch (estado)
                {
                    case 3:
                        acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-sitemap""></i> Volver a proceso</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-clipboard-list""></i> Volver a procesos</button> </div>' +
                            '<div class=""form-group  col-lg-12 col-md-12 col-sm-12""><button class=""modal-effect btn btn-info"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""documentacion()""><i class=""fas fa-plus""></i> Agregar Documentación</button> </div>';

                        break;
                    case 4:
                        acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""widt");
                WriteLiteral(@"h:100%""><i class=""fas fa-sitemap""></i> Volver a proceso</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-clipboard-list""></i> Volver a procesos</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""modal-effect btn btn-info"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""documentacion()""><i class=""fas fa-eye""></i> Documentación</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-danger"" style=""width:100%"" onclick=""eliminarDocumentosDG()""><i class=""fas fa-trash""></i> Eliminar</button> </div>' +
                            '<div class=""form-group col-lg-12 col-md-12 col-sm-12""><button class=""btn btn-info"" id=""generar"" style=""width:100%""><i class=""fas fa-file-signature""></i> Generar declaración de gastos</button> </div>';

  ");
                WriteLiteral(@"                      break;
                    default:
                        acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-sitemap""></i> Volver a proceso</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-clipboard-list""></i> Volver a procesos</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""modal-effect btn btn-secondary"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""documentacion()""><i class=""fas fa-eye""></i> Documentación</button> </div>' +
                            '<div class=""form-group col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""descargar"" style=""width:100%""><i class=""fas fa-download""></i> Descargar</button> </div>' +
                            '");
                WriteLiteral(@"<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""modal-effect btn btn-danger"" data-effect=""effect-just-me"" id = ""rechazar"" style=""width:100%""><i class=""fas fa-times-circle""></i> Declaración rechazada</button> </div>' +
                            '<div class=""form-group col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-info"" id=""aceptar"" style=""width:100%""><i class=""fas fa-check-circle""></i> Declaración aceptda</button> </div>';
                        break;
                }
            }
            else
            {
                switch (estado)
                {
                    case 3:
                        acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-sitemap""></i> Volver a proceso</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i c");
                WriteLiteral(@"lass=""fas fa-clipboard-list""></i> Volver a procesos</button> </div>';

                        break;
                    case 4:
                        acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-sitemap""></i> Volver a proceso</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-clipboard-list""></i> Volver a procesos</button> </div>' +
                            '<div class=""form-group  col-lg-12 col-md-12 col-sm-12""><button class=""modal-effect btn btn-info"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""documentacion()""><i class=""fas fa-eye""></i> Documentación</button> </div>';

                        break;
                    default:
                        acciones = '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""bt");
                WriteLiteral(@"n btn-secondary"" id=""volverProceso"" style=""width:100%""><i class=""fas fa-sitemap""></i> Volver a proceso</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%""><i class=""fas fa-clipboard-list""></i> Volver a procesos</button> </div>' +
                            '<div class=""form-group  col-lg-6 col-md-6 col-sm-12""><button class=""modal-effect btn btn-info"" data-effect=""effect-just-me"" id = ""documentacion"" style=""width:100%""><i class=""fas fa-eye""></i> Documentación</button> </div>' +
                            '<div class=""form-group col-lg-6 col-md-6 col-sm-12""><button class=""btn btn-info"" id=""descargar"" style=""width:100%""><i class=""fas fa-download""></i> Descargar</button> </div>';
                        break;
                }
            }
            

            $('#acciones').empty().append(acciones);

            $('#volverProceso').click(function (e)
            {
      ");
                WriteLiteral(@"          e.preventDefault();
                window.location.href = '/Proceso/VerProceso';
            });

            $('#volverProcesos').click(function (e)
            {
                e.preventDefault();
                window.location.href = '/Proceso/Procesos/';
            });

            

            $('#generar').click(function (e)
            {
                e.preventDefault();
                alert('Generar documentación de la declaración de gastos');
            });

            $('#descargar').click(function (e)
            {
                e.preventDefault();
                alert('Descargar documentación de la declaración de gastos');
            });

            $('#rechazar').click(function (e)
            {
                e.preventDefault();
                alert('Declaración de gastos rechazada.');
            });

            $('#aceptar').click(function (e)
            {
                e.preventDefault();
                alert('Declaración de gas");
                WriteLiteral(@"tos aceptada.');
            });

        }

        function documentacion()
        {
            var tipoEvento = procesoAux.proceso.solicitud.tipoEvento;
            switch (tipoEvento)
            {
                case 'Grupal':
                    window.location.href = '/DeclaracionGastos/DocumentacionPersonas';
                    break;
                default:
                    $.ajax({
                        async: false,
                        url: ""/DeclaracionGastos/GuardarIdParticipante"",
                        method: ""POST"",
                        data: {
                            'IdParticipante': ""-1"",
                        },
                        success: function (respuesta)
                        {
                            window.location.href = '/DeclaracionGastos/Documentos';
                        }
                    });
                    break;
            }
        };

        function eliminarDocumentosDG()
        {
          ");
                WriteLiteral(@"  $('#title-alerta-eliminar-documento').text(""Eliminar documentos"");
            $('#body-alerta-eliminar-documento').text(""¿Esta seguro que desea eliminar todos los documento de la declaracion de gasto?"");

            var botonCancelar = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-r-5"">Cancelar</button >';
            var botonAceptar = '<button type=""button"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20 mg-l-5"" onclick=""confirmarEliminarDocumentosDG()"">Aceptar</button>';

            $('#actions-alerta-eliminar-documento').empty().append(botonCancelar);
            $('#actions-alerta-eliminar-documento').append(botonAceptar);
            $('#modal-alerta-eliminar-documento').modal('show');
        }

        function confirmarEliminarDocumentosDG()
        {
            $('#modal-alerta-eliminar-documento').modal('hide');
            $.ajax({
                async: fa");
                WriteLiteral(@"lse,
                url: ""/DeclaracionGastos/EliminarDocumentosDG"",
                method: ""POST"",
                data: """",
                success: function (respuesta)
                {
                    if (respuesta == ""1"")
                    {
                        $('#title-informacion-eliminacion').text(""Eliminacion exitosa"");
                        $('#body-informacion-eliminacion').text(""Se eliminaron todos los documentos y la carpeta de la declaración de gastos."");
                        $('#modal-informacion-eliminacion').modal('show');
                    }
                    else if (respuesta == ""0"")
                    {
                        $('#title-alerta').text(""Alerta"");
                        $('#body-alerta').text(""No se eliminaron los documentos de la declaración de gastos debido a que no existen."");
                        var boton = '<button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-");
                WriteLiteral(@"b-20"">Aceptar</button>';
                        $('#actions-alerta').empty().append(boton);
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
                }
            });
        }

        $('#btn-DocumentosEliminados').click(function (e)
        {
            e.preventDefault();
            $('#modal-informacion-eliminac");
                WriteLiteral("ion\').modal(\'hide\');\r\n            window.location.href = \'/DeclaracionGastos/VerDeclaracionGastos\';\r\n        });\r\n    </script>\r\n");
            }
            );
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
