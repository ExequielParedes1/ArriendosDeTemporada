using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class EncargadoBLL
    {
        #region Campos
        private string rut { get; set; }
        public string Rut
        {
            get { return rut; }
            set
            {

                if (value.Length > 0)
                {
                    rut = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int nro_contacto { get; set; }
        public int Nro_contacto
        {
            get { return nro_contacto; }
            set
            {

                if (value > 6)
                {
                    nro_contacto = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
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
        private string apellido { get; set; }
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
        private string email { get; set; }
        public string Email
        {
            get { return email; }
            set
            {

                if (value.Length > 0)
                {
                    email = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        #endregion
        #region Metodos
        public List<EncargadoBLL> ListarEncargadoBLL()
        {
            EncargadoDAL modelo = new EncargadoDAL();
            return modelo.ListarEncargadoDAL();
        }
        public int ModificarEncargadoBLL(EncargadoBLL nuevo)
        {
            EncargadoDAL modelo = new EncargadoDAL();
            return modelo.ModificarEncargadoDAL(nuevo);
        }
        public int AgregarEncargadoBLL(EncargadoBLL nuevo)
        {
            EncargadoDAL modelo = new EncargadoDAL();
            return modelo.AgregarEncargadoDAL(nuevo);
        }
        #endregion
    }
}