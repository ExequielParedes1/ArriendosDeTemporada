using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class CaracteristicaBLL
    {
        #region Campos
        public int idCaracteristica { get; set; }

        private string nombre { get; set; }
        public string Nombre
        {
            get { return nombre; }
            set
            {

                if (value.Length > 0)
                {
                    nombre = value;
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

        #endregion
        #region Metodos
        public List<CaracteristicaBLL> listarCaracteristicasBLL()
        {
            CaracteristicaDAL modelo = new CaracteristicaDAL();
            return modelo.listarCaracteristica();
        }
        public int ModificarCaracteristicaBLL(CaracteristicaBLL nuevo)
        {
            CaracteristicaDAL modelo = new CaracteristicaDAL();
            return modelo.ModificarCaracteristicaDAL(nuevo);
        }
        public int AgregarCaracteristicaBLL(CaracteristicaBLL nuevo)
        {
            CaracteristicaDAL modelo = new CaracteristicaDAL();
            return modelo.AgregarCaracteristica(nuevo);
        }
        public int EliminarCarateristicaBLL(int idCaracteristica)
        {
            CaracteristicaDAL modelo = new CaracteristicaDAL();
            return modelo.EliminarCaracteristica(idCaracteristica);
        }
        //public List<CaracteristicaBLL> listaPrueba()
        //{
        //    CaracteristicaDAL modelo = new CaracteristicaDAL();
        //    return modelo.listarCaracteristicaPrueba();
        //}
        #endregion
    }
}