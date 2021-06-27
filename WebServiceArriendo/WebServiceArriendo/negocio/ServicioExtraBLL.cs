using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class ServicioExtraBLL
    {
        public int id_servicio_extra { get; set; }
        private string nombre_servicio { get; set; }
        public string Nombre_servicio
        {
            get { return nombre_servicio; }
            set
            {

                if (value.Length > 0)
                {
                    nombre_servicio = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int varlo_servicio { get; set; }
        public int Valor_servicio
        {
            get { return varlo_servicio; }
            set
            {

                if (value > 0)
                {
                    varlo_servicio = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string descripcion { get; set; }
        public string Descripcion
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
        private int disponible { get; set; }
        public int Disponible
        {
            get { return disponible; }
            set
            {

                if (value >= 0)
                {
                    disponible = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

        public int agregarServicioExtraBLL(ServicioExtraBLL se)
        {
            ServicioExtraDAL modelo = new ServicioExtraDAL();
            return modelo.AgregarServicioExtraDAL(se);
        }
        public List<ServicioExtraBLL> ListarServicioExtraBLL()
        {
            ServicioExtraDAL modelo = new ServicioExtraDAL();
            return modelo.listarServicioExtraDAL();
        }
        public int modificarServicioExtraBLL(ServicioExtraBLL se)
        {
            ServicioExtraDAL modelo = new ServicioExtraDAL();
            return modelo.ModificarServicioExtraDAL(se);
        }
    }
}