using Oracle.ManagedDataAccess.Client;
using WebServiceArriendo.conexión;
using WebServiceArriendo.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WebServiceArriendo.modelo
{
    public class RevisionDAL
    {
        public List<RevisionBLL> ListarRevisionDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM REVISION";
            cmd.CommandType = CommandType.Text;
            List<RevisionBLL> lista = new List<RevisionBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        RevisionBLL nuevo = new RevisionBLL();
                        nuevo.Estado = dr["ESTADO"].ToString();
                        nuevo.Observaciones = dr["OBSERVACIONES"].ToString();
                        nuevo.inventario_items_id_item = Convert.ToInt32(dr["INVENTARIO_ITEMS_ID_ITEM"]);
                        nuevo.inventario_depto_id_depto = Convert.ToInt32(dr["INVENTARIO_DEPTO_ID_DEPTO"]);
                        nuevo.reserva_id_reserva = Convert.ToInt32(dr["RESERVA_ID_RESERVA"]);
                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }

        public int ModificarRevisionDAL(RevisionBLL rev)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_REVISION";

                cmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = rev.Estado;
                cmd.Parameters.Add("p_observaciones", OracleDbType.Varchar2).Value = rev.Observaciones;
                cmd.Parameters.Add("p_inventario_items_id_item", OracleDbType.Int32).Value = rev.inventario_items_id_item;
                cmd.Parameters.Add("p_inventario_depto_id_depto", OracleDbType.Int32).Value = rev.inventario_depto_id_depto;
                cmd.Parameters.Add("p_reserva_id_reserva", OracleDbType.Int32).Value = rev.reserva_id_reserva;

                OracleParameter parameter = new OracleParameter();
                parameter = cmd.Parameters.Add("p_return", OracleDbType.Int32, ParameterDirection.Output);

                parameter.Size = 25;

                cmd.ExecuteNonQuery();
                int valorRetorno = int.Parse(parameter.Value.ToString());
                _conn.Close();
                cmd.Dispose();
                _conn.Dispose();

                _c = null;

                return valorRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public int AgregarRevisionDAL(RevisionBLL rev)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_REVISION";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = rev.Estado;
            cmd.Parameters.Add("p_observaciones", OracleDbType.Varchar2).Value = rev.Observaciones;
            cmd.Parameters.Add("p_inventario_items_id_item", OracleDbType.Int32).Value = rev.inventario_items_id_item;
            cmd.Parameters.Add("p_inventario_depto_id_depto", OracleDbType.Int32).Value = rev.inventario_depto_id_depto;
            cmd.Parameters.Add("p_reserva_id_reserva", OracleDbType.Int32).Value = rev.reserva_id_reserva;

            /*parametro de salida*/
            OracleParameter param = new OracleParameter();
            param = cmd.Parameters.Add("p_return", OracleDbType.Int32, ParameterDirection.Output);
            param.Size = 25;


            /*Terminar la conexion*/
            cmd.ExecuteNonQuery();
            int valorretorno = int.Parse(param.Value.ToString());
            cnn.Close();
            cmd.Dispose();
            cnn.Dispose();
            c = null;

            return valorretorno;
        }
    }
}