#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Categoria\Categoria.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35fa906ba35b8745d6fbef45cfabf90ed6f2a1bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categoria_Categoria), @"mvc.1.0.view", @"/Views/Categoria/Categoria.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35fa906ba35b8745d6fbef45cfabf90ed6f2a1bb", @"/Views/Categoria/Categoria.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Categoria_Categoria : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formCategoria"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Categoria.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Categoria\Categoria.cshtml"
  
    ViewData["Title"] = "Categorias";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""d-lg-flex justify-content-lg-between align-items-lg-center mg-l-30 mg-r-30"">
    <div style=""border:none;"" class=""row input-group-text"">
        <i class=""icon fa fa-clipboard-list tx-60""></i>
        <h4 class=""mg-t-15 mg-l-10"">Lista de categorías registradas</h4>
    </div>
    <div class=""mg-r-30 mg-md-r-0"">
        <button class=""btn btn-info pd-x-25 tx-11 tx-mont tx-semibold pd-y-12"" onclick=""crearCategoria()"">
            <i class=""icon fas fa-plus-square tx-11""></i> Agregar categoría
        </button>
    </div>
</div>


<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">
        <div class=""dataTables_wrapper"">
            <table id=""tablaCategoria"" class=""table display responsive nowrap"" style=""width:100%"">
                <thead class=""thead-colored thead-info"">
                    <tr>
                        <th data-priority=""1"">Id</th>
                        <th>Nombre categoría</th>
                        <th data-priority=""1"">Acciones</th>
   ");
            WriteLiteral(@"                 </tr>
                </thead>
            </table>
        </div>
    </div>

    <!-- MODAL ELIMINAR PROCESO -->
    <div id=""modal-alert"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-size-sm"">
                <div class=""modal-body tx-center pd-y-20 pd-x-20"">
                    <div id=""icon-delete"">
                        <i class=""ionicons ion-ios-help-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    </div>
                    <div id=""icon-delete-confirm"">
                        <i class=""ionicons ion-ios-help-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    </div>
                    <div id=""icon-delete-success"">
                        <i class=""icon ion-ios-checkmark-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    </div>

                ");
            WriteLiteral(@"    <div id=""icon-set"">
                        <i class=""icon ion-compose tx-100 tx-warning lh-1 mg-t-20 d-inline-block""></i>
                        <!--i class=""far fa-edit tx-90 tx-warning lh-1 mg-t-20 d-inline-block""></i-->
                    </div>
                    <div id=""icon-set-confirm"">
                        <i class=""ionicons ion-ios-help-outline tx-100 tx-warning lh-1 mg-t-20 d-inline-block""></i>
                    </div>
                    <div id=""icon-set-success"">
                        <i class=""ionicons ion-ios-checkmark-outline tx-100 tx-warning lh-1 mg-t-20 d-inline-block""></i>
                    </div>

                    <div id=""icon-problema"">
                        <i class=""icon ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    </div>

                    <div id=""icon-create"">
                        <i class=""icon ion-ios-plus-outline tx-100 tx-info lh-1 mg-t-20 d-inline-block""></i>
                    </div>");
            WriteLiteral(@"
                    <div id=""icon-create-success"">
                        <i class=""ionicons ion-ios-checkmark-outline tx-100 tx-info lh-1 mg-t-20 d-inline-block""></i>
                    </div>

                    <div>
                        <h4 class=""tx-danger"" tx-semibold mg-b-20"" id=""title-alerta-eliminar"">Eliminar categoria</h4>
                        <h4 class=""tx-warning"" tx-semibold mg-b-20"" id=""title-alerta-editar"">Modificar categoría</h4>
                        <h4 class=""tx-info"" tx-semibold mg-b-20"" id=""title-alerta-crear"">Crear categoria</h4>
                        <h4 class=""tx-danger"" tx-semibold mg-b-20"" id=""title-alerta-problemas""></h4>
                    </div>

                    <div>
                        <p class=""mg-b-20 mg-x-20"" id=""body-alerta""></p>
                    </div>

                    <div>
                        <input id=""idCategoria"" name=""idCategoria""");
            BeginWriteAttribute("value", " value=\"", 4053, "\"", 4061, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35fa906ba35b8745d6fbef45cfabf90ed6f2a1bb8782", async() => {
                WriteLiteral(@"
                            <div class=""form-group wd-auto col-lg-12"">
                                <div class=""input-group"">
                                    <div class=""input-group-prepend"">
                                        <div class=""input-group-text wd-xs-45"">
                                            <i class=""fas fa-tag tx-16 lh-0 op-6 fa-fw""></i>
                                        </div>
                                    </div>
                                    <input name=""nombreCategoria"" class=""form-control"" id=""nombreCategoria"" required=""required"" type=""text"" placeholder=""Ingrese el nombre la categoria"" data-parsley-errors-container=""#errorNombreCategoria"">
                                </div>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-parsley-validate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>

                    <div id=""actions-alerta"">

                    </div>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35fa906ba35b8745d6fbef45cfabf90ed6f2a1bb11617", async() => {
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
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function ()\r\n        {\r\n            obtenerCategorias()\r\n        });\r\n    </script>\r\n\r\n");
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
