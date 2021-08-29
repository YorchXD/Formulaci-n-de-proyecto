using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimRend.Models;
using Microsoft.AspNetCore.Http;

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
                        Rol = new Rol
                        {
                            Id = Convert.ToInt32(aux["idRol"]),
                            Nombre = aux["nombreRol"].ToString(),
                        },
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

        public static List<Organizacion> LeerOrganizacion(int IdUsuario, String TipoUsuario)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Organizacion_Usuario", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refUsuario", Direction = System.Data.ParameterDirection.Input, Value = IdUsuario });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipoUsuario", Direction = System.Data.ParameterDirection.Input, Value = TipoUsuario });
                var datos = ContexDb.GetDataSet(command);
                List<Organizacion> organizaciones = new List<Organizacion>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        Organizacion organizacion = new Organizacion
                        {
                            Id = Convert.ToInt32(row["idOrganizacionEstudiantil"]),
                            Nombre = row["nombreOrganizacion"].ToString()
                        };

                        organizaciones.Add(organizacion);
                    }
                }

                return organizaciones;
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

        public static UsuarioDirector LeerDirector(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuarioDirector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    return new UsuarioDirector()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        Nombre = prodData["nombre"].ToString(),
                        Sexo = prodData["sexo"].ToString(),
                        Email = prodData["email"].ToString(),
                        Cargo = prodData["cargo"].ToString(),
                        Estado = prodData["estado"].ToString(),
                        EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                        FonoAnexo = Convert.ToInt32(prodData["fonoAnexo"]),

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
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public static List<UsuarioDirector> LeerDirectores()
        {
            List<UsuarioDirector> directores = new List<UsuarioDirector>();
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuariosDirectores", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
           
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var director = new UsuarioDirector()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            Sexo = prodData["sexo"].ToString(),
                            Email = prodData["email"].ToString(),
                            Cargo = prodData["cargo"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                            FonoAnexo = Convert.ToInt32(prodData["fonoAnexo"]),

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
                        };
                        directores.Add(director);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return directores;
        }

        public static bool CrearUsuarioDirector(string nombre, string email, string clave, string sexo, string cargo, int fonoAnexo, int idOE)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_UsuarioDirector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_cargo", Direction = System.Data.ParameterDirection.Input, Value = cargo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fonoAnexo", Direction = System.Data.ParameterDirection.Input, Value = fonoAnexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOE", Direction = System.Data.ParameterDirection.Input, Value = idOE });

                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static bool ActualizarUsuarioDirector(string nombre, string email, string clave, string sexo, string cargo, int fonoAnexo, int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_UsuarioDirector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_cargo", Direction = System.Data.ParameterDirection.Input, Value = cargo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fonoAnexo", Direction = System.Data.ParameterDirection.Input, Value = fonoAnexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static object HabilitarUsuarioDirector(int idUsuarioDirector, string estado)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "CambiarEstado_Director", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = idUsuarioDirector });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static bool EliminarDirector(int IdDirector)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Director", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdDirector });
                ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }


        public static List<UsuarioRepresentante> LeerRepresentantes(int IdCampus, int IdOE, int IdRol)
        {
            List<UsuarioRepresentante> representantes = new List<UsuarioRepresentante>();
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuariosRepresentantes", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idCampus", Direction = System.Data.ParameterDirection.Input, Value = IdCampus });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOE", Direction = System.Data.ParameterDirection.Input, Value = IdOE });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idRol", Direction = System.Data.ParameterDirection.Input, Value = IdRol });

                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var representante = new UsuarioRepresentante()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            RUN = prodData["run"].ToString(),
                            Matricula = Convert.ToInt32(prodData["matricula"]),                            
                            Email = prodData["email"].ToString(),
                            CrearSolicitud = prodData["crearProceso"].ToString(),
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
                                    Id = Convert.ToInt32(prodData["idInstitucionOE"]),
                                    Nombre = prodData["nombreInstitucionOE"].ToString(),
                                    Abreviacion = prodData["abreviacionInstitucionOE"].ToString(),
                                },
                            },

                            Institucion = new Institucion
                            {
                                Id = Convert.ToInt32(prodData["refInstitucion"]),
                                Nombre = prodData["nombreInstitucion"].ToString(),
                                Abreviacion = prodData["abreviacionInstitucion"].ToString(),
                            },
                            Sexo = prodData["sexo"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                        };
                        representantes.Add(representante);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return representantes;
        }

        public static bool ActualizarUsuarioRepresentante(int id, string nombre, string run, int matricula, string email, string clave, string sexo, int idInstitucion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_UsuarioRepresentante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_run", Direction = System.Data.ParameterDirection.Input, Value = run });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_matricula", Direction = System.Data.ParameterDirection.Input, Value = matricula });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idInstitucion", Direction = System.Data.ParameterDirection.Input, Value = idInstitucion });              
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static UsuarioRepresentante LeerRepresentante(int idRepresentante)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuarioRepresentante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idRepresentante", Direction = System.Data.ParameterDirection.Input, Value = idRepresentante });
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
                        Sexo = prodData["sexo"].ToString(),
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
                                Id = Convert.ToInt32(prodData["idInstitucionOE"]),
                                Nombre = prodData["nombreInstitucionOE"].ToString(),
                                Abreviacion = prodData["abreviacionInstitucionOE"].ToString(),
                            },
                        },

                        Institucion = new Institucion
                        {
                            Id = Convert.ToInt32(prodData["refInstitucion"]),
                            Nombre = prodData["nombreInstitucion"].ToString(),
                            Abreviacion = prodData["abreviacionInstitucion"].ToString(),
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
        }



        public static bool CrearUsuarioRepresentante(string nombre, string run, int matricula, string email, string clave, string sexo, int idRol, int idOE, int idInstitucion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_UsuarioRepresentante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_run", Direction = System.Data.ParameterDirection.Input, Value = run });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_matricula", Direction = System.Data.ParameterDirection.Input, Value = matricula });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idRol", Direction = System.Data.ParameterDirection.Input, Value = idRol });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idOE", Direction = System.Data.ParameterDirection.Input, Value = idOE });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idInstitucion", Direction = System.Data.ParameterDirection.Input, Value = idInstitucion });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static object HabilitarUsuarioRepresentante(int idUsuarioRepresentante, string estado)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "CambiarEstado_Representante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = idUsuarioRepresentante });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static List<Rol> LeerRolesRepresentantes()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_RolesRepresentantes", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var rol = new Rol()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString()
                        };
                        roles.Add(rol);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return roles;
        }

        public static List<Campus> LeerCampusRepresentantes()
        {
            List<Campus> campus = new List<Campus>();
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_CampusRepresentantes", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var camp = new Campus()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString()
                        };
                        campus.Add(camp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return campus;
        }

        public static bool EliminarRepresentante(int IdRepresentante)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Representante", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdRepresentante });
                ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static List<UsuarioVicerector> LeerVicerectores()
        {
            List<UsuarioVicerector> vicerectores = new List<UsuarioVicerector>();
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuariosVicerectores", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var vicerrector = new UsuarioVicerector()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            Sexo = prodData["sexo"].ToString(),
                            Email = prodData["email"].ToString(),
                            Cargo = prodData["cargo"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                            FonoAnexo = Convert.ToInt32(prodData["fonoAnexo"]),

                            Rol = new Rol
                            {
                                Id = Convert.ToInt32(prodData["idRol"]),
                                Nombre = prodData["nombreRol"].ToString(),
                            },
                            Institucion = new Institucion
                            {
                                Id = Convert.ToInt32(prodData["refInstitucion"]),
                                Nombre = prodData["nombreInstitucion"].ToString(),
                                Abreviacion = prodData["abreviacionInstitucion"].ToString(),
                            },

                        };
                        vicerectores.Add(vicerrector);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return vicerectores;
        }

        public static object HabilitarUsuarioVicerector(int idUsuarioVicerector, string estado)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "CambiarEstado_Vicerector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = idUsuarioVicerector });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado });
                ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static bool EliminarVicerector(int IdVicerector)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Vicerector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdVicerector });
                ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static bool CrearUsuarioVicerector(string nombre, string email, string clave, string sexo, string cargo, int fonoAnexo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_UsuarioVicerector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_cargo", Direction = System.Data.ParameterDirection.Input, Value = cargo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fonoAnexo", Direction = System.Data.ParameterDirection.Input, Value = fonoAnexo });

                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static UsuarioVicerector LeerVicerector(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuarioVicerector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    return new UsuarioVicerector()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        Nombre = prodData["nombre"].ToString(),
                        Sexo = prodData["sexo"].ToString(),
                        Email = prodData["email"].ToString(),
                        Cargo = prodData["cargo"].ToString(),
                        Estado = prodData["estado"].ToString(),
                        EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                        FonoAnexo = Convert.ToInt32(prodData["fonoAnexo"]),

                        Rol = new Rol
                        {
                            Id = Convert.ToInt32(prodData["refRol"]),
                            Nombre = prodData["nombreRol"].ToString(),
                        },

                        Institucion = new Institucion
                        {
                            Id = Convert.ToInt32(prodData["refInstitucion"]),
                            Nombre = prodData["nombreInstitucion"].ToString(),
                            Abreviacion = prodData["abreviacionInstitucion"].ToString(),
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public static bool ActualizarUsuarioVicerector(string nombre, string email, string clave, string sexo, string cargo, int fonoAnexo, int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_UsuarioVicerector", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_cargo", Direction = System.Data.ParameterDirection.Input, Value = cargo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fonoAnexo", Direction = System.Data.ParameterDirection.Input, Value = fonoAnexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static List<UsuarioAdministrador> LeerAdministradores()
        {
            List<UsuarioAdministrador> administradores = new List<UsuarioAdministrador>();
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuariosAdministradores", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var administrador = new UsuarioAdministrador()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            Sexo = prodData["sexo"].ToString(),
                            Email = prodData["email"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                            Rol = new Rol
                            {
                                Id = Convert.ToInt32(prodData["refRol"]),
                                Nombre = prodData["nombreRol"].ToString(),
                            },
                            Campus = new Campus
                            {
                                Id = Convert.ToInt32(prodData["refCampus"]),
                                Nombre = prodData["nombreCampus"].ToString()
                            },

                        };
                        administradores.Add(administrador);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return administradores;
        }

        public static bool EliminarAdministrador(int IdAdministrador)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_Administrador", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdAdministrador });
                ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static bool CrearUsuarioAdministrador(string nombre, string email, string clave, string sexo, int campus)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_UsuarioAdministrador", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_campus", Direction = System.Data.ParameterDirection.Input, Value = campus });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static UsuarioAdministrador LeerAdministrador(int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_UsuarioAdministrador", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.GetDataSet(command);

                if (datos.Tables[0].Rows.Count == 1)
                {
                    var prodData = datos.Tables[0].Rows[0];
                    return new UsuarioAdministrador()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        Nombre = prodData["nombre"].ToString(),
                        Sexo = prodData["sexo"].ToString(),
                        Email = prodData["email"].ToString(),
                        EstadoEliminacion = prodData["estadoEliminacion"].ToString(),
                        Rol = new Rol
                        {
                            Id = Convert.ToInt32(prodData["refRol"]),
                            Nombre = prodData["nombreRol"].ToString(),
                        },
                        Campus = new Campus
                        {
                            Id = Convert.ToInt32(prodData["refCampus"]),
                            Nombre = prodData["nombreCampus"].ToString()
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public static bool ActualizarUsuarioAdministrador(string nombre, string email, string clave, string sexo, int refCampus, int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_UsuarioAdministrador", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = clave });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexo", Direction = System.Data.ParameterDirection.Input, Value = sexo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refCampus", Direction = System.Data.ParameterDirection.Input, Value = refCampus });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
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