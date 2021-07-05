using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class ReservaBLL
    {
        #region Campos
        public int id_reserva { get; set; }
        private int dias_reserva { get; set; }
        public int _dias_reserva
        {
            get { return dias_reserva; }
            set
            {

                if (value > 0)
                {
                    dias_reserva = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int valor_final { get; set; }
        public int _valor_final
        {
            get { return valor_final; }
            set
            {

                if (value > 0)
                {
                    valor_final = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private DateTime check_in { get; set; }
        public DateTime _check_in
        {
            get { return check_in; }
            set
            {

                if (value != check_in)
                {
                    check_in = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private DateTime check_out { get; set; }
        public DateTime _check_Out
        {
            get { return check_out; }
            set
            {

                if (value >= check_in)
                {
                    check_out = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int total_multas { get; set; }
        public int _total_multas
        {
            get { return total_multas; }
            set
            {

                if (value >= 0)
                {
                    total_multas = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private DateTime fecha_contrato { get; set; }
        public DateTime _fecha_contrato
        {
            get { return fecha_contrato; }
            set
            {

                if (value != null)
                {
                    fecha_contrato = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string metodo_pago { get; set; }
        public string _metodo_pago
        {
            get { return metodo_pago; }
            set
            {

                if (value.Length > 0 && value.Length < 50)
                {
                    metodo_pago = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int departamento_id_departamento { get; set; }
        public int _departamento_id_departamento
        {
            get { return departamento_id_departamento; }
            set
            {

                if (value != 0)
                {
                    departamento_id_departamento = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int anticipo { get; set; }
        public int _anticipo
        {
            get { return anticipo; }
            set
            {

                if (value >= 0)
                {
                    anticipo = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string estado_pago { get; set; }
        public string _estado_pago
        {
            get { return estado_pago; }
            set
            {

                if (value.Length > 0)
                {
                    estado_pago = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string estado { get; set; }
        public string _estado
        {
            get { return estado; }
            set
            {

                if (value.Length > 0)
                {
                    estado = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        #endregion

        #region Metodos

        public int agregarReservaBLL(ReservaBLL item, string correo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ReservaBLL ar = new WSarriendo.ReservaBLL();

            ar.Dias_reserva = item._dias_reserva;
            ar.Valor_final = item._valor_final;
            ar.Check_in = item._check_in;
            ar.Check_Out = item._check_Out;
            ar.Total_multas = item._total_multas;
            ar.Fecha_contrato = item._fecha_contrato;
            ar.Metodo_pago = item._metodo_pago;
            ar.Departamento_id_departamento = item._departamento_id_departamento;
            ar.Anticipo = item._anticipo;
            ar.Estado_pago = item._estado_pago;
            ar.Estado = item._estado;
            ar.id_reserva = wcf.AgregarReserva(ar);
            Correos corre = new Correos();
            UsuarioBLL usuario = new UsuarioBLL();
            usuario = usuario.buscarUsuario(correo);
            if (ar.id_reserva != 0)
            {
                corre.enviarCorreoPago(usuario, item, ar.id_reserva);
                InvolucradoBLL nuevo = new InvolucradoBLL();
                nuevo.usuario_correo = correo;
                nuevo.reserva_id_reserva = ar.id_reserva;
                return nuevo.agregarInvolucrado(nuevo);

            }
            else { return 0; }

        }

        public List<ReservaBLL> listarSegunUsuario(string correo, string estado)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            foreach (var item in wcf.ListaInvolucrado())
            {
                if (item.usuario_correo == correo)
                {
                    foreach (var item2 in wcf.ListarReserva())
                    {
                        if (item.reserva_id_reserva == item2.id_reserva && item2.Estado.Equals(estado) 
                            && item2.Estado_pago.Equals("pendiente"))
                        {
                            ReservaBLL ar = new ReservaBLL();
                            ar.id_reserva = item2.id_reserva;
                            ar._valor_final = item2.Valor_final;
                            ar._check_in = item2.Check_in;
                            ar._check_Out = item2.Check_Out;
                            ar._total_multas = item2.Total_multas;
                            ar._fecha_contrato = item2.Fecha_contrato;
                            ar._metodo_pago = item2.Metodo_pago;
                            ar._departamento_id_departamento = item2.Departamento_id_departamento;
                            ar._anticipo = item2.Anticipo;

                            lista.Add(ar);
                        }
                    }
                }
            }

            return lista;
        }

        public List<ReservaBLL> listarSegunUsuarioFinalizado(string correo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            foreach (var item in wcf.ListaInvolucrado())
            {
                if (item.usuario_correo == correo)
                {
                    foreach (var item2 in wcf.ListarReserva())
                    {
                        if (item.reserva_id_reserva == item2.id_reserva && item2.Valor_final == item2.Anticipo 
                            && item2.Estado_pago.Equals("finalizado") && item2.Estado.Equals("finalizado"))
                        {
                            ReservaBLL ar = new ReservaBLL();
                            ar.id_reserva = item2.id_reserva;
                            ar._valor_final = item2.Valor_final;
                            ar._check_in = item2.Check_in;
                            ar._check_Out = item2.Check_Out;
                            ar._total_multas = item2.Total_multas;
                            ar._fecha_contrato = item2.Fecha_contrato;
                            ar._metodo_pago = item2.Metodo_pago;
                            ar._departamento_id_departamento = item2.Departamento_id_departamento;
                            ar._anticipo = item2.Anticipo;
                            lista.Add(ar);
                        }
                    }
                }
            }

            return lista;
        }

        public int gastoTotalReserva(string correo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            int gastos = 0;

            foreach (var item in wcf.ListaInvolucrado())
            {
                if (item.usuario_correo == correo)
                {
                    foreach (var item2 in wcf.ListarReserva())
                    {
                        if (item.reserva_id_reserva == item2.id_reserva)
                        {
                            gastos = gastos + item2.Valor_final;
                        }
                    }
                }
            }
            return gastos;
        }
        public ReservaBLL buscarReserva(int id)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            ReservaBLL ar = new ReservaBLL();

            foreach (var item in wcf.ListarReserva())
            {
                if (item.id_reserva == id)
                {
                    ar.id_reserva = item.id_reserva;
                    ar._dias_reserva = item.Dias_reserva;
                    ar._valor_final = item.Valor_final;
                    ar._check_in = item.Check_in;
                    ar._check_Out = item.Check_Out;
                    ar._total_multas = item.Total_multas;
                    ar._fecha_contrato = item.Fecha_contrato;
                    ar._metodo_pago = item.Metodo_pago;
                    ar._departamento_id_departamento = item.Departamento_id_departamento;
                    ar._anticipo = item.Anticipo;
                    ar._estado_pago = item.Estado_pago;
                    ar._estado = item.Estado;

                    return ar;
                }
            }
            return ar;
        }
        public int gastoTotalPagado(string correo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            int gastos = 0;

            foreach (var item in wcf.ListaInvolucrado())
            {
                if (item.usuario_correo == correo)
                {
                    foreach (var item2 in wcf.ListarReserva())
                    {
                        if (item.reserva_id_reserva == item2.id_reserva)
                        {
                            gastos = gastos + item2.Anticipo;
                        }
                    }
                }
            }
            return gastos;
        }
        public int gastoTotalPagadoReporte()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            int gastos = 0;

            foreach (var item2 in wcf.ListarReserva())
            {

                gastos = gastos + item2.Anticipo;

            }


            return gastos;
        }
        public int ModificarReservaBLL(ReservaBLL item)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ReservaBLL ar = new WSarriendo.ReservaBLL();
            ar.id_reserva = item.id_reserva;
            ar.Dias_reserva = item._dias_reserva;
            ar.Valor_final = item._valor_final;
            ar.Check_in = item._check_in;
            ar.Check_Out = item._check_Out;
            ar.Total_multas = item._total_multas;
            ar.Fecha_contrato = item._fecha_contrato;
            ar.Metodo_pago = item._metodo_pago;
            ar.Departamento_id_departamento = item._departamento_id_departamento;
            ar.Anticipo = item._anticipo;
            ar.Estado_pago = item._estado_pago;
            ar.Estado = item._estado;
            return wcf.ModificarReserva(ar);
        }
        public List<ReservaBLL> listarTodos()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ReservaBLL> lista = new List<ReservaBLL>();
            foreach (var item2 in wcf.ListarReserva())
            {
                ReservaBLL ar = new ReservaBLL();
                ar.id_reserva = item2.id_reserva;
                ar._valor_final = item2.Valor_final;
                ar._check_in = item2.Check_in;
                ar._check_Out = item2.Check_Out;
                ar._total_multas = item2.Total_multas;
                ar._fecha_contrato = item2.Fecha_contrato;
                ar._metodo_pago = item2.Metodo_pago;
                ar._departamento_id_departamento = item2.Departamento_id_departamento;
                ar._anticipo = item2.Anticipo;
                lista.Add(ar);
            }
            return lista;

        }
        public List<ReservaBLL> listarTodosPoFecha(DateTime inicio, DateTime termino)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ReservaBLL> lista = new List<ReservaBLL>();
            foreach (var item2 in wcf.ListarReserva())
            {
                if (item2.Check_in >= inicio && item2.Check_Out <= termino)
                {
                    ReservaBLL ar = new ReservaBLL();
                    ar.id_reserva = item2.id_reserva;
                    ar._valor_final = item2.Valor_final;
                    ar._check_in = item2.Check_in;
                    ar._check_Out = item2.Check_Out;
                    ar._total_multas = item2.Total_multas;
                    ar._fecha_contrato = item2.Fecha_contrato;
                    ar._metodo_pago = item2.Metodo_pago;
                    ar._departamento_id_departamento = item2.Departamento_id_departamento;
                    ar._anticipo = item2.Anticipo;
                    lista.Add(ar);
                }

            }
            return lista;

        }

        public List<ReservaBLL> listarArriendoPorEstado(string estado)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            foreach (var item2 in wcf.ListarReserva())
            {
                if (item2.Estado == estado)
                {
                    ReservaBLL ar = new ReservaBLL();
                    ar.dias_reserva = item2.Dias_reserva;
                    ar.id_reserva = item2.id_reserva;
                    ar._valor_final = item2.Valor_final;
                    ar._check_in = item2.Check_in;
                    ar._check_Out = item2.Check_Out;
                    ar._total_multas = item2.Total_multas;
                    ar._fecha_contrato = item2.Fecha_contrato;
                    ar._metodo_pago = item2.Metodo_pago;
                    ar._departamento_id_departamento = item2.Departamento_id_departamento;
                    ar._anticipo = item2.Anticipo;
                    lista.Add(ar);
                }
            }
            return lista;
        }
        

        public List<ReservaBLL> listarArriendoPorEstadoSinFuncionario(string estado, List<ReservaBLL> listaArrFuncionario)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ReservaBLL> lista = new List<ReservaBLL>();
            InvolucradoBLL inv = new InvolucradoBLL();
            List<ReservaBLL> listaEliminar = new List<ReservaBLL>();
            ReservaBLL arr = new ReservaBLL();

            foreach (var item in wcf.ListarReserva())
            {
                if (item.Estado.Equals(estado))
                {
                    ReservaBLL ar = new ReservaBLL();
                    ar.dias_reserva = item.Dias_reserva;
                    ar.id_reserva = item.id_reserva;
                    ar._valor_final = item.Valor_final;
                    ar._check_in = item.Check_in;
                    ar._check_Out = item.Check_Out;
                    ar._total_multas = item.Total_multas;
                    ar._fecha_contrato = item.Fecha_contrato;
                    ar._metodo_pago = item.Metodo_pago;
                    ar._departamento_id_departamento = item.Departamento_id_departamento;
                    ar._anticipo = item.Anticipo;
                    lista.Add(ar);
                }
            }

            foreach (var item in lista)
            {
                foreach (var item2 in listaArrFuncionario)
                {
                    if (item.id_reserva == item2.id_reserva)
                    {
                        listaEliminar.Add(item);
                    }
                }
            }


            for (int i = 0; i < lista.Count; i++)
            {
                foreach (var item in listaEliminar)
                {
                    lista.Remove(item);
                }
            }

            return lista;

        }
        public List<ReservaBLL> listarReservaPorEstadoConFuncionario(string estado)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            InvolucradoBLL inv = new InvolucradoBLL();

            foreach (var item2 in wcf.ListarReserva())
            {
                foreach (var item in inv.listaInvolucradosFuncionario())
                {
                    if (item2.Estado == estado && item2.id_reserva == item.reserva_id_reserva)
                    {
                        ReservaBLL ar = new ReservaBLL();
                        ar.dias_reserva = item2.Dias_reserva;
                        ar.id_reserva = item2.id_reserva;
                        ar._valor_final = item2.Valor_final;
                        ar._check_in = item2.Check_in;
                        ar._check_Out = item2.Check_Out;
                        ar._total_multas = item2.Total_multas;
                        ar._fecha_contrato = item2.Fecha_contrato;
                        ar._metodo_pago = item2.Metodo_pago;
                        ar._departamento_id_departamento = item2.Departamento_id_departamento;
                        ar._anticipo = item2.Anticipo;
                        lista.Add(ar);
                    }
                }
            }
            return lista;
        }

        #endregion
    }
}