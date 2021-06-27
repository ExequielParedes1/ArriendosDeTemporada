using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;


namespace WebServiceArriendo.negocio
{
    public class AcompananteBLL
    {
        private string cedula;
        public string Cedula
        {
            get { return cedula; }
            set
            {

                if (value.Length > 0)
                {
                    cedula = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string nombre;
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
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {

                if (value.Length > 0)
                {
                    apellido = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

        private int telefono;
        public int Telefono
        {
            get { return telefono; }
            set
            {

                if (value > 0)
                {
                    telefono = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int agregarAcompanante(AcompananteBLL nuevo)
        {
            AcompananteDAL modelo = new AcompananteDAL();
            return modelo.AgregarAcompananteDAL(nuevo);
        }
        public List<AcompananteBLL> ListarAcompananteBLL()
        {
            AcompananteDAL modelo = new AcompananteDAL();
            return modelo.ListarAcompanantesDAL();
        }
        public int EliminarAcompananteBLL(string cedula)
        {
            AcompananteDAL modelo = new AcompananteDAL();
            return modelo.EliminarAcompananteDAL(cedula);
        }
        public int ModificarAcompananteBLL(AcompananteBLL nuevo)
        {
            AcompananteDAL modelo = new AcompananteDAL();
            return modelo.ModificarAcompananteDAL(nuevo);
        }
    }
}