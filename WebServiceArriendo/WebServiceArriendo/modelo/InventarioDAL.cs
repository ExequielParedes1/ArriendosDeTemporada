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
    public class InventarioDAL
    {
        public int AgregarRegistroInventarioDAL(InventarioBLL r)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_INVENTARIO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_fecha_asignacion", OracleDbType.TimeStamp).Value = r.Fecha_asignacion;
            cmd.Parameters.Add("p_ultima_modificacion", OracleDbType.TimeStamp).Value = r.fecha_ultima_moficacion;
            cmd.Parameters.Add("p_cantidad", OracleDbType.Int32).Value = r.Cantidad;
            cmd.Parameters.Add("p_item_id_item", OracleDbType.Int32).Value = r.Id_item_id;
            cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = r.Id_departamento_id;
            cmd.Parameters.Add("p_valor_total", OracleDbType.Int32).Value = r.Valor_total;

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
        public List<InventarioBLL> ListarRegistronInventarioDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM INVENTARIO";
            cmd.CommandType = CommandType.Text;
            List<InventarioBLL> lista = new List<InventarioBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        InventarioBLL nuevo = new InventarioBLL();
                        nuevo.Fecha_asignacion = Convert.ToDateTime(dr["FECHA_ASIGNACION"]);
                        nuevo.fecha_ultima_moficacion = Convert.ToDateTime(dr["FECHA_ULTIMA_MODIFICACION"]);
                        nuevo.Id_item_id = Convert.ToInt32(dr["ITEMS_ID_ITEM"]);
                        nuevo.Cantidad = Convert.ToInt32(dr["CANTIDAD"]);
                        nuevo.Id_departamento_id = Convert.ToInt32(dr["DEPARTAMENTO_ID_DEPARTAMENTO"]);
                        nuevo.Valor_total = Convert.ToInt32(dr["VALOR_TOTAL"]);



                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int eliminarInventarioDAL(InventarioBLL li)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_ELIMINAR_INVENTARIO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = li.Id_departamento_id;
            cmd.Parameters.Add("p_items_id_items", OracleDbType.Int32).Value = li.Id_item_id;
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

        public int modificarInventarioDAL(InventarioBLL inv)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_INVENTARIO";

                cmd.Parameters.Add("p_fecha_asignacion", OracleDbType.TimeStamp).Value = inv.Fecha_asignacion;
                cmd.Parameters.Add("p_fecha_ultima_moficacion", OracleDbType.TimeStamp).Value = inv.fecha_ultima_moficacion;
                cmd.Parameters.Add("p_cantidad", OracleDbType.Int32).Value = inv.Cantidad;
                cmd.Parameters.Add("p_items_id_items", OracleDbType.Int32).Value = inv.Id_item_id;
                cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = inv.Id_departamento_id;
                cmd.Parameters.Add("p_valor_total", OracleDbType.Int32).Value = inv.Valor_total;

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