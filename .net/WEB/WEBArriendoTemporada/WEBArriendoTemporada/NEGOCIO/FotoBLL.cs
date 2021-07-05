using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class FotoBLL
    {
        public int id_foto { get; set; }
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
        private string nombre { get; set; }
        public string _nombre
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
        private byte[] url { get; set; }
        public byte[] _url
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
        private int id_departamento_id { get; set; }
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

        public int agregarFotoBLL(FotoBLL nueva)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.FotoBLL foto = new WSarriendo.FotoBLL();

            foto.id_foto = nueva.id_foto;
            foto.Descripcion = nueva._descripcion;
            foto.Nombre = nueva._nombre;
            foto.Url = nueva._url;
            foto.Id_departamento_id = nueva.id_departamento_id;

            return wcf.AgregarFoto(foto);
        }
        public List<FotoBLL> listarImagenes()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<FotoBLL> lista = new List<FotoBLL>();

            foreach (var item in wcf.listarImagenes())
            {
                FotoBLL nueva = new FotoBLL();
                nueva.id_foto = item.id_foto;
                nueva._nombre = item.Nombre;
                nueva._descripcion = item.Descripcion;
                nueva._id_departamento_id = item.Id_departamento_id;
                nueva._url = item.Url;
                lista.Add(nueva);

            }
            return lista;
        }
        public List<FotoBLL> listarImagenesPorDpto(int idDepto)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<FotoBLL> lista = new List<FotoBLL>();

            foreach (var item in wcf.listarImagenes())
            {
                if (item.Id_departamento_id == idDepto)
                {
                    FotoBLL nueva = new FotoBLL();
                    nueva.id_foto = item.id_foto;
                    nueva._nombre = item.Nombre;
                    nueva._descripcion = item.Descripcion;
                    nueva._id_departamento_id = item.Id_departamento_id;
                    nueva._url = item.Url;
                    lista.Add(nueva);
                }
            }
            return lista;
        }

        public FotoBLL buscarImagen(int id)
        {
            FotoBLL nuevo = new FotoBLL();
            foreach (var item in listarImagenes())
            {
                if (item.id_foto == id)
                {

                    nuevo.id_foto = item.id_foto;
                    nuevo._nombre = item._nombre;
                    nuevo._descripcion = item.descripcion;
                    nuevo._url = item._url;
                    nuevo._id_departamento_id = item._id_departamento_id;

                    return nuevo;
                }
            }
            return nuevo;
        }
        public int eliminarImagen(int id)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            return wcf.EliminarFoto(id);
        }

    }
}