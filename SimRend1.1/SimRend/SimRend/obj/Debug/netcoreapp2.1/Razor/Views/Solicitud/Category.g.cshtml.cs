#pragma checksum "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b62bbb8934ae29cd2c61151ecbf6eaba440b9de"
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
#line 1 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend;

#line default
#line hidden
#line 2 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\_ViewImports.cshtml"
using SimRend.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b62bbb8934ae29cd2c61151ecbf6eaba440b9de", @"/Views/Solicitud/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Solicitud_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SimRend.Models.Categoria>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
  
    ViewData["Title"] = "Crear Solicitud";

#line default
#line hidden
            BeginContext(99, 402, true);
            WriteLiteral(@"
    <div class=""form-inline"" style=""padding-top: calc(0.5em + 6px);"">
        <h2>Categoría de los gastos del evento</h2>

        <div class=""wrapper toggle"">
            <a href=""#popup"" ><button class=""buttonPrimary""  name="""">Agregar Categorías</button></a>
        </div>
    </div>


    <!--Contenido-->
    <div class=""contenedor_formulario"">
        <div class=""fieldsContainer"">
");
            EndContext();
#line 19 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
             if (ViewData["Seleccionadas"] != null)
            {
                

#line default
#line hidden
#line 21 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                 foreach (var item in ViewData["Seleccionadas"] as List<Categoria>)
                {
                    

#line default
#line hidden
#line 23 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                     using (Html.BeginForm("EliminarCategoria", "Solicitud", FormMethod.Post, new { @style = "border:none" }))
                    {

#line default
#line hidden
            BeginContext(824, 353, true);
            WriteLiteral(@"                        <div class=""cards"">
                            <div class="""" for=""eliminarCategoria"">
                                <div class=""cards"">
                                    <div class=""card"">
                                        <input type=""text"" readonly="""" class="""" style=""border:none; margin-top: 5px;"" name=""Nombre""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1177, "\"", 1197, 1);
#line 29 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
WriteAttributeValue("", 1185, item.Nombre, 1185, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1198, 585, true);
            WriteLiteral(@">
                                    </div>
                                    
                                    <div class=""card"">
                                        <div class=""wrapper"">
                                            <button type= ""submit"" class=""buttonDelete""   name="""">Eliminar</button>
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                            
                        </div>
");
            EndContext();
#line 42 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                    }

#line default
#line hidden
#line 42 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                     
                }

#line default
#line hidden
#line 43 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(1840, 30, true);
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
            EndContext();
#line 48 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
     using (Html.BeginForm("IrPersona", "Solicitud", FormMethod.Get, new { @style = "border:none" }))
    {

#line default
#line hidden
            BeginContext(1980, 323, true);
            WriteLiteral(@"        <div class ="" container"" style=""padding-top: calc(0.5em + 6px); text-align:right;"">
            <div class=""row"">
                <div class=""wrapper toggle"">
                    <button type=""submit"" class=""buttonPrimary""  name="""">Siguiente</button>
                </div>
            </div>
        </div>
");
            EndContext();
#line 57 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
    }

#line default
#line hidden
            BeginContext(2310, 286, true);
            WriteLiteral(@"    <!--Fin Contenido-->




    <!-- Modal -->
    <div class=""modal-wrapper"" id=""popup"">
        <div class=""popup-contenedor"">
            <div class=""bar-title"">
                <span>Agregar categoría</span>
            </div>
        <!--h2>Agregar categoría</h2-->

");
            EndContext();
#line 71 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
             using (Html.BeginForm("AgregarCategoria", "Solicitud", FormMethod.Post, new { @style = "border:none" }))
            {

#line default
#line hidden
            BeginContext(2730, 321, true);
            WriteLiteral(@"                <div class=""popup-contenido"">
                    <div class=""control"">
                        <span style=""margin-left:5%; margin-rigth:5%;"">Seleccione la categoría que desea agregar</span>
                        <select class="""" for=""seleccionCategoria"" name=""Nombre"">
                            ");
            EndContext();
            BeginContext(3051, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8913b41371d543bdab8261b6cb56eb33", async() => {
                BeginContext(3086, 24, true);
                WriteLiteral("Selecciona una categoría");
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
            BeginContext(3119, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 78 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(3218, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(3254, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb0419b9cfd247d0a635a14f79c750b2", async() => {
                BeginContext(3284, 11, false);
#line 80 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                                                            Write(item.Nombre);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 80 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
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
            BeginContext(3304, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 81 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
                                }

#line default
#line hidden
            BeginContext(3341, 87, true);
            WriteLiteral("                        </select>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
            BeginContext(3430, 610, true);
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
#line 96 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
            }

#line default
#line hidden
            BeginContext(4055, 95, true);
            WriteLiteral("            <!--a class=\"popup-cerrar\" href=\"#\">X</a-->\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4176, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 106 "d:\Repositorios\Formulación de proyecto\SimRend1.1\SimRend\SimRend\Views\Solicitud\Category.cshtml"
              await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(4254, 940, true);
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
            BeginContext(5197, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
