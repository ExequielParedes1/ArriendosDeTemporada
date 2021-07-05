using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMConductoresVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTareasRealizadas();
            validarTipoUsuario();

            ConductorBLL conductor = new ConductorBLL();
            VehiculoBLL vehiculo = new VehiculoBLL();
            GridListarVehiculo.DataSource = vehiculo.listarVehiculoEstado(1);
            GridListarVehiculo.DataBind();
            GridConductores.DataSource = conductor.listarConductorEstado(1);
            GridConductores.DataBind();
        }

        protected void btn_agregarVehiculo_Click(object sender, EventArgs e)
        {
            VehiculoBLL nuevo = new VehiculoBLL();
            try
            {
                if (txtPatente.Text == "")
                {
                    throw new Exception("La patente no puede estar vacia");
                }
                else
                {
                    nuevo.patente = txtPatente.Text;
                }
                if (txtModelo.Text == "")
                {
                    throw new Exception("El modelo no puede estar vacio");
                }
                else
                {
                    nuevo.modelo = txtModelo.Text;
                }
                if (int.Parse(txtAño.Text) > 9999 && int.Parse(txtAño.Text) < 999)
                {
                    throw new Exception("El año esta incorrecto");
                }
                else
                {
                    nuevo.año = int.Parse(txtAño.Text);
                }
                if (txtColor.Text == "")
                {
                    throw new Exception("El campo color no puede estar vacio");
                }
                else
                {
                    nuevo.color = txtColor.Text;
                }
                if (int.Parse(DLEstadoVehiculo.SelectedValue) < 0)
                {
                    throw new Exception("El campo estado del vehiculo no puede estar vacio");
                }
                else
                {
                    nuevo.disponible = int.Parse(DLEstadoVehiculo.SelectedValue);
                }

               

                if (nuevo.agregarVehiculo(nuevo) == 1)
                {
                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMConductoresVehiculos.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("AdministrarConductoresVehiculos.aspx");
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

        protected void GridListarVehiculo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cod = GridListarVehiculo.DataKeys[e.RowIndex].Values[0].ToString();
            lblPatente.Text = cod;
            hidenCodDesactivar.Value = cod;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalDesactivar()", true);
        }
        protected void btn_desactivar_Click(object sender, EventArgs e)
        {
            VehiculoBLL nuevo = new VehiculoBLL();
            nuevo = nuevo.buscarVehiculo(hidenCodDesactivar.Value);
            nuevo.disponible = 0;
            if (nuevo.editarehiculo(nuevo) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMConductoresVehiculos.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMConductoresVehiculos.aspx");
            }
        }
        //Cargar los datos en el modal de editar vehiculo
        protected void GridListarVehiculo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string cod = GridListarVehiculo.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            VehiculoBLL nuevo = new VehiculoBLL();
            nuevo = nuevo.buscarVehiculo(cod);

            txtPatenteEdit.Text = nuevo.patente;
            txtModeloEdit.Text = nuevo.modelo;
            txtAñoEdit.Text = nuevo.año.ToString();
            txtColorEdit.Text = nuevo.color;
          
            hidenCod.Value = nuevo.patente;

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalEditar()", true);
        }
        //Edita el vehiculo
        protected void btn_editarVehiculo_click(object sender, EventArgs e)
        {
            VehiculoBLL nuevo = new VehiculoBLL();
            nuevo = nuevo.buscarVehiculo(hidenCod.Value);

            try
            {
                if (txtPatenteEdit.Text == "")
                {
                    throw new Exception("La patente no puede estar vacia");
                }
                else
                {
                    nuevo.patente = txtPatenteEdit.Text;
                }
                if (txtModeloEdit.Text == "")
                {
                    throw new Exception("El modelo no puede estar vacio");
                }
                else
                {
                    nuevo.modelo = txtModeloEdit.Text;
                }
                if (int.Parse(txtAñoEdit.Text) > 9999 && int.Parse(txtAñoEdit.Text) < 999)
                {
                    throw new Exception("El año ingresado es incorrecto");
                }
                else
                {
                    nuevo.año = int.Parse(txtAñoEdit.Text);
                }
                if (txtColorEdit.Text == "")
                {
                    throw new Exception("El Color no puede estar vacio");
                }
                else
                {
                    nuevo.color = txtColorEdit.Text;
                }
                if (nuevo.editarehiculo(nuevo) == 1)
                {
                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMConductoresVehiculos.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("ADMConductoresVehiculos.aspx");
                }
            }
            catch (Exception exp)
            {

                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }

        }

        protected void btn_agregarConductor_Click(object sender, EventArgs e)
        {
            ConductorBLL nuevo = new ConductorBLL();
            try
            {
                if (txtRut.Text == "")
                {
                    throw new Exception("La Rut no puede estar vacia");
                }
                else
                {
                    if (validarRut(txtRut.Text) == false)
                    {
                        throw new Exception("El rut ingresado no es valido");
                    }
                    else
                    {
                        nuevo.rut = txtRut.Text;
                    }

                }
                if (txtNombre.Text == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else
                {
                    nuevo.nombre = txtNombre.Text;
                }
                if (txtApellido.Text == "")
                {
                    throw new Exception("El apellido no puede estar vacio");
                }
                else
                {
                    nuevo.apellido = txtApellido.Text;
                }
                if (int.Parse(DLDisponibleConductor.SelectedValue) < 0)
                {
                    throw new Exception("Tiene que ingresar un estado al conductor");
                }
                else
                {
                    nuevo.disponible = int.Parse(DLDisponibleConductor.SelectedValue);
                }
                if (txtTelefono.Text.Length != 8)
                {
                    throw new Exception("El numero ingresado no es valido");
                }
                else
                {
                    nuevo.telefono = int.Parse(txtTelefono.Text);
                }
                if (txt_correo.Text == "")
                {
                    throw new Exception("El correo ingresado no es valido");
                }
                else
                {
                    nuevo.email = txt_correo.Text;
                }
                if (nuevo.agregarConductor(nuevo) == 1)
                {
                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMConductoresVehiculos.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("ADMConductoresVehiculos.aspx");
                }
            }
            catch (Exception exp)
            {

                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }

        }
        //Cargar datos al modal para desactivar Conductor
        protected void GridConductores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cod = GridConductores.DataKeys[e.RowIndex].Values[0].ToString();
            ConductorBLL nuevo = new ConductorBLL();
            nuevo = nuevo.buscarConducto(cod);
            lblConductor.Text = nuevo.nombre + " " + nuevo.apellido;
            HiddenConductor.Value = cod;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalDesactivarConductor()", true);
        }
        //Desactivar Conductores
        protected void btn_desactivarConductor_Click(object sender, EventArgs e)
        {
            ConductorBLL nuevo = new ConductorBLL();
            nuevo = nuevo.buscarConducto(HiddenConductor.Value);
            nuevo.disponible = 0;
            if (nuevo.editarConductor(nuevo) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMConductoresVehiculos.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMConductoresVehiculos.aspx");
            }
        }
        //Cargar Datos en el modal de editar
        protected void GridConductores_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string cod = GridConductores.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            ConductorBLL nuevo = new ConductorBLL();
            nuevo = nuevo.buscarConducto(cod);

            txtRutEdit.Text = nuevo.rut;
            txtNombreEdit.Text = nuevo.nombre;
            txtApellidoEdit.Text = nuevo.apellido;
            txtTelefonoEdit.Text = nuevo.telefono.ToString();

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModalEditarConductor()", true);

        }
        //Edita al conductor
        protected void btn_EditarConductor_Click(object sender, EventArgs e)
        {
            ConductorBLL nuevo = new ConductorBLL();
            try
            {
                nuevo = nuevo.buscarConducto(txtRutEdit.Text);
                if (txtNombreEdit.Text == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else
                {
                    nuevo.nombre = txtNombreEdit.Text;
                }
                if (txtApellidoEdit.Text == "")
                {
                    throw new Exception("El apellido no puede estar vacio");
                }
                else
                {
                    nuevo.apellido = txtApellidoEdit.Text;
                }
                if (txtTelefonoEdit.Text.Length != 7)
                {
                    throw new Exception("El numero ingresado no es correcto");
                }
                else
                {
                    nuevo.telefono = int.Parse(txtTelefonoEdit.Text);
                }

                if (nuevo.editarConductor(nuevo) == 1)
                {
                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMConductoresVehiculos.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("ADMConductoresVehiculos.aspx");
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }
        }
        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
}