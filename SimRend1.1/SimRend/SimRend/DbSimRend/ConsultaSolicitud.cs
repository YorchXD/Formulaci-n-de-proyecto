using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimRend.Models;

namespace SimRend.DbSimRend
{
    public class ConsultaSolicitud
    {

        public static List<Solicitud> LeerTodo()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leertodos_solicitudes", CommandType = System.Data.CommandType.StoredProcedure };
                //ejemplo command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.GetDataSet(command);
                List<Solicitud> solicitudes = new List<Solicitud>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach(System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var comp = new Solicitud()
                        {

                            Id = Convert.ToInt32(prodData["id"]),
                            FechaActual = Convert.ToDateTime(prodData["fecha"]),
                            Monto = Convert.ToInt32(prodData["monto"]),
                            NombreEvento = prodData["nomEvent"].ToString(),
                            FechaEvento = Convert.ToDateTime(prodData["fecEvent"]),
                            Responsable =  prodData["encargado"].ToString(),
                            LugarEvento = prodData["lugarEvent"].ToString()
                        };

                        solicitudes.Add(comp);
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

        public static void CrearSolicitud(Solicitud solicitud)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "crear_solicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Estado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fecha", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaActual });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_monto", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Monto });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.NombreEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_encargado", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Responsable});
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_lugarEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.LugarEvento });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}


