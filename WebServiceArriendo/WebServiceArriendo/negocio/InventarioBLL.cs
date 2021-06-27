using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class InventarioBLL
    {
        private DateTime fecha_asignacion;
        public DateTime Fecha_asignacion
        {
            get { return fecha_asignacion; }
            set
            {
                if (value != null)
                {
                    fecha_asignacion = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public DateTime fecha_ultima_moficacion;
        private int id_item_id;
        public int Id_item_id
        {
            get { return id_item_id; }
            set
            {
                if (value >= 0)
                {
                    id_item_id = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value > 0)
                {
                    cantidad = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int id_departamento_id;
        public int Id_departamento_id
        {
            get { return id_departamento_id; }
            set
            {
                if (value >= 0)
                {
                    id_departamento_id = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int valor_total;
        public int Valor_total
        {
            get { return valor_total; }
            set
            {
                if (value >= 0)
                {
                    valor_total = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int agregarRegistroInventarioBLL(InventarioBLL ri)
        {
            modelo.InventarioDAL modelo = new modelo.InventarioDAL();
            return modelo.AgregarRegistroInventarioDAL(ri);
        }
        public List<InventarioBLL> ListaRegistroInventarioBLL()
        {
            modelo.InventarioDAL modelo = new modelo.InventarioDAL();
            return modelo.ListarRegistronInventarioDAL();
        }
        public int eliminarInventarioBLL(InventarioBLL nuevo)
        {
            InventarioDAL modelo = new InventarioDAL();
            return modelo.eliminarInventarioDAL(nuevo);
        }
        public int modificarInventario(InventarioBLL nuevo)
        {
            InventarioDAL modelo = new InventarioDAL();
            return modelo.modificarInventarioDAL(nuevo);
        }

    }
}