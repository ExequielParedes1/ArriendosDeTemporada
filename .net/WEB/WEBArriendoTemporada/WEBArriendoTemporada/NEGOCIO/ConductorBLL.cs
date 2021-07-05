using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class ConductorBLL
    {
        #region Campos
        public string rut { get; set; }
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
        public string nombre { get; set; }
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
        public string apellido { get; set; }
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
        public string email { get; set; }
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
        public int telefono { get; set; }
        public int _telefono
        {
            get { return telefono; }
            set
            {

                if (value > 7)
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

        #region Metodos
        public List<ConductorBLL> listarConductorEstado(int estado)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ConductorBLL> lista = new List<ConductorBLL>();
            foreach (var item in wcf.ListarConductor())
            {
                if (item.Disponible == estado)
                {
                    ConductorBLL otro = new ConductorBLL();
                    otro._rut = item.Rut;
                    otro._nombre = item.Nombre;
                    otro._apellido = item.Apellido;
                    otro._disponible = item.Disponible;
                    otro._email = item.Email;
                    otro._telefono = item.Telefono;

                    lista.Add(otro);
                }
            }
            return lista;
        }
        public ConductorBLL buscarConducto(string rut)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            ConductorBLL otro = new ConductorBLL();
            foreach (var item in wcf.ListarConductor())
            {
                if (item.Rut == rut)
                {

                    otro._rut = item.Rut;
                    otro._nombre = item.Nombre;
                    otro._apellido = item.Apellido;
                    otro._disponible = item.Disponible;
                    otro._email = item.Email;
                    otro._telefono = item.Telefono;

                    return otro;
                }
            }
            return otro;
        }
        public int editarConductor(ConductorBLL item)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ConductorBLL otro = new WSarriendo.ConductorBLL();
            otro.Rut = item._rut;
            otro.Nombre = item._nombre;
            otro.Apellido = item._apellido;
            otro.Disponible = item._disponible;
            otro.Email = item._email;
            otro.Telefono = item._telefono;

            return wcf.ModificarConductor(otro);
        }
        public int agregarConductor(ConductorBLL item)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ConductorBLL otro = new WSarriendo.ConductorBLL();
            otro.Rut = item._rut;
            otro.Nombre = item._nombre;
            otro.Apellido = item._apellido;
            otro.Disponible = item._disponible;
            otro.Email = item._email;
            otro.Telefono = item._telefono;
            return wcf.AgregarConductor(otro);
        }
        #endregion
    }
}