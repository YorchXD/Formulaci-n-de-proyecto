using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SimRend.Utility
{
    public class TemplatePDF
    {
        public static string SolicitudPdf(Proceso proceso)
        {
            //ModeloSolicitud modelo = obtenerModelo();
            String pagina = "<!DOCTYPE html><html><head><title></title>";
            pagina += "</head><body> <div id='Solicitud'><DIV ALIGN='center'><img src='https://i.imgur.com/SS6BFCs.png' width='10%'  border=0></DIV><div ALIGN='right'><P> " + proceso.Solicitud.FechaPdf + "</P></div><DIV ALIGN='left'>";

            if (proceso.Organizacion != null)
            {
                if (proceso.Direccion.Sexo.Equals("Femenino"))
                {
                    pagina += "<P style='line-height:1px'><B>Sra. " + proceso.Direccion.Nombre + "</B></P>";
                }
                else
                {
                    pagina += "<P style='line-height:1px'><B>Sr. " + proceso.Direccion.Nombre + "</B></P>";
                }
                pagina += "<P style='line-height:3px'><I>" + proceso.Direccion.Cargo + "</I></P>";
                pagina += "<P style='line-height:3px'><I>" + proceso.Direccion.Institucion.Nombre + "</I></P>";
            }

            pagina += "<P style='line-height:1px'><I>Universidad de Talca</I></P><P style='line-height:1px'><B><U>Presente.</U></B></P></DIV><DIV style='text-align:justify'><P>De nuestra consideración:</P>";

            if (proceso.Organizacion.TipoOE.Nombre.Equals("CAA"))
            {
                pagina += "<P>Junto con saludar cordialmente, me dirijo a usted como " + proceso.Responsable.Rol.Nombre + " del centro de alumnos de  " + proceso.Responsable.Organizacion.Institucion.Nombre + ", para solicitarle apoyo económico con el fin de realizar la actividad estudiantil que se indica a continuación:</P>";
            }
            else
            {
                pagina += "<P>Junto con saludar cordialmente, me dirijo a usted como " + proceso.Responsable.Rol.Nombre + " de " + proceso.Organizacion.Nombre + ", para solicitarle apoyo económico con el fin de realizar la actividad estudiantil que se indica a continuación:</P>";
            }

            pagina += "<ul><li><B>Nombre de la actividad: </B>" + proceso.Solicitud.NombreEvento + ".</li>";
            pagina += "<li><B>Periodo: </B>" + proceso.Solicitud.FechaEvento + ".</li>";
            pagina += "<li><B>Ubicación: </B>" + proceso.Solicitud.LugarEvento + ".</li></ul>";

            NumberFormatInfo FormatoMoneda = new CultureInfo("arn-CL", false).NumberFormat;
            FormatoMoneda.CurrencyPositivePattern = 0;
            String monto = proceso.Solicitud.Monto.ToString("C0", FormatoMoneda);
            

            if (proceso.Solicitud.Participantes != null)
            {
                String montoPorPersona = proceso.Solicitud.MontoPorPersona.ToString("C0", FormatoMoneda);
                pagina += "<P>Para llevar a cabo esta actividad se solicita un monto total de " + monto + " sujeto a rendición y así poder otorgar una ayuda de ";
                pagina += montoPorPersona + " a cada estudiante para solventar parcialmente sus gastos de " + proceso.Solicitud.CategoriasConcatenadas + ".</P>";


                pagina += "<P>Los alumnos que participarán en la actividad son:</P>";

                pagina += "<table><thead><tr class='table100-head'><th>Nombre</th><th>Run</th></tr></thead>";
                pagina += "<tbody>";
                foreach (var item in proceso.Solicitud.Participantes)
                {
                    pagina += "<tr>";
                    pagina += "<td>" + item.Nombre + "</td>";
                    pagina += "<td>" + FormatearRut(item.RUN) + "</td>";
                    pagina += "</tr>";
                }
                pagina += "</tbody></table>";
            }
            else
            {
                
                pagina += "<P>Se solicita un monto total de " + monto + " sujeto a rendición para solventar parcialmente los gastos de " + proceso.Solicitud.CategoriasConcatenadas + ".</P>";
            }


            if (proceso.Organizacion.TipoOE.Nombre.Equals("CAA"))
            {
                pagina += "<P>Dicho monto quedará bajo la responsabilidad de " + proceso.Responsable.Nombre + ", RUT " + FormatearRut(proceso.Responsable.RUN);
                pagina += ", matrícula " + proceso.Responsable.Matricula + ", en su calidad de " + proceso.Responsable.Rol.Nombre;
                pagina += " del Centro de Alumnos de " + proceso.Responsable.Organizacion.Institucion.Nombre + " de la Universidad de Talca. </P>";
            }
            else
            {
                pagina += "<P>Dicho monto quedará bajo la responsabilidad de " + proceso.Responsable.Nombre + ", RUT " + FormatearRut(proceso.Responsable.RUN);
                pagina += ", matrícula " + proceso.Responsable.Matricula + ", en su calidad de  " + proceso.Responsable.Rol.Nombre + " de ";
                pagina += proceso.Organizacion.Nombre + " de la Universidad de Talca.</P>";
            }

            pagina += "<P>Esperando una buena acogida y una pronta respuesta de esta solicitud, se despide atentamente de usted.</P>";
            pagina += "<DIV ALIGN='center' style='padding-top:80px;'><P style='line-height:3px'><B>" + proceso.Responsable.Nombre + "</B></P>";
            pagina += "<P style='line-height:3px'>" + proceso.Responsable.Rol.Nombre + "</P>";

            if (proceso.Responsable.Organizacion.TipoOE.Nombre.Equals("CAA"))
            {
                pagina += "<P style='line-height:3px'>CAA " + proceso.Responsable.Organizacion.Institucion.Nombre + "</P>";
            }
            else
            {
                pagina += "<P style='line-height:3px'>" + proceso.Organizacion.Nombre + "</P>";
            }

            pagina += "<P style='line-height:3px'>Universidad de Talca</P></DIV></body></html> ";

            return pagina;
        }

        // rutina que formatea con separadores de miles y agrega el guion
        public static string FormatearRut(string rut)
        {
            string rutFormateado;
            if (rut.Length == 0)
            {
                rutFormateado = "";
            }
            else
            {
                string rutTemporal;
                string dv;
                Int64 rutNumerico;

                rut = rut.Replace("-", "").Replace(".", "");

                if (rut.Length == 1)
                {
                    rutFormateado = rut;
                }
                else
                {
                    rutTemporal = rut.Substring(0, rut.Length - 1);
                    dv = rut.Substring(rut.Length - 1, 1);

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rutNumerico))
                    {
                        rutNumerico = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    rutFormateado = rutNumerico.ToString("N0");

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }
                }
            }
            return rutFormateado;
        }

        public static string DeclaracionGastosPdf(Proceso proceso)
        {
            NumberFormatInfo FormatoMoneda = new CultureInfo("arn-CL", false).NumberFormat;
            FormatoMoneda.CurrencyPositivePattern = 0;

            //ModeloSolicitud modelo = obtenerModelo();
            String pagina = "<!DOCTYPE html><html><head><title></title></head>";
            pagina += "<div ALIGN='center'><img src='https://i.imgur.com/SS6BFCs.png' width='10%'  BORDER = 0></div>";
            pagina += "<h3 ALIGN='center'>Declaración de gastos</h3>";

            
            String montoSolicitud = proceso.Solicitud.Monto.ToString("C0", FormatoMoneda);
            String montoDG = proceso.DeclaracionGastos.TotalRendido.ToString("C0", FormatoMoneda);

            pagina += "<div ALIGN='left'><ul>";
            pagina += "<li><B>Número resolución: </B>"+ proceso.Resolucion.NumResolucion +"</li>";
            pagina += "<li><B>Unidad: </B>"+ proceso.Direccion.Institucion.Nombre +"</li>";
            pagina += "<li><B>Nombre jefe directo: </B>"+ proceso.Direccion.Nombre +"</li>";
            pagina += "<li><B>Responsable del fondo: </B>"+ proceso.Responsable.Nombre +"</li>";
            pagina += "<li><B>RUN responsable: </B>"+ FormatearRut(proceso.Responsable.RUN) + "</li>";
            pagina += "<li><B>Total solicitado: </B>"+ montoSolicitud + "</li>";
            pagina += "<li><B>Total rendido: </B>"+ montoDG + "</li>";
            pagina += "<li><B>Fono anexo: </B>"+ proceso.Direccion.FonoAnexo +"</li>";
            pagina += "<li><B>Email: </B>"+ proceso.Responsable.Email +"</li>";
            pagina += "</ul></div>";

            if (proceso.Solicitud.TipoEvento.Equals("Grupal"))
            {
                pagina = Grupal(proceso.Solicitud.Participantes, pagina, FormatoMoneda);
                
            }
            else
            {
                pagina = Masiva(proceso.Solicitud.Participantes[0], pagina, FormatoMoneda);
            }


            pagina = GenerarTablaResumen(pagina, FormatoMoneda, proceso);

            pagina += "<div ALIGN='center' style='padding-top:80px;'><P style='line-height:3px'><B>" + proceso.Responsable.Nombre + "</B></P>";
            pagina += "<P style='line-height:3px'>" + proceso.Responsable.Rol.Nombre + "</P>";

            if (proceso.Responsable.Organizacion.TipoOE.Nombre.Equals("CAA"))
            {
                pagina += "<P style='line-height:3px'>CAA " + proceso.Responsable.Organizacion.Institucion.Nombre + "</P>";
            }
            else
            {
                pagina += "<P style='line-height:3px'>" + proceso.Organizacion.Nombre + "</P>";
            }

            pagina += "<P style='line-height:3px'>Universidad de Talca</P></div></body></html> ";

            return pagina;
        }

        private static string GenerarTablaResumen(string pagina, NumberFormatInfo FormatoMoneda, Proceso proceso)
        {
            int total = 0;
            int totalFactura = 0;

            foreach (var participante in proceso.Solicitud.Participantes)
            {
                total += participante.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta") && documento.Estado==1).Sum(doc => doc.Monto);
                totalFactura += participante.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Factura") && documento.Estado == 1).Sum(doc => doc.Monto);
            }


            pagina += "<div style='padding-top:15px; padding-bottom:-15px;'><table><thead><tr class='table100-head'>" +
                        "<th>Ítem</th>" +
                        "<th>Monto</th>" +
                        "</tr></thead><tbody>";

            pagina += "<tr>";
            pagina += "<td><b>Total</b></td>";
            pagina += "<td>" + total.ToString("C0", FormatoMoneda) + "</td>";
            pagina += "</tr>";

            pagina += "<tr>";
            pagina += "<td><b>Facturas</b></td>";
            pagina += "<td>" + totalFactura.ToString("C0", FormatoMoneda) + "</td>";
            pagina += "</tr>";

            pagina += "<tr>";
            pagina += "<td><b>Total declaración de gastos</b></td>";
            pagina += "<td>" + proceso.DeclaracionGastos.TotalRendido.ToString("C0", FormatoMoneda) + "</td>";
            pagina += "</tr>";

            pagina += "</tbody></table></div>";

            return pagina;
        }

        private static String Masiva(Persona participante, String pagina, NumberFormatInfo FormatoMoneda)
        {
            List<Documento> facturas = new List<Documento>();

            List<Documento> facturasAux = participante.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Factura") && documento.Estado==1);
            if (facturasAux.Count() > 0)
            {
                foreach (var facturaAux in facturasAux)
                {
                    facturas.Add(facturaAux);
                }
            }

            if (facturas.Count() > 0)
            {
                pagina += "<div ALIGN='left'><ul>";
                pagina += "<li><B>Documentos: </B> Facturas</li>";
                pagina += "</ul></div>";
                pagina = GenerarTabla(pagina, FormatoMoneda, facturas);
            }

            pagina += "<div ALIGN='left'><ul>";
            pagina += "<li><B>Documentos: </B> Viáticos y otros</li>";
            pagina += "</ul></div>";
            pagina = GenerarTabla(pagina, FormatoMoneda, participante.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta")));

            pagina += "<div ALIGN='left'><ul>";
            pagina += "<li><B>Detalle de la declaración de gasto</B></li>";
            pagina += "</ul></div>";
            return pagina;
        }


        private static String Grupal(List<Persona> participantes, String pagina, NumberFormatInfo FormatoMoneda)
        {            
            List<Documento> facturas = new List<Documento>();

            foreach(var participante in participantes)
            {
                List<Documento> facturasAux = participante.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Factura") && documento.Estado==1);
                if(facturasAux.Count()>0)
                {
                    foreach(var facturaAux in facturasAux)
                    {
                        facturas.Add(facturaAux);
                    }
                }
            }

            if(facturas.Count()>0)
            {
                pagina += "<div ALIGN='left'><ul>";
                pagina += "<li><B>Documentos: </B> Facturas</li>";
                pagina += "</ul></div>";
                pagina = GenerarTabla(pagina, FormatoMoneda, facturas);
            }  

            pagina += "<div ALIGN='left'><ul>";
            pagina += "<li><B>Documentos: </B> Viáticos y otros</li>";
            pagina += "</ul></div>";

            List<Persona> participantesAux = participantes.FindAll(participante => !participante.RUN.Equals("-1"));
            Boolean primero = true;
            int montoTotal = 0;
            for (int i = 0; i < participantesAux.Count(); i++)
            {
                String paddingTop = "";

                if(participantesAux[i].Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta") && documento.Estado==1).Count()>0)
                {
                    if (!primero)
                    {
                        paddingTop = "padding-top:15px;";
                    }
                    else
                    {
                        primero = false;
                    }
                    pagina += "<div style='" + paddingTop + " padding-bottom:10px;'><B>Nombre: </B>" + participantesAux[i].Nombre + "</div>";
                    pagina = GenerarTabla(pagina, FormatoMoneda, participantesAux[i].Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta")));
                    montoTotal += participantesAux[i].Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta") && documento.Estado==1).Sum(documento=>documento.Monto);
                }

            }

            Persona participanteAux = participantes.Find(participante => participante.RUN.Equals("-1"));
            if (participanteAux.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta") && documento.Estado == 1).Count() > 0)
            {
                pagina += "<div style='padding-top:15px; padding-bottom:10px;'><B>Gastos compartidos </B></div>";
                pagina = GenerarTabla(pagina, FormatoMoneda, participanteAux.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta")));
                montoTotal += participanteAux.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta") && documento.Estado == 1).Sum(documento => documento.Monto);
            }

            pagina += "<div ALIGN='left'><ul>";
            pagina += "<li><B>Detalle de la declaración de gasto</B></li>";
            pagina += "</ul></div>";

            pagina += "<table><thead><tr class='table100-head'>" +
                        "<th>Participante</th>" +
                        "<th>Monto</th>" +
                        "</tr></thead><tbody>";
            /*Sumar todas las boletas que tienen en comun y dividirla por la cantidad de participante*/
            int porcionBoletasComun = participanteAux.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta") && documento.Estado==1).Sum(doc => doc.Monto) / participantesAux.Count();
            /*Sumar todas las boletas de cada participante y agregarle la porcion de boletas compartidas*/
            //int montoTotal = 0;
            foreach(var participante in participantesAux)
            {
                int monto = participante.Documentos.FindAll(documento => documento.TipoDocumento.Equals("Boleta") && documento.Estado==1).Sum(documento => documento.Monto) + porcionBoletasComun;
                //montoTotal += monto;

                if(monto>0)
                {
                    pagina += "<tr>";
                    pagina += "<td>" + participante.Nombre + "</td>";
                    pagina += "<td>" + monto.ToString("C0", FormatoMoneda) + "</td>";
                    pagina += "</tr>";
                }                
            }

            /*Sumar el total de boletas compartidas y de cada participante*/
            pagina += "<tr>";
            pagina += "<td><b>Total</b></td>";
            pagina += "<td><b>" + montoTotal.ToString("C0", FormatoMoneda) + "</b></td>";
            pagina += "</tr>";
            pagina += "</tbody></table>";

            return pagina;
        }

        private static String GenerarTabla(String pagina, NumberFormatInfo FormatoMoneda, List<Documento> documentos)
        {
            pagina += "<table><thead><tr class='table100-head'>" +
                        "<th>Nº Documento</th>" +
                        "<th>Fecha</th>" +
                        "<th>Nombre proveedor</th>" +
                        "<th>Descripción</th>" +
                        "<th>Monto</th>" +
                        "</tr></thead>";
            pagina += "<tbody>";
            foreach (var documento in documentos)
            {
                if (documento.Estado == 1)
                {
                    pagina += "<tr>";
                    pagina += "<td>" + documento.Id + "</td>";
                    pagina += "<td>" + documento.FechaDocumento.ToShortDateString() + "</td>";
                    pagina += "<td>" + documento.Proveedor + "</td>";
                    pagina += "<td>" + documento.DescripcionDocumento + "</td>";
                    pagina += "<td>" + documento.Monto.ToString("C0", FormatoMoneda) + "</td>";
                    pagina += "</tr>";
                }
            }
            pagina += "</tbody></table>";

            return pagina;
        }
    }
}
