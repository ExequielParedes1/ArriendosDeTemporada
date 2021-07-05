using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class AcompananteBLL
    {
        #region Campo
        public string cedula;
        public string _cedula
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
        public string nombre;
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
        public string apellido;
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

        public int telefono;
        public int _telefono
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
        #endregion
        public int agregarAcompanante(AcompananteBLL hues)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.AcompananteBLL nuevo = new WSarriendo.AcompananteBLL();
            nuevo.Cedula = hues._cedula;
            nuevo.Nombre = hues._nombre;
            nuevo.Apellido = hues._apellido;
            nuevo.Telefono = hues._telefono;

            return wcf.AgregarAcompanante(nuevo);
        }
        public List<AcompananteBLL> ListarAcompananteBLL()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<AcompananteBLL> lista = new List<AcompananteBLL>();
            foreach (var item in wcf.ListarAcompanante())
            {
                AcompananteBLL nuevo = new AcompananteBLL();
                nuevo._cedula = item.Cedula;
                nuevo._nombre = item.Nombre;
                nuevo._apellido = item.Apellido;
                nuevo._telefono = item.Telefono;

                lista.Add(nuevo);
            }
            return lista;
        }
        public int EliminarAcompananteBLL(string cedula)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            return wcf.EliminarAcompanante(cedula);
        }
        public AcompananteBLL buscarHuesped(string rut)
        {
            AcompananteBLL nuevo = new AcompananteBLL();
            foreach (var item in ListarAcompananteBLL())
            {
                if (item._cedula.Equals(rut))
                {
                    nuevo._cedula = item._cedula;
                    nuevo._nombre = item._nombre;
                    nuevo._apellido = item._apellido;
                    nuevo._telefono = item._telefono;

                    return nuevo;
                }
            }
            return nuevo;
        }
        public int modificarAcompanante(AcompananteBLL otro)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.AcompananteBLL nuevo = new WSarriendo.AcompananteBLL();
            nuevo.Cedula = otro._cedula;
            nuevo.Nombre = otro._nombre;
            nuevo.Apellido = otro._apellido;
            nuevo.Telefono = otro._telefono;

            return wcf.ModificarAcompanante(nuevo);
        }
    }
}