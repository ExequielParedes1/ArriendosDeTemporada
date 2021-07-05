using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBSolicitarTransporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarComboBox();
            validarTareasRealizadas();
            ViajeBLL viaje = new ViajeBLL();
            //GridEsperaSolicitud.DataSource = viaje.listarViajesPorEstado(0);
            GridEsperaSolicitud.DataBind();
        }
        protected void btnSolicitarTransporte(object sender, EventArgs e)
        {
            ViajeBLL viaje = new ViajeBLL();
            try
            {
                if (txtOrigen.Text == "")
                {
                    throw new Exception("Ingrese un origen de transporte");
                }
                else
                {
                    viaje.origen = txtOrigen.Text;
                }
                if (txtDestino.Text == "")
                {
                    throw new Exception("Ingrese un destino de transporte valido");
                }
                else
                {
                    viaje.destino = txtDestino.Text;
                }
                if (txtComienzo.Text == "")
                {
                    throw new Exception("Ingrese una fecha y hora de comienzo");
                }
                else
                {
                    viaje.inicio = Convert.ToDateTime(txtComienzo.Text);
                }
                if (int.Parse(DLdpto.SelectedValue) <= 0)
                {
                    throw new Exception("Ingrese un departamento al cual cargar servicio");
                }
                else
                {
                    viaje.id_arriendo_id = int.Parse(DLdpto.SelectedValue);
                }
                if (DDLConductor.SelectedValue == "")
                {
                    throw new Exception("Tiene que ingresar un conductor");
                }
                else
                {
                    viaje.rutConductor = DDLConductor.SelectedValue;
                }
                if (DDLVehiculo.SelectedValue == "")
                {
                    throw new Exception("Tiene que ingresar un vehiculo para el transporte");
                }
                else
                {
                    viaje.patenteVehiculo = DDLVehiculo.SelectedValue;
                }
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
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
        public void cargarComboBox()
        {
            UsuarioBLL usr = new UsuarioBLL();
            usr = (UsuarioBLL)Session["usuario"];
            ReservaBLL nuevo = new ReservaBLL();

            
            VehiculoBLL auto = new VehiculoBLL();

            foreach (var item in auto.listarVehiculoEstado(1))
            {
                ListItem i;
                i = new ListItem(item.modelo, item.patente);
                DDLVehiculo.Items.Add(i);

            }

            ConductorBLL chofer = new ConductorBLL();
            foreach (var item in chofer.listarConductorEstado(1))
            {
                ListItem i;
                i = new ListItem(item.nombre + " " + item.apellido, item.rut);
                DDLConductor.Items.Add(i);

            }
        }
        protected void GridEsperaSolicitud_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string codigo = GridEsperaSolicitud.DataKeys[e.RowIndex].Values[0].ToString();
            ViajeBLL viaje = new ViajeBLL();
        }
    }
}