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
    public class DetalleMultaDAL
    {
        public List<DetalleMultaBLL> listarDetalleMultaDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM DETALLEMULTA";
            cmd.CommandType = CommandType.Text;
            List<DetalleMultaBLL> lista = new List<DetalleMultaBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DetalleMultaBLL nuevo = new DetalleMultaBLL();
                        nuevo.id_dmulta = Convert.ToInt32(dr["ID_DMULTA"]);
                        nuevo.Objervaciones = dr["OBSERVACIONES"].ToString();
                        nuevo.reserva_id_reserva = Convert.ToInt32(dr["RESERVA_ID_RESERVA"]);
                        nuevo.multa_id_multa = Convert.ToInt32(dr["MULTA_ID_MULTA"]);
                        nuevo.EstadoMulta = dr["ESTADOMULTA"].ToString();

                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int AgregarDetalleMultaDAL(DetalleMultaBLL v)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_DETALLEMULTA";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_dmulta", OracleDbType.Int32).Value = v.id_dmulta;
            cmd.Parameters.Add("p_objervaciones", OracleDbType.Varchar2).Value = v.Objervaciones;
            cmd.Parameters.Add("p_reserva_id_reserva", OracleDbType.Int32).Value = v.reserva_id_reserva;
            cmd.Parameters.Add("p_multa_id_multa", OracleDbType.Int32).Value = v.multa_id_multa;
            cmd.Parameters.Add("p_estadomulta", OracleDbType.Varchar2).Value = v.EstadoMulta;

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