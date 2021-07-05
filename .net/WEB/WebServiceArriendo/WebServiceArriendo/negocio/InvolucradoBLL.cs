using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class InvolucradoBLL
    {
        public string usuario_correo { get; set; }

        public int reserva_id_reserva { get; set; }

        public int AgregarInvolucradoBLL(InvolucradoBLL inv)
        {
            InvolucradosDAL modelo = new InvolucradosDAL();
            return modelo.AgregarInvolucradosDAL(inv);
        }
        public List<InvolucradoBLL> ListarInvolucradoBLL()
        {
            InvolucradosDAL modelo = new InvolucradosDAL();
            return modelo.listarInvolucradosBLL();
        }
        public int eliminarAsociacionFuncionario(InvolucradoBLL inv)
        {
            InvolucradosDAL modelo = new InvolucradosDAL();
            return modelo.EliminarInvolucradoFuncionario(inv);
        }
    }
}