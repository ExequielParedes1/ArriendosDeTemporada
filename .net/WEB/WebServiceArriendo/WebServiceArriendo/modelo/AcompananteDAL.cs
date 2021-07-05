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
    public class AcompananteDAL
    {
        public int AgregarAcompananteDAL(AcompananteBLL h)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_HUESPED";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_cedula", OracleDbType.Varchar2).Value = h.Cedula;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = h.Nombre;
            cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = h.Apellido;
            cmd.Parameters.Add("p_telefono", OracleDbType.Int32).Value = h.Telefono;

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
        public List<AcompananteBLL> ListarAcompanantesDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM ACOMPANANTE";
            cmd.CommandType = CommandType.Text;
            List<AcompananteBLL> lista = new List<AcompananteBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        AcompananteBLL nuevo = new AcompananteBLL();
                        nuevo.Cedula = dr["CEDULA"].ToString();
                        nuevo.Nombre = dr["NOMBRE"].ToString();
                        nuevo.Apellido = dr["APELLIDO"].ToString();
                        nuevo.Telefono = Convert.ToInt32(dr["TELEFONO"]);


                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int EliminarAcompananteDAL(string rut)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_ELIMINAR_HUESPED";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_acompanante_cedula", OracleDbType.Varchar2).Value = rut;
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

        public int ModificarAcompananteDAL(AcompananteBLL ve)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_HUESPED";

                cmd.Parameters.Add("p_cedula", OracleDbType.Varchar2).Value = ve.Cedula;
                cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = ve.Nombre;
                cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = ve.Apellido;
                cmd.Parameters.Add("p_telefono", OracleDbType.Int32).Value = ve.Telefono;


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