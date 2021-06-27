using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class ListaCaracteristicasBLL
    {
        public int idCaracteristica { get; set; }
        public int idDepartamento { get; set; }

        public int AgregarListaCaracteristicaBLL(ListaCaracteristicasBLL ls)
        {
            ListaCaracteristicasDAL modelo = new ListaCaracteristicasDAL();
            return modelo.AgregarListaCaracteristica(ls);
        }
        public int eliminarListaCaracteristicaBLL(ListaCaracteristicasBLL lc)
        {
            ListaCaracteristicasDAL modelo = new ListaCaracteristicasDAL();
            return modelo.eliminarListaCaracteristica(lc);
        }
        public List<ListaCaracteristicasBLL> listarCaracteristicaBLL()
        {
            ListaCaracteristicasDAL modelo = new ListaCaracteristicasDAL();
            return modelo.listarCaracteristicaBLL();
        }
    }
}