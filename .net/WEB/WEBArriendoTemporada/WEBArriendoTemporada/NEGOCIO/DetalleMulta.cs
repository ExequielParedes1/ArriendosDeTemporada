using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class DetalleMulta
    {
        public int id_detalle_multa { get; set; }

        private string observaciones { get; set; }
        public string Observaciones
        {
            get { return observaciones; }
            set
            {

                if (value.Length > 0)
                {
                    observaciones = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int id_reserva { get; set; }
        public int id_multa { get; set; }
        private string estado_detalle { get; set; }
        public string Estado_Detalle
        {
            get { return estado_detalle; }
            set
            {

                if (value.Length > 0)
                {
                    estado_detalle = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

        public int agregarDetalleMultaBLL(DetalleMulta dm)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.DetalleMultaBLL nuevo = new WSarriendo.DetalleMultaBLL();

            nuevo.id_dmulta = dm.id_detalle_multa;
            nuevo.Objervaciones = dm.Observaciones;
            nuevo.reserva_id_reserva = dm.id_reserva;
            nuevo.multa_id_multa = dm.id_multa;

            return wcf.AgregarDetalleMulta(nuevo);
        }
        public List<DetalleMulta> listaDetalleMulta()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<DetalleMulta> lista = new List<DetalleMulta>();

            foreach (var item in wcf.ListarDetalleMulta())
            {
                DetalleMulta nuevo = new DetalleMulta();
                nuevo.id_detalle_multa = item.id_dmulta;
                nuevo.Observaciones = item.Objervaciones;
                nuevo.id_reserva = item.reserva_id_reserva;
                nuevo.id_multa = item.multa_id_multa;
                nuevo.Estado_Detalle = item.EstadoMulta;
                lista.Add(nuevo);
            }
            return lista;
        }

        public List<MultaBLL> listaMultaPorArriendo(int idReserva)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();

            List<MultaBLL> lista = new List<MultaBLL>();

            foreach (var item in wcf.ListarMulta())
            {

                foreach (var item2 in listaDetalleMulta())
                {
                    if (item2.id_reserva == idReserva && item2.id_multa == item.idMulta)
                    {
                        MultaBLL nueva = new MultaBLL();
                        nueva.idMulta = item.idMulta;
                        nueva.Nombre = item.Nombre;
                        nueva.Descripcion = item.Descripcion;
                        nueva.Valor = item.Valor;
                        nueva.Estado_Multa = item.Estado_Multa;

                        lista.Add(nueva);
                    }
                }
            }
            return lista;
        }
        public List<DetalleMulta> listaMultaPorUsuario(string correo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<DetalleMulta> lista = new List<DetalleMulta>();

            foreach (var item in wcf.ListaInvolucrado())
            {
                if (item.usuario_correo.Equals(correo))
                {
                    foreach (var item2 in wcf.ListarDetalleMulta())
                    {
                        if (item.reserva_id_reserva == item2.reserva_id_reserva && item2.EstadoMulta.Equals("pendiente"))
                        {

                            DetalleMulta nuevo = new DetalleMulta();
                            nuevo.id_detalle_multa = item2.id_dmulta;
                            nuevo.Observaciones = item2.Objervaciones;
                            nuevo.id_reserva = item2.reserva_id_reserva;
                            nuevo.id_multa = item2.multa_id_multa;
                            nuevo.Estado_Detalle = item2.EstadoMulta;

                            lista.Add(nuevo);
                        }
                    }
                }
            }
            return lista;

        }
    }
}