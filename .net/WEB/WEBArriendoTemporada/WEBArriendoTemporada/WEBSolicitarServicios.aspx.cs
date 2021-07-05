using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBSolicitarServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioBLL servicio = new ServicioBLL();
            validarTareasRealizadas();
            ReservaBLL ar = new ReservaBLL();
            UsuarioBLL nuevo = new UsuarioBLL();
            nuevo = (UsuarioBLL)Session["usuario"];
            if (nuevo == null)
            {
                Response.Redirect("Inicio.aspx");
            }

            GridArriendo.DataSource = ar.listarSegunUsuario(nuevo._correo, "activo");
            GridArriendo.DataBind();
            GridVArriendoFinalizado.DataSource = ar.listarSegunUsuarioFinalizado(nuevo._correo);
            GridVArriendoFinalizado.DataBind();
            lblGastoTotal.Text = "$" + string.Format("{0:#,##0}", ar.gastoTotalReserva(nuevo._correo));
            lblPagado.Text = "$" + string.Format("{0:#,##0}", ar.gastoTotalPagado(nuevo._correo));
            lblDiferencia.Text = "$" + string.Format("{0:#,##0}", (ar.gastoTotalReserva(nuevo._correo) - ar.gastoTotalPagado(nuevo._correo)));

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

        protected void GridArriendo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string corre = GridArriendo.DataKeys[e.RowIndex].Values[0].ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalPagar()", true);
            ReservaBLL nuevo = new ReservaBLL();
            nuevo = nuevo.buscarReserva(int.Parse(corre));
            lblDeuda.Text = (nuevo._valor_final - nuevo._anticipo).ToString();
            lblNombreUsuario.Text = nuevo.id_reserva.ToString();
        }

        public void Click_pagarDeuda(object sender, EventArgs e)
        {
            ReservaBLL nuevo = new ReservaBLL();
            try
            {
                nuevo = nuevo.buscarReserva(int.Parse(lblNombreUsuario.Text));
                if (int.Parse(txt_pagando.Text) > int.Parse(lblDeuda.Text))
                {
                    throw new Exception("Sobrepasa la deuda");
                }
                if (int.Parse(txt_pagando.Text) <= 0)
                {
                    throw new Exception("El valor ingresado no es valido");
                }
                else
                {
                    nuevo._anticipo = nuevo._anticipo + int.Parse(txt_pagando.Text);
                }
                if (dlTarjeta.SelectedValue == "")
                {
                    throw new Exception("Ingrese un metodo de pago");
                }
                else
                {
                    nuevo._metodo_pago = dlTarjeta.SelectedValue;
                }

                if (int.Parse(lblDeuda.Text) == int.Parse(txt_pagando.Text))
                {
                    nuevo._estado_pago = "finalizado";
                }
                if (nuevo._check_Out < DateTime.Now && nuevo._estado_pago.Equals("finalizado"))
                {
                    nuevo._estado = "finalizado";
                }

                if (nuevo.ModificarReservaBLL(nuevo) == 1)
                {

                    UsuarioBLL usr = new UsuarioBLL();
                    usr = (UsuarioBLL)Session["usuario"];
                    

                    Correos correo = new Correos();
                    correo.enviarCorreoPago(usr, nuevo, nuevo.id_reserva);
                    validar val = new validar();
                    val.realizado = true;
                    Session["registrado"] = val;
                    Response.Redirect("WEBSolicitarServicios.aspx");
                }
                else
                {
                    validar val = new validar();
                    val.realizado = false;
                    Session["registrado"] = val;
                    Response.Redirect("WEBSolicitarServicios.aspx");
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalPagar()", true);
            }
        }

        protected void GridArriendo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string cod = GridArriendo.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            Session["codArriendo"] = cod;
            Response.Redirect("WEBDetalleReserva.aspx");
        }
    }
}