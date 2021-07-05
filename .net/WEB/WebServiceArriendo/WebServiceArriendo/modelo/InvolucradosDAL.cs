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
    public class InvolucradosDAL
    {
        public int AgregarInvolucradosDAL(InvolucradoBLL inv)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_INVOLUCRADOS";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_usuario_email", OracleDbType.Varchar2).Value = inv.usuario_correo;
            cmd.Parameters.Add("p_reserva_id_reserva", OracleDbType.Int32).Value = inv.reserva_id_reserva;

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
        public List<InvolucradoBLL> listarInvolucradosBLL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM INVOLUCRADOS";
            cmd.CommandType = CommandType.Text;
            List<InvolucradoBLL> lista = new List<InvolucradoBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        InvolucradoBLL nuevo = new InvolucradoBLL();
                        nuevo.usuario_correo = dr["USUARIO_EMAIL"].ToString();
                        nuevo.reserva_id_reserva = Convert.ToInt32(dr["RESERVA_ID_RESERVA"]);


                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int EliminarInvolucradoFuncionario(InvolucradoBLL funci)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_ELIMINAR_INVOLUCRADOFUNCIONARIO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_reserva", OracleDbType.Int32).Value = funci.reserva_id_reserva;
            cmd.Parameters.Add("p_correo", OracleDbType.Varchar2).Value = funci.usuario_correo;

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