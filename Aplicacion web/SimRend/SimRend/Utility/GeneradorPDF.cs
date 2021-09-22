using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Utility
{
    public class GeneradorPDF
    {
        private IConverter _converter;
        public GeneradorPDF(IConverter converter)
        {
            _converter = converter;
        }
        public byte[] PDF(Proceso proceso, String tipoPDF)
        {
            String html, titulo;
            if(tipoPDF.Equals("Solicitud"))
            {
                html = TemplatePDF.SolicitudPdf(proceso);
                titulo = "PDF Solicitud";
            }
            else
            {
                html = TemplatePDF.DeclaracionGastosPdf(proceso);
                titulo = "PDF Declaración de Gastos";
            }

            //var convertidor = new SynchronizedConverter(new PdfTools());
            //var convertidor = new BasicConverter(new PdfTools());
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.Letter,

                /*ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },*/
                DocumentTitle = titulo
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = @"" + html,
                //HtmlContent = TemplatePDF.SolicitudPdf(proceso),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "estiloPDF.css") },
                //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return _converter.Convert(pdf);
        }
    }
}
