using MySql.Data.MySqlClient;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaTipoOE
    {
        public static List<TipoOE> LeerTipoOE()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_TipoOE", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<TipoOE> tipoOEs = new List<TipoOE>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var tipoOE = new TipoOE()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            NombreExtendido = prodData["nombreExtendido"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString()
                        };
                        tipoOEs.Add(tipoOE);
                    }
                    return tipoOEs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static int CrearTipoOE(string Nombre, string NombreExtendido)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_TipoOE", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreExtendido", Direction = System.Data.ParameterDirection.Input, Value = NombreExtendido });
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

        public static int ActualizarTipoOE(int IdTipoOE, string Nombre, string NombreExtendido)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_TipoOE", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdTipoOE });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreExtendido", Direction = System.Data.ParameterDirection.Input, Value = NombreExtendido });
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

        public static int EliminarTipoOE(int IdTipoOE)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_TipoOE", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdTipoOE });
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
