using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMRestaurarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTipoUsuario();
            validarTareasRealizadas();
            VehiculoBLL nuevo = new VehiculoBLL();
            GridVehiculosInactivos.DataSource = nuevo.listarVehiculoEstado(0);
            GridVehiculosInactivos.DataBind();
        }

        protected void GridVehiculosInactivos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string code = GridVehiculosInactivos.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            VehiculoBLL veh = new VehiculoBLL();
            veh = veh.buscarVehiculo(code);
            veh.disponible = 1;

            if (veh.editarehiculo(veh) == 1)
            {
                validar val = new validar();
                val.realizado = true;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarVehiculo.aspx");
            }
            else
            {
                validar val = new validar();
                val.realizado = false;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarVehiculo.aspx");
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
    }
}