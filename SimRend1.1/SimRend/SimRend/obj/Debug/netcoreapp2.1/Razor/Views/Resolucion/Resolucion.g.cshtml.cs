#pragma checksum "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1947ec1850db0f3189723babff8022750afeef3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resolucion_Resolucion), @"mvc.1.0.view", @"/Views/Resolucion/Resolucion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Resolucion/Resolucion.cshtml", typeof(AspNetCore.Views_Resolucion_Resolucion))]
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
#line 1 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend;

#line default
#line hidden
#line 2 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1947ec1850db0f3189723babff8022750afeef3e", @"/Views/Resolucion/Resolucion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Resolucion_Resolucion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimRend.Models.ModeloResolucion>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Número de resolución"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("min", new global::Microsoft.AspNetCore.Html.HtmlString("1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Año de la resolución"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("min", new global::Microsoft.AspNetCore.Html.HtmlString("2000"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("exampleInputFile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-describedby", new global::Microsoft.AspNetCore.Html.HtmlString("fileHelp"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
  
    ViewData["Title"] = "Agregar Resolución";

#line default
#line hidden
            BeginContext(96, 243, true);
            WriteLiteral("\r\n<h2>Resumen Solicitud</h2>\r\n\r\n<div class=\"contenedor_formulario\">\r\n    <div class=\"form\">\r\n        <div class=\"contenedor_input\">\r\n\r\n            <div class=\"control\">\r\n                <span><B>Nombre del evento: </B></span>\r\n                ");
            EndContext();
            BeginContext(340, 54, false);
#line 15 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
           Write(Html.DisplayFor(model => model.Solicitud.NombreEvento));

#line default
#line hidden
            EndContext();
            BeginContext(394, 131, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"control\">\r\n                <span><B>Lugar del evento: </B></span>\r\n                ");
            EndContext();
            BeginContext(526, 53, false);
#line 20 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
           Write(Html.DisplayFor(model => model.Solicitud.LugarEvento));

#line default
#line hidden
            EndContext();
            BeginContext(579, 140, true);
            WriteLiteral("\r\n\r\n            </div>\r\n\r\n            <div class=\"control\">\r\n                <span><B>Fecha inicio del evento: </B></span>\r\n                ");
            EndContext();
            BeginContext(720, 59, false);
#line 26 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
           Write(Html.DisplayFor(model => model.Solicitud.FechaInicioEvento));

#line default
#line hidden
            EndContext();
            BeginContext(779, 139, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"control\">\r\n                <span><B>Fecha término del evento: </B></span>\r\n                ");
            EndContext();
            BeginContext(919, 60, false);
#line 31 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
           Write(Html.DisplayFor(model => model.Solicitud.FechaTerminoEvento));

#line default
#line hidden
            EndContext();
            BeginContext(979, 123, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"control\">\r\n                <span><B>Monto($): </B></span>\r\n                ");
            EndContext();
            BeginContext(1103, 47, false);
#line 36 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
           Write(Html.DisplayFor(model => model.Solicitud.Monto));

#line default
#line hidden
            EndContext();
            BeginContext(1150, 126, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"control\">\r\n                <span><B>Responsable: </B></span>\r\n                ");
            EndContext();
            BeginContext(1277, 59, false);
#line 41 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
           Write(Html.DisplayFor(model => model.Solicitud.NombreResponsable));

#line default
#line hidden
            EndContext();
            BeginContext(1336, 118, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <h2>Información general de la Resolución</h2>\r\n");
            EndContext();
#line 49 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
     using (Html.BeginForm("AgregarResolucion", "Resolucion", FormMethod.Post, new { @style = "border:none" }))
    {

#line default
#line hidden
            BeginContext(1574, 243, true);
            WriteLiteral("    <div class=\"contenedor_formulario\">\r\n        <div class=\"form\">\r\n            \r\n            <div class=\"contenedor_input\">\r\n\r\n                <div class=\"control\">\r\n                    <span>Número de resolución</span>\r\n                    ");
            EndContext();
            BeginContext(1817, 99, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3696587cfd3f4d18b8ad4ca440ac9caf", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 58 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Resolucion.NumeroResolucion);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1916, 142, true);
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"control\">\r\n                    <span>Año de la resolución</span>\r\n                    ");
            EndContext();
            BeginContext(2058, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5bd6565bd9d34e49bf073434e6790fc7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 63 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Resolucion.AnioResolucion);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2158, 141, true);
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"control\">\r\n                    <span>Copia del documento</span>\r\n                    ");
            EndContext();
            BeginContext(2299, 114, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8d32566434624c3b9201f05ccdcb3182", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 68 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Resolucion.CopiaDocumento);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2413, 283, true);
            WriteLiteral(@"
                </div>
            </div>  
        </div>
    </div>
    <div class=""wrapperOrientacionBotonFormulario"">
        <div class=""wrapper wrapperBotonFormulario"">
            <button class=""buttonPrimary"" type=""submit"" name="""">Agregar</button>
        </div>

");
            EndContext();
#line 78 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
         using (Html.BeginForm("IrPrincipal", "Resolucion", FormMethod.Get, new { @style = "border:none" }))
        {

#line default
#line hidden
            BeginContext(2817, 167, true);
            WriteLiteral("            <div class=\"wrapper wrapperBotonFormulario\">\r\n                <button class=\"buttonSecundary\" type=\"submit\" name=\"\">Cancelar</button>\r\n            </div>\r\n");
            EndContext();
#line 83 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
        }

#line default
#line hidden
            BeginContext(2995, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 85 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Resolucion\Resolucion.cshtml"
    }

#line default
#line hidden
            BeginContext(3014, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimRend.Models.ModeloResolucion> Html { get; private set; }
    }
}
#pragma warning restore 1591
