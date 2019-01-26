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
                            Responsable = prodData["runEncargado"].ToString(),
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
    }
}
