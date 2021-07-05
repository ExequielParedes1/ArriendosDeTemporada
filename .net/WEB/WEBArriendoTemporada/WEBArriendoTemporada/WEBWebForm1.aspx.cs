using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBWebForm1 : System.Web.UI.Page
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
                nav_losgs.Visible = false;
                nav_funcionario.Visible = false;
                nav_caracInventa.Visible = false;
                navServicios.Visible = false;
                navAdministrar.Visible = false;
                navRestaurar.Visible = false;
                navActivarUsuario.Visible = false;
                menuPerfil.Visible = false;
                nav_contactanos.Visible = true;
                nav_reservar.Visible = true;
                panelAdmin.Visible = false;
                nav_AdministrarArriendos.Visible = false;

                nav_reportes.Visible = false;
                // MenuNotificaciones.Visible = false;
                //MenuMensuja.Visible = false;
                solicitarServicios.Visible = false;
                //    LoginStatus1.Visible = true;
                nav_servicio.Visible = false;
                nav_agregarCliente.Visible = false;
                nav_agregarDepartamento.Visible = false;
                nav_cerrar.Visible = false;
                //   nav_perfil.Visible = false;
                //  nav_administrar.Visible = false;
                // nav_historico.Visible = false;
                // nav_servicios_usuario.Visible = false;
                navActivarServicio.Visible = false;
            }
            else
            {
                if (usuario._tipo.Equals("admin"))
                {

                    UsuarioBLL perfil = new UsuarioBLL();
                    perfil = perfil.buscarUsuario(usuario._correo);
                    nav_losgs.Visible = true;
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
                    txtContraseñaPerfil.Text = perfil._contraseña;

                    nav_funcionario.Visible = true;
                    nav_caracInventa.Visible = true;
                    navServicios.Visible = false;
                    navAdministrar.Visible = true;
                    navRestaurar.Visible = true;
                    navActivarUsuario.Visible = true;
                    menuPerfil.Visible = true;
                    navActivarServicio.Visible = true;
                    nav_contactanos.Visible = false;
                    nav_reservar.Visible = false;
                    panelAdmin.Visible = true;
                    nav_AdministrarArriendos.Visible = true;

                    nav_reportes.Visible = true;
                    //     MenuNotificaciones.Visible = true;
                    //   MenuMensuja.Visible = true;
                    //   nav_servicios_usuario.Visible = false;
                    solicitarServicios.Visible = false;
                    //  nav_historico.Visible = true;
                    nav_servicio.Visible = true;
                    nav_agregarCliente.Visible = true;
                    nav_agregarDepartamento.Visible = true;
                    LoginStatus1.Visible = false;
                    nav_cerrar.Visible = true;
                    //     nav_perfil.Visible = true;
                    //     nav_administrar.Visible = true;
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
                        nav_losgs.Visible = false;
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
                        txtContraseñaPerfil.Text = perfil._contraseña;

                        nav_funcionario.Visible = false;
                        nav_caracInventa.Visible = false;
                        navServicios.Visible = true;
                        navAdministrar.Visible = false;
                        navRestaurar.Visible = false;
                        navActivarUsuario.Visible = false;
                        menuPerfil.Visible = true;
                        navActivarServicio.Visible = false;
                        nav_contactanos.Visible = true;
                        nav_reservar.Visible = true;
                        panelAdmin.Visible = false;
                        nav_AdministrarArriendos.Visible = false;

                        nav_reportes.Visible = false;
                        //nav_servicios_usuario.Visible = true;
                        solicitarServicios.Visible = true;
                        //  nav_historico.Visible = false;
                        LoginStatus1.Visible = false;
                        nav_servicio.Visible = true;
                        nav_agregarCliente.Visible = false;
                        nav_agregarDepartamento.Visible = false;
                        nav_cerrar.Visible = true;
                        lbl_nombreUsuarioTipo.Text = usuario._tipo;
                        lbl_nombreUsuarioNombre.Text = usuario.nombre + " " + usuario._apellido;
                        //    nav_administrar.Visible = false;
                    }
                }

            }

            //LogBLL log = new LogBLL();

            //gridLog.DataSource = log.ListarLogBLL();
            //gridLog.DataBind();
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
    }
}