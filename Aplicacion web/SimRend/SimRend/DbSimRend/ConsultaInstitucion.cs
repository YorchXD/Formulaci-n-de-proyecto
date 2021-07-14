using MySql.Data.MySqlClient;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaInstitucion
    {
        public static List<Institucion> LeerInstituciones()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Institucion", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                List<Institucion> instituciones = new List<Institucion>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var institucion = new Institucion()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Abreviacion = prodData["abreviacion"].ToString(),
                            Nombre = prodData["nombre"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString()
                        };
                        instituciones.Add(institucion);
                    }
                }
                return instituciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static int CrearInstitucion(string Abreviacion, string Nombre)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_Institucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_abreviacion", Direction = System.Data.ParameterDirection.Input, Value = Abreviacion });
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

        public static int ActualizarInstitucion(int IdInstitucion, string Abreviatura, string Nombre)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_Institucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdInstitucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_abreviacion", Direction = System.Data.ParameterDirection.Input, Value = Abreviatura });
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

        public static int EliminarInstitucion(int IdInstitucion)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Institucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdInstitucion });
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
