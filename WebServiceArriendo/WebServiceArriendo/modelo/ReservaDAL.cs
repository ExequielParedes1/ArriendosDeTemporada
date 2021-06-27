using Oracle.ManagedDataAccess.Client;
using WebServiceArriendo.conexión;
using WebServiceArriendo.negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace WebServiceArriendo.modelo
{
    public class ReservaDAL
    {
        public int AgregarReservaDAL(ReservaBLL ar)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_ARRIENDO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_reserva", OracleDbType.Int32).Value = ar.id_reserva;
            cmd.Parameters.Add("p_dias_reserva", OracleDbType.Int32).Value = ar.Dias_reserva;
            cmd.Parameters.Add("p_valor_final", OracleDbType.Int32).Value = ar.Valor_final;
            cmd.Parameters.Add("p_checkin", OracleDbType.TimeStamp).Value = ar.Check_in;
            cmd.Parameters.Add("p_checkout", OracleDbType.TimeStamp).Value = ar.Check_Out;
            cmd.Parameters.Add("p_total_multas", OracleDbType.Int32).Value = ar.Total_multas;
            cmd.Parameters.Add("p_fecha_contrato", OracleDbType.TimeStamp).Value = ar.Fecha_contrato;
            cmd.Parameters.Add("p_metodo_pago", OracleDbType.Varchar2).Value = ar.Metodo_pago;
            cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = ar.Departamento_id_departamento;
            cmd.Parameters.Add("p_anticipo", OracleDbType.Int32).Value = ar.Anticipo;
            cmd.Parameters.Add("p_estadopago", OracleDbType.Varchar2).Value = ar.Estado_pago;
            cmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = ar.Estado;
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

        public List<ReservaBLL> listarReserva()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM RESERVA";
            cmd.CommandType = CommandType.Text;
            List<ReservaBLL> listar = new List<ReservaBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ReservaBLL nuevo = new ReservaBLL();
                        nuevo.id_reserva = Convert.ToInt32(dr["ID_RESERVA"]);
                        nuevo.Dias_reserva = Convert.ToInt32(dr["DIAS_RESERVA"]);
                        nuevo.Valor_final = Convert.ToInt32(dr["VALOR_FINAL"]);
                        nuevo.Check_in = Convert.ToDateTime(dr["CHECKIN"]);
                        nuevo.Check_Out = Convert.ToDateTime(dr["CHECKOUT"]);
                        nuevo.Total_multas = Convert.ToInt32(dr["TOTAL_MULTAS"]);
                        nuevo.Fecha_contrato = Convert.ToDateTime(dr["FECHA_CONTRATO"]);
                        nuevo.Metodo_pago = dr["METODO_PAGO"].ToString();
                        nuevo.Departamento_id_departamento = Convert.ToInt32(dr["DEPARTAMENTO_ID_DEPARTAMENTO"]);
                        nuevo.Anticipo = Convert.ToInt32(dr["ANTICIPO"]);
                        nuevo.Estado_pago = dr["ESTADODEPAGO"].ToString();
                        nuevo.Estado = dr["ESTADO"].ToString();
                        listar.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listar;
        }
        public int ModificarReserva(ReservaBLL ar)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_ARRIENDO";

                cmd.Parameters.Add("p_id_reserva", OracleDbType.Int32).Value = ar.id_reserva;
                cmd.Parameters.Add("p_dias_reserva", OracleDbType.Int32).Value = ar.Dias_reserva;
                cmd.Parameters.Add("p_valor_final", OracleDbType.Int32).Value = ar.Valor_final;
                cmd.Parameters.Add("p_checkin", OracleDbType.TimeStamp).Value = ar.Check_in;
                cmd.Parameters.Add("p_checkout", OracleDbType.TimeStamp).Value = ar.Check_Out;
                cmd.Parameters.Add("p_total_multas", OracleDbType.Int32).Value = ar.Total_multas;
                cmd.Parameters.Add("p_fecha_contrato", OracleDbType.TimeStamp).Value = ar.Fecha_contrato;
                cmd.Parameters.Add("p_metodo_pago", OracleDbType.Varchar2).Value = ar.Metodo_pago;
                cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = ar.Departamento_id_departamento;
                cmd.Parameters.Add("p_anticipo", OracleDbType.Int32).Value = ar.Anticipo;
                cmd.Parameters.Add("p_estadopago", OracleDbType.Varchar2).Value = ar.Estado_pago;
                cmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = ar.Estado;

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
