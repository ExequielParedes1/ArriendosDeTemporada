using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBDetalleReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarTipoUsuario();
            validarTareasRealizadas();


            if (Session["codArriendo"] == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                string x = Session["codArriendo"].ToString();
                ReservaBLL arr = new ReservaBLL();
                DetalleMulta dm = new DetalleMulta();

                arr = arr.buscarReserva(int.Parse(x));

                gridMultas.DataSource = dm.listaMultaPorArriendo(int.Parse(x));
                gridMultas.DataBind();

                DepartamentoBLL dpto = new DepartamentoBLL();
                dpto = dpto.buscarDepartamento(arr._departamento_id_departamento);
                FotoBLL foto = new FotoBLL();
                Repeater1.DataSource = foto.listarImagenesPorDpto(dpto.idDepartamento);
                Repeater1.DataBind();
                ListaAcompBLL hues = new ListaAcompBLL();
                GridView1.DataSource = hues.ListadoListaAcompananteBLL(arr.id_reserva);
                GridView1.DataBind();

                if (hues.ListadoListaAcompananteBLL(arr.id_reserva).Count < dpto.nro_habitaciones)
                {
                    btnAgregarHuesped.Visible = true;
                    maxHuespedes.Visible = false;
                }
                else
                {
                    btnAgregarHuesped.Visible = false;
                    maxHuespedes.Visible = true;
                }

                UsuarioBLL nuevo = new UsuarioBLL();
                nuevo = (UsuarioBLL)Session["usuario"];
                DetalleServicioBLL ds = new DetalleServicioBLL();
                GridServiciosContratados.DataBind();

                txtIDDpto.Text = dpto.idDepartamento.ToString();
                txtDireccionDpto.Text = dpto.direccion;
                txtMtsDpto.Text = dpto.mtrsCuadrados.ToString();
                txtDiarioDpto.Text = dpto.valirDiario.ToString();
                txtZonaDpto.Text = dpto.zona;
                txtNroHabitacionesDpto.Text = dpto.nro_habitaciones.ToString();
                txtNroBañosDpto.Text = dpto.nro_baños.ToString();


                txtID.Text = arr.id_reserva.ToString();
                txtTotal.Text = arr._valor_final.ToString();
                txtFechaLLegada.Text = arr._check_in.ToString();
                txtFechaSalida.Text = arr._check_Out.ToString();
                txtFechaContrato.Text = arr._fecha_contrato.ToString();
            }
        }
        public void btn_agregarHuesped_click(object sender, EventArgs e)
        {
            AcompananteBLL nuevo = new AcompananteBLL();
            try
            {
                if (txtRut.Text == "")
                {
                    throw new Exception("El rut no puede estar vacio");
                }
                else
                {
                    if (validarRut(txtRut.Text) == false)
                    {
                        throw new Exception("El rut ingresado no es valido");
                    }
                    else
                    {
                        nuevo._cedula = txtRut.Text;
                    }
                }
                if (txtNombre.Text == "El nombre no puede estar vacio")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else
                {
                    nuevo._nombre = txtNombre.Text;
                }
                if (txtApellido.Text == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                else
                {
                    nuevo._apellido = txtApellido.Text;
                }
                if (txtTelefono.Text.Length != 8)
                {
                    throw new Exception("El numero telefonico ingresado no es valido");
                }
                else
                {
                    nuevo._telefono = int.Parse(txtTelefono.Text);
                }

                ListaAcompBLL ls = new ListaAcompBLL();
                ls.cedulaAcompanante = txtRut.Text;
                ls.idReserva = int.Parse(txtID.Text);

                if (nuevo.agregarAcompanante(nuevo) == 1)
                {
                    if (ls.agregarListaAcompananteBLL(ls) == 1)
                    {
                        UsuarioBLL usr = new UsuarioBLL();
                        usr = (UsuarioBLL)Session["usuario"];
                        
                        validar v = new validar();
                        v.realizado = true;
                        Session["registrado"] = v;
                        Response.Redirect("WEBDetalleReserva.aspx");
                    }
                    else
                    {
                        validar v = new validar();
                        v.realizado = false;
                        Session["registrado"] = v;
                        Response.Redirect("WEBDetalleReserva.aspx");
                    }
                }
                else
                {
                    if (nuevo.buscarHuesped(txtRut.Text) != null)
                    {
                        if (ls.agregarListaAcompananteBLL(ls) == 1)
                        {
                            nuevo._cedula = txtRut.Text;
                            nuevo._nombre = txtNombre.Text;
                            nuevo._apellido = txtApellido.Text;
                            nuevo._telefono = int.Parse(txtTelefono.Text);
                            nuevo.modificarAcompanante(nuevo);
                            validar v = new validar();
                            v.realizado = true;
                            Session["registrado"] = v;
                            Response.Redirect("WEBDetalleReserva.aspx");
                        }
                        else
                        {
                            validar v = new validar();
                            v.realizado = false;
                            Session["registrado"] = v;
                            Response.Redirect("WEBDetalleReserva.aspx");
                        }
                    }
                    else
                    {
                        validar v = new validar();
                        v.realizado = false;
                        Session["registrado"] = v;
                        Response.Redirect("WEBDetalleReserva.aspx");
                    }
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalAgregarHuesped()", true);
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string x = Session["codArriendo"].ToString();
            string cod = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            ListaAcompBLL nuevo = new ListaAcompBLL();
            nuevo.idReserva = int.Parse(x);
            nuevo.cedulaAcompanante = cod;

            if (nuevo.eliminarListaAcompanantesBLL(nuevo) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("WEBDetalleReserva.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("WEBDetalleReserva.aspx");
            }
        }

        public void clic_buscarCliente(object sender, EventArgs e)
        {
            AcompananteBLL nuevo = new AcompananteBLL();
            nuevo = nuevo.buscarHuesped(txtRut.Text);
            try
            {
                if (nuevo._nombre == null)
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtTelefono.Text = "";
                    throw new Exception("No se ha encontrado huesped");

                }
                else
                {
                    txtNombre.Text = nuevo._nombre;
                    txtApellido.Text = nuevo._apellido;
                    txtTelefono.Text = nuevo._telefono.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalAgregarHuesped()", true);
                }
            }
            catch (Exception exp)
            {

                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalAgregarHuesped()", true);
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
                if (!nuevo._tipo.Equals("cliente"))
                {
                    Response.Redirect("Inicio.aspx");
                }
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