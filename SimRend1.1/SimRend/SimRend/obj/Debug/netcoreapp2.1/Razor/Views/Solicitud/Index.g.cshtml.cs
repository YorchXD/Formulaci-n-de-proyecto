#pragma checksum "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05486a19a4708d795b997edc932a6f9152eebd7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Solicitud_Index), @"mvc.1.0.view", @"/Views/Solicitud/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Solicitud/Index.cshtml", typeof(AspNetCore.Views_Solicitud_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05486a19a4708d795b997edc932a6f9152eebd7f", @"/Views/Solicitud/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Solicitud_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SimRend.Models.Solicitud>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-1.10.19.dataTables.js.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
  
    ViewData["Title"] = "Busqueda";

#line default
#line hidden
            BeginContext(92, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(112, 292, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#tablaBusqueda').DataTable({ ""lengthChange"": false});
        });
    </script>

    <script src=""https://code.jquery.com/jquery-3.3.1.js"" type=""text/javascript"" charset=""utf-8""></script>
    ");
                EndContext();
                BeginContext(404, 99, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7aaf2b6d1ed4424d9ed20897d2bf8f35", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
                BeginContext(503, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(510, 937, true);
            WriteLiteral(@"
<h2>Búsqueda de Solicitudes</h2>

<div class=""datagrid"">
    <table id=""tablaBusqueda"" class=""table table-striped table-bordered table-sm "" cellspacing=""0"" width=""100%"">
        <thead>
            <tr>
                <th>
                    Fecha de solicitud
                </th>
                <th>
                    Monto($)
                </th>
                <th>
                    Nombre del evento
                </th>
                <th>
                    Fecha de inicio del evento
                </th>
                <th>
                    Fecha de término del evento
                </th>
                <th>
                    Lugar del evento
                </th>
                <th>
                    Responsable
                </th>
                <th>
                    Ver Solicitud
                </th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 52 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#line 54 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1560, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1645, 46, false);
#line 58 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FechaActual));

#line default
#line hidden
            EndContext();
            BeginContext(1691, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1783, 40, false);
#line 61 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Monto));

#line default
#line hidden
            EndContext();
            BeginContext(1823, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1915, 47, false);
#line 64 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NombreEvento));

#line default
#line hidden
            EndContext();
            BeginContext(1962, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2054, 52, false);
#line 67 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FechaInicioEvento));

#line default
#line hidden
            EndContext();
            BeginContext(2106, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2198, 53, false);
#line 70 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FechaTerminoEvento));

#line default
#line hidden
            EndContext();
            BeginContext(2251, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2343, 46, false);
#line 73 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.LugarEvento));

#line default
#line hidden
            EndContext();
            BeginContext(2389, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2481, 46, false);
#line 76 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Responsable));

#line default
#line hidden
            EndContext();
            BeginContext(2527, 65, true);
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n");
            EndContext();
#line 80 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                             using (Html.BeginForm("IrResumen", "Solicitud", FormMethod.Post, new { @style = "border:none" }))
                            {

#line default
#line hidden
            BeginContext(2751, 114, true);
            WriteLiteral("                                <input type=\"hidden\" readonly=\"\" class=\"form-control-plaintext\" name=\"IdSolicitud\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2865, "\"", 2881, 1);
#line 82 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 2873, item.Id, 2873, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2882, 192, true);
            WriteLiteral(">\r\n                                <div class=\"wrapper\">\r\n                                    <button class=\"buttonPrimary\" type=\"submit\">Ver</button>\r\n                                </div>\r\n");
            EndContext();
#line 86 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"

                            }

#line default
#line hidden
            BeginContext(3107, 58, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 90 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                }

#line default
#line hidden
#line 90 "D:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Index.cshtml"
                 

            }

#line default
#line hidden
            BeginContext(3201, 48, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SimRend.Models.Solicitud>> Html { get; private set; }
    }
}
#pragma warning restore 1591
