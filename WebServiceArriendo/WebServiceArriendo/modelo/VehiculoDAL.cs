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
    public class VehiculoDAL
    {
        public List<VehiculoBLL> listarVehiculo()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM VEHICULO";
            cmd.CommandType = CommandType.Text;
            List<VehiculoBLL> listaVehiculo = new List<VehiculoBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        VehiculoBLL nuevo = new VehiculoBLL();
                        nuevo.Patente = dr["PATENTE"].ToString();
                        nuevo.Modelo = dr["MODELO"].ToString();
                        nuevo.Anho = Convert.ToInt32(dr["AÑO"]);
                        nuevo.Color = dr["COLOR"].ToString();
                        nuevo.Disponible = Convert.ToInt32(dr["DISPONIBLE"]);

                        listaVehiculo.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listaVehiculo;
        }
        public int ModificarVehiculoDAL(VehiculoBLL ve)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_VEHICULO";

                cmd.Parameters.Add("p_patente", OracleDbType.Varchar2).Value = ve.Patente;
                cmd.Parameters.Add("p_modelo", OracleDbType.Varchar2).Value = ve.Modelo;
                cmd.Parameters.Add("p_año", OracleDbType.Int32).Value = ve.Anho;
                cmd.Parameters.Add("p_color", OracleDbType.Varchar2).Value = ve.Color;
                cmd.Parameters.Add("p_disponible", OracleDbType.Int32).Value = ve.Disponible;

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
        public int AgregarVehiculo(VehiculoBLL v)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_VEHICULO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_patente", OracleDbType.Varchar2).Value = v.Patente;
            cmd.Parameters.Add("p_modelo", OracleDbType.Varchar2).Value = v.Modelo;
            cmd.Parameters.Add("p_año", OracleDbType.Int32).Value = v.Anho;
            cmd.Parameters.Add("p_color", OracleDbType.Varchar2).Value = v.Color;
            cmd.Parameters.Add("p_disponible", OracleDbType.Int32).Value = v.Disponible;
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