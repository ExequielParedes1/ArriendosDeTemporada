using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class ServicioBLL
    {
        public int idServicio { get; set; }
        public string nombreServicio { get; set; }
        public string _nombreServicio
        {
            get { return nombreServicio; }
            set
            {

                if (value.Length > 0)
                {
                    nombreServicio = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int valor_servicio { get; set; }
        public int _valor_servicio
        {
            get { return valor_servicio; }
            set
            {

                if (value > 0)
                {
                    valor_servicio = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public string descripcion { get; set; }
        public string _descripcion
        {
            get { return descripcion; }
            set
            {

                if (value.Length > 0)
                {
                    descripcion = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int implicaViaje { get; set; }
        public int _implicaViaje
        {
            get { return implicaViaje; }
            set
            {

                if (value > 0)
                {
                    implicaViaje = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

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
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

    }
}