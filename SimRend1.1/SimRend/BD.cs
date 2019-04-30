using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace plan_de_clases.Data
{
    public class DataSource
    {
        private static string connStr = "SERVER=<TU SERVIDOR>;DATABASE=<TU BD>;UID=<iD DE USUARIO>;PASSWORD=<PASS>;SslMode=none;CHARSET=utf8;";

        public static DataSet GetDataSet(MySqlCommand command)
        {
            var ds = new DataSet();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                command.Connection = conn;
                var sqlda = new MySqlDataAdapter(command);
                sqlda.Fill(ds);
                conn.Close();
            }
            return ds;
        }

        /*
         * Ejecuta el commando y lo retorna (en caso de que se requiera revisar parametros de salida).
         * El comando tiene que corresponder con algún procedure existente en la base de datos.
         */
        public static MySqlCommand ExecuteProcedure(MySqlCommand command)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var sqlTran = conn.BeginTransaction();
                try
                {
                    command.Connection = conn;
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    Console.WriteLine(ex.ToString());
                    command = null;
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            return command;
        }
    }
}