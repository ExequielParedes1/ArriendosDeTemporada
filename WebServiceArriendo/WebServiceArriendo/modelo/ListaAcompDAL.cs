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
    public class ListaAcompDAL
    {
        public int AgregarListaAcompananteDAL(ListaAcompBLL ls)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_LISTAHUESPEDES";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_acompanante_cedula", OracleDbType.Varchar2).Value = ls.cedulaAcompanante;
            cmd.Parameters.Add("p_reserva_id_reserva", OracleDbType.Int32).Value = ls.idReserva;
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
        public List<ListaAcompBLL> listadoAcompananteDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM LISTAACOMP";
            cmd.CommandType = CommandType.Text;
            List<ListaAcompBLL> lista = new List<ListaAcompBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ListaAcompBLL nuevo = new ListaAcompBLL();
                        nuevo.cedulaAcompanante = dr["ACOMPANANTE_CEDULA"].ToString();

                        nuevo.idReserva = Convert.ToInt32(dr["RESERVA_ID_RESERVA"]);


                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }

        public int EliminarListaAcompananteDAL(ListaAcompBLL lh)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_ELIMINAR_LISTAHUESPED";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_acompanante_cedula", OracleDbType.Varchar2).Value = lh.cedulaAcompanante;
            cmd.Parameters.Add("p_reserva_id_reserva", OracleDbType.Int32).Value = lh.idReserva;
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