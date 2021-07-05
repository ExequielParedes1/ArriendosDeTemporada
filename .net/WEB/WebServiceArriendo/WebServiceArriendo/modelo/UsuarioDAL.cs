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
    public class UsuarioDAL
    {
        public List<UsuarioBLL> listarUsuario()
        {
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM USUARIO";
            cmd.CommandType = CommandType.Text;
            List<UsuarioBLL> listaUsuarios = new List<UsuarioBLL>();
            using (DbDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioBLL nuevo = new UsuarioBLL();
                        nuevo.Correo = dr["EMAIL"].ToString();
                        nuevo.Cedula = dr["CEDULA"].ToString();
                        nuevo.Nombre = dr["NOMBRE"].ToString();
                        nuevo.Apellido = dr["APELLIDO"].ToString();
                        nuevo.NumeroContacto = Convert.ToInt32(dr["TELEFONO"]);
                        nuevo.Estado = dr["ESTADO"].ToString();
                        nuevo.Contrasenha = dr["PASSWORD"].ToString();
                        nuevo.Tipo = dr["TIPO"].ToString();

                        listaUsuarios.Add(nuevo);
                    }
                }
            }
            cnn.Dispose();
            return listaUsuarios;
        }
        public int ModificarUsuarioDAL(UsuarioBLL usr)
        {
            try
            {
                conexion _c = new conexion();
                OracleConnection _conn = _c.conectar();
                _conn.Open();

                OracleCommand cmd = _conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "PROCE_MODIFICAR_USUARIO";

                cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = usr.Correo;
                cmd.Parameters.Add("p_cedula", OracleDbType.Varchar2).Value = usr.Cedula;
                cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = usr.Nombre;
                cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = usr.Apellido;
                cmd.Parameters.Add("p_telefono", OracleDbType.Int32).Value = usr.NumeroContacto;
                cmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = usr.Estado;
                cmd.Parameters.Add("p_tipo", OracleDbType.Varchar2).Value = usr.Tipo;
                cmd.Parameters.Add("p_password", OracleDbType.Varchar2).Value = usr.Contrasenha;

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
        public int AgregarUsuario(UsuarioBLL us)
        {
            /*Conexion*/
            conexion c = new conexion();
            OracleConnection cnn = c.conectar();
            cnn.Open();
            OracleCommand cmd = cnn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            /*LLAMAR PROCEDIMEINTO*/
            cmd.CommandText = "PROCE_AGREGAR_USUARIO";
            /*PARAMETROS*/
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = us.Correo;
            cmd.Parameters.Add("p_cedula", OracleDbType.Varchar2).Value = us.Cedula;
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = us.Nombre;
            cmd.Parameters.Add("p_apellido", OracleDbType.Varchar2).Value = us.Apellido;
            cmd.Parameters.Add("p_telefono", OracleDbType.Int32).Value = us.NumeroContacto;
            cmd.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = us.Estado;
            cmd.Parameters.Add("p_password", OracleDbType.Varchar2).Value = us.Contrasenha;
            cmd.Parameters.Add("p_tipo", OracleDbType.Varchar2).Value = us.Tipo;


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