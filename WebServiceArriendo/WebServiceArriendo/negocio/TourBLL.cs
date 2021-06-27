using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceArriendo.negocio
{
    public class TourBLL
    {
        public int idTour { get; set; }

        private DateTime inicio { get; set; }
        public DateTime Inicio
        {
            get { return inicio; }
            set
            {

                if (value < termino)
                {
                    inicio = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private DateTime termino { get; set; }
        public DateTime Termino
        {
            get { return termino; }
            set
            {

                if (value > inicio)
                {
                    termino = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string origen { get; set; }
        public string Origen
        {
            get { return origen; }
            set
            {

                if (value.Length > 0)
                {
                    origen = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string destino { get; set; }
        public string Destino
        {
            get { return destino; }
            set
            {

                if (value.Length > 0)
                {
                    destino = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string rutConductor { get; set; }
        public string RutConductor
        {
            get { return rutConductor; }
            set
            {

                if (value.Length > 0)
                {
                    rutConductor = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string patenteVehiculo { get; set; }
        public string PatenteVehiculo
        {
            get { return patenteVehiculo; }
            set
            {

                if (value.Length > 0)
                {
                    patenteVehiculo = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int nro_participantes { get; set; }
        public int Nro_participantes
        {
            get { return nro_participantes; }
            set
            {

                if (value > 0)
                {
                    nro_participantes = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }



        //public int agregarTourBLL(TourBLL nuevo)
        //{
        //    TourDAL modelo = new TourDAL();
        //    return modelo.AgregarTourDAL(nuevo);
        //}
    }
}