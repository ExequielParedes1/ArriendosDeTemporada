using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class ViajeBLL
    {
        public int id_viaje { get; set; }
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
                    throw new Exception("¡Dato Inicorrecto!");

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
                    throw new Exception("¡Dato Inicorrecto!");

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
                    throw new Exception("¡Dato Inicorrecto!");

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
                    throw new Exception("¡Dato Inicorrecto!");

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
                    throw new Exception("¡Dato Inicorrecto!");

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
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }
        public int id_arriendo_id { get; set; }
        public int _id_arriendo_id
        {
            get { return id_arriendo_id; }
            set
            {

                if (value >= 0)
                {
                    id_arriendo_id = value;
                }
                else
                {
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }
        public int disponible { get; set; }
        public int _disponible
        {
            get { return disponible; }
            set
            {

                if (value == 0 || value == 1)
                {
                    disponible = value;
                }
                else
                {
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }

       
    }
}