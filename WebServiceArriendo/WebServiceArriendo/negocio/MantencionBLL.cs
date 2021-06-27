using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class MantencionBLL
    {
        #region Campos
        public int id_mantencion { get; set; }
        private int varlo_total { get; set; }
        public int Varlo_total
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
        public string Descripcion
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
        public DateTime Fecha_inicio
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
        public DateTime Fecha_termino
        {
            get { return fecha_termino; }
            set
            {

                if (value != null)
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
        public string Motivo
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
        public string Tipo_mantencion
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
        public string Encargado_rut
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
        public int Departamento_id_departamento
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
        public string EstadoMantencion
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
        #region Metodos
        public List<MantencionBLL> ListarMantecionBLL()
        {
            MantencionDAL modelo = new MantencionDAL();
            return modelo.ListaMantencionDAL();
        }
        public int AgregarMantecionBLL(MantencionBLL man)
        {
            MantencionDAL modelo = new MantencionDAL();
            return modelo.AgregarMantencionDAL(man);
        }
        public int ModificarMantencionBLL(MantencionBLL man)
        {
            MantencionDAL modelo = new MantencionDAL();
            return modelo.ModificarMantencion(man);
        }
        #endregion
    }
}