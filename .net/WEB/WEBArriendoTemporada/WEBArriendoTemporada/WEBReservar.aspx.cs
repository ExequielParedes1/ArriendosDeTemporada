using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBReservar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarComboBox();
        }
        protected void reservar_clic(object sender, EventArgs e)
        {
            PeticionBLL nuevo = new PeticionBLL();
            try
            {
                if (DLZona.SelectedValue == "")
                {
                    throw new Exception("No hay zonas disponibles");
                }
                else
                {
                    nuevo.zona = DLZona.SelectedValue;
                }
                if (txtDate1.Text == "")
                {
                    throw new Exception("Tiene que ingresar una fecha de inicio");
                }
                else
                {
                    if (Convert.ToDateTime(txtDate1.Text) < DateTime.Now)
                    {
                        throw new Exception("La fecha de inicio no es valida");
                    }
                    else
                    {
                        nuevo.checkIn = Convert.ToDateTime(txtDate1.Text);
                    }
                }
                if (txtDate2.Text == "")
                {
                    throw new Exception("La fecha de termino no puede estar vacia");
                }
                else
                {
                    if (Convert.ToDateTime(txtDate1.Text) > Convert.ToDateTime(txtDate2.Text))
                    {
                        throw new Exception("La fecha de termino tiene que ser posterior a la fecha de inicio");
                    }
                    else
                    {
                        nuevo.checOut = Convert.ToDateTime(txtDate2.Text);
                    }
                }
                if (int.Parse(txt_habitaciones.Text) <= 0)
                {
                    throw new Exception("El numero de habitaciones no es correcto");

                }
                else
                {
                    nuevo.cantHabitacion = int.Parse(txt_habitaciones.Text);
                }
                if (int.Parse(txt_huespedes.Text) <= 0)
                {
                    throw new Exception("El numero de huespedes no es correcto");
                }
                else
                {
                    nuevo.cantHuespedes = int.Parse(txt_huespedes.Text);
                }
                //aca tengo que hacer un if para que al momento de de buscar me diga si es que tiene una deuda de un arriendo 
                DetalleMulta dm = new DetalleMulta();
                UsuarioBLL usr = new UsuarioBLL();
                usr = (UsuarioBLL)Session["usuario"];
                if (dm.listaMultaPorUsuario(usr._correo).Count > 0)
                {
                    throw new Exception("No se puede realizar reserva si tiene MULTAS pendientes");
                }
                Session["peticion"] = nuevo;
                Response.Redirect("WEBPeticion.aspx");
            }
            catch (Exception exp)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "No se puedo registrar", "alertify.alert('¡Error!', '" + exp.Message.ToString() + "', function(){ alertify.error('Intente nuevamente'); });", true);
            }


        }
        public void cargarComboBox()
        {

            DepartamentoBLL dpto = new DepartamentoBLL();

            List<string> listaZona = new List<string>();
            List<string> listaZonaSinRepetir = new List<string>();

            foreach (var item in dpto.listarDepartamentoPorEstado(1))
            {
                listaZona.Add(item._Zona);
            }
            listaZonaSinRepetir = listaZona.Distinct().ToList();
            foreach (var item in listaZonaSinRepetir)
            {
                ListItem i;
                i = new ListItem(item, item);
                DLZona.Items.Add(i);

            }
        }
    }
}