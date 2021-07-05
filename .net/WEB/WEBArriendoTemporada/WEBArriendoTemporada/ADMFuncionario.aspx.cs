using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTipoUsuario();
            validarTareasRealizadas();
            UsuarioBLL nuevo = new UsuarioBLL();
            kt_table_1.DataSource = nuevo.listarUsuarioFuncionarios();
            kt_table_1.DataBind();
            ReservaBLL arr = new ReservaBLL();

            GridView1.DataSource = arr.listarArriendoPorEstadoSinFuncionario("activo", arr.listarReservaPorEstadoConFuncionario("activo"));
            GridView1.DataBind();
            GridView2.DataSource = arr.listarReservaPorEstadoConFuncionario("activo");
            GridView2.DataBind();

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

        protected void kt_table_1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            kt_table_1.PageIndex = e.NewPageIndex;
            kt_table_1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            string cod = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            arriendoAsignar.Value = cod;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalAsignar()", true);
        }

        protected void kt_table_1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string correo = kt_table_1.DataKeys[e.RowIndex].Values[0].ToString();
            UsuarioBLL usr = new UsuarioBLL();
            usr = usr.buscarUsuario(correo);
            InvolucradoBLL nuevo = new InvolucradoBLL();
            nuevo.usuario_correo = correo;
            nuevo.reserva_id_reserva = int.Parse(arriendoAsignar.Value);

            Correos mail = new Correos();
            if (nuevo.agregarInvolucrado(nuevo) == 1)
            {
                string asunto = "Asignacion de arriendo";
                mail.asignacionDeArriendo(usr._nombre, usr._correo, asunto, arriendoAsignar.Value);

           

                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMFuncionario.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMFuncionario.aspx");
            }
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataBind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalFuncionarioAsignado()", true);
            string cod = GridView2.DataKeys[e.RowIndex].Values[0].ToString();
            InvolucradoBLL inv = new InvolucradoBLL();

            UsuarioBLL funcionario = new UsuarioBLL();
            funcionario = inv.buscarFuncionarioAsociado(int.Parse(cod));

            List<UsuarioBLL> lista = new List<UsuarioBLL>();

            lista.Add(funcionario);

            gridFuncionarioAsignado.DataSource = lista;
            gridFuncionarioAsignado.DataBind();

            hidenFuncionarioAsociado.Value = cod;

        }

        protected void gridFuncionarioAsignado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cod = gridFuncionarioAsignado.DataKeys[e.RowIndex].Values[0].ToString();

            hidenFuncionarioAsociadoArriendo.Value = cod;
            correo.Text = cod;
            InvolucradoBLL inv = new InvolucradoBLL();
            inv.usuario_correo = cod;
            inv.reserva_id_reserva = int.Parse(hidenFuncionarioAsociado.Value);

            if (inv.eliminarFuncionarioAsociado(inv) == 1)
            {
               
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMFuncionario.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMFuncionario.aspx");
            }
        }
    }
}