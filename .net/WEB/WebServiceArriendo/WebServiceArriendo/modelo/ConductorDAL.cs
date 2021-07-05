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
    public class ConductorDAL
    {
        public List<ConductorBLL> listarConductor()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM CONDUCTOR";
            cmd.CommandType = CommandType.Text;
            List<ConductorBLL> listaConductor = new List<ConductorBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ConductorBLL nuevo = new ConductorBLL();
                        nuevo.Rut = dr["RUT"].ToString();
                        nuevo.Nombre = dr["NOMBRE"].ToString();
                        nuevo.Apellido = dr["APELLIDO"].ToString();
                        nuevo.Disponible = Convert.ToInt32(dr["DISPONIBLE"]);
                        nuevo.Email = dr["EMAIL"].ToString();
                        nuevo.Telefono = Convert.ToInt32(dr["NRO_CONTACTO"]);
                        listaConductor.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listaConductor;
        }
        public int ModificarConductorDAL(ConductorBLL ve)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_CONDUCTOR";

                cmd.Parameters.Add("p_rut", OracleDbType.Varchar2).Value = ve.Rut;
                cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = ve.Nombre;
                cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = ve.Apellido;
                cmd.Parameters.Add("p_disponible", OracleDbType.Int32).Value = ve.Disponible;
                cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = ve.Email;
                cmd.Parameters.Add("p_nro_contacto", OracleDbType.Int32).Value = ve.Telefono;

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

        public int AgregarConductor(ConductorBLL ch)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_CONDUCTOR";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_rut", OracleDbType.Varchar2).Value = ch.Rut;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = ch.Nombre;
            cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = ch.Apellido;
            cmd.Parameters.Add("p_disponible", OracleDbType.Varchar2).Value = ch.Disponible;
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = ch.Email;
            cmd.Parameters.Add("p_nro_contacto", OracleDbType.Int32).Value = ch.Telefono;
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