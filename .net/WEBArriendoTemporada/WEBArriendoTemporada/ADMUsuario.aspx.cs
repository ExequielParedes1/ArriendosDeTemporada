using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            nuevo = (UsuarioBLL)Session["usuario"];
            if (nuevo == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                if (!nuevo._tipo.Equals("admin"))
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            validarTareasRealizadas();

            kt_table_1.DataSource = nuevo.listarUsuariosSegunEstadoYlogeo("activo", nuevo._correo);
            kt_table_1.DataBind();
            GridPendientes.DataSource = nuevo.listarUsuariosSegunEstadoYlogeo("pendiente", nuevo._correo);
            GridPendientes.DataBind();
        }


        protected void dataTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            UsuarioBLL usr = new UsuarioBLL();
            string idUsr = kt_table_1.DataKeys[e.RowIndex].Values[0].ToString();
            hidenCodDesactivar.Value = idUsr;
            usr = usr.buscarUsuario(idUsr);
            lblNombreUsuario.Text = usr.nombre + " " + usr._apellido;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalDesactivar()", true);

        }
        public void btn_desactivar_Click(object sender, EventArgs e)
        {
            
            UsuarioBLL logueado = new UsuarioBLL();
            logueado = (UsuarioBLL)Session["usuario"];

            string variable = hidenCodDesactivar.Value;
            UsuarioBLL nuevo = new UsuarioBLL();
            nuevo = nuevo.buscarUsuario(variable);
            nuevo._estado = "inactivo";

            if (nuevo.editarUsuario(nuevo) == 1)
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

        protected void dataTable_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string variable = kt_table_1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            UsuarioBLL usr = new UsuarioBLL();
            usr = usr.buscarUsuario(variable);
            txtRutEdit.Text = usr._cedula;
            txtNombreEdit.Text = usr._nombre;
            txtApellidoEdit.Text = usr._apellido;
            txtTelefonoEdit.Text = usr._numeroContacto.ToString();
            txtCorreoEdit.Text = usr._correo;
            txtPassEdit.Text = usr._contraseña;
            DLTipoEdit.SelectedValue = usr._tipo;

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalEditar()", true);
        }
        public void btnEditClick(object sender, EventArgs e)
        {
            UsuarioBLL usr = new UsuarioBLL();
            usr = usr.buscarUsuario(txtCorreoEdit.Text);
            try
            {
                if (txtRutEdit.Text == "")
                {
                    throw new Exception("El rut no puede estar vacio");
                }
                else
                {
                    usr._cedula = txtRutEdit.Text;
                }
                if (txtNombreEdit.Text == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else
                {
                    usr._nombre = txtNombreEdit.Text;
                }
                if (txtApellidoEdit.Text == "")
                {
                    throw new Exception("El apellido no puede estar vacio");
                }
                else
                {
                    usr._apellido = txtApellidoEdit.Text;
                }
                if (txtTelefonoEdit.Text.Length != 8)
                {
                    throw new Exception("El numero ingresado no es valido");
                }
                else
                {
                    usr._numeroContacto = int.Parse(txtTelefonoEdit.Text);
                }
                if (txtCorreoEdit.Text == "")
                {
                    throw new Exception("El correo no puede estar vacio");
                }
                else
                {
                    usr._correo = txtCorreoEdit.Text;
                }
                if (txtPassEdit.Text == "")
                {
                    throw new Exception("La contraseña no puede estar vacia");
                }
                else
                {
                    usr._contraseña = txtPassEdit.Text;
                }
                if (DLTipoEdit.SelectedValue == "")
                {
                    throw new Exception("El tipo de usuario no puede estar vacio");
                }
                else
                {
                    usr._tipo = DLTipoEdit.SelectedValue;
                }
                if (usr.editarUsuario(usr) == 1)
                {
                   
                    UsuarioBLL logueado = new UsuarioBLL();
                    logueado = (UsuarioBLL)Session["usuario"];


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
        public void agregarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            try
            {
                if (txtRut.Text == "")
                {
                    throw new Exception("El rut no puede estar vacio");
                }
                else
                {
                    if (validarRut(txtRut.Text) == false)
                    {
                        throw new Exception("El rut ingresado no es valido");
                    }
                    else
                    {
                        nuevo._cedula = txtRut.Text;
                    }
                }
                if (txt_nombreUsuario.Text == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else
                {
                    nuevo._nombre = txt_nombreUsuario.Text;
                }
                if (txt_apellidoUsuario.Text == "")
                {
                    throw new Exception("El apellido no puede estar vacio");
                }
                else
                {
                    nuevo._apellido = txt_apellidoUsuario.Text;
                }
                if (txt_contraseñaUsuario.Text == "")
                {
                    throw new Exception("La contraseña no puede estar vacia");
                }
                else
                {
                    if (txt_repetir_contraseña.Text == "")
                    {
                        throw new Exception("La contraseña no puede estar vacia");
                    }
                    else
                    {
                        if (txt_contraseñaUsuario.Text != txt_repetir_contraseña.Text)
                        {
                            throw new Exception("Las contraseñas tienen que ser iguales");
                        }
                        else
                        {
                            nuevo._contraseña = txt_contraseñaUsuario.Text;
                        }
                    }
                }

                if (txt_correoUsuario.Text == "")
                {
                    throw new Exception("El correo no puede estar vacio");
                }
                else
                {
                    nuevo._correo = txt_correoUsuario.Text;
                }
                if (txt_numeroContactoUsuario.Text.Length != 8)
                {
                    throw new Exception("El numero ingresado no es valido");
                }
                else
                {
                    nuevo._numeroContacto = int.Parse(txt_numeroContactoUsuario.Text);
                }

                nuevo._tipo = Dl_tipoUsuario.SelectedValue;
                nuevo._estado = "pendiente";


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

        protected void GridPendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPendientes.PageIndex = e.NewPageIndex;
            GridPendientes.DataBind();
        }


        protected void dataTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            kt_table_1.PageIndex = e.NewPageIndex;
            kt_table_1.DataBind();
        }

        protected void GridPendientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string codigo = GridPendientes.DataKeys[e.RowIndex].Values[0].ToString();
            UsuarioBLL usr = new UsuarioBLL();
            
            usr = usr.buscarUsuario(codigo);
            

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalFecha()", true);
        }

        protected void GridPendientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            UsuarioBLL usr = new UsuarioBLL();
            string corre = GridPendientes.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            Correos correo = new Correos();
            usr = usr.buscarUsuario(corre);
            usr._estado = "activo";
            correo.enviarCorreoDeConfirmacion(usr._correo, usr.nombre, usr._apellido);
            if (usr.editarUsuario(usr) == 1)
            {
               
                UsuarioBLL logueado = new UsuarioBLL();
                logueado = (UsuarioBLL)Session["usuario"];
                

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
        public void ClickLupa(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("Inicio.aspx");
        }
    }
}