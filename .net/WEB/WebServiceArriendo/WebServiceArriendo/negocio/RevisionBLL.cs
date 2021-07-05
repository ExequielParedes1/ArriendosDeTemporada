using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class RevisionBLL
    {
        private string estado { get; set; }
        public string Estado
        {
            get { return estado; }
            set
            {

                if (value.Length > 0)
                {
                    estado = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }

        private string observaciones { get; set; }
        public string Observaciones
        {
            get { return observaciones; }
            set
            {

                if (value.Length > 0)
                {
                    observaciones = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }


        public int inventario_items_id_item { get; set; }
        public int inventario_depto_id_depto { get; set; }
        public int reserva_id_reserva { get; set; }

        public int AgregarRevisionBLL(RevisionBLL rev)
        {
            RevisionDAL modelo = new RevisionDAL();
            return modelo.AgregarRevisionDAL(rev);
        }
        public int ModificarRevisionBLL(RevisionBLL rev)
        {
            RevisionDAL modelo = new RevisionDAL();
            return modelo.ModificarRevisionDAL(rev);
        }
        public List<RevisionBLL> ListaRevisionBLL()
        {
            RevisionDAL modelo = new RevisionDAL();
            return modelo.ListarRevisionDAL();
        }

    }
}