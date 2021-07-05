using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class TourBLL
    {
        public DateTime inicio { get; set; }
        public DateTime _inicio
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
        public DateTime termino { get; set; }
        public DateTime _termino
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
        public string origen { get; set; }
        public string _origen
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
        public string destino { get; set; }
        public string _destino
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
        public string rutConductor { get; set; }
        public string _rutConductor
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
        public string patenteVehiculo { get; set; }
        public string _patenteVehiculo
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
        public string servicioExtraID { get; set; }
        public string _servicioExtraID
        {
            get { return servicioExtraID; }
            set
            {

                if (value.Length > 0)
                {
                    servicioExtraID = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int idTour { get; set; }
        public int _idTour
        {
            get { return idTour; }
            set
            {

                if (value > 0)
                {
                    idTour = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }


       
    }
}