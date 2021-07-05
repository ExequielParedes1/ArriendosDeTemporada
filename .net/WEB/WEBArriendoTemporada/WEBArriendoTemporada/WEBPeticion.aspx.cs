using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class WEBPeticion : System.Web.UI.Page
    {
        List<DepartamentoBLL> listaCarro = new List<DepartamentoBLL>();
        protected void Page_Load(object sender, EventArgs e)
        {
            PeticionBLL pet = new PeticionBLL();
            pet = (PeticionBLL)Session["peticion"];
            txtDate1.Text = pet._checkIn.ToString("dd/MM/yyyy");
            txtDate2.Text = pet._checkOut.ToString("dd/MM/yyyy");
            LblDias.Text = cantidadDias(txtDate1.Text, txtDate2.Text).ToString();
            txtZona.Text = pet._zona;
            if (Session["dptoReserva"] != null)
            {

                DepartamentoBLL carroDpto = new DepartamentoBLL();
                listaCarro = (List<DepartamentoBLL>)Session["dptoReserva"];


            }

            //calendarasd.


            GridCarro.DataSource = listaCarro;
            GridCarro.DataBind();
            int precio = 0;

            foreach (var item in listaCarro)
            {
                precio = precio + (item._ValorDiario * int.Parse(LblDias.Text));
            }
            LblPrecio.Text = string.Format("{0:#,##0}", precio);
            lblDeuda.Text = string.Format("{0:#,##0}", precio);
            lblAdelanto.Text = string.Format("{0:#,##0}", (precio * 0.30));
            //lblResto.Text = string.Format("{0:#,##0}", (precio * 0.30));
            txt_pagando.Text = (precio * 0.30).ToString();
            int x = listaCarro.Count;
            lblCantidadArriendos.Text = x.ToString();
            validarTareasRealizadas();
            validarTipoUsuario();

            txtZona.Text = pet._zona;
            MantencionBLL m = new MantencionBLL();
            txt_habitaciones.Text = pet._cantHabitacion.ToString();
            txt_huespedes.Text = pet._cantHuespedes.ToString();

            DepartamentoBLL nuevo = new DepartamentoBLL();
            GridDepartamentos.DataSource = nuevo.filtrarDepartamento(1, pet.cantHabitacion, pet.zona, listaCarro, pet.checkIn, pet.checOut);
            GridDepartamentos.DataBind();

        }


        //aca tengo que crear una lista recorrerla y reemplazar los datos de la lista para el arriendo
        //donde dice nueva necesito reemplazar para que me entregue los item
        protected void Click_Pagar(object sender, EventArgs e)
        {
            foreach (var dpto in listaCarro)
            {
                UsuarioBLL usr = new UsuarioBLL();
                usr = (UsuarioBLL)Session["usuario"];
                ReservaBLL nueva = new ReservaBLL();
                int precio = 0;
                foreach (var item in listaCarro)
                {
                    precio = precio + (item._ValorDiario * int.Parse(LblDias.Text));
                }
                nueva._dias_reserva = cantidadDias(txtDate1.Text, txtDate2.Text);
                nueva._valor_final = dpto._ValorDiario * int.Parse(LblDias.Text);
                nueva._check_in = Convert.ToDateTime(txtDate1.Text);
                nueva._check_Out = Convert.ToDateTime(txtDate2.Text);
                nueva._total_multas = 0;
                nueva._fecha_contrato = DateTime.UtcNow;
                nueva._metodo_pago = dlTarjeta.SelectedValue;
                nueva._departamento_id_departamento = dpto.idDepartamento;
                nueva._estado = "activo";
                if (int.Parse(txt_pagando.Text) < (precio * 0.30))
                {
                    throw new Exception("Necesita pagar cubrir el minimo solicitado");

                }
                else
                {
                    if (int.Parse(txt_pagando.Text) > precio)
                    {
                        throw new Exception("No puede exceder el costo máximo");

                    }
                    else
                    {
                        nueva._anticipo = (int)(dpto._ValorDiario * 0.30);
                    }

                }
                nueva._estado_pago = "pendiente";
                nueva._estado = "activo";

                int idArr = nueva.agregarReservaBLL(nueva, usr._correo);
                if (idArr != 0)
                {

                
                }
            }
            Response.Redirect("WEBSolicitarServicios.aspx");

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
        public int cantidadDias(string inicio, string final)
        {
            DateTime fInicio = Convert.ToDateTime(inicio);
            DateTime fFinal = Convert.ToDateTime(final);

            // Difference in days, hours, and minutes.
            TimeSpan ts = fFinal - fInicio;


            int diferenciaDias = ts.Days;
            if (diferenciaDias < 1)
            {
                return 1;
            }
            else
            {
                return diferenciaDias;
            }

        }

        protected void GridDepartamentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridDepartamentos.DataKeys[e.RowIndex].Values[0].ToString();
            DepartamentoBLL nuevo = new DepartamentoBLL();
            nuevo = nuevo.buscarDepartamento(int.Parse(id));
            Session["CarroDpto"] = nuevo;
            LblPrecio.Text = (nuevo.valirDiario * int.Parse(LblDias.Text)).ToString();
            lblAdelanto.Text = ((nuevo.valirDiario * int.Parse(LblDias.Text)).ToString());

            validar v = new validar();
            v.realizado = true;
            Session["registrado"] = v;


            listaCarro.Add(nuevo);
            Session["dptoReserva"] = listaCarro;
            Response.Redirect("WEBPeticion.aspx");

            // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ModalCalendario()", true);
        }
        //Metodo ecoger fecha especifica 


        protected void GridCarro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridCarro.DataKeys[e.RowIndex].Values[0].ToString();
            DepartamentoBLL dpto = new DepartamentoBLL();
            dpto = dpto.buscarDepartamento(int.Parse(id));
            List<DepartamentoBLL> listaCarroEliminar = new List<DepartamentoBLL>();
            foreach (var item in listaCarro)
            {
                if (item.idDepartamento == dpto.idDepartamento)
                {
                    listaCarroEliminar.Add(item);
                }
            }
            for (int i = 0; i < listaCarro.Count; i++)
            {
                foreach (var item in listaCarroEliminar)
                {
                    listaCarro.Remove(item);
                }
            }
            Response.Redirect("WEBPeticion.aspx");
        }

        protected void GridDepartamentos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id = GridDepartamentos.DataKeys[e.NewSelectedIndex].Values[0].ToString();

            FotoBLL nuevo = new FotoBLL();
            Repeater1.DataSource = nuevo.listarImagenesPorDpto(int.Parse(id));
            Repeater1.DataBind();

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "openModalFotosDeptos()", true);
        }
    }
}