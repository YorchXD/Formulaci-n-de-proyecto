#pragma checksum "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d8192984af8258828128e1204ac623b612b8777"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error_OperacionNoAutorizada), @"mvc.1.0.view", @"/Views/Error/OperacionNoAutorizada.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d8192984af8258828128e1204ac623b612b8777", @"/Views/Error/OperacionNoAutorizada.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5333797a72fe5d91267e374330e9fe46b247725", @"/Views/_ViewImports.cshtml")]
    public class Views_Error_OperacionNoAutorizada : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
  
    ViewData["Title"] = "Operacion no autorizada";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Content Header (Page header) -->
<section class=""content-header"">
    <h1>
        Error, no tienes permiso
    </h1>
</section>
<!-- Main content -->
<section class=""content"">
    <div class=""error-page"">
        <h2 class=""headline text-red"">Error</h2>
        <div class=""error-content"">
            <h3><i class=""fa fa-warning text-red""></i>Sin autorización</h3>
");
#nullable restore
#line 17 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
             if (ViewBag.operacion != "")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Operación ");
#nullable restore
#line 19 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
                        Write(ViewBag.operacion);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 20 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
             if (ViewBag.modulo != "")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Modulo ");
#nullable restore
#line 23 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
                     Write(ViewBag.modulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 24 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
             if (ViewBag.msjeErrorExcepcion != "")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>");
#nullable restore
#line 27 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
              Write(ViewBag.msjeErrorExcepcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 28 "D:\Repositorios\Formulación de proyecto\Aplicacion web\SimRend\SimRend\Views\Error\OperacionNoAutorizada.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <!-- /.error-page -->\r\n</section>");
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
