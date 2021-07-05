using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class CaracteristicaDptoBLL
    {
        #region Campos
        public int idCaracteristica { get; set; }

        public string nombre { get; set; }
        public string _Nombre
        {
            get { return nombre; }
            set
            {

                if (value.Length > 0)
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public string descripcion { get; set; }
        public string _Descripcion
        {
            get { return descripcion; }
            set
            {

                if (value.Length > 0)
                {
                    descripcion = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

        #endregion

        #region Metodos
        public int agregarCaracteriscaBLL(CaracteristicaDptoBLL carac)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.CaracteristicaBLL nuevo = new WSarriendo.CaracteristicaBLL();

            nuevo.idCaracteristica = carac.idCaracteristica;
            nuevo.Nombre = carac._Nombre;
            nuevo.Descripcion = carac._Descripcion;

            return wcf.AgregarCaracteristica(nuevo);
        }
        public int modificarCaracteristicaBLL(CaracteristicaDptoBLL carac)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.CaracteristicaBLL nuevo = new WSarriendo.CaracteristicaBLL();

            nuevo.idCaracteristica = carac.idCaracteristica;
            nuevo.Nombre = carac._Nombre;
            nuevo.Descripcion = carac._Descripcion;
            return wcf.ModificarCaracteristica(nuevo);
        }
        public List<CaracteristicaDptoBLL> listarCaracteristicas()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<CaracteristicaDptoBLL> lista = new List<CaracteristicaDptoBLL>();
            foreach (var item in wcf.listarCaracteristicas())
            {
                CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
                nuevo.idCaracteristica = item.idCaracteristica;
                nuevo._Nombre = item.Nombre;
                nuevo._Descripcion = item.Descripcion;
                lista.Add(nuevo);

            }
            return lista;
        }
        public List<CaracteristicaDptoBLL> listarCaracteristicasFilrado(List<CaracteristicaDptoBLL> listaDpto)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<CaracteristicaDptoBLL> lista = new List<CaracteristicaDptoBLL>();
            List<CaracteristicaDptoBLL> listaBorrar = new List<CaracteristicaDptoBLL>();
            foreach (var item in wcf.listarCaracteristicas())
            {
                CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
                nuevo.idCaracteristica = item.idCaracteristica;
                nuevo._Nombre = item.Nombre;
                nuevo._Descripcion = item.Descripcion;
                lista.Add(nuevo);
            }
            foreach (var item in lista)
            {
                foreach (var item2 in listaDpto)
                {
                    if (item.idCaracteristica == item2.idCaracteristica)
                    {
                        listaBorrar.Add(item);
                    }
                }
            }
            for (int i = 0; i < lista.Count; i++)
            {
                foreach (var item in listaBorrar)
                {
                    lista.Remove(item);
                }
            }

            return lista;
        }
        public List<CaracteristicaDptoBLL> listarCaracteristicasNoPertenicientesAlDpto()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<CaracteristicaDptoBLL> lista = new List<CaracteristicaDptoBLL>();
            foreach (var item in wcf.listarCaracteristicas())
            {
                CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
                nuevo.idCaracteristica = item.idCaracteristica;
                nuevo._Nombre = item.Nombre;
                nuevo._Descripcion = item.Descripcion;
                lista.Add(nuevo);

            }
            return lista;
        }
        public CaracteristicaDptoBLL buscarCaracteristica(int id)
        {
            CaracteristicaDptoBLL nuevo = new CaracteristicaDptoBLL();
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            foreach (var item in wcf.listarCaracteristicas())
            {
                if (item.idCaracteristica == id)
                {
                    nuevo.idCaracteristica = item.idCaracteristica;
                    nuevo._Nombre = item.Nombre;
                    nuevo._Descripcion = item.Descripcion;
                    return nuevo;
                }
            }
            return nuevo;
        }
        public int eliminarCaracteristica(int id)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            return wcf.EliminarCarateristica(id);
        }
        #endregion
    }
}