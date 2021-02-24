using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using SimRend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.DbSimRend
{
    public class ConsultaDeclaracionGastos
    {
        /*#############################################Leer######################################################*/
        /// <summary>
        /// Muestra los datos de la declaracion de gastos en base al id de esta
        /// </summary>
        /// <param name="RefDeclaracionGastos"></param>
        /// <returns>Devuelve los datos principales de la declaracion de gastos que son la fecha limite del evento, el monto total de la documentacion guardada y el monto total de los documentos seleccionados a rendir. En caso de que exista algun problema, devuelve un null.</returns>
        public static DeclaracionGastos LeerDeclaracionGastos(int RefDeclaracionGastos)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_Declaracion_Gastos", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refDeclaracionGastos", Direction = System.Data.ParameterDirection.Input, Value = RefDeclaracionGastos });
                var datos = ContexDb.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    DeclaracionGastos declaracionGastos;
                    var prodData = datos.Tables[0].Rows[0];
                    declaracionGastos = new DeclaracionGastos()
                    {
                        Id = Convert.ToInt32(prodData["id"]),
                        FechaLimite = Convert.ToDateTime(prodData["fechaLimite"]),
                        TotalDocumentacion = Convert.ToInt32(prodData["totalDocumentacion"]),
                        TotalRendido = Convert.ToInt32(prodData["totalRendido"])
                    };
                    return declaracionGastos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        public static List<Persona> LeerDocumentos(int refDeclaracionGastos, List<Persona> participantes, List<Categoria> Categorias)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Leer_documentos_DG", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refDeclaracionGastos", Direction = System.Data.ParameterDirection.Input, Value = refDeclaracionGastos });
                var datos = ContexDb.GetDataSet(command);
                List<Documento> documentos = new List<Documento>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        String refPaticipante = prodData["refParticipante"].ToString();
                        Documento documento = new Documento()
                        {
                            Id = Convert.ToInt32(prodData["id"]),
                            CodigoDocumento = prodData["codigoDocumento"].ToString(),
                            Proveedor = prodData["proveedor"].ToString(),
                            FechaDocumento = Convert.ToDateTime(prodData["fecha"]),
                            Monto = Convert.ToInt32(prodData["monto"]),
                            DescripcionDocumento = prodData["descripcion"].ToString(),
                            TipoDocumento = prodData["tipo"].ToString(),
                            CopiaDoc = prodData["copiaDoc"].ToString(),
                            Categoria = Categorias.Find(categoria => categoria.Id == Convert.ToInt32(prodData["refCategoria"])),
                            Estado = Convert.ToInt32(prodData["estado"])
                        };

                        if (participantes.Find(participante => participante.RUN.Equals(refPaticipante)).Documentos == null)
                        {
                            participantes.Find(participante => participante.RUN.Equals(refPaticipante)).Documentos = new List<Documento>();
                        }

                        participantes.Find(participante => participante.RUN.Equals(refPaticipante)).Documentos.Add(documento);
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

        public static int EliminarDocumento(int idDocumento)
        {
            try
            {

                var command = new MySqlCommand() { CommandText = "Eliminar_documento", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = idDocumento });
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

        public static int CrearDocumento(Documento DocumentoAux, String RefParticipante, int RefDeclaracionGastos)
        {
            try
            {
                if(RefParticipante.Equals("-1"))
                {
                    RefParticipante = null;
                }

                var command = new MySqlCommand() { CommandText = "Crear_Documento", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoDocumento", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.CodigoDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_proveedor", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.Proveedor });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaDocumento", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.FechaDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_monto", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.Monto });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_descripcionDocumento", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.DescripcionDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipoDocumento", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.TipoDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_copiaDoc", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.CopiaDoc });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refCategoria", Direction = System.Data.ParameterDirection.Input, Value = DocumentoAux.Categoria.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refParticipante", Direction = System.Data.ParameterDirection.Input, Value = RefParticipante });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refDeclaracionGastos", Direction = System.Data.ParameterDirection.Input, Value = RefDeclaracionGastos });
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

        public static int DocumentoSeleccionado(int Estado, int IdDocumento)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Modificar_seleccion_documento", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_idDocumento", Direction = System.Data.ParameterDirection.Input, Value = IdDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = Estado });
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

        internal static int ModificarDocumento(Documento Documento)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "Actualizar_documento", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_id", Direction = System.Data.ParameterDirection.Input, Value = Documento.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigoDocumento", Direction = System.Data.ParameterDirection.Input, Value = Documento.CodigoDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_proveedor", Direction = System.Data.ParameterDirection.Input, Value = Documento.Proveedor });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_fechaDocumento", Direction = System.Data.ParameterDirection.Input, Value = Documento.FechaDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_monto", Direction = System.Data.ParameterDirection.Input, Value = Documento.Monto });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_descripcionDocumento", Direction = System.Data.ParameterDirection.Input, Value = Documento.DescripcionDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tipoDocumento", Direction = System.Data.ParameterDirection.Input, Value = Documento.TipoDocumento });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_copiaDoc", Direction = System.Data.ParameterDirection.Input, Value = Documento.CopiaDoc });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_refCategoria", Direction = System.Data.ParameterDirection.Input, Value = Documento.Categoria.Id });
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


        /*###########################################Fin leer####################################################*/
    }
}
