using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class DepartamentoBLL
    {
        #region Campos
        public int idDepartamento { get; set; }
        public string direccion { get; set; }
        public string _Direccion
        {
            get { return direccion; }
            set
            {

                if (value.Length > 0)
                {
                    direccion = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int mtrsCuadrados { get; set; }
        public int _MtrsCuadrados
        {
            get { return mtrsCuadrados; }
            set
            {

                if (value > 0)
                {
                    mtrsCuadrados = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int valirDiario { get; set; }
        public int _ValorDiario
        {
            get { return valirDiario; }
            set
            {

                if (value > 0)
                {
                    valirDiario = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int disponible { get; set; }
        public int _Disponible
        {
            get { return disponible; }
            set
            {

                if (value == 0 || value == 1)
                {
                    disponible = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public string zona { get; set; }
        public string _Zona
        {
            get { return zona; }
            set
            {

                if (value.Length > 0)
                {
                    zona = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int nro_habitaciones { get; set; }
        public int _Nro_habitaciones
        {
            get { return nro_habitaciones; }
            set
            {

                if (value > 0)
                {
                    nro_habitaciones = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int nro_baños { get; set; }
        public int _Nro_baños
        {
            get { return nro_baños; }
            set
            {

                if (value > 0)
                {
                    nro_baños = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        #endregion

        #region Metodos
        public List<DepartamentoBLL> listarDepartamentoPorEstado(int estado)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<DepartamentoBLL> lista = new List<DepartamentoBLL>();
            foreach (var item in wcf.ListarDepartamento())
            {
                if (item.Disponible == estado)
                {
                    DepartamentoBLL otro = new DepartamentoBLL();
                    otro.idDepartamento = item.idDepartamento;
                    otro._Direccion = item.Direccion;
                    otro._MtrsCuadrados = item.MtrsCuadrados;
                    otro._ValorDiario = item.ValorDiario;
                    otro._Disponible = item.Disponible;
                    otro._Zona = item.Zona;
                    otro._Nro_habitaciones = item.Nro_habitaciones;
                    otro._Nro_baños = item.Nro_banhos;
                    lista.Add(otro);
                }
            }
            return lista;

        }

        public int AgregarDepartamentoBLL(DepartamentoBLL item)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.DepartamentoBLL otro = new WSarriendo.DepartamentoBLL();
            otro.idDepartamento = item.idDepartamento;
            otro.Direccion = item.direccion;
            otro.MtrsCuadrados = item.mtrsCuadrados;
            otro.ValorDiario = item.valirDiario;
            otro.Disponible = item.disponible;
            otro.Zona = item.zona;
            otro.Nro_habitaciones = item.nro_habitaciones;
            otro.Nro_banhos = item.nro_baños;
            return wcf.AgregarDepartamento(otro);
        }

        public DepartamentoBLL buscarDepartamento(int id)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            DepartamentoBLL otro = new DepartamentoBLL();
            foreach (var item in wcf.ListarDepartamento())
            {
                if (item.idDepartamento == id)
                {
                    otro.idDepartamento = item.idDepartamento;
                    otro._Direccion = item.Direccion;
                    otro._MtrsCuadrados = item.MtrsCuadrados;
                    otro._ValorDiario = item.ValorDiario;
                    otro._Disponible = item.Disponible;
                    otro._Zona = item.Zona;
                    otro._Nro_habitaciones = item.Nro_habitaciones;
                    otro._Nro_baños = item.Nro_banhos;
                }
            }
            return otro;
        }
        public int editarDepartamento(DepartamentoBLL item)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.DepartamentoBLL otro = new WSarriendo.DepartamentoBLL();
            otro.idDepartamento = item.idDepartamento;
            otro.Direccion = item.direccion;
            otro.MtrsCuadrados = item.mtrsCuadrados;
            otro.ValorDiario = item.valirDiario;
            otro.Disponible = item.disponible;
            otro.Zona = item.zona;
            otro.Nro_habitaciones = item.nro_habitaciones;
            otro.Nro_banhos = item.nro_baños;
            return wcf.ModificarDepartamento(otro);
        }

        public List<DepartamentoBLL> filtrarDepartamento(int estado, int habitaciones, string zona, List<DepartamentoBLL> listaCarro, DateTime inicio, DateTime termino)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            MantencionBLL mantencion = new MantencionBLL();
            List<DepartamentoBLL> lista = new List<DepartamentoBLL>();
            List<DepartamentoBLL> listaEliminar = new List<DepartamentoBLL>();
            foreach (var item in wcf.ListarDepartamento())
            {
                if (item.Disponible == estado && item.Nro_habitaciones == habitaciones && item.Zona == zona)
                {
                    DepartamentoBLL otro = new DepartamentoBLL();
                    otro.idDepartamento = item.idDepartamento;
                    otro._Direccion = item.Direccion;
                    otro._MtrsCuadrados = item.MtrsCuadrados;
                    otro._ValorDiario = item.ValorDiario;
                    otro._Disponible = item.Disponible;
                    otro._Zona = item.Zona;
                    otro._Nro_habitaciones = item.Nro_habitaciones;
                    otro._Nro_baños = item.Nro_banhos;
                    lista.Add(otro);
                }
            }
            foreach (var item2 in lista)
            {
                foreach (var item in listaCarro)
                {
                    if (item.idDepartamento == item2.idDepartamento)
                    {
                        listaEliminar.Add(item2);
                    }
                }
            }



            //filtra que no pueda arrendar departamento fuera de fecha

            List<WSarriendo.ReservaBLL> arriendoEliminar = new List<WSarriendo.ReservaBLL>();

            foreach (var item in wcf.ListarReserva())
            {
                if (item.Check_in >= inicio && item.Check_Out <= termino)
                {
                    arriendoEliminar.Add(item);
                }
            }
            for (int i = 0; i < lista.Count; i++)
            {
                foreach (var item3 in wcf.ListarReserva())
                {
                    foreach (var item in arriendoEliminar)
                    {
                        foreach (var item2 in lista)
                        {
                            if (item2.idDepartamento == item.Departamento_id_departamento || item2.idDepartamento == item3.Departamento_id_departamento)
                            {
                                listaEliminar.Add(item2);
                            }
                        }
                    }
                }

            }
            foreach (var item2 in lista)
            {
                foreach (var item in mantencion.ListarMantencionSegunFecha(inicio, termino))
                {
                    if (item2.idDepartamento == item._departamento_id_departamento)
                    {
                        listaEliminar.Add(item2);
                    }
                }
            }


            for (int i = 0; i < lista.Count; i++)
            {
                foreach (var item in listaEliminar)
                {
                    lista.Remove(item);
                }
            }
            return lista;
        }

        public List<DepartamentoBLL> listarTodosDptos()
        {
            List<DepartamentoBLL> lista = new List<DepartamentoBLL>();
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();

            foreach (var item in wcf.ListarDepartamento())
            {
                DepartamentoBLL otro = new DepartamentoBLL();
                otro.idDepartamento = item.idDepartamento;
                otro._Direccion = item.Direccion;
                otro._MtrsCuadrados = item.MtrsCuadrados;
                otro._ValorDiario = item.ValorDiario;
                otro._Disponible = item.Disponible;
                otro._Zona = item.Zona;
                otro._Nro_habitaciones = item.Nro_habitaciones;
                otro._Nro_baños = item.Nro_banhos;
                lista.Add(otro);
            }
            return lista;

        }
        #endregion

    }
}