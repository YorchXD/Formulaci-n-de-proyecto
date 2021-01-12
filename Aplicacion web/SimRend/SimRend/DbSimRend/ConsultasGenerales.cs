using MySql.Data.MySqlClient;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultasGenerales
    {

        /*#############################################Crear######################################################*/
        


        /*###########################################Fin crear####################################################*/

        /*#############################################Leer########################################################*/

        public static Operacion Leer_Operacion(int idOperacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Operacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOperacion", Direction = System.Data.ParameterDirection.Input, Value = idOperacion });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    Operacion operacion = new Operacion()
                    {
                        Id = Convert.ToInt32(datos.Tables[0].Rows[0]["id"]),
                        IdModulo = Convert.ToInt32(datos.Tables[0].Rows[0]["idModulo"]),
                        Nombre = datos.Tables[0].Rows[0]["nombre"].ToString()
                    };
                    return operacion;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static Modulo Leer_Modulo(int idModulo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Modulo", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idModulo", Direction = System.Data.ParameterDirection.Input, Value = idModulo });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    Modulo modulo = new Modulo()
                    {
                        Id = Convert.ToInt32(datos.Tables[0].Rows[0]["id"]),
                        Nombre = datos.Tables[0].Rows[0]["nombre"].ToString()
                    };
                    return modulo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static List<Proceso> LeerProcesosOrganizacion(int refOrganizacionEstudiantil)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Procesos_Organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacionEstudiantil });
                //ejemplo command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.GetDataSet(command);

                List<Proceso> procesos = new List<Proceso>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        int idSolicitud = Convert.ToInt32(prodData["refSolicitud"]);
                        int idResolucion= Convert.ToInt32(prodData["refResolucion"]);
                        int idDeclaracionGastos = Convert.ToInt32(prodData["refDeclaracionGastos"]);
                        Solicitud solicitud = ConsultaSolicitud.LeerSolicitud(idSolicitud);
                        if (solicitud.NombreResponsable == null)
                        {
                            solicitud.NombreResponsable = ConsultaSolicitud.LeerResponsable(solicitud.IdResponsable).Nombre;
                        }

                        Proceso proceso = new Proceso()
                        {
                            Id = Convert.ToInt32(prodData["idFondo"]),
                            Estado = Convert.ToInt32(prodData["estado"]),
                            Solicitud = solicitud,
                            Resolucion = new Resolucion() { Id = idResolucion },
                            DeclaracionGastos = new DeclaracionGastos() { Id = idDeclaracionGastos }
                        };

                        procesos.Add(proceso);
                    }

                    return procesos;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;

        }

        /*###########################################Fin leer######################################################*/

        /*#############################################Actualizar##################################################*/
        public static void ActualizarEstadoUsurioRepresentate(int refRepresentante, string estado)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Modificar_crearProceso_usuario_representante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refResponsable", Direction = System.Data.ParameterDirection.Input, Value = refRepresentante });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_nombre", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);
                //return datos.Parameters["out_nombre"].Value.ToString();

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //return null;
        }

        public static Boolean ActualizarEstadoProceso(int estado, int refProceso, String nombreProceso)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_Estado_Proceso", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refProceso", Direction = System.Data.ParameterDirection.Input, Value = refProceso });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreProceso", Direction = System.Data.ParameterDirection.Input, Value = nombreProceso });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }


        /*###########################################Fin actualizar################################################*/

        /*##############################################Eliminar###################################################*/



        /*############################################Fin eliminar#################################################*/
    }
}
