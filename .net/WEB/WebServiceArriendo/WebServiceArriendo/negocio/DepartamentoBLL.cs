using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceArriendo.modelo;

namespace WebServiceArriendo.negocio
{
    public class DepartamentoBLL
    {
        #region Campos
        public int idDepartamento { get; set; }
        private string direccion { get; set; }
        public string Direccion
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
        private int mtrsCuadrados { get; set; }
        public int MtrsCuadrados
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
        private int valirDiario { get; set; }
        public int ValorDiario
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
        private int disponible { get; set; }
        public int Disponible
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
        private string zona { get; set; }
        public string Zona
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
        private int nro_habitaciones { get; set; }
        public int Nro_habitaciones
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
        private int nro_banhos { get; set; }
        public int Nro_banhos
        {
            get { return nro_banhos; }
            set
            {

                if (value > 0)
                {
                    nro_banhos = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        #endregion
        #region Metodos
        public List<DepartamentoBLL> ListarDepartamentoBLL()
        {
            DepartamentoDAL modelo = new DepartamentoDAL();
            return modelo.listarDepartamento();
        }
        public int AgregarDepartamentoBLL(DepartamentoBLL dpto)
        {
            DepartamentoDAL modelo = new DepartamentoDAL();
            return modelo.AgregarDepartamentoDAL(dpto);
        }
        public int ModificarDepartamentoBLL(DepartamentoBLL dpto)
        {
            DepartamentoDAL modelo = new DepartamentoDAL();
            return modelo.ModificarDepartamentoDAL(dpto);
        }
        #endregion
    }
}