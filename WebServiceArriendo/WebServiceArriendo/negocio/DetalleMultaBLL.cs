using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class DetalleMultaBLL
    {
        #region Campos
        public int id_dmulta { get; set; }
        private string objervaciones { get; set; }
        public string Objervaciones
        {
            get { return objervaciones; }
            set
            {

                if (value.Length > 0)
                {
                    objervaciones = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

        private string estadomulta { get; set; }
        public string EstadoMulta
        {
            get { return estadomulta; }
            set
            {

                if (value.Length > 0)
                {
                    estadomulta = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int reserva_id_reserva { get; set; }
        public int multa_id_multa { get; set; }

        #endregion
        #region Metodos
        public List<DetalleMultaBLL> ListarDetalleMultaBLL()
        {
            DetalleMultaDAL modelo = new DetalleMultaDAL();
            return modelo.listarDetalleMultaDAL();
        }
        public int AgregarDetalleMultaBLL(DetalleMultaBLL dm)
        {
            DetalleMultaDAL modelo = new DetalleMultaDAL();
            return modelo.AgregarDetalleMultaDAL(dm);
        }
        #endregion
    }
}