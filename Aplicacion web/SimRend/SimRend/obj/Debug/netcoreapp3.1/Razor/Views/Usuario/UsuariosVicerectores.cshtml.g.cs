#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\UsuariosVicerectores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b24b0b32ad09e82cf632d574936a507491dc7dd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_UsuariosVicerectores), @"mvc.1.0.view", @"/Views/Usuario/UsuariosVicerectores.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b24b0b32ad09e82cf632d574936a507491dc7dd7", @"/Views/Usuario/UsuariosVicerectores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_UsuariosVicerectores : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info pd-x-25 tx-11 tx-mont tx-semibold pd-y-12"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Usuario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CrearUsuarioVicerector", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Usuario\UsuariosVicerectores.cshtml"
  
    ViewData["Title"] = "Usuarios vicerectores";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""d-lg-flex justify-content-lg-between align-items-lg-center mg-l-30 mg-r-30"">
    <div style=""border:none;"" class=""row input-group-text"">
        <i class=""icon fa fa-clipboard-list tx-60""></i>
        <h4 class=""mg-t-15 mg-l-10"">Lista de vicerectores registrados</h4>
    </div>
    <div class=""mg-r-30 mg-md-r-0"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b24b0b32ad09e82cf632d574936a507491dc7dd75325", async() => {
                WriteLiteral("\r\n            <i class=\"icon fas fa-plus-square tx-11\"></i> Agregar Vicerector\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>


<div class=""br-pagebody"">
    <div class=""br-section-wrapper"">
        <div class=""dataTables_wrapper"">
            <table id=""tablaUsuarioVicerector"" class=""table display responsive nowrap"" style=""width:100%"">
                <thead class=""thead-colored thead-info"">
                    <tr>
                        <th data-priority=""1"">Id</th>
                        <th>Nombre</th>
                        <th>Sexo</th>
                        <th>Email</th>
                        <th>Institucion</th>
                        <th>Cargo</th>
                        <th>Fono anexo</th>
                        <th>Estado</th>
                        <th data-priority=""1"">Acciones</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <!-- MODAL ELIMINAR PROCESO -->
    <div id=""modal-alert"" class=""modal fade"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal-dialog modal-dialog-centered"" r");
            WriteLiteral(@"ole=""document"">
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


                    <div id=""icon-problema"">
                        <i class=""icon ion-ios-close-outline tx-100 tx-danger lh-1 mg-t-20 d-inline-block""></i>
                    </div>

                    <div>
                        <h4 class=""tx-danger"" tx-semibold mg-b-20"" id=""title-alerta-el");
            WriteLiteral(@"iminar"">Eliminar vicerector</h4>
                        <h4 class=""tx-danger"" tx-semibold mg-b-20"" id=""title-alerta-problemas""></h4>
                    </div>

                    <div>
                        <p class=""mg-b-20 mg-x-20"" id=""body-alerta""></p>
                    </div>

                    <div>
                        <input id=""idVicerector"" name=""idVicerector""");
            BeginWriteAttribute("value", " value=\"", 3061, "\"", 3069, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b24b0b32ad09e82cf632d574936a507491dc7dd79941", async() => {
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
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function ()\r\n        {\r\n            obtenerVicerectores()\r\n        });\r\n    </script>\r\n");
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
