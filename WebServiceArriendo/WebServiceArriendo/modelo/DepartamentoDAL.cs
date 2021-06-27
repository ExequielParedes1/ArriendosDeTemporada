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
    public class DepartamentoDAL
    {
        public List<DepartamentoBLL> listarDepartamento()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM DEPARTAMENTO";
            cmd.CommandType = CommandType.Text;
            List<DepartamentoBLL> listaDepartamento = new List<DepartamentoBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DepartamentoBLL nuevo = new DepartamentoBLL();
                        nuevo.idDepartamento = Convert.ToInt32(dr["ID_DEPARTAMENTO"]);
                        nuevo.Direccion = dr["DIRECCION"].ToString();
                        nuevo.MtrsCuadrados = Convert.ToInt32(dr["METROS_CUADRADOS"]);
                        nuevo.ValorDiario = Convert.ToInt32(dr["VALOR_ARRIENDO_DIARIO"]);
                        nuevo.Disponible = Convert.ToInt32(dr["DISPONBILE"]);
                        nuevo.Zona = dr["ZONA"].ToString();
                        nuevo.Nro_habitaciones = Convert.ToInt32(dr["NRO_HABITACIONES"]);
                        nuevo.Nro_banhos = Convert.ToInt32(dr["NRO_BANIOS"]);
                        listaDepartamento.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listaDepartamento;
        }

        public int AgregarDepartamentoDAL(DepartamentoBLL us)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_DEPARTAMENTO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = us.Direccion;
            cmd.Parameters.Add("p_metros_cuadrados", OracleDbType.Int32).Value = us.MtrsCuadrados;
            cmd.Parameters.Add("p_valor_arriendo_diario", OracleDbType.Int32).Value = us.ValorDiario;
            cmd.Parameters.Add("p_disponible", OracleDbType.Int32).Value = us.Disponible;
            cmd.Parameters.Add("p_zona", OracleDbType.Varchar2).Value = us.Zona;
            cmd.Parameters.Add("p_nro_habitaciones", OracleDbType.Int32).Value = us.Nro_habitaciones;
            cmd.Parameters.Add("p_nro_banios", OracleDbType.Varchar2).Value = us.Nro_banhos;

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
        public int ModificarDepartamentoDAL(DepartamentoBLL dpto)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_DEPARTAMENTO";

                cmd.Parameters.Add("p_id_departamento", OracleDbType.Int32).Value = dpto.idDepartamento;
                cmd.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = dpto.Direccion;
                cmd.Parameters.Add("p_metros_cuadrados", OracleDbType.Int32).Value = dpto.MtrsCuadrados;
                cmd.Parameters.Add("p_valor_arriendo_diario", OracleDbType.Int32).Value = dpto.ValorDiario;
                cmd.Parameters.Add("p_disponible", OracleDbType.Int32).Value = dpto.Disponible;
                cmd.Parameters.Add("p_zona", OracleDbType.Varchar2).Value = dpto.Zona;
                cmd.Parameters.Add("p_nro_habitaciones", OracleDbType.Int32).Value = dpto.Nro_habitaciones;
                cmd.Parameters.Add("p_nro_banios", OracleDbType.Int32).Value = dpto.Nro_banhos;

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