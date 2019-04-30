#pragma checksum "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0570b699030ff1a7b9cfa80677beda891b566d2"
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
#line 1 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend;

#line default
#line hidden
#line 1 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
using SimRend.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0570b699030ff1a7b9cfa80677beda891b566d2", @"/Views/Solicitud/GeneratePDF.cshtml")]
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
#line 4 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
  
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19f749446ed74e7ead22f027d200a478", async() => {
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
#line 45 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                      Write(Html.DisplayFor(model => model.Solicitud.FechaPdf));

#line default
#line hidden
            EndContext();
            BeginContext(1458, 38, true);
            WriteLiteral("</P></div>\r\n\r\n    <DIV ALIGN=\"left\">\r\n");
            EndContext();
#line 48 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.CAA != null)
        {
            

#line default
#line hidden
#line 50 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
             if (Model.CAA.SexoDirCarrera.Equals("Femenino"))
            {

#line default
#line hidden
            BeginContext(1618, 51, true);
            WriteLiteral("                <P style=\"line-height:1px\"><B>Sra. ");
            EndContext();
            BeginContext(1670, 49, false);
#line 52 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                              Write(Html.DisplayFor(model => model.CAA.NomDirCarrera));

#line default
#line hidden
            EndContext();
            BeginContext(1719, 10, true);
            WriteLiteral("</B></P>\r\n");
            EndContext();
#line 53 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1777, 51, true);
            WriteLiteral("                <P style=\"line-height:3px\"><B> Sr. ");
            EndContext();
            BeginContext(1829, 49, false);
#line 56 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                              Write(Html.DisplayFor(model => model.CAA.NomDirCarrera));

#line default
#line hidden
            EndContext();
            BeginContext(1878, 11, true);
            WriteLiteral(" </B></P>\r\n");
            EndContext();
#line 57 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
            }

#line default
#line hidden
            BeginContext(1906, 42, true);
            WriteLiteral("            <P style=\"line-height:3px\"><I>");
            EndContext();
            BeginContext(1949, 41, false);
#line 59 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.CAA.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(1990, 52, true);
            WriteLiteral("</I></P>\r\n            <P style=\"line-height:3px\"><I>");
            EndContext();
            BeginContext(2043, 43, false);
#line 60 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(2086, 10, true);
            WriteLiteral("</I></P>\r\n");
            EndContext();
#line 61 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2132, 42, true);
            WriteLiteral("            <P style=\"line-height:3px\"><B>");
            EndContext();
            BeginContext(2175, 53, false);
#line 64 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.Federacion.NomDirDAAE));

#line default
#line hidden
            EndContext();
            BeginContext(2228, 52, true);
            WriteLiteral("</B></P>\r\n            <P style=\"line-height:3px\"><I>");
            EndContext();
            BeginContext(2281, 48, false);
#line 65 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                     Write(Html.DisplayFor(model => model.Federacion.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(2329, 10, true);
            WriteLiteral("</I></P>\r\n");
            EndContext();
#line 66 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(2350, 254, true);
            WriteLiteral("\r\n        <P style=\"line-height:1px\"><I>Universidad de Talca</I></P>\r\n        <P style=\"line-height:1px\"><B><U>Presente.</U></B></P>\r\n    </DIV>\r\n\r\n    <DIV style=\"text-align:justify\">\r\n        <P>\r\n            De nuestra consideración:\r\n        </P>\r\n\r\n");
            EndContext();
#line 77 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Organizacion.Tipo.Equals("CAA"))
        {

#line default
#line hidden
            BeginContext(2668, 88, true);
            WriteLiteral("            <P>\r\n                Junto con saludar cordialmente, me dirijo a usted como ");
            EndContext();
            BeginContext(2757, 49, false);
#line 80 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                  Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(2806, 44, true);
            WriteLiteral(" del\r\n                centro de alumnos de  ");
            EndContext();
            BeginContext(2851, 43, false);
#line 81 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                 Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(2894, 149, true);
            WriteLiteral(", para solicitarle apoyo económico con el fin de realizar\r\n                la actividad estudiantil que se indica a continuación:\r\n            </P>\r\n");
            EndContext();
#line 84 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(3079, 88, true);
            WriteLiteral("            <P>\r\n                Junto con saludar cordialmente, me dirijo a usted como ");
            EndContext();
            BeginContext(3168, 49, false);
#line 88 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                  Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(3217, 21, true);
            WriteLiteral(" de\r\n                ");
            EndContext();
            BeginContext(3239, 59, false);
#line 89 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.Federacion.NombreFederacion));

#line default
#line hidden
            EndContext();
            BeginContext(3298, 149, true);
            WriteLiteral(", para solicitarle apoyo económico con el fin de realizar\r\n                la actividad estudiantil que se indica a continuación:\r\n            </P>\r\n");
            EndContext();
#line 92 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(3458, 74, true);
            WriteLiteral("\r\n        \r\n        <ul>\r\n            <li><B>Nombre de la actividad:</B>  ");
            EndContext();
            BeginContext(3533, 54, false);
#line 96 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                           Write(Html.DisplayFor(model => model.Solicitud.NombreEvento));

#line default
#line hidden
            EndContext();
            BeginContext(3587, 40, true);
            WriteLiteral(".</li>\r\n            <li><B>Periodo:</B> ");
            EndContext();
            BeginContext(3628, 53, false);
#line 97 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                           Write(Html.DisplayFor(model => model.Solicitud.FechaEvento));

#line default
#line hidden
            EndContext();
            BeginContext(3681, 42, true);
            WriteLiteral(".</li>\r\n            <li><B>Ubicación:</B> ");
            EndContext();
            BeginContext(3724, 53, false);
#line 98 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                             Write(Html.DisplayFor(model => model.Solicitud.LugarEvento));

#line default
#line hidden
            EndContext();
            BeginContext(3777, 25, true);
            WriteLiteral(".</li>\r\n        </ul>\r\n\r\n");
            EndContext();
#line 101 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Participantes != null)
        {

#line default
#line hidden
            BeginContext(3856, 98, true);
            WriteLiteral("            <P>\r\n                Para llevar a cabo esta actividad se solicita un monto total de $");
            EndContext();
            BeginContext(3955, 47, false);
#line 104 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                            Write(Html.DisplayFor(model => model.Solicitud.Monto));

#line default
#line hidden
            EndContext();
            BeginContext(4002, 72, true);
            WriteLiteral(" sujeto a rendición y así poder otorgar una ayuda\r\n                de  $");
            EndContext();
            BeginContext(4075, 57, false);
#line 105 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                Write(Html.DisplayFor(model => model.Solicitud.MontoPorPersona));

#line default
#line hidden
            EndContext();
            BeginContext(4132, 78, true);
            WriteLiteral(" a cada estudiante para solventar parcialmente sus gastos de\r\n                ");
            EndContext();
            BeginContext(4211, 54, false);
#line 106 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.CategoriasConcatenadas));

#line default
#line hidden
            EndContext();
            BeginContext(4265, 21, true);
            WriteLiteral(".\r\n            </P>\r\n");
            EndContext();
            BeginContext(4288, 70, true);
            WriteLiteral("            <P>Los alumnos que participarán en la actividad son:</P>\r\n");
            EndContext();
            BeginContext(4360, 296, true);
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
#line 119 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                     foreach (var item in Model.Participantes)
                    {

#line default
#line hidden
            BeginContext(4743, 82, true);
            WriteLiteral("                        <tr class=\"table-light\">\r\n                            <td>");
            EndContext();
            BeginContext(4826, 41, false);
#line 122 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(4867, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4907, 38, false);
#line 123 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Run));

#line default
#line hidden
            EndContext();
            BeginContext(4945, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 125 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                    }

#line default
#line hidden
            BeginContext(5006, 50, true);
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n");
            EndContext();
#line 129 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5092, 64, true);
            WriteLiteral("            <P>\r\n                Se solicita un monto total de $");
            EndContext();
            BeginContext(5157, 47, false);
#line 133 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                          Write(Html.DisplayFor(model => model.Solicitud.Monto));

#line default
#line hidden
            EndContext();
            BeginContext(5204, 79, true);
            WriteLiteral(" sujeto a rendición para solventar parcialmente los gastos de\r\n                ");
            EndContext();
            BeginContext(5284, 54, false);
#line 134 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.CategoriasConcatenadas));

#line default
#line hidden
            EndContext();
            BeginContext(5338, 20, true);
            WriteLiteral("\r\n            </P>\r\n");
            EndContext();
#line 136 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(5369, 45, true);
            WriteLiteral("\r\n    </DIV>\r\n\r\n    <DIV ALIGN=\"justify\">\r\n\r\n");
            EndContext();
#line 142 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Organizacion.Tipo.Equals("CAA"))
        {

#line default
#line hidden
            BeginContext(5478, 72, true);
            WriteLiteral("        <P>\r\n            Dicho monto quedará bajo la responsabilidad de ");
            EndContext();
            BeginContext(5551, 50, false);
#line 145 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                      Write(Html.DisplayFor(model => model.Responsable.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(5601, 19, true);
            WriteLiteral(",\r\n            RUT ");
            EndContext();
            BeginContext(5621, 47, false);
#line 146 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.Responsable.Run));

#line default
#line hidden
            EndContext();
            BeginContext(5668, 12, true);
            WriteLiteral(", matrícula ");
            EndContext();
            BeginContext(5681, 53, false);
#line 146 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Responsable.Matricula));

#line default
#line hidden
            EndContext();
            BeginContext(5734, 32, true);
            WriteLiteral(",\r\n            en su calidad de ");
            EndContext();
            BeginContext(5767, 49, false);
#line 147 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                        Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(5816, 26, true);
            WriteLiteral(" del Centro de Alumnos de ");
            EndContext();
            BeginContext(5843, 43, false);
#line 147 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                                                    Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(5886, 57, true);
            WriteLiteral(" de la\r\n            Universidad de Talca.\r\n        </P>\r\n");
            EndContext();
#line 150 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5979, 72, true);
            WriteLiteral("        <P>\r\n            Dicho monto quedará bajo la responsabilidad de ");
            EndContext();
            BeginContext(6052, 50, false);
#line 154 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                      Write(Html.DisplayFor(model => model.Responsable.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(6102, 19, true);
            WriteLiteral(",\r\n            RUT ");
            EndContext();
            BeginContext(6122, 47, false);
#line 155 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
           Write(Html.DisplayFor(model => model.Responsable.Run));

#line default
#line hidden
            EndContext();
            BeginContext(6169, 12, true);
            WriteLiteral(", matrícula ");
            EndContext();
            BeginContext(6182, 53, false);
#line 155 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                       Write(Html.DisplayFor(model => model.Responsable.Matricula));

#line default
#line hidden
            EndContext();
            BeginContext(6235, 33, true);
            WriteLiteral(",\r\n            en su calidad de  ");
            EndContext();
            BeginContext(6269, 49, false);
#line 156 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                         Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(6318, 4, true);
            WriteLiteral(" de ");
            EndContext();
            BeginContext(6323, 59, false);
#line 156 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                                                               Write(Html.DisplayFor(model => model.Federacion.NombreFederacion));

#line default
#line hidden
            EndContext();
            BeginContext(6382, 57, true);
            WriteLiteral(" de la\r\n            Universidad de Talca.\r\n        </P>\r\n");
            EndContext();
#line 159 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(6450, 249, true);
            WriteLiteral("\r\n        <P>\r\n            Esperando una buena acogida y una pronta respuesta de esta solicitud, se despide atentamente de usted.\r\n        </P>\r\n    </DIV>\r\n\r\n    <DIV ALIGN=\"center\" style=\"padding-top:80px;\">\r\n        <P style=\"line-height:3px\"><B>");
            EndContext();
            BeginContext(6700, 50, false);
#line 167 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                 Write(Html.DisplayFor(model => model.Responsable.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(6750, 46, true);
            WriteLiteral("</B></P>\r\n        <P style=\"line-height:3px\"> ");
            EndContext();
            BeginContext(6797, 49, false);
#line 168 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                               Write(Html.DisplayFor(model => model.Responsable.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(6846, 6, true);
            WriteLiteral("</P>\r\n");
            EndContext();
#line 169 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         if (Model.Organizacion.Tipo.Equals("CAA"))
        {

#line default
#line hidden
            BeginContext(6916, 43, true);
            WriteLiteral("            <P style=\"line-height:3px\">CAA ");
            EndContext();
            BeginContext(6960, 43, false);
#line 171 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                      Write(Html.DisplayFor(model => model.CAA.Carrera));

#line default
#line hidden
            EndContext();
            BeginContext(7003, 6, true);
            WriteLiteral("</P>\r\n");
            EndContext();
#line 172 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(7045, 39, true);
            WriteLiteral("            <P style=\"line-height:3px\">");
            EndContext();
            BeginContext(7085, 59, false);
#line 175 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
                                  Write(Html.DisplayFor(model => model.Federacion.NombreFederacion));

#line default
#line hidden
            EndContext();
            BeginContext(7144, 6, true);
            WriteLiteral("</P>\r\n");
            EndContext();
#line 176 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(7161, 245, true);
            WriteLiteral("        <P style=\"line-height:3px\">Universidad de Talca</P>\r\n    </DIV>\r\n\r\n</div>\r\n\r\n    <div style=\"padding-top:50px\">\r\n\r\n    <div class=\"form-inline my-2 my-lg-0\">\r\n        <button class=\"btn btn-success my-2 my-sm-0\" style=\"margin-right:15px\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 7406, "\"", 7471, 3);
            WriteAttributeValue("", 7416, "location.href=\'", 7416, 15, true);
#line 185 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
WriteAttributeValue("", 7431, Url.Action("DescargarPDF","Solicitud"), 7431, 39, false);

#line default
#line hidden
            WriteAttributeValue("", 7470, "\'", 7470, 1, true);
            EndWriteAttribute();
            BeginContext(7472, 27, true);
            WriteLiteral(">Generar PDF</button>\r\n\r\n\r\n");
            EndContext();
#line 188 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
         using (Html.BeginForm("VolverIndex", "Solicitud", FormMethod.Get, new { @style = "border:none" }))
        {

#line default
#line hidden
            BeginContext(7619, 91, true);
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-success my-2 my-sm-0\">Finalizar</button>\r\n");
            EndContext();
#line 191 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\GeneratePDF.cshtml"
        }

#line default
#line hidden
            BeginContext(7721, 50, true);
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
