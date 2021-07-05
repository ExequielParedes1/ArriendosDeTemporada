using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class ListaCaracteristicaBLL
    {
        public int idCaracteristica { get; set; }
        public int idDepartamento { get; set; }

        public int AgregarListaCaracteristicaBLL(ListaCaracteristicaBLL lc)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ListaCaracteristicasBLL nuevo = new WSarriendo.ListaCaracteristicasBLL();
            nuevo.idCaracteristica = lc.idCaracteristica;
            nuevo.idDepartamento = lc.idDepartamento;

            return wcf.AgregarListaCaracteristica(nuevo);
        }
        public List<ListaCaracteristicaBLL> ListadoCaracteristicaBLL()
        {
            List<ListaCaracteristicaBLL> lista = new List<ListaCaracteristicaBLL>();
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            foreach (var item in wcf.ListarListaCaracteristica())
            {
               
                ListaCaracteristicaBLL nuevo = new ListaCaracteristicaBLL();
                nuevo.idDepartamento = item.idDepartamento;
                nuevo.idCaracteristica = item.idCaracteristica;
                lista.Add(nuevo);
               
            }
            return lista;
        }
        public List<CaracteristicaDptoBLL> ListadoCaracteristicaSegunDepartamentoBLL(int idDpto)
        {
            List<CaracteristicaDptoBLL> lista = new List<CaracteristicaDptoBLL>();
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            CaracteristicaDptoBLL carac = new CaracteristicaDptoBLL();
            foreach (var item in wcf.ListarListaCaracteristica())
            {
                if (item.idDepartamento == idDpto)
                {
                    foreach (var item3 in carac.listarCaracteristicas())
                    {
                        if (item.idCaracteristica == item3.idCaracteristica)
                        {
                            CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
                            nuevo.idCaracteristica = item3.idCaracteristica;
                            nuevo._Nombre = item3._Nombre;
                            nuevo._Descripcion = item3._Descripcion;
                            lista.Add(nuevo);

                        }
                    }
                }

            }
            return lista;
        }

        public int eliminarListaCaracteristicaBLL(ListaCaracteristicaBLL lc)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ListaCaracteristicasBLL nuevo = new WSarriendo.ListaCaracteristicasBLL();
            nuevo.idDepartamento = lc.idDepartamento;
            nuevo.idCaracteristica = lc.idCaracteristica;
            return wcf.EliminarListaCaracteristica(nuevo);
        }


    }
}