using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;
namespace WebServiceArriendo.negocio
{
    public class ItemBLL
    {
        public int id_item;
        private string nombre;
        public string Nombre
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
        public int Valor
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
        public int agregarItemBLL(ItemBLL nuevo)
        {
            ItemDAL modelo = new ItemDAL();
            return modelo.AgregarItemDAL(nuevo);
        }
        public List<ItemBLL> listarItemBLL()
        {
            ItemDAL modelo = new ItemDAL();
            return modelo.ListarItemDAL();
        }
        public int eliminarItemBLL(int idItem)
        {
            ItemDAL modelo = new ItemDAL();
            return modelo.EliminarItemDAL(idItem);
        }

    }
}