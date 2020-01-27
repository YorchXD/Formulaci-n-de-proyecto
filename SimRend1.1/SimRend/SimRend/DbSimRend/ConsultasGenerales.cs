using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimRend.Models;

namespace SimRend.DbSimRend
{
    public class ConsultasGenerales
    {
       
        /*Crear*/
        /*Leer*/

         public static List<Solicitud> LeerSolicitudOrganizacion(int idOrganizacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leertodas_solicitudes_organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = idOrganizacion });
                //ejemplo command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.GetDataSet(command);
                List<Solicitud> solicitudes = new List<Solicitud>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var solicitud = new Solicitud()
                        {

                            Id = Convert.ToInt32(prodData["id"]),
                            FechaActual = Convert.ToDateTime(prodData["fechaCreacion"]),
                            Monto = Convert.ToInt32(prodData["monto"]),
                            NombreEvento = prodData["nomEvent"].ToString(),
                            FechaInicioEvento = Convert.ToDateTime(prodData["fecIniEvent"]),
                            FechaTerminoEvento = Convert.ToDateTime(prodData["fecTerEvent"]),
                            RutResponsable = prodData["runEncargado"].ToString(),
                            LugarEvento = prodData["lugarEvent"].ToString()
                        };

                        solicitudes.Add(solicitud);
                    }
                    return solicitudes;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }
            return null;
        }


        /*Actualizar*/
        public static void Actualizar_Estado_Proceso(int proceso, int id_proceso, int estado)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "actualizar_estado_proceso", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_proceso", Direction = System.Data.ParameterDirection.Input, Value = proceso });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id_proceso", Direction = System.Data.ParameterDirection.Input, Value = id_proceso });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                var datos = ContexDb.ExecuteProcedure(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static String ModificarEstadoResponsable(string refResponsable, string estado)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "cambiar_estado_responsable", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refResponsable", Direction = System.Data.ParameterDirection.Input, Value = refResponsable });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_nombre", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);
                return datos.Parameters["out_nombre"].Value.ToString();

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
        /*Eliminar*/
    }
}
