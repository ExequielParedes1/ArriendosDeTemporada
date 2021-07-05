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
    public class MultaDAL
    {
        public int AgregarMultaDAL(MultaBLL mul)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_MULTA";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_multa", OracleDbType.Int32).Value = mul.idMulta;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = mul.Nombre;
            cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = mul.Descripcion;
            cmd.Parameters.Add("p_valor", OracleDbType.Int32).Value = mul.Valor;
            cmd.Parameters.Add("p_estado_multa", OracleDbType.Varchar2).Value = mul.Estado_Multa;

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
        public List<MultaBLL> listarMultaBLL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM MULTA";
            cmd.CommandType = CommandType.Text;
            List<MultaBLL> lista = new List<MultaBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        MultaBLL nuevo = new MultaBLL();
                        nuevo.idMulta = Convert.ToInt32(dr["ID_MULTA"]);
                        nuevo.Nombre = dr["NOMBRE"].ToString();
                        nuevo.Descripcion = dr["DESCRIPCION"].ToString();
                        nuevo.Valor = Convert.ToInt32(dr["VALOR"]);
                        nuevo.Estado_Multa = dr["ESTADO_MULTA"].ToString();

                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int ModificarMultaDAL(MultaBLL mul)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_MULTA";

                cmd.Parameters.Add("p_id_multa", OracleDbType.Int32).Value = mul.idMulta;
                cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = mul.Nombre;
                cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = mul.Descripcion;
                cmd.Parameters.Add("p_valor", OracleDbType.Int32).Value = mul.Valor;
                cmd.Parameters.Add("p_estado_multa", OracleDbType.Varchar2).Value = mul.Estado_Multa;

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
    }
}
    