#pragma checksum "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46f37e2799a505b24979ea647803c250eee1f704"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Solicitud_Person), @"mvc.1.0.view", @"/Views/Solicitud/Person.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Solicitud/Person.cshtml", typeof(AspNetCore.Views_Solicitud_Person))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46f37e2799a505b24979ea647803c250eee1f704", @"/Views/Solicitud/Person.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Solicitud_Person : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimRend.Models.Persona>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control mr-sm-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Nombre de la persona"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Run de la persona"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
  
    ViewData["Title"] = "Crear Solicitud";

#line default
#line hidden
            BeginContext(84, 377, true);
            WriteLiteral(@"
<div class=""form-inline"" style=""padding-top: calc(0.5em + 6px);"">
    <h2>Personas que participan en el evento</h2>

    <div class=""wrapper toggle"">
        <a href=""#popup"" ><button class=""buttonPrimary""  name="""">Agregar Persona</button></a>
    </div>
</div>




<!--Contenido-->
    <div class=""contenedor_formulario"">
        <div class=""fieldsContainer"">
");
            EndContext();
#line 21 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
             if (ViewData["Personas"] != null)
            {
                

#line default
#line hidden
#line 23 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
                 foreach (var item in ViewData["Personas"] as List<Persona>)
                {
                    

#line default
#line hidden
#line 25 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
                     using (Html.BeginForm("EliminarPersona", "Solicitud", FormMethod.Post, new { @style = "border:none" }))
                    {
                        

#line default
#line hidden
            BeginContext(796, 308, true);
            WriteLiteral(@"                            <div class="""" for=""eliminarPersona"">
                                <div class=""cards1"">
                                    <div class=""card1"">
                                        <input type=""text"" readonly="""" class="""" style=""border:none; margin-top: 5px;"" name=""Nombre""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1104, "\"", 1124, 1);
#line 31 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
WriteAttributeValue("", 1112, item.Nombre, 1112, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1125, 237, true);
            WriteLiteral(">\r\n                                    </div>\r\n\r\n                                    <div class=\"card1\">\r\n                                        <input type=\"text\" readonly=\"\" class=\"\" style=\"border:none; margin-top: 5px;\" name=\"Nombre\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1362, "\"", 1379, 1);
#line 35 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
WriteAttributeValue("", 1370, item.Run, 1370, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1380, 524, true);
            WriteLiteral(@">
                                    </div>
                                    
                                    <div class=""card1"">
                                        <div class=""wrapper"">
                                            <button type= ""submit"" class=""buttonDelete""   name="""">Eliminar</button>
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
");
            EndContext();
#line 46 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
                            
                    }

#line default
#line hidden
#line 47 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
                     
                }

#line default
#line hidden
#line 48 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(1991, 30, true);
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
            EndContext();
#line 53 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
     using (Html.BeginForm("Resume", "Solicitud", FormMethod.Get, new { @style = "border:none" }))
    {

#line default
#line hidden
            BeginContext(2128, 320, true);
            WriteLiteral(@"        <div class ="" container"" style=""padding-top: calc(0.5em + 6px); text-align:right;"">
            <div class=""row"">
                <div class=""wrapper toggle"">
                    <button type=""submit"" class=""buttonPrimary"">Crear Solicitud</button>
                </div>
            </div>
        </div>
");
            EndContext();
#line 62 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
    }

#line default
#line hidden
            BeginContext(2455, 296, true);
            WriteLiteral(@"    <!--Fin Contenido-->












<!-- Modal -->
    <div class=""modal-wrapper"" id=""popup"">
        <div class=""popup-contenedor"">
            <div class=""bar-title"">
                <span>Agregar persona</span>
            </div>
        <!--h2>Agregar categoría</h2-->

");
            EndContext();
#line 84 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
             using (Html.BeginForm("AgregarPersona", "Solicitud", FormMethod.Post, new { @style = "border:none" }))
            {

#line default
#line hidden
            BeginContext(2883, 237, true);
            WriteLiteral("                <div class=\"popup-contenido\">\r\n                    <div class=\"contenedor_input\">\r\n                        <div class=\"control\">\r\n                            <span>Nombre de la persona</span>\r\n                            ");
            EndContext();
            BeginContext(3120, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d2ba37a47f674dfcaa5ad0a0a6a82a4d", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 90 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Nombre);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3210, 197, true);
            WriteLiteral("\r\n                        </div>\r\n                        \r\n\r\n                        <div class=\"control\">\r\n                            <span>RUT de la persona</span>\r\n                            ");
            EndContext();
            BeginContext(3407, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "75554a00815543f7b0ad82e562074b9f", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 96 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Run);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3491, 86, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
            BeginContext(3579, 610, true);
            WriteLiteral(@"                <div class=""popup-footer"">
                    <div class=""wrapperOrientacionBotonFormulario"">
                        <div class=""wrapper wrapperBotonFormulario toggle"">
                            <a href=""#""><button type=""button"" class=""buttonSecundary"" data-dismiss=""modal"">Cerrar</button></a>
                        </div>
                        <div class=""wrapper wrapperBotonFormulario toggle"">
                            <button type=""submit"" class=""buttonPrimary""  name="""">Agregar</button>
                        </div>
                    </div>
                </div>
");
            EndContext();
#line 111 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
            }

#line default
#line hidden
            BeginContext(4204, 115, true);
            WriteLiteral("            <!--a class=\"popup-cerrar\" href=\"#\">X</a-->\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4337, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 131 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Person.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(4407, 826, true);
                WriteLiteral(@"
    <!--#########################################Para crear solicitud#################################-->
    <!-- MATERIAL DESIGN ICONIC FONT -->
    <!--link rel=""stylesheet"" href=""fonts/material-design-iconic-font/css/material-design-iconic-font.css""-->
    <!-- STYLE CSS -->
    <!--link rel=""stylesheet"" href=""~/css/style.css""-->
    <!--#################################################################################################-->
    <!--#############Para crear una solicitud################-->
    <!--script src=""~/js/jquery-3.3.1.min.js""></script-->
    <!-- JQUERY STEP -->
    <!--script src=""~/js/jquery.steps.js""></script-->
    <!--script src=""~/js/main.js""></script-->
    <!--#####################################################-->
    <!--script src=""~/js/bootstrap.js""></script-->

");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimRend.Models.Persona> Html { get; private set; }
    }
}
#pragma warning restore 1591
