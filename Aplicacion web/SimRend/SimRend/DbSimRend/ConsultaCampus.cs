using MySql.Data.MySqlClient;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaCampus
    {
        public static List<Campus> LeerCampus()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Campus", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Campus> Campus = new List<Campus>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var campus = new Campus()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString()
                        };
                        Campus.Add(campus);
                    }
                    return Campus;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static int CrearCampus(string Nombre)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_Campus", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                var datos = ContexDb.ExecuteProcedure(command);
                result = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = -1;
            }
            return result;
        }

        public static int ActualizarCampus(int IdCampus, string Nombre)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_Campus", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdCampus });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                var datos = ContexDb.ExecuteProcedure(command);
                result = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = -1;
            }
            return result;
        }

        public static int EliminarCampus(int IdCampus)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Campus", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdCampus });
                var datos = ContexDb.ExecuteProcedure(command);
                result = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = -1;
            }
            return result;
        }
    }
}
