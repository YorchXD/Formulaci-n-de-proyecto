#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Resolucion\CrearResolucion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "277797acbee4f43546b43c8b5f431ac713cac07f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resolucion_CrearResolucion), @"mvc.1.0.view", @"/Views/Resolucion/CrearResolucion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"277797acbee4f43546b43c8b5f431ac713cac07f", @"/Views/Resolucion/CrearResolucion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Resolucion_CrearResolucion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/parsley.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/i18n/es.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.numeric.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Resolucion.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Resolucion\CrearResolucion.cshtml"
  
    ViewData["Title"] = "Agregar documento";

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
                <h4 style=""padding-left:5%"">Agregar resolución</h4>
            </div>
        </div>
    </div>
</div><!-- d-flex -->


<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">

        <div class=""card bd-0"">
            <div class=""card-header bg-teal-info bd bd-0 tx-white-8 tx-bold"">
                Resumen de la solicitud
            </div><!-- card-header -->

            <div class=""card-body bd bd-t-0 rounded-bottom-0"">
                <dl class=""row"">
                    <dt class=""col-sm-3 tx-inverse"">Nombre del evento</dt>
                    <dd class=""col-sm-9"" id=""nombreEvento"">-</dd>

                    <dt class=""col-sm-3 tx-inverse"">Responsable de la s");
            WriteLiteral(@"olicitud</dt>
                    <dd class=""col-sm-9"" id=""responsable"">-</dd>

                    <dt class=""col-sm-3 tx-inverse"">Monto de la solicitud</dt>
                    <dd class=""col-sm-9"" id=""monto"">-</dd>

                    <dt class=""col-sm-3 text-truncate tx-inverse"">Fecha de inicio</dt>
                    <dd class=""col-sm-9"" id=""fechaInicio"">-</dd>

                    <dt class=""col-sm-3 text-truncate tx-inverse"">Fecha de término</dt>
                    <dd class=""col-sm-9"" id=""fechaTermino"">-</dd>

                    <dt class=""col-sm-3 text-truncate tx-inverse"">Lugar del evento</dt>
                    <dd class=""col-sm-9"" id=""lugarEvento"">-</dd>
                </dl>
            </div>
        </div>

        <div class=""card bd-0 mg-t-40"">
            <div class=""card-header bg-teal-info bd bd-0 tx-white-8 tx-bold"">
                Datos de la resolución
            </div><!-- card-header -->

            <div class=""card-body bd bd-t-0 rounded-bottom-0"">
   ");
            WriteLiteral(@"             <div class=""form-group wd-auto"">
                    <label class=""form-control-label"">Número de resolución:</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text""><i class=""fas fa-fingerprint tx-16 lh-0 op-6 fa-fw""></i></span>
                        </div>
                        <input name=""numResolucion"" required=""required"" class=""form-control numeric"" id=""numResolucion"" type=""text"" placeholder=""Ingrese el número de la resolución""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 2675, "\"", 2688, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorNumResolucion"">
                    </div>
                    <div id=""errorNumResolucion""></div>
                </div>

                <div class=""form-group wd-auto"">
                    <label class=""form-control-label"">Año de la resolución: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fa fa-calendar-alt tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""anioResolucion"" required=""required"" class=""form-control numeric"" id=""anioResolucion"" type=""text"" placeholder=""Ingrese el año de la resolución""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 3503, "\"", 3516, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorAnioResolucion"">
                    </div>
                    <div id=""errorAnioResolucion""></div>
                </div>

                <div class=""form-group wd-auto"">
                    <label class=""form-control-label"">Copia del documento: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""far fa-file-pdf tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>

                        <div class=""custom-file"">
                            <label class=""custom-file-label custom-file-label-inverse"" id=""nombreArchivo"">Seleccione un archivo PDF</label>
                            <input type=""file"" required=""required"" class=""custom-file-input"" id=""resolucion"" data-parsley-errors-container=""#errorResolucion"">
                        </div>
     ");
            WriteLiteral(@"               </div>
                    <div id=""errorResolucion""></div>
                </div>

            </div>
            <div class=""card-footer bd bd-t-0"">
                <div class=""row"" id=""acciones"">
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""btn btn-secondary"" id=""volver"" style=""width:100%"">
                            <i class=""fas fa-sitemap""></i> Volver a proceso
                        </button>
                    </div>
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""btn btn-secondary"" id=""volverProcesos"" style=""width:100%"">
                            <i class=""fas fa-clipboard-list""></i> Volver a procesos
                        </button>
                    </div>
                    <div class=""form-group  col-lg-12 col-md-12 col-sm-12"">
                        <button class=""modal-effect btn btn-info"" id=""guardar"" data-effect=""effect");
            WriteLiteral(@"-just-me"" style=""width:100%"">
                            <i class=""fas fa-save""></i> Guardar
                        </button>
                    </div>

                </div>
            </div>
        </div>

    </div><!-- br-section-wrapper -->
    <!-- MODAL INFORMACION -->
    <div id=""modal-informacion"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <i class=""icon ion-ios-checkmark-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-success tx-semibold mg-b-20"" id=""title-informacion""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-informacion""></p>
                    <button type=""button"" id=""btn-ResolucionCreada"" class=""btn btn-success tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"" dat");
            WriteLiteral(@"a-dismiss=""modal"" aria-label=""Close"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
    <!-- MODAL PREGUNTAR GUARDAR RESOLUCION -->
    <div class=""modal fade"" id=""modal-confirmar-guardar"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">×</span>
                    </button>
                    <i class=""ionicons ion-ios-help-outline tx-100 tx-success lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-success mg-b-20"" id=""title-confirmar-guardar""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-confirmar-guardar""></p>
  ");
            WriteLiteral(@"                  <button type=""button"" data-dismiss=""modal"" class=""btn btn-secondary tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Cancelar
                    </button>
                    <button type=""button"" id=""btnConfirmarGuardar"" class=""btn btn-success tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"">
                        Aceptar
                    </button>
                </div><!-- modal-body -->
            </div>
        </div>
    </div>

    <!-- MODAL ERROR -->
    <div id=""modal-alerta"" class=""modal fade"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                    <i class=""icon i");
            WriteLiteral(@"con ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    <h4 class=""tx-danger  tx-semibold mg-b-20"" id=""title-alerta""></h4>
                    <p class=""mg-b-20 mg-x-20"" id=""body-alerta""></p>
                    <button type=""button"" class=""btn btn-danger tx-11 tx-uppercase pd-y-12 pd-x-25 tx-mont tx-medium mg-b-20"" data-dismiss=""modal"" aria-label=""Close"">
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277797acbee4f43546b43c8b5f431ac713cac07f15044", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277797acbee4f43546b43c8b5f431ac713cac07f16144", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277797acbee4f43546b43c8b5f431ac713cac07f17244", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277797acbee4f43546b43c8b5f431ac713cac07f18344", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function ()\r\n        {\r\n            obtenerSolicitud();\r\n        });\r\n    </script>\r\n");
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
