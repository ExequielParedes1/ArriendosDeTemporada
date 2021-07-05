using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class UsuarioBLL
    {
        #region Campos
        private string correo { get; set; }
        public string Correo
        {
            get { return correo; }
            set
            {

                if (value.Length > 0)
                {
                    correo = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string cedula { get; set; }
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
        private int numeroContacto { get; set; }
        public int NumeroContacto
        {
            get { return numeroContacto; }
            set
            {

                if (value > 6)
                {
                    numeroContacto = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string contrasenha { get; set; }
        public string Contrasenha
        {
            get { return contrasenha; }
            set
            {

                if (value.Length > 0)
                {
                    contrasenha = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string tipo { get; set; }
        public string Tipo
        {
            get { return tipo; }
            set
            {

                if (value.Length > 0)
                {
                    tipo = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string estado { get; set; }
        public string Estado
        {
            get { return estado; }
            set
            {

                if (value.Length > 0)
                {
                    estado = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        #endregion

        public int agregarUsuarioBLL(UsuarioBLL nuevo)
        {
            UsuarioDAL modelo = new UsuarioDAL();
            return modelo.AgregarUsuario(nuevo);
        }
        public List<UsuarioBLL> ListarUsuarioBLL()
        {
            UsuarioDAL modelo = new UsuarioDAL();
            return modelo.listarUsuario();
        }
        public int ModificarUsuarioBLL(UsuarioBLL usr)
        {
            UsuarioDAL modelo = new UsuarioDAL();
            return modelo.ModificarUsuarioDAL(usr);
        }
    }
}