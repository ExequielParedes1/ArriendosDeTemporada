using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBViaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
            ViajeBLL viaje = new ViajeBLL();
            
            GridViajesPendientes.DataBind();
        }

        protected void GridViajesPendientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string cod = GridViajesPendientes.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            ViajeBLL viaje = new ViajeBLL();
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