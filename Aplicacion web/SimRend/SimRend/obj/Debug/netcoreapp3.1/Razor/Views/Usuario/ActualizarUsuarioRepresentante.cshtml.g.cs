#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\ActualizarUsuarioRepresentante.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd89e1446bb486789a14fd396bab088a3b309d2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_ActualizarUsuarioRepresentante), @"mvc.1.0.view", @"/Views/Usuario/ActualizarUsuarioRepresentante.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd89e1446bb486789a14fd396bab088a3b309d2b", @"/Views/Usuario/ActualizarUsuarioRepresentante.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_ActualizarUsuarioRepresentante : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\ActualizarUsuarioRepresentante.cshtml"
  
    ViewData["Title"] = "Actualizar usuario representante";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""br-pagetitle row"">
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <div class=""input-group-text wd-auto"" style=""border:none;"">
                <i class=""icon ion-person-stalker""></i>
                <h4 style=""padding-left:5%"">Crear usuario representante</h4>
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
            WriteLiteral("                </div>\r\n                        </div>\r\n                        <input name=\"nombre\" required=\"required\" class=\"form-control\" id=\"nombre\" type=\"text\" placeholder=\"Ingrese el nombre del usuario representante\"");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 1315, "\"", 1328, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorNombre"">
                    </div>
                    <div id=""errorNombre""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">RUN:</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fa fa-id-card tx-20 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""run"" required=""required"" class=""form-control"" id=""run"" type=""text"" placeholder=""Ingrese el RUN del usuario representante""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 2104, "\"", 2117, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorRUN"" oninput=""checkRun(this)"">
                    </div>
                    <div id=""errorRUN""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Matrícula:</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fa fa-id-card tx-20 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input name=""matricula"" required=""required"" class=""form-control"" id=""matricula"" type=""text"" placeholder=""Ingrese la matricula del usuario representante""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 2936, "\"", 2949, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorMatricula"">
                    </div>
                    <div id=""errorMatricula""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Email: </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-at tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input autocomplete=""off"" name=""email"" required=""required"" class=""form-control"" id=""email"" type=""email"" placeholder=""Ingrese el email del usuario representante""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 3756, "\"", 3769, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorEmail"">
                    </div>
                    <div id=""errorEmail""></div>
                </div>

                <div class=""form-group wd-auto col-sm-12 col-lg-6"">
                    <label class=""form-control-label"">Clave (Modifique este campo solo si reseteará): </label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-key tx-16 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <input autocomplete=""new-password"" name=""clave"" required=""required"" class=""form-control"" id=""clave"" type=""password"" placeholder=""Ingrese la clave del usuario representante""");
            BeginWriteAttribute("onkeypress", " onkeypress=\"", 4622, "\"", 4635, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-parsley-errors-container=""#errorClave"">
                        <div class=""input-group-append"">
                            <button type=""button"" id=""verClave"" class=""btn btn-info btn-flat"" onclick=""mostrarClave()""><span id=""iconoClave"" class=""fa fa-eye-slash icon""></span></button>
                        </div>
                    </div>
                    <div id=""errorClave""></div>
                </div>

                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Sexo: </label>
                    <div class=""input-group parsley-select"" id=""sexoMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-venus-mars tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <select name=""sexo"" class=""form-control required"" data-placeholder=""Sel");
            WriteLiteral("eccione el sexo del usuario representante\" id=\"sexo\"\r\n                                data-parsley-class-handler=\"#campusMarco\" data-parsley-errors-container=\"#errorSexo\" required>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b12494", async() => {
                WriteLiteral("Seleccione el sexo del usuario representante");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b14141", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b15331", async() => {
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

                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Rol: </label>
                    <div class=""input-group parsley-select"" id=""rolMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-user-tag tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <select name=""rol"" class=""form-control required"" data-placeholder=""Seleccione el rol del usuario representante"" id=""rol""
                                data-parsley-class-handler=""#rolMarco"" data-parsley-errors-container=""#errorRol"" required disabled>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b17462", async() => {
                WriteLiteral("Seleccione el rol del usuario representante");
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
            WriteLiteral(@"
                        </select>
                    </div>
                    <div id=""errorRol""></div>
                </div>


                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Campus: </label>
                    <div class=""input-group parsley-select"" id=""campusMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-map-marked-alt tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <select name=""campus"" class=""form-control required"" data-placeholder=""Seleccione el campus al que pertenece el usuario representate"" id=""campus""
                                data-parsley-class-handler=""#campusMarco"" data-parsley-errors-container=""#errorCampus"" required disabled>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b20091", async() => {
                WriteLiteral("Seleccione el campus al que pertenece el usuario representante");
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
            WriteLiteral(@"
                        </select>
                    </div>
                    <div id=""errorCampus""></div>
                </div>

                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Organización estudiantil: </label>
                    <div class=""input-group parsley-select"" id=""oeMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fab fa-hubspot tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <select name=""oe"" class=""form-control required"" data-placeholder=""Seleccione la O.E. a la que pertenece el usuario representante"" id=""oe""
                                data-parsley-class-handler=""#oeMarco"" data-parsley-errors-container=""#errorOE"" required disabled>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b22732", async() => {
                WriteLiteral("Seleccione la O.E. a la que pertenece el usuario representante");
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
            WriteLiteral(@"

                        </select>
                    </div>
                    <div id=""errorOE""></div>
                </div>

                <div class=""form-group wd-auto col-lg-6 col-md-12"">
                    <label class=""form-control-label"">Institución: </label>
                    <div class=""input-group parsley-select"" id=""institucionMarco"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text wd-xs-45"">
                                <i class=""fas fa-university tx-22 lh-0 op-6 fa-fw""></i>
                            </div>
                        </div>
                        <select name=""institucion"" class=""form-control required"" data-placeholder=""Seleccione la institución a la que pertenece el usuario representante"" id=""institucion""
                                data-parsley-class-handler=""#institucionMarco"" data-parsley-errors-container=""#errorInstitucion"" required disabled>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b25413", async() => {
                WriteLiteral("Seleccione la institución a la que pertenece el usuario representante");
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
            WriteLiteral(@"
                        </select>
                    </div>
                    <div id=""errorInstitucion""></div>
                </div>
            </div>
            <div class=""form-layout-footer"">
                <div class=""row"" id=""acciones"">
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""btn btn-secondary"" id=""guardar"" style=""width:100%"" onclick=""volverRepresentantes()"">
                            <i class=""fas fa-window-close""></i> Cancelar
                        </button>
                    </div>
                    <div class=""form-group  col-lg-6 col-md-6 col-sm-12"">
                        <button class=""modal-effect btn btn-info tx-transform-none"" id=""guardar"" data-effect=""effect-just-me"" style=""width:100%"" onclick=""modificarUsuarioRepresentante()"">
                            <i class=""fas fa-save""></i> Guardar
                        </button>
                    </div>

                </div>
          ");
            WriteLiteral(@"  </div>
        </div>
    </div><!-- br-section-wrapper -->
</div><!-- br-pagebody -->
<!-- MODAL ELIMINAR PROCESO -->
<div id=""modal-alert"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
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
                    <h4 class=""tx-warning"" tx-semibold ");
            WriteLiteral(@"mg-b-20"" id=""title-alerta-modificar"">Modificar usuario representante</h4>
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b29865", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b30965", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b32065", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd89e1446bb486789a14fd396bab088a3b309d2b33165", async() => {
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
            mainActualizar();
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
