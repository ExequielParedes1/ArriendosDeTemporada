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
    public class ListaCaracteristicasDAL
    {
        public int AgregarListaCaracteristica(ListaCaracteristicasBLL lc)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_LISTACARACTERISTICA";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = lc.idDepartamento;
            cmd.Parameters.Add("p_caracteristica_id_caracteristica", OracleDbType.Int32).Value = lc.idCaracteristica;

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
        public List<ListaCaracteristicasBLL> listarCaracteristicaBLL()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM LISTACARACTERISTICAS";
            cmd.CommandType = CommandType.Text;
            List<ListaCaracteristicasBLL> lista = new List<ListaCaracteristicasBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ListaCaracteristicasBLL nuevo = new ListaCaracteristicasBLL();
                        nuevo.idCaracteristica = Convert.ToInt32(dr["CARACTERISTICAS_ID_CARACT"]);
                        nuevo.idDepartamento = Convert.ToInt32(dr["DEPARTAMENTO_ID_DEPARTAMENTO"]);


                        lista.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return lista;
        }

        public int eliminarListaCaracteristica(ListaCaracteristicasBLL lc)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_ELIMINAR_LISTACARACTERISTICA";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = lc.idDepartamento;
            cmd.Parameters.Add("p_caracteristica_id_caracteristica", OracleDbType.Int32).Value = lc.idCaracteristica;
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