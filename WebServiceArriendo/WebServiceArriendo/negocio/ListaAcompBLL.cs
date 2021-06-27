using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;
namespace WebServiceArriendo.negocio
{
    public class ListaAcompBLL
    {
        public string cedulaAcompanante { get; set; }
        public int idReserva { get; set; }

        public int agregarListaAcompananteBLL(ListaAcompBLL ls)
        {
            ListaAcompDAL modelo = new ListaAcompDAL();
            return modelo.AgregarListaAcompananteDAL(ls);
        }
        public List<ListaAcompBLL> listarListaAcompanante()
        {
            ListaAcompDAL modelo = new ListaAcompDAL();
            return modelo.listadoAcompananteDAL();
        }
        public int eliminarListaAcompananteBLL(ListaAcompBLL lh)
        {
            ListaAcompDAL modelo = new ListaAcompDAL();
            return modelo.EliminarListaAcompananteDAL(lh);
        }
    }
}