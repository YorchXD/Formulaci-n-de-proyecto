using MySql.Data.MySqlClient;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaSolicitud
    {
        /*#############################################Crear Solicitud######################################################*/

        public static int CrearSolicitud(Solicitud solicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_solicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fecha", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaCreacion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_monto", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Monto });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.NombreEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaInicioEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaInicioEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaTerminoEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaTerminoEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_lugarEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.LugarEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipoActividad", Direction = System.Data.ParameterDirection.Input, Value = solicitud.TipoEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaCreacionPDF", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaFinPdf });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaModificacion", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaModificacion});
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

        public static int CrearProcesoFondo(int refOrganizacion, int refSolicitud, int estado, int refResponsable)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_proceso_fondo", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refResponsable", Direction = System.Data.ParameterDirection.Input, Value = refResponsable });
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

        public static void AgregarCategoria(int idSolicitud, int idCategoria, DateTime FechaModificacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Agregar_categoria", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = idSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refCategoria", Direction = System.Data.ParameterDirection.Input, Value = idCategoria });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaModificacion", Direction = System.Data.ParameterDirection.Input, Value = FechaModificacion });

                var datos = ContexDb.ExecuteProcedure(command);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void AgregarParticipante(Persona persona)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Agregar_Participante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = persona.Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_run", Direction = System.Data.ParameterDirection.Input, Value = persona.RUN });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void AgregarParSol(String refParticipante, int refSolicitud, DateTime FechaModificacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Agregar_parsol", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refParticipante", Direction = System.Data.ParameterDirection.Input, Value = refParticipante });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaModificacion", Direction = System.Data.ParameterDirection.Input, Value = FechaModificacion });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);

                //saber.Id = Convert.ToInt32(datos.Parameters["out_id"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*###########################################Fin crear Solicitud####################################################*/

        /*#############################################Leer Solicitud########################################################*/

        /*Consultas de la organizacion (caa o federacion)*/
        /*public static List<UsuarioRepresentante> LeerRepresetantes(int refOrganizacionEstudiantil)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Representantes", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacionEstudiantil });
                var datos = ContexDb.GetDataSet(command);
                List<UsuarioRepresentante> representantes = new List<UsuarioRepresentante>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var responsable = new UsuarioRepresentante()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            RUN = prodData["run"].ToString(),
                            Sexo = prodData["sexo"].ToString(),
                            Matricula = Convert.ToInt32(prodData["matricula"]),
                            Carrera = prodData["carrera"].ToString(),
                            Rol = new Rol
                            {
                                Id = Convert.ToInt32(prodData["idRol"]),
                                Nombre = prodData["nombreRol"].ToString(),
                            },
                            CrearSolicitud = prodData["crearProceso"].ToString(),
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

            return null;
        }*/

        /*public static List<UsuarioRepresentante> LeerRepresetantesHabilitados(int refOrganizacionEstudiantil)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Representantes", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOrganizacion", Direction = System.Data.ParameterDirection.Input, Value = refOrganizacionEstudiantil });
                var datos = ContexDb.GetDataSet(command);
                List<UsuarioRepresentante> representantes = new List<UsuarioRepresentante>();

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var responsable = new UsuarioRepresentante()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            RUN = prodData["run"].ToString(),
                            Sexo = prodData["sexo"].ToString(),
                            Matricula = Convert.ToInt32(prodData["matricula"]),
                            Carrera = prodData["carrera"].ToString(),
                            IdRol = Convert.ToInt32(prodData["idRol"]),
                            NombreRol = prodData["nombreRol"].ToString(),
                            CrearSolicitud = prodData["crearProceso"].ToString(),
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

            return null;
        }*/

        public static Solicitud LeerSolicitud(int idSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Solicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = idSolicitud });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    Solicitud solicitud;
                    var prodData = datos.Tables[0].Rows[0];
                    solicitud = new Solicitud()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        NombreEvento = prodData["nomEvent"].ToString(),
                        LugarEvento = prodData["lugarEvent"].ToString(),
                        Monto = Convert.ToInt32(prodData["monto"]),
                        FechaInicioEvento = Convert.ToDateTime(prodData["fecIniEvent"]),
                        FechaTerminoEvento = Convert.ToDateTime(prodData["fecTerEvent"]),
                        //IdResponsable = Convert.ToInt32(prodData["refResponsable"]),
                        TipoEvento = prodData["tipoActividad"].ToString(),
                        RefProceso = Convert.ToInt32(prodData["idFondo"]),
                        FechaFinPdf = Convert.ToDateTime(prodData["fechaCreacionPDF"])/*,
                        EstadoProceso = Convert.ToInt32(prodData["estado"])*/
                    };
                    return solicitud;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

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
            return null;
        }

        public static List<Categoria> LeerCategoriasSeleccionadas(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Categorias_Seleccionadas", CommandType = System.Data.CommandType.StoredProcedure };
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
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString()
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
            return null;
        }


        public static List<Persona> LeerParticipantes(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Participantes", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                var datos = ContexDb.GetDataSet(command);
                List<Persona> participantes = new List<Persona>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var participante = new Persona()
                        {
                            Nombre = prodData["nombre"].ToString(),
                            RUN = prodData["run"].ToString(),
                            EstadoEdicion = Convert.ToInt32(prodData["estadoEdicion"])
                        };

                        participantes.Add(participante);
                    }
                    return participantes;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static Organizacion LeerOrganizacion(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    Organizacion organizacion = new Organizacion()
                    {
                        Nombre = prodData["nombre"].ToString(),
                        TipoOE = new TipoOE { Nombre = prodData["tipo"].ToString() },
                    };

                    return organizacion;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static Direccion LeerDireccion(int refSolicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Direccion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = refSolicitud });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    Direccion direccion = new Direccion()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        Nombre = prodData["nombre"].ToString(),
                        Sexo = prodData["sexo"].ToString(),
                        Cargo = prodData["cargo"].ToString(),
                        Institucion = new Institucion
                        {
                            Id = Convert.ToInt32(prodData["refInstitucion"]),
                            Nombre = prodData["nombreInstitucion"].ToString(),
                            Abreviacion = prodData["abreviacionInstitucion"].ToString(),
                        },
                        FonoAnexo = Convert.ToInt32(prodData["fonoAnexo"]),
                    };

                    return direccion;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static Persona LeerParticipante(String refParticipante)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Participante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refParticipante", Direction = System.Data.ParameterDirection.Input, Value = refParticipante});
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    Persona participante;
                    var prodData = datos.Tables[0].Rows[0];
                    participante = new Persona()
                    {
                        Nombre = prodData["nombre"].ToString(),
                        RUN = prodData["run"].ToString(),
                        EstadoEdicion = Convert.ToInt32(prodData["estadoEdicion"])
                    };
                    return participante;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /*public static UsuarioRepresentante LeerResponsable(int refResponsable)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Responsable", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refResponsable", Direction = System.Data.ParameterDirection.Input, Value = refResponsable });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    UsuarioRepresentante responsable;
                    var prodData = datos.Tables[0].Rows[0];
                    responsable = new UsuarioRepresentante()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        Nombre = prodData["nombre"].ToString(),
                        RUN = prodData["run"].ToString(),
                        Matricula = Convert.ToInt32(prodData["matricula"]),
                        Email = prodData["email"].ToString(),

                        Rol = new Rol
                        {
                            Id = Convert.ToInt32(prodData["idRol"]),
                            Nombre = prodData["nombreRol"].ToString(),
                        },

                        Organizacion = new Organizacion
                        {
                            Id = Convert.ToInt32(prodData["idOrganizacionEstudiantil"]),
                            Nombre = prodData["nombreOE"].ToString(),
                            Campus = new Campus
                            {
                                Id = Convert.ToInt32(prodData["idCampus"]),
                                Nombre = prodData["nombreCampus"].ToString()
                            },

                            Institucion = new Institucion
                            {
                                Id = Convert.ToInt32(prodData["refInstitucion"]),
                                Nombre = prodData["nombreInstitucion"].ToString(),
                                Abreviacion = prodData["abreviacionInstitucion"].ToString(),
                            },
                        },

                        Estado = prodData["estado"].ToString(),
                        EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                    };

                    return responsable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }*/

        /*public static UsuarioRepresentante LeerResponsableSolicitud(int refResponsable)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Responsable", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refResponsable", Direction = System.Data.ParameterDirection.Input, Value = refResponsable });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    UsuarioRepresentante responsable;
                    var prodData = datos.Tables[0].Rows[0];
                    responsable = new UsuarioRepresentante()
                    {
                        Nombre = prodData["nombre"].ToString(),
                        RUN = prodData["run"].ToString(),
                        Carrera = prodData["carrera"].ToString(),
                        NombreRol = prodData["cargo"].ToString(),
                        Matricula = Convert.ToInt32(prodData["matricula"])
                    };
                    return responsable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }*/

        /*###########################################Fin leer Solicitud######################################################*/

        /*#############################################Actualizar Solicitud##################################################*/

        public static void ModificarSolicitud(Solicitud solicitud)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Modificar_solicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_monto", Direction = System.Data.ParameterDirection.Input, Value = solicitud.Monto });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.NombreEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaInicioEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaInicioEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaTerminoEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaTerminoEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_lugarEvento", Direction = System.Data.ParameterDirection.Input, Value = solicitud.LugarEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipoActividad", Direction = System.Data.ParameterDirection.Input, Value = solicitud.TipoEvento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaCreacionPDF", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaFinPdf });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaModificacion", Direction = System.Data.ParameterDirection.Input, Value = solicitud.FechaModificacion });
                var datos = ContexDb.ExecuteProcedure(command);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void ModificarResponsableFondo(int RefSolicitud, int RefResponsable)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Modificar_responsable_proceso", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = RefSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refResponsable", Direction = System.Data.ParameterDirection.Input, Value = RefResponsable });
                var datos = ContexDb.ExecuteProcedure(command);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
    
        }

        public static int ModificarParticipante(String Nombre, String Run, int IdSolicitud, DateTime FechaModificacion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_participante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_run", Direction = System.Data.ParameterDirection.Input, Value = Run });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idSolicitud", Direction = System.Data.ParameterDirection.Input, Value = IdSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaModificacion", Direction = System.Data.ParameterDirection.Input, Value = FechaModificacion });
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

        /*###########################################Fin actualizar Solicitud################################################*/

        /*##############################################Eliminar Solicitud###################################################*/

        public static Boolean EliminarCategoria(int IdSolicitud, int IdCategoria, DateTime FechaModificacion)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_categoria_seleccionada", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = IdSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refCategoria", Direction = System.Data.ParameterDirection.Input, Value = IdCategoria });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaModificacion", Direction = System.Data.ParameterDirection.Input, Value = FechaModificacion });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static Boolean EliminarParticipante(int IdSolicitud, String IdParticipante, DateTime FechaModificacion)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Participante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refSolicitud", Direction = System.Data.ParameterDirection.Input, Value = IdSolicitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refParticipante", Direction = System.Data.ParameterDirection.Input, Value = IdParticipante });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaModificacion", Direction = System.Data.ParameterDirection.Input, Value = FechaModificacion });
                //command.Parameters.Add(new MySqlParameter() { ParameterName = "out_id", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// Se encarga de eliminar una solicitud en particular y por ende elimina el proceso (Para realizar esta eliminacion, el proceso
        /// no debe tener asignado una resolucion y una declaracion de gasto)
        /// (1) Indica que se ha eliminado la solicitud correctamente
        /// (-1) Existen problemas de conexion con la base de datos o el parametro ingresado en la variable id no es correcto
        /// (-2) Aun existe la solicitud en la BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1, -1 o -2</returns>
        public static int EliminarSolicitud(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_solicitud", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_validacion", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = ContexDb.ExecuteProcedure(command);
                return Convert.ToInt32(datos.Parameters["out_validacion"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return -1;
        }
        /*############################################Fin eliminar Solicitud#################################################*/

    }
}
