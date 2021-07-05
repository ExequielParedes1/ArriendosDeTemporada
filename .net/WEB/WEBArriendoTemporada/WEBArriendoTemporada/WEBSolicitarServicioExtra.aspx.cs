using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBSolicitarServicioExtra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
            ServicioBLL servicio = new ServicioBLL();
            DetalleServicioBLL ds = new DetalleServicioBLL();
            //GridListarServiciosExtra.DataSource = servicio.listarServicioPordisponibilidad(1);
            GridListarServiciosExtra.DataBind();

            GridServiciosContratados.DataBind();

            UsuarioBLL nuevo = new UsuarioBLL();
            nuevo = (UsuarioBLL)Session["usuario"];
            // GridServiciosContratados.DataSource = ds.listarServicioPorArriendo(nuevo.Correo);
            GridServiciosContratados.DataBind();
            if (nuevo == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                if (!nuevo._tipo.Equals("cliente"))
                {
                    Response.Redirect("Inicio.aspx");
                }
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

        protected void GridListarServiciosExtra_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cod = GridListarServiciosExtra.DataKeys[e.RowIndex].Values[0].ToString();
            ServicioBLL nuevo = new ServicioBLL();
            // nuevo = nuevo.buscarServicioBLL(int.Parse(cod));
            Session["servicioAsociado"] = nuevo;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalAsignarArriendo()", true);
            UsuarioBLL usr = new UsuarioBLL();
            usr = (UsuarioBLL)Session["usuario"];
            ReservaBLL arr = new ReservaBLL();

            
        }
        protected void Click_asignarServicioArriendo(object sender, EventArgs e)
        {
            DetalleServicioBLL nuevo = new DetalleServicioBLL();
            ServicioBLL ser = new ServicioBLL();
            ser = (ServicioBLL)Session["servicioAsociado"];
            nuevo._precio = ser.valor_servicio;
            nuevo._fecha = DateTime.Now;
            nuevo.id_servicioExtra = ser.idServicio;
            nuevo.id_arriendo = int.Parse(dl_arriendosAsociados.SelectedValue);

            


        }
    }
}