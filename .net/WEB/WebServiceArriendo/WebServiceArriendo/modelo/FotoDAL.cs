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
    public class FotoDAL
    {
        public int AgregarFotoDAL(FotoBLL fo)
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_FOTO";
            cmd.Parameters.Add("p_id_foto", OracleDbType.Int32).Value = fo.id_foto;
            cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = fo.Descripcion;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = fo.Nombre;
            cmd.Parameters.Add("p_departamento_id_departamento", OracleDbType.Int32).Value = fo.Id_departamento_id;
            cmd.Parameters.Add("p_imagen", OracleDbType.Blob).Value = fo.Url;


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
        public List<FotoBLL> listarImagenes()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM FOTO";
            cmd.CommandType = CommandType.Text;
            List<FotoBLL> listar = new List<FotoBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FotoBLL nuevo = new FotoBLL();
                        nuevo.id_foto = Convert.ToInt32(dr["ID_FOTO"]);
                        nuevo.Descripcion = dr["DESCRIPCION"].ToString();
                        nuevo.Nombre = dr["NOMBRE"].ToString();
                        nuevo.Id_departamento_id = Convert.ToInt32(dr["DEPARTAMENTO_ID_DEPARTAMENTO"]);
                        nuevo.Url = (byte[])dr["IMAGEN"];

                        listar.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listar;
        }

        public int EliminarFotoDAL(int id_foto)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_ELIMINAR_FOTO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_id_foto", OracleDbType.Int32).Value = id_foto;

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