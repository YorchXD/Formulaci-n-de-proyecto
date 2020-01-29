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

        /*Consultas de la organizacion (caa o federacion)*/
        public static List<Responsable> LeerRepresetantes(int refOrganizacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leer_responsables_organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacion });
                var datos = ContexDb.GetDataSet(command);
                List<Responsable> representantes = new List<Responsable>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var responsable = new Responsable()
                        {
                            Run = prodData["run"].ToString(),
                            Nombre = prodData["nombre"].ToString(),
                            Matricula = Convert.ToInt32(prodData["matricula"]),
                            Cargo = prodData["cargo"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            Sexo = prodData["sexo"].ToString()

                        };
                        representantes.Add(responsable);
                    }
                    return representantes;
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

        internal static int Leer_Estado_Proceso(int idSolicitud, int proceso)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leer_Estado_Proceso", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_proceso", Direction = System.Data.ParameterDirection.Input, Value = proceso });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id_proceso", Direction = System.Data.ParameterDirection.Input, Value = idSolicitud });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    return Convert.ToInt32(prodData["estado"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }
            return -1;
        }

        public static Responsable Leer_Responsable(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "responsable_solicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1 )
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    var responsable = new Responsable()
                    {
                        Run = prodData["run"].ToString(),
                        Nombre = prodData["nombre"].ToString(),
                        Matricula = Convert.ToInt32(prodData["matricula"]),
                        Cargo = prodData["cargo"].ToString()

                    };
                    
                    return responsable;
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

        public static Organizacion Leer_Organizacion(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leer_organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    var organizacion = new Organizacion()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        Tipo = prodData["tipo"].ToString()

                    };

                    return organizacion;
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

        public static Federacion Leer_Federacion(int refOrganizacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leer_Federacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacion });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    var federacion = new Federacion()
                    {
                        NomDirDAAE = prodData["nomDirDAAE"].ToString(),
                        Campus = prodData["campus"].ToString(),
                        SexoDirDAAE = prodData["sexoDirDAAE"].ToString(),
                        Cargo = prodData["cargo"].ToString(),
                        NombreFederacion = prodData["nombreFederacion"].ToString()

                    };

                    return federacion;
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

        public static CAA Leer_CAA(int refOrganizacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leer_CAA", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacion });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    var caa = new CAA()
                    {
                        NomDirCarrera = prodData["nomDirCarrera"].ToString(),
                        Carrera = prodData["carrera"].ToString(),
                        SexoDirCarrera = prodData["sexoDirCarrera"].ToString(),
                        Cargo = prodData["cargo"].ToString()

                    };

                    return caa;
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
        /*Fin consultas organizacion*/


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
