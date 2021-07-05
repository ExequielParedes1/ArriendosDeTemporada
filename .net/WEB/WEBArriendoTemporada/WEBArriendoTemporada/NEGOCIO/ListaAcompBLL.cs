using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class ListaAcompBLL
    {
        public string cedulaAcompanante { get; set; }
        public int idReserva { get; set; }

        public int agregarListaAcompananteBLL(ListaAcompBLL ls)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ListaAcompBLL nuevo = new WSarriendo.ListaAcompBLL();

            nuevo.cedulaAcompanante = ls.cedulaAcompanante;
            nuevo.idReserva = ls.idReserva;

            return wcf.AgregarListaAcompanante(nuevo);
        }
        public List<ListaAcompBLL> listarListaAcompanante()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ListaAcompBLL> lista = new List<ListaAcompBLL>();
            foreach (var item in wcf.ListarListaAcompanante())
            {
                ListaAcompBLL nuevo = new ListaAcompBLL();
                nuevo.cedulaAcompanante = item.cedulaAcompanante;
                nuevo.idReserva = item.idReserva;
                lista.Add(nuevo);
            }
            return lista;
        }

        public List<AcompananteBLL> ListadoListaAcompananteBLL(int reserva)
        {
            List<AcompananteBLL> lista = new List<AcompananteBLL>();
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            AcompananteBLL huesped = new AcompananteBLL();


            foreach (var item in wcf.ListarListaAcompanante())
            {
                if (item.idReserva == reserva)
                {

                    foreach (var item2 in huesped.ListarAcompananteBLL())
                    {
                        if (item2.cedula == item.cedulaAcompanante)
                        {
                            AcompananteBLL nuevo = new AcompananteBLL();
                            nuevo.cedula = item2.cedula;
                            nuevo.nombre = item2.nombre;
                            nuevo.apellido = item2.apellido;
                            nuevo.telefono = item2.telefono;
                            lista.Add(nuevo);
                        }
                    }
                }
            }
            return lista;
        }
        public int eliminarListaAcompanantesBLL(ListaAcompBLL ls)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ListaAcompBLL nuevo = new WSarriendo.ListaAcompBLL();
            nuevo.cedulaAcompanante = ls.cedulaAcompanante;
            nuevo.idReserva = ls.idReserva;

            return wcf.EliminarListaAcompanante(nuevo);
        }
    }
}