using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimRend.Models;

namespace SimRend.DbSimRend
{
    public class Usuario
    {
        public static int CrearOrganizacion(String Tipo, String Nombre, String Email, String Pass)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "crear_organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipo", Direction = System.Data.ParameterDirection.Input, Value = Tipo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_usuario", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_clave", Direction = System.Data.ParameterDirection.Input, Value = Pass });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_email", Direction = System.Data.ParameterDirection.Input, Value = Email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = "Habilitado" });
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

        public static Boolean DeshabilitarHabilitarOrganizacion(int Id, String Estado)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "crear_organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = Estado });
                var datos = ContexDb.ExecuteProcedure(command);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static Boolean CrearCAA(CAA a, int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "crear_organizacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nomDirCarrera", Direction = System.Data.ParameterDirection.Input, Value = a.NomDirCarrera });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_carrera", Direction = System.Data.ParameterDirection.Input, Value = a.Carrera });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexoDirCarrera", Direction = System.Data.ParameterDirection.Input, Value = a.SexoDirCarrera });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_cargo", Direction = System.Data.ParameterDirection.Input, Value = "" });
                var datos = ContexDb.ExecuteProcedure(command);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static Boolean CrearFederacion(Federacion f, int id)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "crear_federacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nomDirDAAE", Direction = System.Data.ParameterDirection.Input, Value = f.NomDirDAAE });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_campus", Direction = System.Data.ParameterDirection.Input, Value = f.Campus });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_sexoDirDAAE", Direction = System.Data.ParameterDirection.Input, Value = f.SexoDirDAAE });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_cargo", Direction = System.Data.ParameterDirection.Input, Value = "" });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nombreFederacion", Direction = System.Data.ParameterDirection.Input, Value = f.NombreFederacion });

                
                var datos = ContexDb.ExecuteProcedure(command);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

    }
}