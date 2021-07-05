using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class MultaBLL
    {
        public int idMulta { get; set; }
        private string nombre { get; set; }
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
        private int valor { get; set; }
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
        private string estado_multa { get; set; }
        public string Estado_Multa
        {
            get { return estado_multa; }
            set
            {

                if (value.Length > 0)
                {
                    estado_multa = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int agregarMultaBLL(MultaBLL multa)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.MultaBLL nuevo = new WSarriendo.MultaBLL();
            nuevo.Nombre = multa.Nombre;
            nuevo.Descripcion = multa.Descripcion;
            nuevo.Valor = multa.Valor;
            nuevo.Estado_Multa = multa.Estado_Multa;

            return wcf.AgregarMulta(nuevo);
        }
        public List<MultaBLL> listaMultaBLL()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<MultaBLL> lista = new List<MultaBLL>();

            foreach (var item in wcf.ListarMulta())
            {
                MultaBLL nueva = new MultaBLL();
                nueva.idMulta = item.idMulta;
                nueva.nombre = item.Nombre;
                nueva.Descripcion = item.Descripcion;
                nueva.Valor = item.Valor;
                nueva.Estado_Multa = item.Estado_Multa;

                lista.Add(nueva);
            }
            return lista;

        }

    }
}