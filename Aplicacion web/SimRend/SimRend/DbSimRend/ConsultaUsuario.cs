using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimRend.Models;

namespace SimRend.DbSimRend
{
    public class ConsultaUsuario
    {
        public static Usuario IniciarSesion(string email, string clave, string tipoUsuario)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "iniciar_sesion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipoUsuario", Direction = System.Data.ParameterDirection.Input, Value = tipoUsuario });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    var aux = datos.Tables[0].Rows[0];
                    Usuario usuario = new Usuario() 
                    { 
                        Id = Convert.ToInt32(aux["id"]),
                        Email = aux["email"].ToString(),
                        Clave = aux["clave"].ToString(),
                        Nombre = aux["nombre"].ToString(),
                        Estado = aux["estado"].ToString(),
                        IdRol = Convert.ToInt32(aux["idRol"]),
                        IdOrganizacionEstudiantil = Convert.ToInt32(aux["idOrganizacionEstudiantil"]),
                        NombreOrganizacionEstudiantil = aux["nombreOrganizacion"].ToString(),
                        NombreRol = aux["nombreRol"].ToString()
                    };

                    return usuario;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        public static int Leer_Rol_Operacion(int idRolUsuario, int idOperacion)
        {
            int cantOperaciones = 0;
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Rol_Operacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idRolUsuario", Direction = System.Data.ParameterDirection.Input, Value = idRolUsuario });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOperacion", Direction = System.Data.ParameterDirection.Input, Value = idOperacion });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    cantOperaciones = datos.Tables[0].Rows.Count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                cantOperaciones = -1;
            }

            return cantOperaciones;
        }


        /**
         * Funciones aun sin ocupar
         **/

        public static String Leer_Correo(string Email)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leer_Correo", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = Email });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    return prodData["email"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static void Cambiar_clave(string Email, string Clave)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "cambiar_clave", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_correo", Direction = System.Data.ParameterDirection.Input, Value = Email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = Clave });
                var datos = ContexDb.ExecuteProcedure(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*Fin consultas de usuario*/
    }
}