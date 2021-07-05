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
    public class ItemDAL
    {
        public int AgregarItemDAL(ItemBLL it)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_ITEM";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_item", OracleDbType.Int32).Value = it.id_item;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = it.Nombre;
            cmd.Parameters.Add("p_valor", OracleDbType.Int32).Value = it.Valor;

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
        public List<ItemBLL> ListarItemDAL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM ITEMS";
            cmd.CommandType = CommandType.Text;
            List<ItemBLL> lista = new List<ItemBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ItemBLL nuevo = new ItemBLL();
                        nuevo.id_item = Convert.ToInt32(dr["ID_ITEM"]);
                        nuevo.Nombre = dr["NOMBRE"].ToString();
                        nuevo.Valor = Convert.ToInt32(dr["VALOR"]);

                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }
        public int EliminarItemDAL(int idItem)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_ELIMINAR_ITEMS";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_item", OracleDbType.Varchar2).Value = idItem;
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