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
    public class ViajeDAL
    {
        public int AgregarViajeDAL(ViajeBLL v)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_VIAJE";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_viaje", OracleDbType.Int32).Value = v.id_viaje;
            cmd.Parameters.Add("p_origen", OracleDbType.Varchar2).Value = v.Origen;
            cmd.Parameters.Add("p_destino", OracleDbType.Varchar2).Value = v.Destino;
            cmd.Parameters.Add("p_comienzo", OracleDbType.TimeStamp).Value = v.Comienzo;
            cmd.Parameters.Add("p_precio", OracleDbType.Int32).Value = v.Precio;
            cmd.Parameters.Add("p_conductor_rut", OracleDbType.Varchar2).Value = v.Conductor_rut;
            cmd.Parameters.Add("p_vehiculo_patente", OracleDbType.Varchar2).Value = v.Vehiculo_patente;

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

        public List<ViajeBLL> ListarViajeDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM VIAJE";
            cmd.CommandType = CommandType.Text;
            List<ViajeBLL> listar = new List<ViajeBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ViajeBLL nuevo = new ViajeBLL();
                        nuevo.id_viaje = Convert.ToInt32(dr["ID_VIAJE"]);
                        nuevo.Origen = dr["ORIGEN"].ToString();
                        nuevo.Destino = dr["DESTINO"].ToString();
                        nuevo.Comienzo = Convert.ToDateTime(dr["COMIENZO"]);
                        nuevo.Precio = Convert.ToInt32(dr["PRECIO"]);
                        nuevo.Conductor_rut = dr["CONDUCTOR_RUT"].ToString();
                        nuevo.Vehiculo_patente = dr["VEHICULO_PATENTE"].ToString();

                        listar.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listar;
        }
        public int ModificarViaje(ViajeBLL v)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_ARRIENDO";

                cmd.Parameters.Add("p_id_viaje", OracleDbType.Int32).Value = v.id_viaje;
                cmd.Parameters.Add("p_origen", OracleDbType.Varchar2).Value = v.Origen;
                cmd.Parameters.Add("p_destino", OracleDbType.Varchar2).Value = v.Destino;
                cmd.Parameters.Add("p_comienzo", OracleDbType.TimeStamp).Value = v.Comienzo;
                cmd.Parameters.Add("p_precio", OracleDbType.Int32).Value = v.Precio;
                cmd.Parameters.Add("p_conductor_rut", OracleDbType.Varchar2).Value = v.Conductor_rut;
                cmd.Parameters.Add("p_vehiculo_patente", OracleDbType.Varchar2).Value = v.Vehiculo_patente;

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