using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class FotoBLL
    {
        public int id_foto;
        private string descripcion;
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
        private byte[] url;
        public byte[] Url
        {
            get { return url; }
            set
            {

                if (value.Length > 0)
                {
                    url = value;
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
        public int agregarFoto(FotoBLL nueva)
        {
            FotoDAL modelo = new FotoDAL();
            return modelo.AgregarFotoDAL(nueva);
        }
        public List<FotoBLL> listarImagenes()
        {
            FotoDAL modelo = new FotoDAL();
            return modelo.listarImagenes();
        }
        public int eliminarFoto(int nuevo)
        {
            FotoDAL modelo = new FotoDAL();
            return modelo.EliminarFotoDAL(nuevo);
        }


    }
}