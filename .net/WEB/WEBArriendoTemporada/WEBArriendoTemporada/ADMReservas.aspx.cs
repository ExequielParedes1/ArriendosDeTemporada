using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReservaBLL arr = new ReservaBLL();
            validarTipoUsuario();
            GridView1.DataSource = arr.listarArriendoPorEstado("activo");
            GridView1.DataBind();
            GridView2.DataSource = arr.listarArriendoPorEstado("finalizado");
            GridView2.DataBind();
            GridView3.DataSource = arr.listarArriendoPorEstado("anulado");
            GridView3.DataBind();
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cod = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            hidenIDArriendo.Value = cod;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalDesactivar()", true);
        }
        protected void btn_desactivar_arriendo(object sender, EventArgs e)
        {
            ReservaBLL arr = new ReservaBLL();
            arr = arr.buscarReserva(int.Parse(hidenIDArriendo.Value));
            arr._estado = "inactivo";
            if (arr.ModificarReservaBLL(arr) == 1)
            {
               
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMReservas.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMReservas.aspx");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string cod = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            Session["codDetalleArriendo"] = cod;
            Response.Redirect("ADMDetalleReserva.aspx");
        }
    }
}