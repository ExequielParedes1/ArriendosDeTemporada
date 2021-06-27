using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class ViajeBLL
    {
        public int id_viaje { get; set; }
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
        private DateTime comienzo { get; set; }
        public DateTime Comienzo
        {
            get { return comienzo; }
            set
            {

                if (value != null)
                {
                    comienzo = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int precio { get; set; }
        public int Precio
        {
            get { return precio; }
            set
            {

                if (value > 0)
                {
                    precio = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string conductor_rut { get; set; }
        public string Conductor_rut
        {
            get { return conductor_rut; }
            set
            {

                if (value.Length > 0)
                {
                    conductor_rut = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string vehiculo_patente { get; set; }
        public string Vehiculo_patente
        {
            get { return vehiculo_patente; }
            set
            {

                if (value.Length > 0)
                {
                    vehiculo_patente = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

        public int AgregarViajeBLL(ViajeBLL nuevo)
        {
            ViajeDAL modelo = new ViajeDAL();
            return modelo.AgregarViajeDAL(nuevo);
        }
        public List<ViajeBLL> ListarViajeBLL()
        {
            ViajeDAL modelo = new ViajeDAL();
            return modelo.ListarViajeDAL();
        }
        public int ModificarViajeBLL(ViajeBLL nuevo)
        {
            ViajeDAL modelo = new ViajeDAL();
            return modelo.ModificarViaje(nuevo);
        }
    }
}