using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class ConductorBLL
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
        private int disponible { get; set; }
        public int Disponible
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
        private int telefono;
        public int Telefono
        {
            get { return telefono; }

            set
            {
                if (value >= 0)
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
                else
                {
                    throw new Exception("¡Dato Nulo!");
                }

            }
        }
        #endregion
        #region Metodos
        public List<ConductorBLL> ListarConductorBLL()
        {
            ConductorDAL modelo = new ConductorDAL();
            return modelo.listarConductor();
        }
        public int ModificarConductorBLL(ConductorBLL con)
        {
            ConductorDAL modelo = new ConductorDAL();
            return modelo.ModificarConductorDAL(con);
        }
        public int AgregarConductorBLL(ConductorBLL con)
        {
            ConductorDAL modelo = new ConductorDAL();
            return modelo.AgregarConductor(con);
        }
        #endregion
    }
}