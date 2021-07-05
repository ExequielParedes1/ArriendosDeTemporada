using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class ItemBLL
    {
        public int id_item { get; set; }
        private string nombre;
        public string _nombre
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
        private int valor;
        public int _valor
        {
            get { return valor; }
            set
            {

                if (value > 0)
                {
                    valor = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int AgregarItemBLL(ItemBLL nuevo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.ItemBLL it = new WSarriendo.ItemBLL();

            it.id_item = nuevo.id_item;
            it.Nombre = nuevo._nombre;
            it.Valor = nuevo._valor;

            return wcf.AgregarItem(it);
        }
        public List<ItemBLL> listarItemBLL()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ItemBLL> lista = new List<ItemBLL>();

            foreach (var item in wcf.ListarItem())
            {
                ItemBLL nuevo = new ItemBLL();
                nuevo.id_item = item.id_item;
                nuevo._nombre = item.Nombre;
                nuevo._valor = item.Valor;

                lista.Add(nuevo);
            }
            return lista;
        }
        public List<ItemBLL> listarItemBLLFiltrado(List<InventarioBLL> listaInventario)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<ItemBLL> lista = new List<ItemBLL>();
            List<ItemBLL> listaBorrar = new List<ItemBLL>();
            foreach (var item in wcf.ListarItem())
            {
                ItemBLL nuevo = new ItemBLL();
                nuevo.id_item = item.id_item;
                nuevo._nombre = item.Nombre;
                nuevo._valor = item.Valor;

                lista.Add(nuevo);
            }
            foreach (var item in lista)
            {
                foreach (var item2 in listaInventario)
                {
                    if (item.id_item == item2._id_item_id)
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
        public int eliminarItemBLL(int id)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            return wcf.EliminarItem(id);
        }
        public ItemBLL buscarItemBLL(int id)
        {
            ItemBLL nuevo = new ItemBLL();
            foreach (var item in listarItemBLL())
            {
                if (item.id_item == id)
                {
                    nuevo.id_item = item.id_item;
                    nuevo._nombre = item._nombre;
                    nuevo._valor = item._valor;

                    return nuevo;
                }
            }
            return nuevo;
        }
    }
}