using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //valida las paginas para sus usos
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                  new ScriptResourceDefinition
                  {
                      Path = "~/scripts/jquery-1.8.3.min.js",
                      DebugPath = "~/scripts/jquery-1.8.3.js",
                      CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js",
                      CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.js"
                  });

            UsuarioBLL usuario = new UsuarioBLL();
            usuario = (UsuarioBLL)Session["usuario"];

            if (usuario == null)
            {
                nav_contactanos.Visible = true;
                nav_reservar.Visible = true;
                Nav_Login.Visible = true;

                Nav_Registrar.Visible = false;
                Nav_ADM1.Visible = false;
                Nav_ADM2.Visible = false;
                Nav_ADM3.Visible = false;
                Nav_ADM4.Visible = false;
                Nav_Web_Viajes.Visible = false;            //href="WEBViaje.aspx"
                Nav_Webpetici.Visible = false;             //href="~/WEBPeticion.aspx"
                Nav_RecuCuent.Disabled = false;             //href="~/WEBRecuperarCuenta.aspx"
                Nav_DetaReser.Visible = false;             //href = "WEBDetalleReserva.aspx"
                Nav_ModelDept.Visible = false;             //href="~/WEBGaleriaDepartamento.aspx"
                Nav_ADM_Condu.Visible = false;             //href= "~/ADMConductoresVehiculos.aspx"
                Nav_ADM_ResDe.Visible = false;             //href="~/ADMReservaDetalle.aspx"
                nav_funcionario.Visible = false;           //href="AdministrarFuncionario.aspx"
                nav_caracInventa.Visible = false;          //href="AdministrarCaracteristicaInventario.aspx"
                navServicios.Visible = false;              //href="AdministrarServicio.aspx"
                navActivarUsuario.Visible = false;         //href = "~/ADMUsuario.aspx"
                menuPerfil.Visible = false;
                nav_AdministrarArriendos.Visible = false;  //href="AdministrarArriendos.aspx"
                nav_reportes.Visible = false;
                solicitarServicios.Visible = false;
                nav_agregarCliente.Visible = false;        //href="AdministrarUsuario.aspx"
                nav_agregarDepartamento.Visible = false;   //href="Departamento.aspx"
                nav_cerrar.Visible = false;
                navActivarServicio.Visible = false;        //href="RestaurarServicios.aspx"
            }
            else
            {
                if (usuario._tipo.Equals("admin"))
                {
                    UsuarioBLL perfil = new UsuarioBLL();
                    perfil = perfil.buscarUsuario(usuario._correo);
                    txtCorreoPerfil.ReadOnly = true;
                    txtCorreoPerfil.Text = perfil._correo;
                    txtRutPerfil.ReadOnly = true;
                    txtRutPerfil.Text = perfil._cedula;
                    txtNombrePerfil.ReadOnly = true;
                    txtNombrePerfil.Text = perfil._nombre;
                    txtApellidoPerfil.ReadOnly = true;
                    txtApellidoPerfil.Text = perfil._apellido;
                    txtTelefonoPerfil.ReadOnly = true;
                    txtTelefonoPerfil.Text = perfil._numeroContacto.ToString();
                    txtContraseñaPerfil.ReadOnly = true;
                    txtContraseñaPerfil.Attributes.Add("value", perfil._contraseña);

                    //Vistas Visibles para el ADMIN
                    nav_funcionario.Visible = true;
                    nav_caracInventa.Visible = true;
                    navActivarUsuario.Visible = true; //href="RestaurarUsuario.aspx"
                    navServicios.Visible = true;
                    navActivarServicio.Visible = true;
                    nav_AdministrarArriendos.Visible = true;
                    nav_agregarCliente.Visible = true;
                    nav_agregarDepartamento.Visible = true;
                    nav_reportes.Visible = true;
                    nav_cerrar.Visible = true;

                    menuPerfil.Visible = false;
                    Nav_Registrar.Visible = false;
                    Nav_ADM4.Visible = false;
                    Nav_DetaReser.Visible = false;
                    Nav_ModelDept.Visible = false;
                    Nav_Ver_Depto.Visible = false;
                    Nav_Web_Viajes.Visible = false;
                    Nav_Webpetici.Visible = false;
                    Nav_ADM_ResDe.Visible = false;
                    nav_contactanos.Visible = false;
                    nav_reservar.Visible = false;
                    solicitarServicios.Visible = false;
                    LoginStatus1.Visible = false;
                    lbl_nombreUsuarioTipo.Text = usuario._tipo;
                    lbl_nombreUsuarioNombre.Text = usuario.nombre + " " + usuario._apellido;
                }
                else
                {
                    if (usuario._tipo.Equals("cliente"))
                    {
                        UsuarioBLL perfil = new UsuarioBLL();
                        perfil = perfil.buscarUsuario(usuario._correo);
                        txtCorreoPerfil.ReadOnly = true;
                        txtCorreoPerfil.Text = perfil._correo;
                        txtRutPerfil.ReadOnly = true;
                        txtRutPerfil.Text = perfil._cedula;
                        txtNombrePerfil.ReadOnly = true;
                        txtNombrePerfil.Text = perfil._nombre;
                        txtApellidoPerfil.ReadOnly = true;
                        txtApellidoPerfil.Text = perfil._apellido;
                        txtTelefonoPerfil.ReadOnly = true;
                        txtTelefonoPerfil.Text = perfil._numeroContacto.ToString();
                        txtContraseñaPerfil.ReadOnly = true;
                        txtContraseñaPerfil.Attributes.Add("value", perfil._contraseña);

                        navServicios.Visible = true;
                        menuPerfil.Visible = true;
                        nav_contactanos.Visible = true;
                        nav_reservar.Visible = true;
                        solicitarServicios.Visible = true;
                        nav_cerrar.Visible = true;

                        Nav_ADM1.Visible = false;
                        Nav_ADM2.Visible = false;
                        Nav_ADM3.Visible = false;

                        Nav_Registrar.Visible = false;
                        menuPerfil.Visible = false;
                        Nav_Ver_Depto.Visible = true;
                        Nav_ModelDept.Visible = false;
                        Nav_DetaReser.Visible = false;  
                        Nav_Webpetici.Visible = false;
                        nav_funcionario.Visible = false;
                        nav_caracInventa.Visible = false;
                        
                        //navAdministrar.Visible = false;
                        //navRestaurar.Visible = false;
                        navActivarUsuario.Visible = false;
                        
                        navActivarServicio.Visible = false;
                        
                        //panelAdmin.Visible = false;
                        nav_AdministrarArriendos.Visible = false;

                        nav_reportes.Visible = false;
                        //nav_servicios_usuario.Visible = true;
                        //  nav_historico.Visible = false;
                        LoginStatus1.Visible = false;
                        //nav_servicio.Visible = true;
                        nav_agregarCliente.Visible = false;
                        nav_agregarDepartamento.Visible = false;
                        lbl_nombreUsuarioTipo.Text = usuario._tipo;
                        lbl_nombreUsuarioNombre.Text = usuario.nombre + " " + usuario._apellido;
                        //    nav_administrar.Visible = false;
                    }
                }
            }
        }

        public void cerrar_click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Inicio.aspx");
        }
        public void clic_editar_perfil(object sender, EventArgs e)
        {
            txtCorreoPerfil.ReadOnly = true;
            txtRutPerfil.ReadOnly = true;
            txtNombrePerfil.ReadOnly = false;
            txtApellidoPerfil.ReadOnly = false;
            txtTelefonoPerfil.ReadOnly = false;
            txtContraseñaPerfil.ReadOnly = false;

            Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalEditarPerfil()", true);
        }

        public void click_guardar_cambios_perfil(object sender, EventArgs e)
        {
            UsuarioBLL nuevo = new UsuarioBLL();
            nuevo = nuevo.buscarUsuario(txtCorreoPerfil.Text);

            nuevo._nombre = txtNombrePerfil.Text;
            nuevo._apellido = txtApellidoPerfil.Text;
            nuevo._numeroContacto = int.Parse(txtTelefonoPerfil.Text);
            nuevo._contraseña = txtContraseñaPerfil.Text;

            if (nuevo.editarUsuario(nuevo) == 1)
            {

            }
        }
    }
}