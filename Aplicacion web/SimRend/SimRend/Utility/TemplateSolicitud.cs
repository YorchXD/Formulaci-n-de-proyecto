using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Utility
{
    public class TemplatePDF
    {
        public static string SolicitudPdf(Proceso proceso)
        {
            //ModeloSolicitud modelo = obtenerModelo();
            String pagina = "<!DOCTYPE html><html><head><title></title>";
            pagina += "<style type = 'text/css'>";
            pagina += " body{ font-family: sans-serif; margin-left:80px; margin-right:80px;}";
            pagina += "table {border-spacing: 1;border-collapse: collapse;background: white;margin: 0 auto;position: relative;}";
            pagina += "table * {position: relative;}";
            pagina += "table td, table th {padding-left: 8px;}";
            pagina += "table thead tr {height: 40px;background: #000000;}";
            pagina += "table tbody tr {height: 30px;}";
            pagina += "table tbody tr:last-child {border: 0;}";
            pagina += "table td, table th {text-align: left;}";
            pagina += "table td.l, table th.l {text-align: right;}";
            pagina += "table td.c, table th.c {text-align: center;}";
            pagina += "table td.r, table th.r {text-align: center;}";

            pagina += ".table100-head th{color: #fff;line-height: 1.2;font-weight: unset;}";
            pagina += "tbody tr:nth-child(even) {background-color: #f5f5f5;}";
            pagina += "tbody tr {color: #000000;line-height: 1.2;font-weight: unset;}";
            pagina += "tbody tr:hover {color: #000000;background-color: #f5f5f5;cursor: pointer;}";
            pagina += ".column1 {width: 260px;padding-left: 40px;}";
            pagina += ".column2 {width: 260px;text-align: right;padding-right: 62px;}</style>";

            pagina += "</head><body> <div id='Solicitud'><DIV ALIGN='center'><img src='https://i.imgur.com/SS6BFCs.png' width='10%'  border=0></DIV--><div ALIGN='right'><P> " + proceso.Solicitud.FechaPdf + "</P></div><DIV ALIGN='left'>";

            if (proceso.Organizacion != null)
            {
                if (proceso.Direccion.Sexo.Equals("Femenino"))
                {
                    pagina += "<P style='line-height:1px'><B>Sra. " + proceso.Direccion.Nombre + "</B></P>";
                }
                else
                {
                    pagina += "<P style='line-height:1px'><B>Sr. " + proceso.Direccion.Nombre + "/B></P>";
                }
                pagina += "<P style='line-height:3px'><I>" + proceso.Direccion.Cargo + "</I></P>";
                pagina += "<P style='line-height:3px'><I>" + proceso.Direccion.NombreInstitucion + "</I></P>";
            }

            pagina += "<P style='line-height:1px'><I>Universidad de Talca</I></P><P style='line-height:1px'><B><U>Presente.</U></B></P></DIV><DIV style='text-align:justify'><P>De nuestra consideración:</P>";

            if (proceso.Organizacion.Tipo.Equals("CAA"))
            {
                pagina += "<P>Junto con saludar cordialmente, me dirijo a usted como " + proceso.Responsable.Cargo + " del centro de alumnos de  " + proceso.Responsable.Carrera + ", para solicitarle apoyo económico con el fin de realizar la actividad estudiantil que se indica a continuación:</P>";
            }
            else
            {
                pagina += "<P>Junto con saludar cordialmente, me dirijo a usted como " + proceso.Responsable.Cargo + " de " + proceso.Organizacion.Nombre + ", para solicitarle apoyo económico con el fin de realizar la actividad estudiantil que se indica a continuación:</P>";
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
                pagina += "<table align='center'><thead><tr class='table100-head'><th class='column1'>Nombre</th><th class='column2'>Run</th></tr></thead>";
                pagina += "<tbody>";
                foreach (var item in proceso.Solicitud.Participantes)
                {
                    pagina += "<tr class='table-light'>";
                    pagina += "<td class='column1'>" + item.Nombre + "</td>";
                    pagina += "<td class='column2'>" + FormatearRut(item.RUN) + "</td>";
                    pagina += "</tr>";
                }
                pagina += "</tbody></table>";
            }
            else
            {
                
                pagina += "<P>Se solicita un monto total de " + monto + " sujeto a rendición para solventar parcialmente los gastos de " + proceso.Solicitud.CategoriasConcatenadas + ".</P>";
            }


            if (proceso.Organizacion.Tipo.Equals("CAA"))
            {
                pagina += "<P>Dicho monto quedará bajo la responsabilidad de " + proceso.Responsable.Nombre + ", RUT " + FormatearRut(proceso.Responsable.RUN);
                pagina += ", matrícula " + proceso.Responsable.Matricula + ", en su calidad de " + proceso.Responsable.Cargo;
                pagina += " del Centro de Alumnos de " + proceso.Responsable.Carrera + " de la Universidad de Talca. </P>";
            }
            else
            {
                pagina += "<P>Dicho monto quedará bajo la responsabilidad de " + proceso.Responsable.Nombre + ", RUT " + FormatearRut(proceso.Responsable.RUN);
                pagina += ", matrícula " + proceso.Responsable.Matricula + ", en su calidad de  " + proceso.Responsable.Cargo + " de ";
                pagina += proceso.Organizacion.Nombre + " de la Universidad de Talca.</P>";
            }

            pagina += "<P>Esperando una buena acogida y una pronta respuesta de esta solicitud, se despide atentamente de usted.</P>";
            pagina += "<DIV ALIGN='center' style='padding-top:80px;'><P style='line-height:3px'><B>" + proceso.Responsable.Nombre + "</B></P>";
            pagina += "<P style='line-height:3px'>" + proceso.Responsable.Cargo + "</P>";

            if (proceso.Organizacion.Tipo.Equals("CAA"))
            {
                pagina += "<P style='line-height:3px'>CAA " + proceso.Responsable.Carrera + "</P>";
            }
            else
            {
                pagina += "<P style='line-height:3px'>" + proceso.Organizacion.Nombre + "</P>";
            }

            pagina += "<P style='line-height:3px'>Universidad de Talca</P></DIV>";

            return pagina;
        }

        // rutina que formatea con separadores de miles y agrega el guion
        public static string FormatearRut(string rut)
        {
            string rutFormateado = string.Empty;

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
    }

    
}
