#pragma checksum "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1f9529bfa88986de7adfe7c2792428c87041426"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Solicitud_GeneratePDF), @"mvc.1.0.view", @"/Views/Solicitud/GeneratePDF.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Solicitud/GeneratePDF.cshtml", typeof(AspNetCore.Views_Solicitud_GeneratePDF))]
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
#line 1 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend;

#line default
#line hidden
#line 1 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
using SimRend.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1f9529bfa88986de7adfe7c2792428c87041426", @"/Views/Solicitud/GeneratePDF.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Solicitud_GeneratePDF : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimRend.Models.ModeloSolicitud>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jspdf.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
  
    ViewData["Title"] = "Crear Solicitud";

#line default
#line hidden
            BeginContext(115, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(135, 327, true);
                WriteLiteral(@"
    <!-- Scripts down here -->
   
    <!--script src=""http://html2canvas.hertzen.com/build/html2canvas.js""></script-->

    <!-- Code editor -->

    <script src=""https://cdnjs.cloudflare.com/ajax/libs/ace/1.2.5/ace.js"" type=""text/javascript"" charset=""utf-8""></script>

    <!-- Scripts in development mode -->
    ");
                EndContext();
                BeginContext(462, 41, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e2f80af26244e1daa7bf3b4feb49012", async() => {
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
                EndContext();
                BeginContext(503, 733, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        function DescargarPDF() {
            var doc = new jsPDF();
            // We'll make our own renderer to skip this editor
            var specialElementHandlers = {
                '#editor': function (element, renderer) {
                    return true;

                }
            };

            // All units are in the set measurement for the document
            // This can be changed to ""pt"" (points), ""mm"" (Default), ""cm"", ""in""
            doc.fromHTML($('#Solicitud').get(0), 15, 15, {
                'width': 170,
                'elementHandlers': specialElementHandlers
            });
            doc.save(""sample.pdf"");
        }

    </script>
");
                EndContext();
            }
            );
            BeginContext(1239, 168, true);
            WriteLiteral("\r\n<div id=\"Solicitud\">\r\n    <!--DIV ALIGN=\"center\"><img src=~/images/GenerarPDF/logoUtalca.png width=\"120\" height=\"120\" border=0></DIV-->\r\n\r\n    <div ALIGN=\"right\"><P> ");
            EndContext();
            BeginContext(1408, 50, false);
#line 45 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                      Write(Html.DisplayFor(model => model.Solicitud.FechaPdf));

#line default
#line hidden
            EndContext();
            BeginContext(1458, 38, true);
            WriteLiteral("</P></div>\r\n\r\n    <DIV ALIGN=\"left\">\r\n");
            EndContext();
#line 48 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.CAA != null)
        {
            

#line default
#line hidden
#line 50 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
             if (Model.CAA.SexoDirCarrera.Equals("Femenino"))
            {

#line default
#line hidden
            BeginContext(1618, 51, true);
            WriteLiteral("                <P style=\"line-height:1px\"><B>Sra. ");
            EndContext();
            BeginContext(1670, 49, false);
#line 52 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                              Write(Html.DisplayFor(model => model.CAA.NomDirCarrera));

#line default
#line hidden
            EndContext();
            BeginContext(1719, 10, true);
            WriteLiteral("</B></P>\r\n");
            EndContext();
#line 53 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1777, 51, true);
            WriteLiteral("                <P style=\"line-height:3px\"><B> Sr. ");
            EndContext();
            BeginContext(1829, 49, false);
#line 56 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                              Write(Html.DisplayFor(model => model.CAA.NomDirCarrera));

#line default
#line hidden
            EndContext();
            BeginContext(1878, 11, true);
            WriteLiteral(" </B></P>\r\n");
            EndContext();
#line 57 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
            }

#line default
#line hidden
            BeginContext(1906, 42, true);
            WriteLiteral("            <P style=\"line-height:3px\"><I>");
            EndContext();
            BeginContext(1949, 41, false);
#line 59 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.CAA.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(1990, 52, true);
            WriteLiteral("</I></P>\r\n            <P style=\"line-height:3px\"><I>");
            EndContext();
            BeginContext(2043, 43, false);
#line 60 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(2086, 10, true);
            WriteLiteral("</I></P>\r\n");
            EndContext();
#line 61 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2132, 42, true);
            WriteLiteral("            <P style=\"line-height:3px\"><B>");
            EndContext();
            BeginContext(2175, 53, false);
#line 64 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.Federacion.NomDirDAAE));

#line default
#line hidden
            EndContext();
            BeginContext(2228, 52, true);
            WriteLiteral("</B></P>\r\n            <P style=\"line-height:3px\"><I>");
            EndContext();
            BeginContext(2281, 48, false);
#line 65 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.Federacion.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(2329, 10, true);
            WriteLiteral("</I></P>\r\n");
            EndContext();
#line 66 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(2350, 254, true);
            WriteLiteral("\r\n        <P style=\"line-height:1px\"><I>Universidad de Talca</I></P>\r\n        <P style=\"line-height:1px\"><B><U>Presente.</U></B></P>\r\n    </DIV>\r\n\r\n    <DIV style=\"text-align:justify\">\r\n        <P>\r\n            De nuestra consideración:\r\n        </P>\r\n\r\n");
            EndContext();
#line 77 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Organizacion.Tipo.Equals("CAA"))
        {

#line default
#line hidden
            BeginContext(2668, 88, true);
            WriteLiteral("            <P>\r\n                Junto con saludar cordialmente, me dirijo a usted como ");
            EndContext();
            BeginContext(2757, 49, false);
#line 80 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                  Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(2806, 43, true);
            WriteLiteral(" del\r\n                centro de alumnos de ");
            EndContext();
            BeginContext(2850, 43, false);
#line 81 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(2893, 149, true);
            WriteLiteral(", para solicitarle apoyo económico con el fin de realizar\r\n                la actividad estudiantil que se indica a continuación:\r\n            </P>\r\n");
            EndContext();
#line 84 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(3078, 88, true);
            WriteLiteral("            <P>\r\n                Junto con saludar cordialmente, me dirijo a usted como ");
            EndContext();
            BeginContext(3167, 49, false);
#line 88 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                  Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(3216, 21, true);
            WriteLiteral(" de\r\n                ");
            EndContext();
            BeginContext(3238, 59, false);
#line 89 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.Federacion.NombreFederacion));

#line default
#line hidden
            EndContext();
            BeginContext(3297, 149, true);
            WriteLiteral(", para solicitarle apoyo económico con el fin de realizar\r\n                la actividad estudiantil que se indica a continuación:\r\n            </P>\r\n");
            EndContext();
#line 92 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(3457, 74, true);
            WriteLiteral("\r\n        \r\n        <ul>\r\n            <li><B>Nombre de la actividad:</B>  ");
            EndContext();
            BeginContext(3532, 54, false);
#line 96 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                           Write(Html.DisplayFor(model => model.Solicitud.NombreEvento));

#line default
#line hidden
            EndContext();
            BeginContext(3586, 40, true);
            WriteLiteral(".</li>\r\n            <li><B>Periodo:</B> ");
            EndContext();
            BeginContext(3627, 53, false);
#line 97 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                           Write(Html.DisplayFor(model => model.Solicitud.FechaEvento));

#line default
#line hidden
            EndContext();
            BeginContext(3680, 42, true);
            WriteLiteral(".</li>\r\n            <li><B>Ubicación:</B> ");
            EndContext();
            BeginContext(3723, 53, false);
#line 98 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                             Write(Html.DisplayFor(model => model.Solicitud.LugarEvento));

#line default
#line hidden
            EndContext();
            BeginContext(3776, 25, true);
            WriteLiteral(".</li>\r\n        </ul>\r\n\r\n");
            EndContext();
#line 101 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Participantes != null)
        {

#line default
#line hidden
            BeginContext(3855, 98, true);
            WriteLiteral("            <P>\r\n                Para llevar a cabo esta actividad se solicita un monto total de $");
            EndContext();
            BeginContext(3954, 47, false);
#line 104 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                            Write(Html.DisplayFor(model => model.Solicitud.Monto));

#line default
#line hidden
            EndContext();
            BeginContext(4001, 72, true);
            WriteLiteral(" sujeto a rendición y así poder otorgar una ayuda\r\n                de  $");
            EndContext();
            BeginContext(4074, 57, false);
#line 105 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                Write(Html.DisplayFor(model => model.Solicitud.MontoPorPersona));

#line default
#line hidden
            EndContext();
            BeginContext(4131, 78, true);
            WriteLiteral(" a cada estudiante para solventar parcialmente sus gastos de\r\n                ");
            EndContext();
            BeginContext(4210, 54, false);
#line 106 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.CategoriasConcatenadas));

#line default
#line hidden
            EndContext();
            BeginContext(4264, 21, true);
            WriteLiteral(".\r\n            </P>\r\n");
            EndContext();
            BeginContext(4287, 70, true);
            WriteLiteral("            <P>Los alumnos que participarán en la actividad son:</P>\r\n");
            EndContext();
            BeginContext(4359, 296, true);
            WriteLiteral(@"            <table class=""table"">
                <thead class=""table-dark"">
                    <tr>
                        <th scope=""col"">Nombre</th>
                        <th scope=""col"">Run/Matrícula</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 119 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                     foreach (var item in Model.Participantes)
                    {

#line default
#line hidden
            BeginContext(4742, 82, true);
            WriteLiteral("                        <tr class=\"table-light\">\r\n                            <td>");
            EndContext();
            BeginContext(4825, 41, false);
#line 122 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(4866, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4906, 38, false);
#line 123 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Run));

#line default
#line hidden
            EndContext();
            BeginContext(4944, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 125 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                    }

#line default
#line hidden
            BeginContext(5005, 50, true);
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n");
            EndContext();
#line 129 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5091, 64, true);
            WriteLiteral("            <P>\r\n                Se solicita un monto total de $");
            EndContext();
            BeginContext(5156, 47, false);
#line 133 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                          Write(Html.DisplayFor(model => model.Solicitud.Monto));

#line default
#line hidden
            EndContext();
            BeginContext(5203, 79, true);
            WriteLiteral(" sujeto a rendición para solventar parcialmente los gastos de\r\n                ");
            EndContext();
            BeginContext(5283, 54, false);
#line 134 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.CategoriasConcatenadas));

#line default
#line hidden
            EndContext();
            BeginContext(5337, 20, true);
            WriteLiteral("\r\n            </P>\r\n");
            EndContext();
#line 136 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(5368, 45, true);
            WriteLiteral("\r\n    </DIV>\r\n\r\n    <DIV ALIGN=\"justify\">\r\n\r\n");
            EndContext();
#line 142 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Organizacion.Tipo.Equals("CAA"))
        {

#line default
#line hidden
            BeginContext(5477, 72, true);
            WriteLiteral("        <P>\r\n            Dicho monto quedará bajo la responsabilidad de ");
            EndContext();
            BeginContext(5550, 50, false);
#line 145 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                      Write(Html.DisplayFor(model => model.Responsable.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(5600, 19, true);
            WriteLiteral(",\r\n            RUT ");
            EndContext();
            BeginContext(5620, 47, false);
#line 146 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.Responsable.Run));

#line default
#line hidden
            EndContext();
            BeginContext(5667, 12, true);
            WriteLiteral(", matrícula ");
            EndContext();
            BeginContext(5680, 53, false);
#line 146 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Responsable.Matricula));

#line default
#line hidden
            EndContext();
            BeginContext(5733, 32, true);
            WriteLiteral(",\r\n            en su calidad de ");
            EndContext();
            BeginContext(5766, 49, false);
#line 147 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                        Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(5815, 26, true);
            WriteLiteral(" del Centro de Alumnos de ");
            EndContext();
            BeginContext(5842, 43, false);
#line 147 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                                                    Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(5885, 57, true);
            WriteLiteral(" de la\r\n            Universidad de Talca.\r\n        </P>\r\n");
            EndContext();
#line 150 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5978, 72, true);
            WriteLiteral("        <P>\r\n            Dicho monto quedará bajo la responsabilidad de ");
            EndContext();
            BeginContext(6051, 50, false);
#line 154 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                      Write(Html.DisplayFor(model => model.Responsable.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(6101, 19, true);
            WriteLiteral(",\r\n            RUT ");
            EndContext();
            BeginContext(6121, 47, false);
#line 155 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.Responsable.Run));

#line default
#line hidden
            EndContext();
            BeginContext(6168, 12, true);
            WriteLiteral(", matrícula ");
            EndContext();
            BeginContext(6181, 53, false);
#line 155 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Responsable.Matricula));

#line default
#line hidden
            EndContext();
            BeginContext(6234, 33, true);
            WriteLiteral(",\r\n            en su calidad de  ");
            EndContext();
            BeginContext(6268, 49, false);
#line 156 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                         Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(6317, 4, true);
            WriteLiteral(" de ");
            EndContext();
            BeginContext(6322, 59, false);
#line 156 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                               Write(Html.DisplayFor(model => model.Federacion.NombreFederacion));

#line default
#line hidden
            EndContext();
            BeginContext(6381, 57, true);
            WriteLiteral(" de la\r\n            Universidad de Talca.\r\n        </P>\r\n");
            EndContext();
#line 159 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(6449, 249, true);
            WriteLiteral("\r\n        <P>\r\n            Esperando una buena acogida y una pronta respuesta de esta solicitud, se despide atentamente de usted.\r\n        </P>\r\n    </DIV>\r\n\r\n    <DIV ALIGN=\"center\" style=\"padding-top:80px;\">\r\n        <P style=\"line-height:3px\"><B>");
            EndContext();
            BeginContext(6699, 50, false);
#line 167 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                 Write(Html.DisplayFor(model => model.Responsable.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(6749, 46, true);
            WriteLiteral("</B></P>\r\n        <P style=\"line-height:3px\"> ");
            EndContext();
            BeginContext(6796, 49, false);
#line 168 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                               Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(6845, 6, true);
            WriteLiteral("</P>\r\n");
            EndContext();
#line 169 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Organizacion.Tipo.Equals("CAA"))
        {

#line default
#line hidden
            BeginContext(6915, 43, true);
            WriteLiteral("            <P style=\"line-height:3px\">CAA ");
            EndContext();
            BeginContext(6959, 43, false);
#line 171 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                      Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(7002, 6, true);
            WriteLiteral("</P>\r\n");
            EndContext();
#line 172 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(7044, 39, true);
            WriteLiteral("            <P style=\"line-height:3px\">");
            EndContext();
            BeginContext(7084, 59, false);
#line 175 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                  Write(Html.DisplayFor(model => model.Federacion.NombreFederacion));

#line default
#line hidden
            EndContext();
            BeginContext(7143, 6, true);
            WriteLiteral("</P>\r\n");
            EndContext();
#line 176 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(7160, 294, true);
            WriteLiteral(@"        <P style=""line-height:3px"">Universidad de Talca</P>
    </DIV>

</div>

    <div style=""padding-top:50px"">

    <div class=""form-inline my-2 my-lg-0"">
        <button class=""btn btn-success my-2 my-sm-0"" style=""margin-right:15px"" onclick=""DescargarPDF();"">Generar PDF</button>
");
            EndContext();
#line 186 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         using (Html.BeginForm("VolverIndex", "Solicitud", FormMethod.Get, new { @style = "border:none" }))
        {

#line default
#line hidden
            BeginContext(7574, 91, true);
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-success my-2 my-sm-0\">Finalizar</button>\r\n");
            EndContext();
#line 189 "C:\Users\Liemind\Documents\Universidad de Talca\OtraMalditaPrueba\Yorchwea\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(7676, 50, true);
            WriteLiteral("    </div>\r\n        \r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimRend.Models.ModeloSolicitud> Html { get; private set; }
    }
}
#pragma warning restore 1591
