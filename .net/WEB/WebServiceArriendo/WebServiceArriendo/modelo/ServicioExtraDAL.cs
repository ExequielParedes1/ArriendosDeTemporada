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
    public class ServicioExtraDAL
    {
        public int AgregarServicioExtraDAL(ServicioExtraBLL se)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_SERVICIOEXTRA";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_servicio", OracleDbType.Int32).Value = se.id_servicio_extra;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = se.Nombre_servicio;
            cmd.Parameters.Add("p_valor", OracleDbType.Int32).Value = se.Valor_servicio;
            cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = se.Descripcion;
            cmd.Parameters.Add("p_disponible", OracleDbType.Int32).Value = se.Disponible;


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

        public List<ServicioExtraBLL> listarServicioExtraDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM SERVICIOEXTRA";
            cmd.CommandType = CommandType.Text;
            List<ServicioExtraBLL> listar = new List<ServicioExtraBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ServicioExtraBLL nuevo = new ServicioExtraBLL();
                        nuevo.id_servicio_extra = Convert.ToInt32(dr["ID_SERVICIO"]);
                        nuevo.Nombre_servicio = dr["NOMBRE_SERVICIO"].ToString();
                        nuevo.Valor_servicio = Convert.ToInt32(dr["VALOR_SERVICIO"]);
                        nuevo.Descripcion = dr["DESCRIPCION"].ToString();
                        nuevo.Disponible = Convert.ToInt32(dr["DISPONIBLE"]);


                        listar.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listar;
        }
        public int ModificarServicioExtraDAL(ServicioExtraBLL se)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_SERVICIOEXTRA";

                cmd.Parameters.Add("p_id_servicio", OracleDbType.Int32).Value = se.id_servicio_extra;
                cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = se.Nombre_servicio;
                cmd.Parameters.Add("p_valor", OracleDbType.Int32).Value = se.Valor_servicio;
                cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = se.Descripcion;
                cmd.Parameters.Add("p_disponible", OracleDbType.Int32).Value = se.Disponible;
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