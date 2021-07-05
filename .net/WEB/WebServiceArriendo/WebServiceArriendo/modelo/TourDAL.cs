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
    public class TourDAL
    {
        //    public List<TourBLL> listarTour()
        //    {
        //        Conexion c = new Conexion();
        //        OracleConnection cnn = c.conectar();
        //        cnn.Open();
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.Connection = cnn;
        //        cmd.CommandText = "SELECT * FROM TOUR";
        //        cmd.CommandType = CommandType.Text;
        //        List<TourBLL> lista = new List<TourBLL>();
        //        using (DbDataReader dr = cmd.ExecuteReader())
        //        {
        //            if (dr.HasRows)
        //            {
        //                while (dr.Read())
        //                {
        //                    TourBLL nuevo = new TourBLL();
        //                    nuevo.idTour = Convert.ToInt32(dr["ID_TOUR"]);
        //                    nuevo.inicio = Convert.ToDateTime(dr["INICIO"]);
        //                    nuevo.inicio = Convert.ToDateTime(dr["INICIO"]);
        //                    nuevo.valor_servicio = Convert.ToInt32(dr["VALOR_SERVICIO"]);
        //                    nuevo.descripcion = dr["DESCRIPCION"].ToString();
        //                    nuevo.implicaViaje = Convert.ToInt32(dr["IMPLICA_VIAJE"]);
        //                    nuevo.disponible = Convert.ToInt32(dr["DISPONIBLE"]);

        //                    listaServicio.Add(nuevo);
        //                }
        //            }
        //        }
        //        cnn.Dispose();
        //        ((  return listaServicio;
        //    }
        //}

        //public int AgregarTourDAL(TourBLL to)
        //{
        //    /*Conexion*/
        //    Conexion c = new Conexion();
        //    OracleConnection cnn = c.conectar();
        //    cnn.Open();
        //    OracleCommand cmd = cnn.CreateCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    /*LLAMAR PROCEDIMEINTO*/
        //    cmd.CommandText = "PROCE_AGREGAR_TOUR";
        //    /*PARAMETROS*/
        //    cmd.Parameters.Add("p_inicio", OracleDbType.TimeStamp).Value = to.inicio;
        //    cmd.Parameters.Add("p_termino", OracleDbType.TimeStamp).Value = to.termino;
        //    cmd.Parameters.Add("p_origen", OracleDbType.Varchar2).Value = to.origen;
        //    cmd.Parameters.Add("p_destino", OracleDbType.Varchar2).Value = to.destino;
        //    cmd.Parameters.Add("p_rut_conductor", OracleDbType.Varchar2).Value = to.rutConductor;
        //    cmd.Parameters.Add("p_patente_vehiculo", OracleDbType.Varchar2).Value = to.patenteVehiculo;
        //    cmd.Parameters.Add("p_servicioextra_id", OracleDbType.Int32).Value = to.servicioExtraID;

        //    /*parametro de salida*/
        //    OracleParameter param = new OracleParameter();
        //    param = cmd.Parameters.Add("p_return", OracleDbType.Int32, ParameterDirection.Output);
        //    param.Size = 25;


        //    /*Terminar la conexion*/
        //    cmd.ExecuteNonQuery();
        //    int valorretorno = int.Parse(param.Value.ToString());
        //    cnn.Close();
        //    cmd.Dispose();
        //    cnn.Dispose();
        //    c = null;

        //    return valorretorno;
        //}
    }
}