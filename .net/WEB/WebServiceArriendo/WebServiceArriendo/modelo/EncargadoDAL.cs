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
    public class EncargadoDAL
    {
        public List<EncargadoBLL> ListarEncargadoDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM ENCARGADO";
            cmd.CommandType = CommandType.Text;
            List<EncargadoBLL> lista = new List<EncargadoBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EncargadoBLL nuevo = new EncargadoBLL();
                        nuevo.Rut = dr["RUT"].ToString();
                        nuevo.Nro_contacto = Convert.ToInt32(dr["NRO_CONTACTO"]);
                        nuevo.Nombre = dr["NOMBRE"].ToString();
                        nuevo.Apellido = dr["APELLIDO"].ToString();
                        nuevo.Email = dr["EMAIL"].ToString();

                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int ModificarEncargadoDAL(EncargadoBLL ve)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_ENCARGADO";

                cmd.Parameters.Add("p_rut", OracleDbType.Varchar2).Value = ve.Rut;
                cmd.Parameters.Add("p_nro_contacto", OracleDbType.Int32).Value = ve.Nro_contacto;
                cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = ve.Nombre;
                cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = ve.Apellido;
                cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = ve.Email;

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
        public int AgregarEncargadoDAL(EncargadoBLL v)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_ENCARGADO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_rut", OracleDbType.Varchar2).Value = v.Rut;
            cmd.Parameters.Add("p_nro_contacto", OracleDbType.Int32).Value = v.Nro_contacto;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = v.Nombre;
            cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = v.Apellido;
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = v.Email;
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