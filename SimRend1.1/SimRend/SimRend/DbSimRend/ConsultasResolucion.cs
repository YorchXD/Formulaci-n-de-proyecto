using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SimRend.Models;

namespace SimRend.DbSimRend
{
    public class ConsultaResolucion
    {
        /*#############################################Crear Resolucion|######################################################*/
        public static int CrearResolucion(Resolucion resolucion)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "crear_resolucion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idResolucion", Direction = System.Data.ParameterDirection.Input, Value = resolucion.NumeroResolucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_anio", Direction = System.Data.ParameterDirection.Input, Value = resolucion.AnioResolucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_copiaDocumento", Direction = System.Data.ParameterDirection.Input, Value = resolucion.CopiaDocumento });
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

        public static void Agregar_Resol_ProcFondo(int refResolucion, int refProceso, int estado)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "agregar_resol_ProcFondo", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refResolucion", Direction = System.Data.ParameterDirection.Input, Value = refResolucion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refProceso", Direction = System.Data.ParameterDirection.Input, Value = refProceso });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = estado});
                var datos = ContexDb.ExecuteProcedure(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /*###########################################Fin crear Resolucion####################################################*/

        /*#############################################Leer Resolucion########################################################*/

        /*###########################################Fin leer Resolucion######################################################*/

        /*#############################################Actualizar Resolucion##################################################*/

        /*###########################################Fin actualizar Resolucion################################################*/

        /*##############################################Eliminar Resolucion##################################################*/

        /*############################################Fin eliminar Resolucion################################################*/

    }
}