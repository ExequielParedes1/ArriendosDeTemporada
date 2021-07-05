using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
        }

        protected void btn_iniciar_Click(object sender, EventArgs e)
        {

            UsuarioBLL usuario = new UsuarioBLL();

            try
            {
                string usuar = "";
                string clave = "";
                if (user.Text == "")
                {
                    throw new Exception("El nombre de usuario no puede estar vacio");
                }
                else
                {
                    if (usuario.buscarUsuario(user.Text) == null)
                    {
                        throw new Exception("No hay usuarios registrados con ese correo");
                    }
                    else
                    {
                        usuar = user.Text;
                    }

                }
                if (pass.Text == "")
                {
                    throw new Exception("La contraseña ingresada no puede estar vacia");
                }
                else
                {
                    clave = pass.Text;
                }
                usuario = usuario.validarUsuario(usuar, clave);
                if (usuario._tipo.Equals("funcionario"))
                {
                    throw new Exception("No se puede iniciar sesion");
                }
                if (usuario._correo != null)
                {
                    if (usuario._estado.Equals("activo"))
                    {
                        Session["usuario"] = usuario;
                        if (usuario._tipo.Equals("cliente"))
                        {
                            Response.Redirect("WEBReservar.aspx");
                        }
                        else if (usuario._tipo.Equals("admin"))
                        {
                            Response.Redirect("WEBDepartamento.aspx");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "usuarioNoExiste()", true);
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }



        }
        public void validarTareasRealizadas()
        {
            validar nuevo = new validar();
            nuevo = (validar)Session["registrado"];

            if (nuevo != null)
            {
                if (nuevo.realizado)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "showCreateThanksYouForm()", true);
                    Session.Remove("registrado");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", " error()", true);
                    Session.Remove("registrado");
                }
            }
        }

        protected void registrate_Click(object sender, EventArgs e)
        {
            Response.Redirect("WEBRegistrar.aspx");
        }
    }
}