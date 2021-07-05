using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class VehiculoBLL
    {
        #region Campos
        public string patente { get; set; }
        public string _patente
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
        public string modelo { get; set; }
        public string _modelo
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
        public int año { get; set; }
        public int _año
        {
            get { return año; }
            set
            {

                if (value > 1900 && value < 2030)
                {
                    año = value;
                }
                else
                {
                    throw new Exception("¡Dato Inicorrecto!");

                }
            }
        }
        public string color { get; set; }
        public string _color
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
        #endregion

        public List<VehiculoBLL> listarVehiculoEstado(int disponible)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();

            List<VehiculoBLL> lista = new List<VehiculoBLL>();
            foreach (var item in wcf.ListarVehiculo())
            {
                if (item.Disponible == disponible)
                {
                    VehiculoBLL nuevoV = new VehiculoBLL();
                    nuevoV._patente = item.Patente;
                    nuevoV._modelo = item.Modelo;
                    nuevoV._año = item.Anho;
                    nuevoV._color = item.Color;
                    nuevoV._disponible = item.Disponible;
                    lista.Add(nuevoV);
                }
            }
            return lista;
        }

        public VehiculoBLL buscarVehiculo(string patente)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            VehiculoBLL nuevoV = new VehiculoBLL();
            foreach (var item in wcf.ListarVehiculo())
            {
                if (item.Patente == patente)
                {
                    nuevoV._patente = item.Patente;
                    nuevoV._modelo = item.Modelo;
                    nuevoV._año = item.Anho;
                    nuevoV._color = item.Color;
                    nuevoV._disponible = item.Disponible;
                    return nuevoV;
                }
            }
            return nuevoV;
        }

        public int editarehiculo(VehiculoBLL v)
        {
            WSarriendo.VehiculoBLL nuevo = new WSarriendo.VehiculoBLL();
            nuevo.Patente = v._patente;
            nuevo.Modelo = v._modelo;
            nuevo.Anho = v._año;
            nuevo.Color = v._color;
            nuevo.Disponible = v._disponible;
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            return wcf.ModificarVehiculo(nuevo);
        }
        public int agregarVehiculo(VehiculoBLL v)
        {
            WSarriendo.VehiculoBLL nuevo = new WSarriendo.VehiculoBLL();
            nuevo.Patente = v._patente;
            nuevo.Modelo = v._modelo;
            nuevo.Anho = v._año;
            nuevo.Color = v._color;
            nuevo.Disponible = v._disponible;
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            return wcf.AgregarVehiculo(nuevo);
        }
    }
}