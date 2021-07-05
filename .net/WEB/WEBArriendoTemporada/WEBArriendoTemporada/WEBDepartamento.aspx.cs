using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTipoUsuario();

            validarTareasRealizadas();

            DepartamentoBLL nuevo = new DepartamentoBLL();
            GridDepartamentos.DataSource = nuevo.listarDepartamentoPorEstado(1);
            GridDepartamentos.DataBind();

        }
        protected void btn_agregarDepartamento_click(object sender, EventArgs e)
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();

            try
            {
                if (txt_direccion.Text == "")
                {
                    throw new Exception("La direccion no puede estar vacia");
                }
                else
                {
                    nuevo._Direccion = txt_direccion.Text;
                }
                if (int.Parse(txt_metrosC.Text) <= 0)
                {
                    throw new Exception("Los metros ingresados no son correctos");
                }
                else
                {
                    nuevo._MtrsCuadrados = int.Parse(txt_metrosC.Text);
                }
                if (int.Parse(txt_valorDiarios.Text) <= 0)
                {
                    throw new Exception("El valor de ingresado diario no es correcto");
                }
                else
                {
                    nuevo._ValorDiario = int.Parse(txt_valorDiarios.Text);
                }
                if (int.Parse(Dl_estadoDpto.SelectedValue) < 0)
                {
                    throw new Exception("El estado ingresado no es valido");
                }
                else
                {
                    nuevo._Disponible = int.Parse(Dl_estadoDpto.SelectedValue);
                }
                if (dltxt_zona.Text == "")
                {
                    throw new Exception("La zona no puede estar vacia");
                }
                else
                {
                    nuevo._Zona = dltxt_zona.SelectedValue;
                }
                if (int.Parse(txt_habitaciones.Text) <= 0)
                {
                    throw new Exception("El numero de habitaciones no es correcto");
                }
                else
                {
                    nuevo._Nro_habitaciones = int.Parse(txt_habitaciones.Text);
                }
                if (int.Parse(txt_baños.Text) <= 0)
                {
                    throw new Exception("El numero de baños ingresados no es correcto");
                }
                else
                {
                    nuevo._Nro_baños = int.Parse(txt_baños.Text);
                }

                int cod = nuevo.AgregarDepartamentoBLL(nuevo);
                if (cod != 0)
                {
                    
                    UsuarioBLL logueado = new UsuarioBLL();
                    logueado = (UsuarioBLL)Session["usuario"];

                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("WEBDepartamento.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("WEBDepartamento.aspx");
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
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



        //Nos lleva al panel de administracion de dicho departamento
        protected void GridDepartamentos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string idDpto = GridDepartamentos.DataKeys[e.NewSelectedIndex].Values[0].ToString();

            DepartamentoBLL nuevo = new DepartamentoBLL();
            nuevo = nuevo.buscarDepartamento(int.Parse(idDpto));
            Session["Departamento"] = nuevo;
            Response.Redirect("ADMDepartamento.aspx");

           
        }
        protected void btn_editarDepartamento_click(object sender, EventArgs e)
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();


        }

        protected void GridDepartamentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idDpto = GridDepartamentos.DataKeys[e.RowIndex].Values[0].ToString();
            hidenCodDesactivar.Value = idDpto;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalDesactivar()", true);
        }
        protected void btn_desactivar_Click(object sender, EventArgs e)
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();
            nuevo = nuevo.buscarDepartamento(int.Parse(hidenCodDesactivar.Value));
            nuevo.disponible = 0;
            if (nuevo.editarDepartamento(nuevo) == 1)
            {
                
                UsuarioBLL logueado = new UsuarioBLL();
                logueado = (UsuarioBLL)Session["usuario"];

                
                validar val = new validar();
                val.realizado = true;
                Session["registrado"] = val;
                Response.Redirect("WEBDepartamento.aspx");
            }
            else
            {
                validar val = new validar();
                val.realizado = false;
                Session["registrado"] = val;
                Response.Redirect("WEBDepartamento.aspx");
            }
        }

        protected void GridDepartamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDepartamentos.PageIndex = e.NewPageIndex;
            GridDepartamentos.DataBind();

        }
    }
}