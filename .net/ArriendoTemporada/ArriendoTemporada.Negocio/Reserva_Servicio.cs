using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArriendoTemporada.DALC;

namespace ArriendoTemporada.Negocio
{
    public class Reserva_Servicio
    {

        public decimal Cupos { get; set; }
        public Reserva Reserva { get; set; }
        public Servicio Servicio { get; set; }

        ArriendoTemporadaEntities db = new ArriendoTemporadaEntities();


        public List<Reserva> ReadId(decimal cliente_id)
        {
            return db.RESERVA_SERVICIO.Select(rs => new Reserva_Servicio()
            {
                Cupos = rs.CANTIDAD_CUPO,
                Reserva = new Reserva()
                {
                    Id = rs.RESERVA.ID_RESERVA,
                    Fecha_Inicio = rs.RESERVA.FECHA_INICIO,
                    Fecha_Fin = rs.RESERVA.FECHA_FIN,
                    Estado = rs.RESERVA.ESTADO,
                    Cliente_Id = rs.RESERVA.CLIENTE_ID_CLIENTE

                },
                Servicio = new Servicio()
                {
                    Id_Servicio = rs.SERVICIO.ID_SERVICIO,


                }
            }).Where(r => r.Cliente_Id == cliente_id).ToList();

        }







    }
}
