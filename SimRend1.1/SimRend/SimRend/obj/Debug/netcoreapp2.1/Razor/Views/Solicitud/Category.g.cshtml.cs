#pragma checksum "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43ac1137db85a706ae084362a99efe3ecf9c691b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Solicitud_Category), @"mvc.1.0.view", @"/Views/Solicitud/Category.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Solicitud/Category.cshtml", typeof(AspNetCore.Views_Solicitud_Category))]
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
#line 1 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend;

#line default
#line hidden
#line 2 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43ac1137db85a706ae084362a99efe3ecf9c691b", @"/Views/Solicitud/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Solicitud_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SimRend.Models.Categoria>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-3.3.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.steps.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
  
    ViewData["Title"] = "Crear Solicitud";

#line default
#line hidden
            BeginContext(99, 372, true);
            WriteLiteral(@"
<div class=""form-inline"" style=""padding-top: calc(0.5em + 6px);"">
    <h3 class=""mr-auto my-2 my-lg-0"">
        Categoría de los gastos del evento
        <!-- Button trigger modal -->
        <!--button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#modalAgregarCategoria"">
            Agregar Categoria
        </button-->
    </h3>

");
            EndContext();
#line 16 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
     using (Html.BeginForm("AgregarCategoria", "Solicitud", FormMethod.Post, new { @style = "border:none" }))
    {

#line default
#line hidden
            BeginContext(589, 162, true);
            WriteLiteral("        <div class=\"form-inline mr-auto my-2 my-lg-0\">\r\n            <select class=\"form-control mr-sm-2\" for=\"seleccionCategoria\" name=\"Nombre\">\r\n                ");
            EndContext();
            BeginContext(751, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e7c9c07e09341fc988e289e8f71dd77", async() => {
                BeginContext(786, 24, true);
                WriteLiteral("Selecciona una categoria");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(819, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 21 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(886, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(906, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebfe0c619a554c85a8afb03376a36635", async() => {
                BeginContext(936, 11, false);
#line 23 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                                            Write(item.Nombre);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 23 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                       WriteLiteral(item.Nombre);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(956, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 24 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                }

#line default
#line hidden
            BeginContext(977, 128, true);
            WriteLiteral("            </select>\r\n            <button type=\"submit\" class=\"btn btn-primary my-2 my-sm-0\">Agregar</button>\r\n        </div>\r\n");
            EndContext();
#line 28 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"

    }

#line default
#line hidden
            BeginContext(1114, 20, true);
            WriteLiteral("</div>\r\n\r\n<hr />\r\n\r\n");
            EndContext();
#line 34 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
 if (ViewData["Seleccionadas"] != null)
{
    

#line default
#line hidden
#line 36 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
     foreach (var item in ViewData["Seleccionadas"] as List<Categoria>)
    {
        

#line default
#line hidden
#line 38 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
         using (Html.BeginForm("EliminarCategoria", "Solicitud", FormMethod.Post, new { @style = "border:none" }))
        {

#line default
#line hidden
            BeginContext(1385, 403, true);
            WriteLiteral(@"            <div class=""container"">
                <div class=""row"">
                    <div class="" mx-auto col-md-8"">
                        <div class=""card"">
                            <div class=""card-body d-flex justify-content-between align-items-center"" for=""eliminarCategoria"">
                                <input type=""text"" readonly="""" class=""form-control-plaintext"" name=""Nombre""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1788, "\"", 1808, 1);
#line 45 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
WriteAttributeValue("", 1796, item.Nombre, 1796, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1809, 247, true);
            WriteLiteral(">\r\n                                <button type=\"submit\" class=\"btn btn-warning btn-sm\">Eliminar</button>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 52 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
        }

#line default
#line hidden
#line 52 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
         

    }

#line default
#line hidden
#line 54 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
     
}

#line default
#line hidden
            BeginContext(2079, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 57 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
 using (Html.BeginForm("Person", "Solicitud", FormMethod.Get, new { @style = "border:none" }))
{

#line default
#line hidden
            BeginContext(2180, 307, true);
            WriteLiteral(@"    <div class ="" container"" style=""padding-top: calc(0.5em + 6px); text-align:right;"">
        <div class=""row"">
            <div class="" mx-auto col-md-8"">
                  <button type=""submit"" class=""btn btn-success  my-2 my-sm-0"">Siguiente</button>
            </div>
        </div>
    </div>
");
            EndContext();
#line 66 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
}

#line default
#line hidden
            BeginContext(2490, 10, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2518, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 73 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(2588, 290, true);
                WriteLiteral(@"
    <!--#########################################Para crear solicitud#################################-->
    <!-- MATERIAL DESIGN ICONIC FONT -->
    <!--link rel=""stylesheet"" href=""fonts/material-design-iconic-font/css/material-design-iconic-font.css""-->
    <!-- STYLE CSS -->
    ");
                EndContext();
                BeginContext(2878, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "04d1c63e18064107ac85e26de2a00b4d", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
                BeginContext(2924, 182, true);
                WriteLiteral("\r\n    <!--#################################################################################################-->\r\n    <!--#############Para crear una solicitud################-->\r\n    ");
                EndContext();
                BeginContext(3106, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8561203b9c3342ae9d96fbb018dbbbb0", async() => {
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
                EndContext();
                BeginContext(3154, 32, true);
                WriteLiteral("\r\n    <!-- JQUERY STEP -->\r\n    ");
                EndContext();
                BeginContext(3186, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7074ebebce234656bb2c911379b50f92", async() => {
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
                EndContext();
                BeginContext(3230, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3236, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3093e5e8e0224d5cbe7e71ca27d16b1b", async() => {
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
                EndContext();
                BeginContext(3272, 72, true);
                WriteLiteral("\r\n    <!--#####################################################-->\r\n    ");
                EndContext();
                BeginContext(3344, 41, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72d09a88b5fb4a54b0ae1b215e358e94", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3385, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(3392, 1481, true);
            WriteLiteral(@"
<!-- Modal -->
<!--div class=""modal fade"" id=""modalAgregarCategoria"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modalAgregarCategoria"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Seleccione la categoría que desea agregar</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>

            <div class=""modal-body"">
                using (Html.BeginForm(""AgregarCategoria"", ""Solicitud"", FormMethod.Post, new { style = ""border:none"" }))
                {
                    <div class=""form-row"">
                        <select class=""form-control"" for=""seleccionCategoria"" name=""Nombre"">
                            foreach (var item in Model)
{
                                <option value=""item.Nombre"">item.Nombr");
            WriteLiteral(@"e</option>
                            }
                        </select>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
                        <button type=""submit"" class=""btn btn-primary"">Aceptar</button>
                    </div>
                }
            </div>
        </div>
    </div>
</div-->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SimRend.Models.Categoria>> Html { get; private set; }
    }
}
#pragma warning restore 1591
