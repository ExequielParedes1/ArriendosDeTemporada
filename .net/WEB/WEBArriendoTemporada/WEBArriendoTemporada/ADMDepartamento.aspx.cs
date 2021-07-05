using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;
namespace WEBArriendoTemporada
{
    public partial class ADMDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaCaracteristicaBLL lstaCara = new ListaCaracteristicaBLL();
            DepartamentoBLL nuevo = new DepartamentoBLL();
            nuevo = (DepartamentoBLL)Session["Departamento"];
            ListaCaracteristicaBLL carDpto = new ListaCaracteristicaBLL();
            MantencionBLL manten = new MantencionBLL();
            cargarDatosDepartamento();
            validarTareasRealizadas();
            validarTipoUsuario();
            CaracteristicaDptoBLL ca = new CaracteristicaDptoBLL();
            ItemBLL item = new ItemBLL();
            InventarioBLL ri = new InventarioBLL();
            GrindInventario.DataSource = item.listarItemBLLFiltrado(ri.listarRegistroInventarioDpto(nuevo.idDepartamento));
            GrindInventario.DataBind();
            GridCaracteristicas.DataSource = lstaCara.ListadoCaracteristicaSegunDepartamentoBLL(nuevo.idDepartamento);
            GridCaracteristicas.DataBind();
            GridTodosLosServicios.DataSource = ca.listarCaracteristicasFilrado(lstaCara.ListadoCaracteristicaSegunDepartamentoBLL(nuevo.idDepartamento));
            GridTodosLosServicios.DataBind();
            GridMantencionesActivas.DataSource = manten.listarMantenciones(nuevo.idDepartamento, "activa");
            GridMantencionesActivas.DataBind();
            GridMantencionesInActivas.DataSource = manten.listarMantenciones(nuevo.idDepartamento, "inactivo");
            GridMantencionesInActivas.DataBind();
            GridView1.DataSource = ri.listarRegistroInventarioDpto(nuevo.idDepartamento);
            GridView1.DataBind();
        }

        public void btnEditar_click(object sender, EventArgs e)
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();
            nuevo = (DepartamentoBLL)Session["Departamento"];
            nuevo = nuevo.buscarDepartamento(nuevo.idDepartamento);


            txt_direccionedit.Text = nuevo.direccion;
            txt_metrosCedit.Text = nuevo.mtrsCuadrados.ToString();
            txt_valorDiariosedit.Text = nuevo.valirDiario.ToString();
            txt_zonaedit.Text = nuevo.zona;
            txt_habitacionesedit.Text = nuevo.nro_habitaciones.ToString();
            txt_bañosedit.Text = nuevo.nro_baños.ToString();

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalEditar()", true);
        }
        public void btn_editarrDepartamento_click(object sender, EventArgs e)
        {

            DepartamentoBLL nuevo = new DepartamentoBLL();
            try
            {
                nuevo = nuevo.buscarDepartamento(int.Parse(txtID.Text));
                if (txt_direccionedit.Text == "")
                {
                    throw new Exception("La direccion no puede estar vacia");
                }
                else
                {
                    nuevo.direccion = txt_direccionedit.Text;
                }
                if (int.Parse(txt_metrosCedit.Text) <= 0)
                {
                    throw new Exception("Los metros cuadrados del departamento son incorrectos");
                }
                else
                {
                    nuevo.mtrsCuadrados = int.Parse(txt_metrosCedit.Text);
                }
                if (int.Parse(txt_valorDiariosedit.Text) <= 0)
                {
                    throw new Exception("El valor diario ingresado no es valido");
                }
                else
                {
                    nuevo.valirDiario = int.Parse(txt_valorDiariosedit.Text);
                }
                if (txt_zonaedit.Text == "")
                {
                    throw new Exception("La zona ingresada no es correcta");
                }
                else
                {
                    nuevo.zona = txt_zonaedit.Text;
                }
                if (int.Parse(txt_habitacionesedit.Text) <= 0)
                {
                    throw new Exception("El numero de habitaciones ingresado no es correcto");
                }
                else
                {
                    nuevo.nro_habitaciones = int.Parse(txt_habitacionesedit.Text);
                }
                if (int.Parse(txt_bañosedit.Text) <= 0)
                {
                    throw new Exception("El numero de baños ingresado no es correcto");
                }
                else
                {
                    nuevo.nro_baños = int.Parse(txt_bañosedit.Text);
                }
                if (nuevo.editarDepartamento(nuevo) == 1)
                {
                  
                    validar val = new validar();
                    val.realizado = true;
                    Session["registrado"] = val;
                    Response.Redirect("ADMDepartamento.aspx");
                }
                else
                {
                    validar val = new validar();
                    val.realizado = false;
                    Session["registrado"] = val;
                    Response.Redirect("ADMDepartamento.aspx");
                }



            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }

        }
        public void clic_desactivar_departamento(object sender, EventArgs e)
        {
            string idDpto = txtID.Text;
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


        public void cargarDatosDepartamento()
        {
            try
            {
                DepartamentoBLL nuevo = new DepartamentoBLL();
                nuevo = (DepartamentoBLL)Session["Departamento"];
                nuevo = nuevo.buscarDepartamento(nuevo.idDepartamento);
                txtID.Text = nuevo.idDepartamento.ToString();
                txtDirecccion.Text = nuevo.direccion;
                txtMtrs.Text = nuevo.mtrsCuadrados.ToString();
                txtValorDiario.Text = nuevo.valirDiario.ToString();
                txtZona.Text = nuevo.zona;

            }
            catch (Exception)
            {
                Response.Redirect("Inicio.aspx");
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
        //Esta opcion lo que hace es asociar los servicios con el departamento
        protected void GridTodosLosServicios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DepartamentoBLL nuevoDpto = new DepartamentoBLL();
            nuevoDpto = (DepartamentoBLL)Session["Departamento"];
            string codigo = GridTodosLosServicios.DataKeys[e.RowIndex].Values[0].ToString();
            ListaCaracteristicaBLL relacion = new ListaCaracteristicaBLL();
            relacion.idDepartamento = nuevoDpto.idDepartamento;
            relacion.idCaracteristica = int.Parse(codigo);
            if (relacion.AgregarListaCaracteristicaBLL(relacion) == 1)
            {
               


                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
        }

        protected void GridCaracteristicas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string codigo = GridCaracteristicas.DataKeys[e.RowIndex].Values[0].ToString();
            CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
            nuevo = nuevo.buscarCaracteristica(int.Parse(codigo));
            //nuevo.idDepartamento = null;
            if (nuevo.modificarCaracteristicaBLL(nuevo) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
        }

        protected void GridCaracteristicas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string codigo = GridCaracteristicas.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            DepartamentoBLL nuevoDpto = new DepartamentoBLL();
            nuevoDpto = (DepartamentoBLL)Session["Departamento"];
            ListaCaracteristicaBLL nueva = new ListaCaracteristicaBLL();
            nueva.idDepartamento = nuevoDpto.idDepartamento;
            nueva.idCaracteristica = int.Parse(codigo);
            if (nueva.eliminarListaCaracteristicaBLL(nueva) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
        }
        public void btn_finalizarMantencion(object sender, EventArgs e)
        {
            MantencionBLL mantencion = new MantencionBLL();
            EncargadoBLL encargado = new EncargadoBLL();

            try
            {
                if (txtRutEncargado.Text == "")
                {
                    throw new Exception("El rut no puede estar vacio");
                }
                else
                {
                    if (validarRut(txtRutEncargado.Text) == false)
                    {
                        throw new Exception("El rut ingreso no es valido");
                    }
                    else
                    {
                        encargado._rut = txtRutEncargado.Text;
                    }
                    //agregar que el rut sea valido

                }
                if (txtNumeroContactoEncargadoo.Text.Length == 7)
                {
                    throw new Exception("El numero de contacto del encargado no es correcto");
                }
                else
                {
                    encargado._nro_contacto = int.Parse(txtNumeroContactoEncargadoo.Text);
                }
                if (txtNombreEncargado.Text == "")
                {
                    throw new Exception("El nombre del encargado no puede estar vacio");
                }
                else
                {
                    encargado._nombre = txtNombreEncargado.Text;
                }
                if (txtApellidoEncargado.Text == "")
                {
                    throw new Exception("El apellido del encargado no puede estar vacio");
                }
                else
                {
                    encargado._apellido = txtApellidoEncargado.Text;
                }
                if (txtCorreoEncargado.Text == "")
                {
                    throw new Exception("El correo del encargado no puede estar vacio");
                }
                else
                {
                    encargado._email = txtCorreoEncargado.Text;
                }

                mantencion._fecha_termino = Convert.ToDateTime(txtFechaTermino.Text);
                mantencion._motivo = txtMotivo.Text;
                mantencion._tipo_mantencion = txtTipoMantencion.Text;
                mantencion._fecha_inicio = Convert.ToDateTime(txtFechaInicio.Text);
                mantencion._descripcion = txtDescipcion.Text;
                mantencion._varlo_total = int.Parse(txtValorMantecion.Text);
                mantencion._encargado_rut = txtRutEncargado.Text;
                mantencion._departamento_id_departamento = int.Parse(txtID.Text);

                if (encargado.agregarEncargadoBLL(encargado) == 1)
                {
                    mantencion.agregarMantencion(mantencion);
                   

                    validar v = new validar();
                    v.realizado = true;
                    Session["registrado"] = v;
                    Response.Redirect("ADMDepartamento.aspx");
                }
                else
                {
                    validar v = new validar();
                    v.realizado = false;
                    Session["registrado"] = v;
                    Response.Redirect("ADMDepartamento.aspx");
                }

            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModarAgregarEncargado()", true);
            }

        }
        public void clic_mantencion(object sender, EventArgs e)
        {
            try
            {
                if (txtValorMantecion.Text.Length <= 0)
                {
                    throw new Exception("El valor de la mantencion no es correcto");
                }
                if (txtDescipcion.Text == "")
                {
                    throw new Exception("La mantencion tiene que tener una descripcion");
                }
                if (Convert.ToDateTime(txtFechaInicio.Text) < DateTime.Now)
                {
                    throw new Exception("La fecha de inicio tiene que ser mayor a la actual");
                }
                if (Convert.ToDateTime(txtFechaTermino.Text) < Convert.ToDateTime(txtFechaInicio.Text))
                {
                    throw new Exception("La fecha de termino no puede ser inferior a la de termino");
                }
                if (txtMotivo.Text == "")
                {
                    throw new Exception("La mantencion tiene que tener un motivo");
                }
                if (txtTipoMantencion.Text == "")
                {
                    throw new Exception("La mantencion tiene que tener un tipo de mantencion");
                }
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModarAgregarEncargado()", true);
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }

        }
        public void clic_buscarEncargado(object sender, EventArgs e)
        {
            try
            {
                EncargadoBLL nuevo = new EncargadoBLL();
                nuevo = nuevo.buscarEncargadoBLL(txtRutEncargado.Text);
                if (nuevo._email == "")
                {
                    throw new Exception("No se encuentra registrado ese rut");
                }
                txtNumeroContactoEncargadoo.Text = nuevo._nro_contacto.ToString();
                txtNombreEncargado.Text = nuevo._nombre;
                txtApellidoEncargado.Text = nuevo._apellido;
                txtCorreoEncargado.Text = nuevo._email;

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModarAgregarEncargado()", true);
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModarAgregarEncargado()", true);
            }



        }

        protected void GridMantenciones_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string codigo = GridMantencionesActivas.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            MantencionBLL nuevo = new MantencionBLL();
            nuevo = nuevo.buscarMantencion(int.Parse(codigo));

            nuevo._estadoMantencion = "inactivo";
            if (nuevo.modificarMantencion(nuevo) == 1)
            {
               
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
        }

        protected void clic_galeria(object sender, EventArgs e)
        {
            Response.Redirect("WEBGaleriaDepartamento.aspx");
        }

        protected void GrindInventario_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string codigo = GrindInventario.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            hidencantidad.Value = codigo;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModalCantidadInventario()", true);
        }
        protected void clic_cantidad_inventario(object sender, EventArgs e)
        {
            DepartamentoBLL nuevo = new DepartamentoBLL();
            nuevo = (DepartamentoBLL)Session["Departamento"];
            InventarioBLL ri = new InventarioBLL();
            ItemBLL item = new ItemBLL();
            item = item.buscarItemBLL(int.Parse(hidencantidad.Value));

            ri._fecha_asignacion = DateTime.Now;
            ri._id_item_id = item.id_item;
            ri._cantidad = int.Parse(txtCantidadInventario.Text);
            ri._id_departamento_id = nuevo.idDepartamento;
            ri._valor_total = item._valor * (int.Parse(txtCantidadInventario.Text));

            if (ri.agregarRegistroInventario(ri) == 1)
            {
                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }

        }
        public void clic_Volver_mantencion(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModalMantencion()", true);
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string codigo = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            DepartamentoBLL nuevoDpto = new DepartamentoBLL();
            nuevoDpto = (DepartamentoBLL)Session["Departamento"];
            InventarioBLL nueva = new InventarioBLL();

            nueva = nueva.buscarInventario(nuevoDpto.idDepartamento, int.Parse(codigo));
            if (nueva.eliminarInventario(nueva) == 1)
            {
               

                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string codigo = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            modiInventario.Value = codigo;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModalCantidadInventarioModificar()", true);
        }
        protected void clic_modi_inventario(object sender, EventArgs e)
        {
            InventarioBLL nuevo = new InventarioBLL();
            DepartamentoBLL nuevoDpto = new DepartamentoBLL();
            nuevoDpto = (DepartamentoBLL)Session["Departamento"];

            nuevo = nuevo.buscarInventario(nuevoDpto.idDepartamento, int.Parse(modiInventario.Value));
            nuevo._cantidad = int.Parse(TextBox1.Text);
            if (nuevo.modificarInventario(nuevo) == 1)
            {
               

                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }

        }

        protected void GridMantencionesActivas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cod = GridMantencionesActivas.DataKeys[e.RowIndex].Values[0].ToString();
            MantencionBLL man = new MantencionBLL();
            man = man.buscarMantencion(int.Parse(cod));
            txtModValor.Text = man._varlo_total.ToString();
            txtModDesc.Text = man._descripcion;
            txtModInicio.Text = man._fecha_inicio.ToString("yyyy-MM-dd");
            txtModTermino.Text = man._fecha_termino.ToString("yyyy-MM-dd");
            txtModMotivo.Text = man._motivo;
            txtmodTipo.Text = man._tipo_mantencion;
            hidenModMantencion.Value = cod;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalModificarMantencion()", true);
        }
        protected void clic_editar_mantencion(object sender, EventArgs e)
        {
            MantencionBLL man = new MantencionBLL();
            man = man.buscarMantencion(int.Parse(hidenModMantencion.Value));
            man._varlo_total = int.Parse(txtModValor.Text);
            man._descripcion = txtModDesc.Text;
            man._fecha_inicio = Convert.ToDateTime(txtModInicio.Text);
            man._fecha_termino = Convert.ToDateTime(txtModTermino.Text);
            man._motivo = txtModMotivo.Text;
            man._tipo_mantencion = txtmodTipo.Text;
            if (man.modificarMantencion(man) == 1)
            {
             

                validar v = new validar();
                v.realizado = true;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
            }
            else
            {
                validar v = new validar();
                v.realizado = false;
                Session["registrado"] = v;
                Response.Redirect("ADMDepartamento.aspx");
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