using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class EncargadoBLL
    {
        #region Campos
        private string rut { get; set; }
        public string _rut
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
        public int _nro_contacto
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
        public string _nombre
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
        public string _apellido
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
        public string _email
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

        public List<EncargadoBLL> ListarEncargadoBLL()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<EncargadoBLL> lista = new List<EncargadoBLL>();
            foreach (var item in wcf.ListarEncargado())
            {
                EncargadoBLL nuevo = new EncargadoBLL();
                nuevo._rut = item.Rut;
                nuevo._nro_contacto = item.Nro_contacto;
                nuevo._nombre = item.Nombre;
                nuevo._apellido = item.Apellido;
                nuevo._email = item.Email;

                lista.Add(nuevo);
            }
            return lista;
        }
        public int agregarEncargadoBLL(EncargadoBLL otro)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.EncargadoBLL nuevo = new WSarriendo.EncargadoBLL();

            nuevo.Rut = otro._rut;
            nuevo.Nombre = otro._nombre;
            nuevo.Apellido = otro._apellido;
            nuevo.Nro_contacto = otro._nro_contacto;
            nuevo.Email = otro._email;

            return wcf.AgregarEncargado(nuevo);
        }

        public EncargadoBLL buscarEncargadoBLL(string rut)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            EncargadoBLL nuevo = new EncargadoBLL();
            foreach (var item in wcf.ListarEncargado())
            {
                if (item.Rut == rut)
                {
                    nuevo._rut = item.Rut;
                    nuevo._nombre = item.Nombre;
                    nuevo._apellido = item.Apellido;
                    nuevo._nro_contacto = item.Nro_contacto;
                    nuevo._email = item.Email;
                    return nuevo;
                }
            }
            return nuevo;
        }
    }
}