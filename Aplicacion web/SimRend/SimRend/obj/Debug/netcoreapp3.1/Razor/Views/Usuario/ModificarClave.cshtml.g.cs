#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\ModificarClave.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d78768f5f44821ce71afd27b6e14a0046a45f768"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_ModificarClave), @"mvc.1.0.view", @"/Views/Usuario/ModificarClave.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d78768f5f44821ce71afd27b6e14a0046a45f768", @"/Views/Usuario/ModificarClave.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_ModificarClave : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/parsley.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/i18n/es.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.numeric.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Usuario.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\ModificarClave.cshtml"
  
    ViewData["Title"] = "Modificar clave";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""br-pagetitle row"">
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <div class=""input-group-text wd-auto"" style=""border:none;"">
                <i class=""icon ion-person-stalker""></i>
                <h4 style=""padding-left:5%"">Modificar clave</h4>
            </div>
        </div>
    </div>
</div><!-- d-flex -->


<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">
        <div class=""form-layout"">

            <input name=""id"" class=""form-control"" id=""id"" type=""hidden"">
            <input name=""idOE"" class=""form-control"" id=""idOE"" type=""hidden"">
            <div class=""row mg-b-25"">
                <div class=""form-group wd-auto col-sm-12 col-lg-12"">
                    <label class=""form-control-label"">Clave actual: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                             ");
            WriteLiteral(@"   <i class=""fas fa-key tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input autocomplete=""new-password"" name=""clave"" required=""required"" class=""form-control"" id=""claveActual"" type=""password"" placeholder=""Ingrese la clave actual del usuario""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 1391, "\"", 1404, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorClaveActual"">
                        <div class=""input-group-append"">
                            <button type=""button"" id=""verClave"" class=""btn btn-warning btn-flat"" onclick=""mostrarClaveActual()""><span id=""iconoClave"" class=""fa fa-eye-slash icon""></span></button>
                        </div>
                    </div>
                    <div id=""errorClaveActual""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-12"">
                    <label class=""form-control-label"">Nueva clave: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-key tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input autocomplete=""new-password"" name=""clave"" required=""required"" class=""form");
            WriteLiteral("-control\" id=\"nuevaClave\" type=\"password\" placeholder=\"Ingrese la nueva clave del usuario\"");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 2519, "\"", 2532, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorNuevaClave"">
                        <div class=""input-group-append"">
                            <button type=""button"" id=""verClave"" class=""btn btn-warning btn-flat"" onclick=""mostrarNuevaClave()""><span id=""iconoClave"" class=""fa fa-eye-slash icon""></span></button>
                        </div>
                    </div>
                    <div id=""errorNuevaClave""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-12"">
                    <label class=""form-control-label"">Confirmar clave: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-key tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input autocomplete=""new-password"" name=""clave"" required=""required"" class=""for");
            WriteLiteral("m-control\" id=\"confirmacionNuevaClave\" type=\"password\" placeholder=\"Ingrese la confirmación de la nueva clave del usuario\"");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 3679, "\"", 3692, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorConfirmarClave"">
                        <div class=""input-group-append"">
                            <button type=""button"" id=""verClave"" class=""btn btn-warning btn-flat"" onclick=""mostrarConfirmarClave()""><span id=""iconoClave"" class=""fa fa-eye-slash icon""></span></button>
                        </div>
                    </div>
                    <div id=""errorConfirmarClave""></div>
                </div>
            </div>
            <div class=""form-layout-footer"">
                <div class=""row"" id=""acciones"">
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""btn btn-secondary"" id=""guardar"" style=""width:100%"" onclick=""actualizarDatos()"">
                            <i class=""fas fa-window-close""></i> Cancelar
                        </button>
                    </div>
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""modal-e");
            WriteLiteral(@"ffect btn btn-warning tx-transform-none"" id=""modificar"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""modificarClave()"">
                            <i class=""fas fa-pen-square""></i> Modificar
                        </button>
                    </div>

                </div>
            </div>
        </div>
    </div><!-- br-section-wrapper -->
</div><!-- br-pagebody -->

<!-- MODAL ELIMINAR PROCESO -->
<div id=""modal-alerta"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content tx-size-sm"">
            <div class=""modal-body tx-center pd-y-20 pd-x-20"">

                <div id=""icon-problema"">
                    <i class=""icon ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                </div>

                <div id=""icon-modificar"">
                    <i class=""icon ion-ios-plus-outline tx-100 tx-warning lh-1 mg-t-20 d-inline-bl");
            WriteLiteral(@"ock""></i>
                </div>
                <div id=""icon-modificar-success"">
                    <i class=""ionicons ion-ios-checkmark-outline tx-100 tx-warning lh-1 mg-t-20 d-inline-block""></i>
                </div>

                <div>
                    <h4 class=""tx-warning"" tx-semibold mg-b-20"" id=""title-alerta-modificar"">Modificar clave</h4>
                    <h4 class=""tx-danger"" tx-semibold mg-b-20"" id=""title-alerta-problemas""></h4>
                </div>

                <div>
                    <p class=""mg-b-20 mg-x-20"" id=""body-alerta""></p>
                </div>

                <div id=""actions-alerta"">

                </div>
            </div><!-- modal-body -->
        </div><!-- modal-content -->
    </div><!-- modal-dialog -->
</div><!-- modal -->
    
    
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d78768f5f44821ce71afd27b6e14a0046a45f76812301", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d78768f5f44821ce71afd27b6e14a0046a45f76813401", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d78768f5f44821ce71afd27b6e14a0046a45f76814501", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d78768f5f44821ce71afd27b6e14a0046a45f76815601", async() => {
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
                WriteLiteral(@"
    <script>
        
        function mostrarClaveActual()
        {
            var cambio = document.getElementById(""claveActual"");
            if (cambio.type == ""password"")
            {
                cambio.type = ""text"";
                $('#iconoClave').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            }
            else
            {
                cambio.type = ""password"";
                $('#iconoClave').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
            }
        }

        function mostrarNuevaClave()
        {
            var cambio = document.getElementById(""nuevaClave"");
            if (cambio.type == ""password"")
            {
                cambio.type = ""text"";
                $('#iconoClave').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            }
            else
            {
                cambio.type = ""password"";
                $('#iconoClave').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
          ");
                WriteLiteral(@"  }
        }

        function mostrarConfirmarClave()
        {
            var cambio = document.getElementById(""confirmacionNuevaClave"");
            if (cambio.type == ""password"")
            {
                cambio.type = ""text"";
                $('#iconoClave').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            }
            else
            {
                cambio.type = ""password"";
                $('#iconoClave').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
            }
        }
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