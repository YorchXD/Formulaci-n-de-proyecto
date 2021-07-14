using MySql.Data.MySqlClient;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaCategoria
    {
        public static List<Categoria> LeerCategorias()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Categorias", CommandType = System.Data.CommandType.StoredProcedure };
                //ejemplo command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.GetDataSet(command);
                List<Categoria> categorias = new List<Categoria>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var categoria = new Categoria()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString()
                        };
                        categorias.Add(categoria);
                    }
                    return categorias;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static int CrearCategoria(string Nombre)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_Categoria", CommandType = System.Data.CommandType.StoredProcedure };
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

        public static int ActualizarCategoria(int IdCategoria, string Nombre)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_Categoria", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdCategoria });
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

        public static int EliminarCategoria(int IdCategoria)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Categoria", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdCategoria });
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
