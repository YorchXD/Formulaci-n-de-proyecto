#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\DeclaracionGastos\VerDocumento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdd0d699312d82982dbcef2e8602ef751e524425"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DeclaracionGastos_VerDocumento), @"mvc.1.0.view", @"/Views/DeclaracionGastos/VerDocumento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdd0d699312d82982dbcef2e8602ef751e524425", @"/Views/DeclaracionGastos/VerDocumento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_DeclaracionGastos_VerDocumento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/parsley.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/i18n/es.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery.maskedinput/jquery.maskedinput.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\DeclaracionGastos\VerDocumento.cshtml"
  
    ViewData["Title"] = "Ver documento";

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
                <h4 style=""padding-left:5%"">Ver documento</h4>
            </div>
        </div>
    </div>
</div><!-- d-flex -->


<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">
        <div class=""form-layout"">
            <div class=""row mg-b-25"">
                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Código del documento:</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-barcode tx-20 lh-0 op-6 fa-fw""></i>
                           ");
            WriteLiteral(@" </div>
                        </div>
                        <input name=""codigoDocumento"" required=""required"" class=""form-control"" id=""codigoDocumento"" type=""text"" placeholder=""Ingrese el código del documento"" readonly>
                    </div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Proveedor: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-store tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""proveedor"" required=""required"" class=""form-control"" id=""proveedor"" type=""text"" placeholder=""Ingrese el nombre del proveedor"" readonly>
                    </div>
                </div>

                <div class=""form-group wd-auto");
            WriteLiteral(@" col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Fecha del documento: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fa fa-calendar-alt tx-20 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""fechaDocumento"" type=""text"" class=""form-control fc-datepicker"" placeholder=""Ingrese la fecha del documento"" id=""fechaDocumento"" required=""required"" readonly>
                    </div>
                </div>

                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Monto($): </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
               ");
            WriteLiteral(@"                 <i class=""fa fa-money-bill-wave tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""Monto"" class=""form-control"" id=""monto"" required=""required"" type=""text"" placeholder=""Monto del documento"" readonly>
                    </div>
                </div>

                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Descripción del documento: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-file-signature tx-20 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""descripcionDocumento"" class=""form-control"" id=""descripcionDocumento"" required=""required"" type=""text"" placeholder=""Ingrese la descripción d");
            WriteLiteral(@"el documento"" readonly>
                    </div>
                </div>

                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Categoria: </label>
                    <div class=""input-group parsley-select"" id=""categoriaMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-tag tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""categoria"" class=""form-control"" id=""categoria"" required=""required"" type=""text"" placeholder=""Categoría del documento"" readonly>
                    </div>
                </div>
                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Tipo de documento: </label>
                    <div class=""input-group parsley-select"" id=""tipoDocu");
            WriteLiteral(@"mentoMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-file-invoice-dollar tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""tipoDocumento"" class=""form-control"" id=""tipoDocumento"" required=""required"" type=""text"" placeholder=""Categoría del documento"" readonly>
                    </div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Copia del documento: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""far fa-file-pdf tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
     ");
            WriteLiteral(@"                   <input type=""text"" class=""form-control"" id=""nombreArchivo"" placeholder=""Nombre del documento"" readonly>
                        <span class=""input-group-append"">
                            <button class=""btn btn-secondary"" type=""button"" id=""descargarDocumento"" title=""Descargar""><i class=""fa fa-download tx-16""></i></button>
                        </span>
                    </div>
                </div>

            </div>
            <div class=""form-layout-footer"">
                <div class=""row"" id=""acciones"">
                    
                </div>
            </div>
        </div>

    </div><!-- br-section-wrapper -->
    <!-- MODAL ELIMINAR DOCUMENTO -->
    <div id=""modal-alerta-eliminar-documento"" class=""modal fade"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""ionicons ion-ios-help");
            WriteLiteral(@"-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-danger  tx-semibold mg-b-20"" id=""title-alerta-eliminar-documento""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-alerta-eliminar-documento""></p>
                    <button type=""button"" data-dismiss=""modal"" class=""btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Cancelar
                    </button>
                    <button type=""button"" id=""btnConfirmarEliminarDocumento"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->

    <!-- MODAL INFORMACION ELIMINACION -->
    <div id=""modal-informacion-eliminacion"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=");
            WriteLiteral(@"""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""icon ion-ios-checkmark-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-success tx-semibold mg-b-20"" id=""title-informacion-eliminacion""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-informacion-eliminacion""></p>
                    <button type=""button"" id=""btn-DocumentoEliminado"" class=""btn btn-success tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"" data-dismiss=""modal"" aria-label=""Close"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->

    <!-- MODAL ALERTA -->
    <div id=""modal-alerta"" class=""modal fade"">
        <div class=""modal-dialog modal-dialog-centered"" r");
            WriteLiteral(@"ole=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""icon icon ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-danger  tx-semibold mg-b-20"" id=""title-alerta""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-alerta""></p>
                    <button type=""button"" data-dismiss=""modal"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div><!-- br-pagebody -->


");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdd0d699312d82982dbcef2e8602ef751e52442515322", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdd0d699312d82982dbcef2e8602ef751e52442516422", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdd0d699312d82982dbcef2e8602ef751e52442517522", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>

        var id, estado;

        $(document).ready(function ()
        {
            verDocumento();
        });

        function verDocumento()
        {
            $.ajax({
                async: false,
                url: ""/DeclaracionGastos/DatosDocumento"",
                method: ""POST"",
                data: """",
                success: function (respuesta)
                {
                    //console.log(respuesta);
                    id = respuesta.documento.id;
                    estado = respuesta.documento.estado;
                    $('#codigoDocumento').val(respuesta.documento.codigoDocumento);
                    $('#proveedor').val(respuesta.documento.proveedor);
                    $('#fechaDocumento').val(respuesta.documento.fechaDocumento.split(""T"")[0]);
                    $('#monto').val(formatoNumero(respuesta.documento.monto));
                    $('#descripcionDocumento').val(respuesta.documento.descripcionDocumento);
                  ");
                WriteLiteral(@"  $('#categoria').val(respuesta.documento.categoria.nombre);
                    $('#tipoDocumento').val(respuesta.documento.tipoDocumento);
                    var rutaDoc = respuesta.documento.copiaDoc.split(""\\"");
                    $('#nombreArchivo').val(rutaDoc[rutaDoc.length - 1]);
                    insertarAcciones(respuesta.estadoProceso, respuesta.estadoFinalProceso);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown)
                {
                    $('#title-alerta').text(textStatus);
                    $('#body-alerta').text(errorThrown);
                    $('#modal-alerta').modal('show');
                } 
            });
        }

        function insertarAcciones(estadoProceso, estadoFinalProceso)
        {
            if (estadoProceso == 4 && estadoFinalProceso == ""Abierto"")
            {
                var volver = '<div class=""form-group  col-lg-4 col-md-4 col-sm-12""> <button class=""btn btn-secondary"" id=""volverDocu");
                WriteLiteral(@"mentos"" style=""width:100%"" onclick=""volverDocumentos()""><i class=""fas fa-arrow-circle-left""></i> Volver</button></div>';
                var modificar = '<div class=""form-group  col-lg-4 col-md-4 col-sm-12""><button class=""modal-effect btn btn-warning tx-transform-none"" id=""modificarDocumento"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""modificarDocumento()""><i class=""fas fa-edit""></i> Modificar</button></div>';
                var eliminar = '<div class=""form-group  col-lg-4 col-md-4 col-sm-12""><button class=""modal-effect btn btn-danger tx-transform-none"" id=""eliminarDocumento"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""eliminarDocumento()""><i class=""fas fa-trash""></i> Eliminar</button></div >';
                $('#acciones').empty().append(volver);
                $('#acciones').append(modificar);
                $('#acciones').append(eliminar);
            }
            else
            {
                var volver = '<div class=""form-group  col-lg-12 col-md-12 col-sm-12""");
                WriteLiteral(@"> <button class=""btn btn-secondary"" id=""volverDocumentos"" style=""width:100%"" onclick=""volverDocumentos()""><i class=""fas fa-arrow-circle-left""></i> Volver</button></div>';
                $('#acciones').empty().append(volver);
            }
        }

        function volverDocumentos()
        {
            window.location.href = '/DeclaracionGastos/Documentos';
        };

        function modificarDocumento()
        {
            window.location.href = '/DeclaracionGastos/ActualizarDocumento';
        }

        $(""#descargarDocumento"").click(function (e)
        {
            e.preventDefault();
            window.location.href = '/DeclaracionGastos/DescargarDocumento';
        });

        function formatoNumero(num)
        {
            return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, ""$1."")
        }

        function eliminarDocumento()
        {
            if (estado == 0)
            {
                $('#title-alerta-eliminar-documento').text(""Eliminar docume");
                WriteLiteral(@"nto"");
                $('#body-alerta-eliminar-documento').text(""¿Está seguro que desea eliminar el documento?"");
                $('#modal-alerta-eliminar-documento').modal('show');
            }
            else
            {
                $('#title-alerta').text(""Alerta"");
                $('#body-alerta').text(""No se puede eliminar el documento debido a que se encuentra seleccionado para ser declarado como gasto del evento. Si desea eliminarlo, debe dejar el documento como no seleccionado y posteriormente preceder a eliminarlo."");
                $('#modal-alerta').modal('show');
            }
        };

        $('#btnConfirmarEliminarDocumento').click(function (e)
        {
            e.preventDefault();
            $.ajax({
                async: false,
                url: ""/DeclaracionGastos/EliminarDocumento"",
                method: ""POST"",
                data: {
                    'IdDocumento': id,
                },
                success: function (respuesta)
    ");
                WriteLiteral(@"            {
                    $('#modal-alerta-eliminar-documento').modal('hide');
                    $('#title-informacion-eliminacion').text(respuesta.titulo);
                    $('#body-informacion-eliminacion').text(respuesta.msj);
                    $('#modal-informacion-eliminacion').modal('show');
                },
                error: function (XMLHttpRequest, textStatus, errorThrown)
                {
                    $('#title-alerta').text(textStatus);
                    $('#body-alerta').text(errorThrown);
                    $('#modal-alerta').modal('show');
                } 
            });
        });

        $('#btn-DocumentoEliminado').click(function (e)
        {
            e.preventDefault();
            $('#modal-informacion-eliminacion').modal('hide');
            window.location.href = '/DeclaracionGastos/Documentos';
        });

    </script>

");
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
