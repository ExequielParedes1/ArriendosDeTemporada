using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class PeticionBLL
    {
        public string zona { get; set; }
        public string _zona
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
        public DateTime checkIn { get; set; }
        public DateTime _checkIn
        {
            get { return checkIn; }
            set
            {

                if (value < checOut)
                {
                    checkIn = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public DateTime checOut { get; set; }
        public DateTime _checkOut
        {
            get { return checOut; }
            set
            {

                if (value > checkIn)
                {
                    checOut = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int cantHabitacion { get; set; }
        public int _cantHabitacion
        {
            get { return cantHabitacion; }
            set
            {

                if (value > 0)
                {
                    cantHabitacion = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
        public int cantHuespedes { get; set; }
        public int _cantHuespedes
        {
            get { return cantHuespedes; }
            set
            {

                if (value > 0)
                {
                    cantHuespedes = value;
                }
                else
                {
                    throw new Exception("¡Dato incorrecto!");

                }
            }
        }
    }
}