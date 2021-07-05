using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class InventarioBLL
    {
        private DateTime fecha_asignacion;
        public DateTime _fecha_asignacion
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
        public DateTime fecha_ultima_moficacion { get; set; }

        private int cantidad;
        public int _cantidad
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
        private int id_item_id;
        public int _id_item_id
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
        private int id_departamento_id;
        public int _id_departamento_id
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
        public int _valor_total
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
        public string nombreItem { get; set; }
        public int agregarRegistroInventario(InventarioBLL ri)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.InventarioBLL nuevo = new WSarriendo.InventarioBLL();

            nuevo.Fecha_asignacion = ri._fecha_asignacion;
            nuevo.fecha_ultima_moficacion = ri.fecha_asignacion;
            nuevo.Id_item_id = ri._id_item_id;
            nuevo.Cantidad = ri._cantidad;
            nuevo.Id_departamento_id = ri._id_departamento_id;
            nuevo.Valor_total = ri._valor_total;

            return wcf.AgregarRegistroInventario(nuevo);
        }
        public List<InventarioBLL> listarRegistroInventario()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<InventarioBLL> lista = new List<InventarioBLL>();

            foreach (var ri in wcf.ListarRegistroInventario())
            {
                InventarioBLL nuevo = new InventarioBLL();
                nuevo._fecha_asignacion = ri.Fecha_asignacion;
                nuevo.fecha_ultima_moficacion = ri.fecha_ultima_moficacion;
                nuevo._id_item_id = ri.Id_item_id;
                nuevo._cantidad = ri.Cantidad;
                nuevo._id_departamento_id = ri.Id_departamento_id;
                nuevo._valor_total = ri.Valor_total;
                lista.Add(nuevo);
            }
            return lista;
        }
        public List<InventarioBLL> listarRegistroInventarioDpto(int idDepartamento)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<InventarioBLL> lista = new List<InventarioBLL>();
            ItemBLL item = new ItemBLL();
            foreach (var ri in wcf.ListarRegistroInventario())
            {
                if (ri.Id_departamento_id == idDepartamento)
                {
                    item = item.buscarItemBLL(ri.Id_item_id);
                    InventarioBLL nuevo = new InventarioBLL();
                    nuevo._fecha_asignacion = ri.Fecha_asignacion;
                    nuevo.fecha_ultima_moficacion = ri.fecha_ultima_moficacion;
                    nuevo._id_item_id = ri.Id_item_id;
                    nuevo._cantidad = ri.Cantidad;
                    nuevo._id_departamento_id = ri.Id_departamento_id;
                    nuevo._valor_total = ri.Valor_total;
                    nuevo.nombreItem = item._nombre;
                    lista.Add(nuevo);
                }

            }
            return lista;
        }

        public InventarioBLL buscarInventario(int idDepartamento, int idItems)
        {
            InventarioBLL nuevo = new InventarioBLL();
            foreach (var item in listarRegistroInventario())
            {
                if (item._id_departamento_id == idDepartamento && item._id_item_id == idItems)
                {
                    nuevo._fecha_asignacion = item._fecha_asignacion;
                    nuevo.fecha_ultima_moficacion = item.fecha_ultima_moficacion;
                    nuevo._cantidad = item._cantidad;
                    nuevo._id_item_id = item._id_item_id;
                    nuevo._id_departamento_id = item._id_departamento_id;
                    nuevo._valor_total = item._valor_total;

                    return nuevo;

                }
            }
            return nuevo;
        }
        public int eliminarInventario(InventarioBLL inv)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.InventarioBLL nuevo = new WSarriendo.InventarioBLL();
            nuevo.Fecha_asignacion = inv._fecha_asignacion;
            nuevo.fecha_ultima_moficacion = inv.fecha_ultima_moficacion;
            nuevo.Cantidad = inv._cantidad;
            nuevo.Id_item_id = inv._id_item_id;
            nuevo.Id_departamento_id = _id_departamento_id;
            nuevo.Valor_total = inv._valor_total;


            return wcf.eliminarRegistroInventario(nuevo);
        }

        public int modificarInventario(InventarioBLL inv)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.InventarioBLL nuevo = new WSarriendo.InventarioBLL();
            nuevo.Fecha_asignacion = inv._fecha_asignacion;
            nuevo.fecha_ultima_moficacion = inv.fecha_ultima_moficacion;
            nuevo.Cantidad = inv._cantidad;
            nuevo.Id_item_id = inv._id_item_id;
            nuevo.Id_departamento_id = _id_departamento_id;
            nuevo.Valor_total = inv._valor_total;


            return wcf.modificarRegistroInventario(nuevo);
        }


    }
}