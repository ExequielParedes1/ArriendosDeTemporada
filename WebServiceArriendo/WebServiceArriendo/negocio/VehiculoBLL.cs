using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class VehiculoBLL
    {
        private string patente { get; set; }
        public string Patente
        {
            get { return patente; }
            set
            {

                if (value.Length > 0)
                {
                    patente = value;
                }
                else
                {
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }
        private string modelo { get; set; }
        public string Modelo
        {
            get { return modelo; }
            set
            {

                if (value.Length > 0)
                {
                    modelo = value;
                }
                else
                {
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }
        private int anho { get; set; }
        public int Anho
        {
            get { return anho; }
            set
            {

                if (value > 1900 && value < 2030)
                {
                    anho = value;
                }
                else
                {
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }
        private string color { get; set; }
        public string Color
        {
            get { return color; }
            set
            {

                if (value.Length > 0)
                {
                    color = value;
                }
                else
                {
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }
        private int disponible { get; set; }
        public int Disponible
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
        public int editarehiculo(VehiculoBLL ve)
        {
            VehiculoDAL nuevo = new VehiculoDAL();
            return nuevo.ModificarVehiculoDAL(ve);
        }
        public int agregarVehiculo(VehiculoBLL v)
        {
            VehiculoDAL modelo = new VehiculoDAL();
            return modelo.AgregarVehiculo(v);
        }
        public List<VehiculoBLL> ListarVehiculoBLL()
        {
            VehiculoDAL modelo = new VehiculoDAL();
            return modelo.listarVehiculo();
        }
    }
}