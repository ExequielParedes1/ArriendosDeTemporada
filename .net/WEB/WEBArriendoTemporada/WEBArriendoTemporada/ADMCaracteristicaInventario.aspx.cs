using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMCaracteristicaInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
            validarTipoUsuario();
            CaracteristicaDptoBLL ca = new CaracteristicaDptoBLL();
            GridTodosLosServicios.DataSource = ca.listarCaracteristicas();
            GridTodosLosServicios.DataBind();
            ItemBLL item = new ItemBLL();
            GridInventario.DataSource = item.listarItemBLL();
            GridInventario.DataBind();
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

        protected void clic_crear_caract(object sender, EventArgs e)
        {
            try
            {
                CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
                if (txtNombreCarac.Text == "")
                {
                    throw new Exception("La caracteristica tiene que tener un nombre");
                }
                else
                {
                    nuevo._Nombre = txtNombreCarac.Text;
                }
                if (txtDescripcionCarac.Text == "")
                {
                    throw new Exception("La caracteristica tiene que tener una descripcion");
                }
                else
                {
                    nuevo._Descripcion = txtDescripcionCarac.Text;
                }


                if (nuevo.agregarCaracteriscaBLL(nuevo) == 1)
                {

                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMCaracteristicaInventario.aspx");

                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("ADMCaracteristicaInventario.aspx");
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }

        }
        public void clic_crear_item(object sender, EventArgs e)
        {
            try
            {
                ItemBLL nuevo = new ItemBLL();
                if (txtNombreItem.Text == "")
                {
                    throw new Exception("El item de inventario tiene que tener un nombre");
                }
                else
                {
                    nuevo._nombre = txtNombreItem.Text;
                }
                if (txtValorItem.Text.Length < 0)
                {
                    throw new Exception("El item tiene que tener un valor");
                }
                else
                {
                    nuevo._valor = int.Parse(txtValorItem.Text);
                }
                if (nuevo.AgregarItemBLL(nuevo) == 1)
                {
                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMCaracteristicaInventario.aspx");

                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("ADMCaracteristicaInventario.aspx");
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }

        }

        protected void GridTodosLosServicios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string codigo = GridTodosLosServicios.DataKeys[e.NewSelectedIndex].Values[0].ToString();

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalDesactivar()", true);
            HidenCaracte.Value = codigo;

        }
        protected void btn_desactivarCara_clic(object sender, EventArgs e)
        {
            CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
            if (nuevo.eliminarCaracteristica(int.Parse(HidenCaracte.Value)) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMCaracteristicaInventario.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMCaracteristicaInventario.aspx");
            }
        }

        protected void GridInventario_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            string codigo = GridInventario.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            HiddItem.Value = codigo;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalEliminarItem()", true);
        }
        protected void btn_eliminarItem(object sender, EventArgs e)
        {
            ItemBLL nuevo = new ItemBLL();


            if (nuevo.eliminarItemBLL(int.Parse(HiddItem.Value)) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMCaracteristicaInventario.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMCaracteristicaInventario.aspx");
            }
        }

        protected void GridTodosLosServicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTodosLosServicios.PageIndex = e.NewPageIndex;
            GridTodosLosServicios.DataBind();
        }

        protected void GridInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridInventario.PageIndex = e.NewPageIndex;
            GridInventario.DataBind();
        }
       
    }
}