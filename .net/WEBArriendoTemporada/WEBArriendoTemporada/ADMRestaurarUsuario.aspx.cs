using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMRestaurarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
            cargarGrilla();
        }

        protected void rowSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //LogBLL log = new LogBLL();
            UsuarioBLL logueado = new UsuarioBLL();
            logueado = (UsuarioBLL)Session["usuario"];
            string correo = GridUsuariosHistoricos.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            UsuarioBLL usr = new UsuarioBLL();
            usr = usr.buscarUsuario(correo);
            usr._estado = "activo";

            if (usr.editarUsuario(usr) == 1)
            {
                
                validar val = new validar();
                val.realizado = true;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarUsuario.aspx");
            }
            else
            {
                validar val = new validar();
                val.realizado = false;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarUsuario.aspx");
            }
        }
        //Permite la paginacion de la lista de usuarios
        protected void GridUsuariosHistoricos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridUsuariosHistoricos.PageIndex = e.NewPageIndex;
            GridUsuariosHistoricos.DataBind();
        }
        //boton de log de usuarios
        protected void GridUsuariosHistoricos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


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
        public void cargarGrilla()
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            nuevo = (UsuarioBLL)Session["usuario"];
            GridUsuariosHistoricos.DataSource = nuevo.listarUsuariosSegunEstadoYlogeo("inactivo", nuevo._correo);
            GridUsuariosHistoricos.DataBind();
        }
    }
}