using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaOrganizacionEstudiantil
    {
        public static List<Organizacion> LeerOrganizaciones()
        {
            try
            {
                List<Organizacion> organizaciones = new List<Organizacion>();
                var command = new MySqlCommand() { CommandText = "Leer_Organizaciones", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Organizacion organizacion = new Organizacion()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString(),
                            Email = prodData["email"].ToString(),
                            Campus = prodData["campus"].ToString(),
                            Tipo = prodData["tipo"].ToString(),
                            Estado = prodData["estado"].ToString(),
                            EstadoEliminacion = prodData["estadoEliminacion"].ToString()
                        };
                        organizaciones.Add(organizacion);
                    }
                    return organizaciones;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static List<TipoOE> Leer_TipoOE()
        {
            List<TipoOE> tiposOE = new List<TipoOE>();
            var command = new MySqlCommand() { CommandText = "Leer_TipoOE", CommandType = System.Data.CommandType.StoredProcedure };
            try
            {
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        TipoOE tipoOE = new TipoOE()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString()
                        };
                        tiposOE.Add(tipoOE);
                    }
                    return tiposOE;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static bool CrearOrganizacion(string nombre, string email, int idCampus, int idTipoOE)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Crear_OE", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombre", Direction = System.Data.ParameterDirection.Input, Value = nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipoOE", Direction = System.Data.ParameterDirection.Input, Value = idTipoOE });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_campus", Direction = System.Data.ParameterDirection.Input, Value = idCampus });
                var datos = ContexDb.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static List<Campus> Leer_Campus()
        {
            List<Campus> campus = new List<Campus>();
            var command = new MySqlCommand() { CommandText = "Leer_Campus", CommandType = System.Data.CommandType.StoredProcedure };
            try
            {
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        Campus camp = new Campus()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            Nombre = prodData["nombre"].ToString()
                        };
                        campus.Add(camp);
                    }
                    return campus;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public static int EliminarOE(int IdOE)
        {
            int result;
            try
            {
                var command = new MySqlCommand() { CommandText = "Eliminar_OE", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = IdOE });
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
