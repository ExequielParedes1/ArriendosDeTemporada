using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class ReservaBLL
    {
        #region Campos
        public int id_reserva { get; set; }
        private int dias_reserva { get; set; }
        public int Dias_reserva
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
        public int Valor_final
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
        public DateTime Check_in
        {
            get { return check_in; }
            set
            {

                if (value != check_out)
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
        public DateTime Check_Out
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
        public int Total_multas
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
        public DateTime Fecha_contrato
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
        public string Metodo_pago
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
        public int Departamento_id_departamento
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
        public int Anticipo
        {
            get { return anticipo; }
            set
            {

                if (value > 0)
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
        public string Estado_pago
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
        public string Estado
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
        public int AgregarReservaBLL(ReservaBLL arr)
        {
            ReservaDAL nuevo = new ReservaDAL();
            return nuevo.AgregarReservaDAL(arr);
        }
        public List<ReservaBLL> ListarReservaBLL()
        {
            ReservaDAL modelo = new ReservaDAL();
            return modelo.listarReserva();
        }
        public int ModificarReservaBLL(ReservaBLL arr)
        {
            ReservaDAL modelo = new ReservaDAL();
            return modelo.ModificarReserva(arr);
        }
        #endregion
    }
}
