using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;
namespace WEBArriendoTemporada
{
    public partial class ADMRestaurarDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTipoUsuario();
            validarTareasRealizadas();
            DepartamentoBLL nuevo = new DepartamentoBLL();
            GridDepartamentosInactivos.DataSource = nuevo.listarDepartamentoPorEstado(0);
            GridDepartamentosInactivos.DataBind();
        }

        protected void GridDepartamentosInactivos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string code = GridDepartamentosInactivos.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            DepartamentoBLL dpto = new DepartamentoBLL();
            dpto = dpto.buscarDepartamento(int.Parse(code));
            dpto.disponible = 1;

            if (dpto.editarDepartamento(dpto) == 1)
            {
                
                UsuarioBLL logueado = new UsuarioBLL();
                logueado = (UsuarioBLL)Session["usuario"];

               
                validar val = new validar();
                val.realizado = true;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarDepartamento.aspx");
            }
            else
            {
                validar val = new validar();
                val.realizado = false;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarDepartamento.aspx");
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
        public void validarTipoUsuario()
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
        }

        protected void GridDepartamentosInactivos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}