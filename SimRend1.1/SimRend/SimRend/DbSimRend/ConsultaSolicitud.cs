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

        public static List<Solicitud> LeerTodoSolicitud()
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
                        var solicitud = new Solicitud()
                        {

                            Id = Convert.ToInt32(prodData["id"]),
                            FechaActual = Convert.ToDateTime(prodData["fechaCreacion"]),
                            Monto = Convert.ToInt32(prodData["monto"]),
                            NombreEvento = prodData["nomEvent"].ToString(),
                            FechaInicioEvento = Convert.ToDateTime(prodData["fecIniEvent"]),
                            FechaTerminoEvento = Convert.ToDateTime(prodData["fecTerEvent"]),
                            Responsable =  prodData["encargado"].ToString(),
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

        public static int CrearSolicitud(Solicitud solicitud)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "crear_solicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Estado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fecha", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaActual });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_monto", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Monto });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.NombreEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaInicioEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaInicioEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaTerminoEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaTerminoEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_encargado", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Responsable});
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_lugarEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.LugarEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                return Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

        public static List<Categoria> LeerTodoCategorias()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leertodos_categorias", CommandType = System.Data.CommandType.StoredProcedure };
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
                            Nombre = prodData["nombre"].ToString()
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
            finally
            {

            }
            return null;

        }

        public static void AgregarCategoria(SolicitudCategoria categoria)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "agregar_categoria", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = categoria.RefSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refCategoria", Direction = System.Data.ParameterDirection.Input, Value = categoria.RefCategoria });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EliminarCategoria(SolicitudCategoria categoria)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "eliminar_categoria_seleccionada", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = categoria.RefSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refCategoria", Direction = System.Data.ParameterDirection.Input, Value = categoria.RefCategoria });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<Categoria> LeerCategoriasSeleccionadas(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "categorias_seleccionadas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                var datos = ContexDb.GetDataSet(command);
                List<Categoria> CategoriasSeleccionadas = new List<Categoria>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var categoria = new Categoria()
                        {
                            Nombre = prodData["refCategoria"].ToString()
                        };

                        CategoriasSeleccionadas.Add(categoria);
                    }
                    return CategoriasSeleccionadas;
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

        public static void AgregarPersona(Persona persona)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "agregar_personas", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = persona.Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_run", Direction = System.Data.ParameterDirection.Input, Value = persona.Run });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void AgregarPerSol(String refPersona, int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "agregar_persol", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refPersona", Direction = System.Data.ParameterDirection.Input, Value = refPersona });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<Persona> LeerPersonasSolicitud(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "leerpersonas_refSolicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                var datos = ContexDb.GetDataSet(command);
                List<Persona> personas = new List<Persona>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var persona = new Persona()
                        {
                            Nombre = prodData["nombre"].ToString(),
                            Run = prodData["run"].ToString()
                        };

                        personas.Add(persona);
                    }
                    return personas;
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

        public static int IniciarSesion(Login login)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "iniciar_sesion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_usuario", Direction = System.Data.ParameterDirection.Input, Value = login.Usuario });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = login.Clave });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    System.Data.DataRow row = datos.Tables[0].Rows[0];
                    var prodData = row;
                    return Convert.ToInt32(prodData["id"].ToString());
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return -1;
        }

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
                            Responsable = prodData["encargado"].ToString(),
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

        public static void AgregarOrgSol(int refOrganizacion, int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "crear_orgsol", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
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


