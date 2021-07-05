using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class MantencionBLL
    {
        #region Campos
        public int id_mantencion { get; set; }
        private int varlo_total { get; set; }
        public int _varlo_total
        {
            get { return varlo_total; }
            set
            {

                if (value > 0)
                {
                    varlo_total = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string descripcion { get; set; }
        public string _descripcion
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
        private DateTime fecha_inicio { get; set; }
        public DateTime _fecha_inicio
        {
            get { return fecha_inicio; }
            set
            {

                if (value != null)
                {
                    fecha_inicio = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private DateTime fecha_termino { get; set; }
        public DateTime _fecha_termino
        {
            get { return fecha_termino; }
            set
            {

                if (value > _fecha_inicio)
                {
                    fecha_termino = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string motivo { get; set; }
        public string _motivo
        {
            get { return motivo; }
            set
            {

                if (value.Length > 0)
                {
                    motivo = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string tipo_mantencion { get; set; }
        public string _tipo_mantencion
        {
            get { return tipo_mantencion; }
            set
            {

                if (value.Length > 0)
                {
                    tipo_mantencion = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string encargado_rut { get; set; }
        public string _encargado_rut
        {
            get { return encargado_rut; }
            set
            {

                if (value.Length > 0)
                {
                    encargado_rut = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private int departamento_id_departamento { get; set; }
        public int _departamento_id_departamento
        {
            get { return departamento_id_departamento; }
            set
            {

                if (value >= 0)
                {
                    departamento_id_departamento = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        private string estadoMantencion { get; set; }
        public string _estadoMantencion
        {
            get { return estadoMantencion; }
            set
            {

                if (value.Length >= 0)
                {
                    estadoMantencion = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        #endregion

        public int agregarMantencion(MantencionBLL otro)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.MantencionBLL nuevo = new WSarriendo.MantencionBLL();

            nuevo.id_mantencion = otro.id_mantencion;
            nuevo.Varlo_total = otro._varlo_total;
            nuevo.Descripcion = otro._descripcion;
            nuevo.Fecha_inicio = otro._fecha_inicio;
            nuevo.Fecha_termino = otro._fecha_termino;
            nuevo.Motivo = otro._motivo;
            nuevo.Tipo_mantencion = otro._tipo_mantencion;
            nuevo.Encargado_rut = otro.encargado_rut;
            nuevo.Departamento_id_departamento = otro._departamento_id_departamento;
            nuevo.EstadoMantencion = "activa";
            return wcf.AgregarMantencion(nuevo);
        }
        public List<MantencionBLL> listarMantenciones(int departamento, string estado)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<MantencionBLL> lista = new List<MantencionBLL>();
            foreach (var item in wcf.ListarMantencion())
            {
                if (item.Departamento_id_departamento == departamento && item.EstadoMantencion.Equals(estado))
                {
                    MantencionBLL nuevo = new MantencionBLL();
                    nuevo.id_mantencion = item.id_mantencion;
                    nuevo._varlo_total = item.Varlo_total;
                    nuevo._descripcion = item.Descripcion;
                    nuevo._fecha_inicio = item.Fecha_inicio;
                    nuevo._fecha_termino = item.Fecha_termino;
                    nuevo._motivo = item.Motivo;
                    nuevo._tipo_mantencion = item.Tipo_mantencion;
                    nuevo._encargado_rut = item.Encargado_rut;
                    nuevo._departamento_id_departamento = item.Departamento_id_departamento;
                    nuevo._estadoMantencion = item.EstadoMantencion;

                    lista.Add(nuevo);
                }
            }
            return lista;
        }
        public MantencionBLL buscarMantencion(int idMantencion)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            MantencionBLL nuevo = new MantencionBLL();
            foreach (var item in wcf.ListarMantencion())
            {
                if (item.id_mantencion == idMantencion)
                {
                    nuevo.id_mantencion = item.id_mantencion;
                    nuevo._varlo_total = item.Varlo_total;
                    nuevo._descripcion = item.Descripcion;
                    nuevo._fecha_inicio = item.Fecha_inicio;
                    nuevo._fecha_termino = item.Fecha_termino;
                    nuevo._motivo = item.Motivo;
                    nuevo._tipo_mantencion = item.Tipo_mantencion;
                    nuevo._encargado_rut = item.Encargado_rut;
                    nuevo._departamento_id_departamento = item.Departamento_id_departamento;
                    nuevo._estadoMantencion = item.EstadoMantencion;

                    return nuevo;
                }
            }
            return nuevo;
        }
        public int modificarMantencion(MantencionBLL item)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.MantencionBLL nuevo = new WSarriendo.MantencionBLL();
            nuevo.id_mantencion = item.id_mantencion;
            nuevo.Varlo_total = item._varlo_total;
            nuevo.Descripcion = item._descripcion;
            nuevo.Fecha_inicio = item._fecha_inicio;
            nuevo.Fecha_termino = item._fecha_termino;
            nuevo.Motivo = item._motivo;
            nuevo.Tipo_mantencion = item._tipo_mantencion;
            nuevo.Encargado_rut = item._encargado_rut;
            nuevo.Departamento_id_departamento = item._departamento_id_departamento;
            nuevo.EstadoMantencion = item._estadoMantencion;

            return wcf.ModificarMantencion(nuevo);
        }
        public List<MantencionBLL> ListarMantencionSegunFecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<MantencionBLL> lista = new List<MantencionBLL>();

            foreach (var item in wcf.ListarMantencion())
            {
                if (item.Fecha_inicio >= fechaInicio && item.Fecha_termino <= fechaTermino)
                {
                    MantencionBLL nuevo = new MantencionBLL();
                    nuevo.id_mantencion = item.id_mantencion;
                    nuevo._varlo_total = item.Varlo_total;
                    nuevo._descripcion = item.Descripcion;
                    nuevo._fecha_inicio = item.Fecha_inicio;
                    nuevo._fecha_termino = item.Fecha_termino;
                    nuevo._motivo = item.Motivo;
                    nuevo._tipo_mantencion = item.Tipo_mantencion;
                    nuevo._encargado_rut = item.Encargado_rut;
                    nuevo._departamento_id_departamento = item.Departamento_id_departamento;
                    nuevo._estadoMantencion = item.EstadoMantencion;

                    lista.Add(nuevo);
                }
            }
            return lista;

        }
    }
}