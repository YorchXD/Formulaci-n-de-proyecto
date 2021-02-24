using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaResolucion
    {
        /*#############################################Crear######################################################*/
        public static List<int> CrearResolucion(int anioResolucion, int numeroResolucion, string refSolicitud, string ruta)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_resolucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_anioResolucion", Direction = System.Data.ParameterDirection.Input, Value = anioResolucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_numeroResolucion", Direction = System.Data.ParameterDirection.Input, Value = numeroResolucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_ruta", Direction = System.Data.ParameterDirection.Input, Value = ruta });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id_resolucion", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id_declaracion_gastos", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);
                List<int> ids = new List<int>();
                ids.Add(Convert.ToInt32(datos.Parameters["out_id_resolucion"].Value));
                ids.Add(Convert.ToInt32(datos.Parameters["out_id_declaracion_gastos"].Value));

                return ids;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /*###########################################Fin crear####################################################*/

        /*#############################################Leer######################################################*/
        /// <summary>
        /// Muestra los datos de la resolucion en base al id de la resolucion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Resolucion LeerResolucion(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Resolucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id});
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    Resolucion resolucion;
                    var prodData = datos.Tables[0].Rows[0];
                    resolucion = new Resolucion()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        NumResolucion = Convert.ToInt32(prodData["numero"]),
                        AnioResolucion = Convert.ToInt32(prodData["anio"]),
                        CopiaDoc = prodData["copiaDoc"].ToString()
                    };
                    return resolucion;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        /*###########################################Fin leer####################################################*/

        /*#############################################Actualizar######################################################*/
        /// <summary>
        /// -1) Indica que ocurrio un error, posiblemente de conexion
        /// 1) Indica que la actualizacion fue exitosa.
        /// -2) Indica que se ha ingresado numero de resolucion y el año que pertenece a una resolucion ya existente o no se encuentra registrada
        /// </summary>
        /// <param name="resolucion"></param>
        /// <returns>-1, 1 o -2</returns>
        public static int ActualizarResolucion(Resolucion resolucion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_Resolucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_anioResolucion", Direction = System.Data.ParameterDirection.Input, Value = resolucion.AnioResolucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_numeroResolucion", Direction = System.Data.ParameterDirection.Input, Value = resolucion.NumResolucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = resolucion.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_ruta", Direction = System.Data.ParameterDirection.Input, Value = resolucion.CopiaDoc });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_respuesta", Direction = System.Data.ParameterDirection.Output, Value = -2 });
                var datos = ContexDb.ExecuteProcedure(command);
                return Convert.ToInt32(datos.Parameters["out_respuesta"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        /*###########################################Fin actualizar####################################################*/

        /*#############################################Eliminar######################################################*/
        /// <summary>
        /// Elimina un resolucion siempre y cuando ya no exista una declaracion de gasto asociada al proceso
        /// (1) Indica que se ha eliminado la resolucion correctamente
        /// (-1) Existen problemas de conexion con la base de datos o el parametro ingresado en la variable id no es correcto
        /// (-2) Aun existe la resolucion en la BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1, -1 o -2</returns>
        public static int EliminarResolucion(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_resolucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_validacion", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);
                return Convert.ToInt32(datos.Parameters["out_validacion"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }
        /*###########################################Fin eliminar####################################################*/
    }
}
