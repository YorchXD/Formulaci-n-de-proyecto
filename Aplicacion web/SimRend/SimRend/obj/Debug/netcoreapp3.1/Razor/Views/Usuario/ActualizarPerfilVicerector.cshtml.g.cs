#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\ActualizarPerfilVicerector.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4341b57d67167b004000176b40926104c478c34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_ActualizarPerfilVicerector), @"mvc.1.0.view", @"/Views/Usuario/ActualizarPerfilVicerector.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4341b57d67167b004000176b40926104c478c34", @"/Views/Usuario/ActualizarPerfilVicerector.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_ActualizarPerfilVicerector : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Femenino", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Masculino", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/parsley.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/parsleyjs/i18n/es.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.numeric.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Usuario.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\ActualizarPerfilVicerector.cshtml"
  
    ViewData["Title"] = "Actualizar perfil usuario vicerector";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""br-pagetitle row"">
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <div class=""input-group-text wd-auto"" style=""border:none;"">
                <i class=""icon ion-person-stalker""></i>
                <h4 style=""padding-left:5%"">Actualizar perfil usuario vicerector</h4>
            </div>
        </div>
    </div>
</div><!-- d-flex -->


<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">
        <div class=""form-layout"">

            <input name=""id"" class=""form-control"" id=""id"" type=""hidden"">
            <div class=""row mg-b-25"">
                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Nombre:</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-map-marked-alt tx-20 lh-0 op-6 fa-fw""></i>
 ");
            WriteLiteral("                           </div>\r\n                        </div>\r\n                        <input name=\"nombre\" required=\"required\" class=\"form-control\" id=\"nombre\" type=\"text\" placeholder=\"Ingrese el nombre del usuario vicerector\"");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 1327, "\"", 1340, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorNombre"">
                    </div>
                    <div id=""errorNombre""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Email: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-at tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input autocomplete=""off"" name=""email"" required=""required"" class=""form-control"" id=""email"" type=""email"" placeholder=""Ingrese el email del usuario vicerector""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 2138, "\"", 2151, 0);
            EndWriteAttribute();
            WriteLiteral(" data-parsley-errors-container=\"#errorEmail\" readonly>\r\n                    </div>\r\n                    <div id=\"errorEmail\"></div>\r\n                </div>\r\n\r\n");
            WriteLiteral(@"
                <div class=""form-group wd-auto col-lg-12 col-md-12"">
                    <label class=""form-control-label"">Sexo: </label>
                    <div class=""input-group parsley-select"" id=""sexoMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-venus-mars tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <select name=""sexo"" class=""form-control required"" data-placeholder=""Seleccione el sexo del usuario vicerector"" id=""sexo""
                                data-parsley-class-handler=""#campusMarco"" data-parsley-errors-container=""#errorSexo"" required>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4341b57d67167b004000176b40926104c478c349204", async() => {
                WriteLiteral("Seleccione el sexo del usuario vicerector");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4341b57d67167b004000176b40926104c478c3410847", async() => {
                WriteLiteral("Femenino");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4341b57d67167b004000176b40926104c478c3412037", async() => {
                WriteLiteral("Masculino");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                    </div>
                    <div id=""errorSexo""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Cargo:</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-user-tag tx-20 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""cargo"" required=""required"" class=""form-control"" id=""cargo"" type=""text"" placeholder=""Ingrese el cargo del usuario vicerector""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 5254, "\"", 5267, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorCargo"">
                    </div>
                    <div id=""errorCargo""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Fono anexo:</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-phone tx-20 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""fonoAnexo"" required=""required"" class=""form-control"" id=""fonoAnexo"" type=""text"" placeholder=""Ingrese el fono anexo del usuario vicerector""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 6063, "\"", 6076, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorFonoAnexo"">
                    </div>
                    <div id=""errorFonoAnexo""></div>
                </div>
            </div>
            <div class=""form-layout-footer"">
                <div class=""row"" id=""acciones"">
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""btn btn-secondary"" id=""cancelar"" style=""width:100%"" onclick=""volverProcesosVicerector()"">
                            <i class=""fas fa-window-close""></i> Cancelar
                        </button>
                    </div>
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""modal-effect btn btn-warning tx-transform-none"" id=""modificar"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""modificarUsuarioVicerector()"">
                            <i class=""fas fa-pen-square""></i> Modificar
                        </button>
                    </div>

       ");
            WriteLiteral(@"         </div>
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
                    <i class=""icon ion-ios-plus-outline tx-100 tx-warning lh-1 mg-t-20 d-inline-block""></i>
                </div>
                <div id=""icon-modificar-success"">
                    <i class=""ionicons ion-ios-checkmark-outline tx-100 tx-warning lh-1 mg-t-20 d-inline-block""></i>
                </div>

                <div>
                    <h4 c");
            WriteLiteral(@"lass=""tx-warning"" tx-semibold mg-b-20"" id=""title-alerta-modificar"">Modificar usuario vicerector</h4>
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4341b57d67167b004000176b40926104c478c3417969", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4341b57d67167b004000176b40926104c478c3419069", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4341b57d67167b004000176b40926104c478c3420169", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4341b57d67167b004000176b40926104c478c3421269", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        
        $(document).ready(function ()
        {
            obtenerVicerector();
        });
        function mostrarClave()
        {
            var cambio = document.getElementById(""clave"");
            if (cambio.type == ""password"")
            {
                cambio.type = ""text"";
                $('#iconoClave').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            } else
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