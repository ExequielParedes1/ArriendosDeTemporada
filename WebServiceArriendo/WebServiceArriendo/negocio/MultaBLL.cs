using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;
namespace WebServiceArriendo.negocio
{
    public class MultaBLL
    {
        #region Campos
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
        #endregion
        #region Metodos

        public int AgregarMultaBLL(MultaBLL mul)
        {
            MultaDAL modelo = new MultaDAL();
            return modelo.AgregarMultaDAL(mul);
        }
        public List<MultaBLL> ListarMultaBLL()
        {
            MultaDAL modelo = new MultaDAL();
            return modelo.listarMultaBLL();
        }
        public int ModificarMultaBLL(MultaBLL mul)
        {
            MultaDAL modelo = new MultaDAL();
            return modelo.ModificarMultaDAL(mul);
        }
        #endregion
    }
}