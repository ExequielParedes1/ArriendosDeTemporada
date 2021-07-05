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
    public class MantencionDAL
    {
        public List<MantencionBLL> ListaMantencionDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM MANTENCION";
            cmd.CommandType = CommandType.Text;
            List<MantencionBLL> lista = new List<MantencionBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        MantencionBLL nuevo = new MantencionBLL();
                        nuevo.id_mantencion = Convert.ToInt32(dr["ID_MANTENCION"]);
                        nuevo.Varlo_total = Convert.ToInt32(dr["VALOR_TOTAL"]);
                        nuevo.Descripcion = dr["DESCRIPCION"].ToString();
                        nuevo.Fecha_inicio = Convert.ToDateTime(dr["FECHA_INICIO"]);
                        nuevo.Fecha_termino = Convert.ToDateTime(dr["FECHA_TERMINO"]);
                        nuevo.Motivo = dr["MOTIVO"].ToString();
                        nuevo.Tipo_mantencion = dr["TIPO_MANTENCION"].ToString();
                        nuevo.Encargado_rut = dr["ENCARGADO_RUT"].ToString();
                        nuevo.Departamento_id_departamento = Convert.ToInt32(dr["DEPARTAMENTO_ID_DEPARTAMENTO"]);
                        nuevo.EstadoMantencion = dr["ESTADO"].ToString();
                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int AgregarMantencionDAL(MantencionBLL ca)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_MANTENCION";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_mantencion", OracleDbType.Int32).Value = ca.id_mantencion;
            cmd.Parameters.Add("p_valor_total", OracleDbType.Int32).Value = ca.Varlo_total;
            cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = ca.Descripcion;
            cmd.Parameters.Add("p_fecha_inicio", OracleDbType.TimeStamp).Value = ca.Fecha_inicio;
            cmd.Parameters.Add("p_fecha_termino", OracleDbType.TimeStamp).Value = ca.Fecha_termino;
            cmd.Parameters.Add("p_motivo", OracleDbType.Varchar2).Value = ca.Motivo;
            cmd.Parameters.Add("p_tipo_mantencion", OracleDbType.Varchar2).Value = ca.Tipo_mantencion;
            cmd.Parameters.Add("p_encargado_rut", OracleDbType.Varchar2).Value = ca.Encargado_rut;
            cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = ca.Departamento_id_departamento;
            cmd.Parameters.Add("p_estado_mantencion", OracleDbType.Varchar2).Value = ca.EstadoMantencion;

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
        public int ModificarMantencion(MantencionBLL ve)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_MANTENCION";

                cmd.Parameters.Add("p_id_mantencion", OracleDbType.Int32).Value = ve.id_mantencion;
                cmd.Parameters.Add("p_valor_total", OracleDbType.Int32).Value = ve.Varlo_total;
                cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = ve.Descripcion;
                cmd.Parameters.Add("p_fecha_inicio", OracleDbType.TimeStamp).Value = ve.Fecha_inicio;
                cmd.Parameters.Add("p_fecha_termino", OracleDbType.TimeStamp).Value = ve.Fecha_termino;
                cmd.Parameters.Add("p_motivo", OracleDbType.Varchar2).Value = ve.Motivo;
                cmd.Parameters.Add("p_tipo_mantencion", OracleDbType.Varchar2).Value = ve.Tipo_mantencion;
                cmd.Parameters.Add("p_encargado_rut", OracleDbType.Varchar2).Value = ve.Encargado_rut;
                cmd.Parameters.Add("p_departamento_id", OracleDbType.Int32).Value = ve.Departamento_id_departamento;
                cmd.Parameters.Add("p_estado_mantencion", OracleDbType.Varchar2).Value = ve.EstadoMantencion;

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