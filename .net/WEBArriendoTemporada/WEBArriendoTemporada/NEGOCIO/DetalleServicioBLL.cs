using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class DetalleServicioBLL
    {
        public int precio { get; set; }
        public int _precio
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
        public DateTime fecha { get; set; }
        public DateTime _fecha
        {
            get { return fecha; }
            set
            {

                if (value != null)
                {
                    fecha = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int id_servicioExtra { get; set; }
        public int _id_servicioExtra
        {
            get { return id_servicioExtra; }
            set
            {

                if (value > 0)
                {
                    id_servicioExtra = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int id_arriendo { get; set; }
        public int _id_arriendo
        {
            get { return id_arriendo; }
            set
            {

                if (value > 0)
                {
                    id_arriendo = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
       
    }
}