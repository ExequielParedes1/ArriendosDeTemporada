using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using WebServiceArriendo.conexión;
using WebServiceArriendo.negocio;
using System.Data;
using System.Data.Common;

namespace WebServiceArriendo.modelo
{
    public class CaracteristicaDAL
    {
       
            public List<CaracteristicaBLL> listarCaracteristica()
            {
                conexion c = new conexion();
                OracleConnection cnn = c.conectar();
                cnn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT * FROM CARACTERISTICAS";
                cmd.CommandType = CommandType.Text;
                List<CaracteristicaBLL> lista = new List<CaracteristicaBLL>();
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            CaracteristicaBLL nuevo = new CaracteristicaBLL();
                            nuevo.idCaracteristica = Convert.ToInt32(dr["ID_CARACTERISTICA"]);
                            nuevo.Nombre = dr["NOMBRE"].ToString();
                            nuevo.Descripcion = dr["DESCRIPCION"].ToString();

                            lista.Add(nuevo);
                        }
                    }
                }
                cnn.Dispose();
                return lista;
            }

            public int ModificarCaracteristicaDAL(CaracteristicaBLL ca)
            {
                try
                {
                    conexion _c = new conexion();
                    OracleConnection _conn = _c.conectar();
                    _conn.Open();

                    OracleCommand cmd = _conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "PROCE_MODIFICAR_CARACTERISTICA";

                    cmd.Parameters.Add("p_id_caracteristica", OracleDbType.Int32).Value = ca.idCaracteristica;
                    cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = ca.Nombre;
                    cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = ca.Descripcion;

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

            public int AgregarCaracteristica(CaracteristicaBLL ca)
            {
                /*Conexion*/
                conexion c = new conexion();
                OracleConnection cnn = c.conectar();
                cnn.Open();
                OracleCommand cmd = cnn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                /*LLAMAR PROCEDIMEINTO*/
                cmd.CommandText = "PROCE_AGREGAR_CARACTERISTICA";
                /*PARAMETROS*/
                cmd.Parameters.Add("p_id_caracteristica", OracleDbType.Int32).Value = ca.idCaracteristica;
                cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = ca.Nombre;
                cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = ca.Descripcion;

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

            public int EliminarCaracteristica(int idCaracteristica)
            {
                /*Conexion*/
                conexion c = new conexion();
                OracleConnection cnn = c.conectar();
                cnn.Open();
                OracleCommand cmd = cnn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                /*LLAMAR PROCEDIMEINTO*/
                cmd.CommandText = "PROCE_ELIMINAR_CARACTERISTICA";
                /*PARAMETROS*/
                cmd.Parameters.Add("p_id_caracteristica", OracleDbType.Int32).Value = idCaracteristica;

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
            //public List<CaracteristicaBLL> listarCaracteristicaPrueba()
            //{
            //    Conexion c = new Conexion();
            //    OracleConnection cnn = c.conectar();
            //    cnn.Open();
            //    OracleCommand cmd = new OracleCommand();
            //    cmd.Connection = cnn;
            //    cmd.CommandText = "PROCE_LISTAR_CARACTERISTICA";
            //    cmd.CommandType = CommandType.Text;
            //    List<CaracteristicaBLL> lista = new List<CaracteristicaBLL>();
            //    using (DbDataReader dr = cmd.ExecuteReader())
            //    {
            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //            {
            //                CaracteristicaBLL nuevo = new CaracteristicaBLL();
            //                nuevo.idCaracteristica = Convert.ToInt32(dr["p_id"]);


            //                lista.Add(nuevo);
            //            }
            //        }
            //    }
            //    cnn.Dispose();
            //    return lista;
            //}
        }
    }
