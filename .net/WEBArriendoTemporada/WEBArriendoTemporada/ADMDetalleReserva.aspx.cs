using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBArriendoTemporada.NEGOCIO;

namespace WEBArriendoTemporada
{
    public partial class ADMDetalleReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //mandar a inicio y ver usuario tipo admin
            if (Session["codDetalleArriendo"].ToString() == "")
            {
                Response.Redirect("Inicio.aspx");
            }
            string codArriendo = Session["codDetalleArriendo"].ToString();
            DetalleMulta dm = new DetalleMulta();
            InvolucradoBLL inv = new InvolucradoBLL();
            UsuarioBLL usr = new UsuarioBLL();
            UsuarioBLL fun = new UsuarioBLL();
            DepartamentoBLL dpto = new DepartamentoBLL();
            ReservaBLL arr = new ReservaBLL();
            ListaAcompBLL ls = new ListaAcompBLL();
            arr = arr.buscarReserva(int.Parse(codArriendo));

            txtID.Text = arr.id_reserva.ToString();
            txtValorFinal.Text = arr._valor_final.ToString();
            txtcheckIn.Text = arr._check_in.ToString("dd/MM/yyyy");
            txtCheckOut.Text = arr._check_Out.ToString("dd/MM/yyyy");
            txtFechaContrato.Text = arr._fecha_contrato.ToString();
            txtMetodoPago.Text = arr._metodo_pago;
            txtEstadoPago.Text = arr._estado_pago;
            txtEstado.Text = arr._estado;

            dpto = dpto.buscarDepartamento(arr._departamento_id_departamento);

            txtIdDepartamento.Text = dpto.idDepartamento.ToString();
            txtDirecccion.Text = dpto._Direccion;
            txtMtrs.Text = dpto._MtrsCuadrados.ToString();
            txtValorDiario.Text = dpto._ValorDiario.ToString();
            txtZona.Text = dpto._Zona;

            FotoBLL nuevo = new FotoBLL();
            Repeater1.DataSource = nuevo.listarImagenesPorDpto(dpto.idDepartamento);
            Repeater1.DataBind();


            usr = inv.buscarUsuarioInvolucrado(arr.id_reserva, "cliente");

            txtCorreousr.Text = usr._correo;
            txtRutusr.Text = usr._cedula;
            txtNombreusr.Text = usr._nombre;
            txtApellidousr.Text = usr._apellido;
            txtTelefonousr.Text = usr._numeroContacto.ToString();

            gridHuespedes.DataSource = ls.ListadoListaAcompananteBLL(arr.id_reserva);
            gridHuespedes.DataBind();

            fun = inv.buscarUsuarioInvolucrado(arr.id_reserva, "funcionario");
            txtCorreoFun.Text = fun._correo;
            txtRutFun.Text = fun._cedula;
            txtNombreFun.Text = fun._nombre;
            txtApellidoFun.Text = fun._apellido;
            txtTelefonoFun.Text = fun._numeroContacto.ToString();

            gridMultas.DataSource = dm.listaMultaPorArriendo(int.Parse(codArriendo));
            gridMultas.DataBind();



        }

        public void clic_multar(object sender, EventArgs e)
        {

            string codArriendo = Session["codDetalleArriendo"].ToString();
            MultaBLL multa = new MultaBLL();
            DetalleMulta dm = new DetalleMulta();
            ReservaBLL arr = new ReservaBLL();

            arr = arr.buscarReserva(int.Parse(codArriendo));

            multa.Nombre = txtNombreMulta.Text;
            multa.Descripcion = txtDescripcionMulta.Text;
            multa.Valor = int.Parse(txtValorMulta.Text);
            multa.Estado_Multa = "activo";
            int codMulta = multa.agregarMultaBLL(multa);
            if (codMulta != 0)
            {
              
                arr._valor_final = arr._valor_final + int.Parse(txtValorMulta.Text);
                arr._estado_pago = "pendiente";
                arr.ModificarReservaBLL(arr);
                dm.Observaciones = txtDescripcionMulta.Text;
                dm.id_reserva = int.Parse(codArriendo);
                dm.id_multa = codMulta;

                dm.agregarDetalleMultaBLL(dm);


            }
            Response.Redirect("ADMDetalleReserva.aspx");
        }
    }
}