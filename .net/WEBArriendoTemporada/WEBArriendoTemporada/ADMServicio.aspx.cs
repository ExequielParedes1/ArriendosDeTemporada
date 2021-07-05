using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTipoUsuario();
            validarTareasRealizadas();
            ServicioBLL nuevoList = new ServicioBLL();
            TourBLL viaje = new TourBLL();
            
            GridView1.DataBind();

        }
        //crear al servicio con su tour
        protected void btn_agregarServicio_Click(object sender, EventArgs e)
        {
            ServicioBLL nuevo = new ServicioBLL();

            nuevo.nombreServicio = txt_nombreServicio.Text;
            nuevo.descripcion = txt_detalle.Text;
            nuevo.valor_servicio = int.Parse(txt_costo.Text);
            nuevo.disponible = int.Parse(Dl_estado.SelectedValue);


            nuevo.implicaViaje = 0;
            
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalSeleccionarViaje()", true);
        }

        //abre moda que permitira eliminar un servicio
        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            ServicioBLL nuevo = new ServicioBLL();
            string codigo = GridView1.DataKeys[e.RowIndex].Values[0].ToString();

            // nuevo = nuevo.buscarServicioBLL(int.Parse(codigo));


            lblNombreEliminar.Text = nuevo.nombreServicio;
            hidenCod.Value = nuevo.idServicio.ToString();

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalEliminar()", true);

        }
        //crear un tour
        protected void btn_agregarViaje_Click(object sender, EventArgs e)
        {
            
        }
        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        //btn del modal que deja inactivo al servicio
        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            ServicioBLL nuevo = new ServicioBLL();
            nuevo._disponible = 0;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        //Valida el tipo de usuario que esta logeado en la pagina
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
        //abre las ventanas emergentes de se realizo o no se logro realizar tareas
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string cod = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            ServicioBLL nuevo = new ServicioBLL();
            txtNomEdit.Text = nuevo.nombreServicio;
            txtCostoEdit.Text = nuevo.valor_servicio.ToString();
            txtDetalleEdit.Text = nuevo.descripcion;
            idService.Value = cod;

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalEditar()", true);
        }

        public void btn_editarServicio_Click(object sender, EventArgs e)
        {
           
        }
    }
}