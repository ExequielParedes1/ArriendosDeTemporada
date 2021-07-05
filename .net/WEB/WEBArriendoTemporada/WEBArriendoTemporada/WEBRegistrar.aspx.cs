using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;
namespace WEBArriendoTemporada
{
    public partial class WEBRegistrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
        }
        protected void btn_registrar_click(object sender, EventArgs e)
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            try
            {
                if (txt_rut.Text == "")
                {
                    throw new Exception("El rut no puede estar vacio");
                }
                else
                {
                    if (validarRut(txt_rut.Text) == false)
                    {
                        throw new Exception("El rut ingresado no es valido");
                    }
                    else
                    {
                        nuevo._cedula = txt_rut.Text;
                    }
                }
                if (txt_nombre.Text == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else
                {
                    nuevo._nombre = txt_nombre.Text;
                }
                if (txt_apellido.Text == "")
                {
                    throw new Exception("El apellido no puede estar vacio");
                }
                else
                {
                    nuevo._apellido = txt_apellido.Text;
                }
                if (pass.Text == "")
                {
                    throw new Exception("La contraseña no puede estar vacia");
                }
                else
                {
                    nuevo._contraseña = pass.Text;
                }
                if (correo.Text == "")
                {
                    throw new Exception("El correo no puede estar vacio");
                }
                else
                {
                    nuevo._correo = correo.Text;
                }
                if (txt_numeroContacto.Text.Length != 8)
                {
                    throw new Exception("El numero ingresado no es valido");
                }
                else
                {
                    nuevo._numeroContacto = int.Parse(txt_numeroContacto.Text);
                }


                nuevo._tipo = "cliente";
                nuevo._estado = "pendiente";
                Session["registrado"] = nuevo;

                if (nuevo.agregatUsuario(nuevo) == 1)
                {
                

                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMUsuario.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("ADMUsuario.aspx");
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }



        }
        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
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
    }
}