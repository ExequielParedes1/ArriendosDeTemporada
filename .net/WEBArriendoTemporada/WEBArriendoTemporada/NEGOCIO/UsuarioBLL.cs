using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class UsuarioBLL
    {
        #region Campos
        private string correo { get; set; }
        public string _correo
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
        private int numeroContacto { get; set; }
        public int _numeroContacto
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
        private string contraseña { get; set; }
        public string _contraseña
        {
            get { return contraseña; }
            set
            {

                if (value.Length > 0)
                {
                    contraseña = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string tipo { get; set; }
        public string _tipo
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
        public string _estado
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

        public int agregatUsuario(UsuarioBLL usr)
        {
            try
            {
                WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
                WSarriendo.UsuarioBLL nuevo = new WSarriendo.UsuarioBLL();

                nuevo.Correo = usr._correo;
                nuevo.Cedula = usr._cedula;
                nuevo.Nombre = usr._nombre;
                nuevo.Apellido = usr._apellido;
                nuevo.NumeroContacto = usr._numeroContacto;
                nuevo.Estado = usr._estado;

                nuevo.Contrasenha = usr.contraseña;
                nuevo.Tipo = usr._tipo;

                return wcf.AgregarUsuario(nuevo);
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo comunicar con el servidor: " + ex);
            }


        }
        public List<UsuarioBLL> listarUsuario()
        {
            try
            {
                WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
                List<UsuarioBLL> lista = new List<UsuarioBLL>();
                foreach (var item in wcf.ListarUsuario())
                {
                    UsuarioBLL nuevo = new UsuarioBLL();
                    nuevo._correo = item.Correo;
                    nuevo._cedula = item.Cedula;
                    nuevo._nombre = item.Nombre;
                    nuevo._apellido = item.Apellido;
                    nuevo._numeroContacto = item.NumeroContacto;
                    nuevo._estado = item.Estado;
                    nuevo._contraseña = item.Contrasenha;
                    nuevo._tipo = item.Tipo;

                    lista.Add(nuevo);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo comunicar con el servidor: " + ex);
            }

        }
        public List<UsuarioBLL> listarUsuarioFuncionarios()
        {
            try
            {
                WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
                List<UsuarioBLL> lista = new List<UsuarioBLL>();
                foreach (var item in wcf.ListarUsuario())
                {
                    if (item.Tipo.Equals("funcionario"))
                    {
                        UsuarioBLL nuevo = new UsuarioBLL();
                        nuevo._correo = item.Correo;
                        nuevo._cedula = item.Cedula;
                        nuevo._nombre = item.Nombre;
                        nuevo._apellido = item.Apellido;
                        nuevo._numeroContacto = item.NumeroContacto;
                        nuevo._estado = item.Estado;
                        nuevo._contraseña = item.Contrasenha;
                        nuevo._tipo = item.Tipo;

                        lista.Add(nuevo);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo comunicar con el servidor: " + ex);
            }

        }
        public UsuarioBLL validarUsuario(string correo, string pass)
        {
            
            try
            {
                WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
                UsuarioBLL usr = new UsuarioBLL();
                foreach (var item in wcf.ListarUsuario())
                {

                    if (item.Correo == correo && item.Contrasenha == pass)
                    {

                        usr._correo = item.Correo;
                        usr._cedula = item.Cedula;
                        usr._nombre = item.Nombre;
                        usr._apellido = item.Apellido;
                        usr._numeroContacto = item.NumeroContacto;
                        usr._contraseña = item.Contrasenha;
                        usr._tipo = item.Tipo;
                        usr._estado = item.Estado;

                        return usr;
                    }
                }
                return usr;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo comunicar con el servidor: " + ex);
            }

        }
        public List<UsuarioBLL> listarUsuariosSegunTipo(string tipo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();

            List<UsuarioBLL> listado = new List<UsuarioBLL>();
            foreach (var item in wcf.ListarUsuario())
            {
                if (item.Estado.Equals("activo") && !item.Correo.Equals(tipo))
                {
                    UsuarioBLL usr = new UsuarioBLL();
                    usr._correo = item.Correo;
                    usr._cedula = item.Cedula;
                    usr._nombre = item.Nombre;
                    usr._apellido = item.Apellido;
                    usr._numeroContacto = item.NumeroContacto;
                    usr._contraseña = item.Contrasenha;
                    usr._tipo = item.Tipo;
                    usr._estado = item.Estado;

                    listado.Add(usr);
                }
            }
            return listado;
        }

        public List<UsuarioBLL> listarUsuariosSegunEstadoYlogeo(string estado, string correo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();

            List<UsuarioBLL> listado = new List<UsuarioBLL>();
            foreach (var item in wcf.ListarUsuario())
            {
                if (item.Estado.Equals(estado) && item.Correo != correo)
                {
                    UsuarioBLL usr = new UsuarioBLL();
                    usr._correo = item.Correo;
                    usr._cedula = item.Cedula;
                    usr._nombre = item.Nombre;
                    usr._apellido = item.Apellido;
                    usr._numeroContacto = item.NumeroContacto;
                    usr._contraseña = item.Contrasenha;
                    usr._tipo = item.Tipo;
                    usr._estado = item.Estado;

                    listado.Add(usr);
                }
            }
            return listado;
        }

        public UsuarioBLL buscarUsuario(string correo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            UsuarioBLL usr = new UsuarioBLL();

            foreach (var item in wcf.ListarUsuario())
            {
                if (item.Correo == correo)
                {

                    usr._correo = item.Correo;
                    usr._cedula = item.Cedula;
                    usr._nombre = item.Nombre;
                    usr._apellido = item.Apellido;
                    usr._numeroContacto = item.NumeroContacto;
                    usr._contraseña = item.Contrasenha;
                    usr._tipo = item.Tipo;
                    usr._estado = item.Estado;

                    return usr;
                }
            }
            return usr;
        }
        public int editarUsuario(UsuarioBLL usr)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.UsuarioBLL nuevo = new WSarriendo.UsuarioBLL();


            nuevo.Correo = usr._correo;
            nuevo.Cedula = usr._cedula;
            nuevo.Nombre = usr._nombre;
            nuevo.Apellido = usr._apellido;
            nuevo.NumeroContacto = usr._numeroContacto;
            nuevo.Estado = usr._estado;
            nuevo.Contrasenha = usr._contraseña;
            nuevo.Tipo = usr._tipo;

            return wcf.ModificarUsuario(nuevo);
        }

       
    }
}