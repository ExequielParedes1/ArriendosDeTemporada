using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMRestaurarConductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
            ConductorBLL nuevo = new ConductorBLL();
            GridConductoresInactivos.DataSource = nuevo.listarConductorEstado(0);
            GridConductoresInactivos.DataBind();
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


        protected void GridConductoresInactivos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string code = GridConductoresInactivos.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            ConductorBLL cho = new ConductorBLL();
            cho = cho.buscarConducto(code);
            cho.disponible = 1;

            if (cho.editarConductor(cho) == 1)
            {
                validar val = new validar();
                val.realizado = true;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarConductor.aspx");
            }
            else
            {
                validar val = new validar();
                val.realizado = false;
                Session["registrado"] = val;
                Response.Redirect("ADMRestaurarConductor.aspx");
            }
        }
    }
}