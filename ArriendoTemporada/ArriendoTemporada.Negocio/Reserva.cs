using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArriendoTemporada.DALC;

namespace ArriendoTemporada.Negocio
{
    public class Reserva
    {
        public decimal Id { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public decimal Estado { get; set; }
        public decimal Cliente_Id { get; set; }

        public Cliente Cliente { get; set; }

        ArriendoTemporadaEntities db = new ArriendoTemporadaEntities();

        public List<Reserva> ReadAll()
        {
            return db.RESERVA.Select(r => new Reserva()
            {
                Id = r.ID_RESERVA,
                Fecha_Inicio = r.FECHA_INICIO,
                Fecha_Fin = r.FECHA_FIN,
                Estado = r.ESTADO,
                Cliente_Id = r.CLIENTE_ID_CLIENTE,
                Cliente = new Cliente()
                {
                    Id = r.CLIENTE.ID_CLIENTE,
                    Rut_Cliente = r.CLIENTE.RUT_CLIENTE,
                    Pasaporte = r.CLIENTE.PASAPORTE,
                    Passwrd = r.CLIENTE.PASSWRD,
                    Nombre = r.CLIENTE.NOMBRE,
                    Apellido_P = r.CLIENTE.APELLIDO_P,
                    Apellido_M = r.CLIENTE.APELLIDO_M,
                    Num_Celular = r.CLIENTE.NUM_CELULAR,
                    Correo = r.CLIENTE.CORREO,
                    Nacionalidad = r.CLIENTE.NACIONALIDAD,
                    Cliente_Frecuente = r.CLIENTE.CLIENTE_FRECUENTE,
                    Estado_Cliente = r.CLIENTE.ESTADO_CLIENTE,

                }
            }).ToList();
        }

        public bool Save()
        {
            try
            {
                //Procedimiento almacenado
                db.INSERT_RESERVA(this.Fecha_Inicio, this.Fecha_Fin, this.Estado, this.Cliente_Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Reserva Find(int id)
        {
            return db.RESERVA.Select(r => new Reserva()
            {
                Id = r.ID_RESERVA,
                Fecha_Inicio = r.FECHA_INICIO,
                Fecha_Fin = r.FECHA_FIN,
                Estado = r.ESTADO,
                Cliente_Id = r.CLIENTE_ID_CLIENTE,
                Cliente = new Cliente()
                {
                    Id = r.CLIENTE.ID_CLIENTE,
                    Rut_Cliente = r.CLIENTE.RUT_CLIENTE,
                    Pasaporte = r.CLIENTE.PASAPORTE,
                    Passwrd = r.CLIENTE.PASSWRD,
                    Nombre = r.CLIENTE.NOMBRE,
                    Apellido_P = r.CLIENTE.APELLIDO_P,
                    Apellido_M = r.CLIENTE.APELLIDO_M,
                    Num_Celular = r.CLIENTE.NUM_CELULAR,
                    Correo = r.CLIENTE.CORREO,
                    Nacionalidad = r.CLIENTE.NACIONALIDAD,
                    Cliente_Frecuente = r.CLIENTE.CLIENTE_FRECUENTE,
                    Estado_Cliente = r.CLIENTE.ESTADO_CLIENTE,

                }
            }).Where(r => r.Id == id).FirstOrDefault();
        }

        public bool Update ()
        {
            try
            {
                db.UPDATE_RESERVA(this.Id, this.Fecha_Inicio, this.Fecha_Fin, this.Estado, this.Cliente_Id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                db.DELETE_RESERVA(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
