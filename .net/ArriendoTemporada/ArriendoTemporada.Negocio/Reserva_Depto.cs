using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArriendoTemporada.DALC;

namespace ArriendoTemporada.Negocio
{
    public class Reserva_Depto
    {
        public Reserva reserva { get; set; }
        public Departamento depto { get; set; }

        ArriendoTemporadaEntities db = new ArriendoTemporadaEntities();

        /*public List<Reserva_Depto> ReadAll()
        {
            return db.RESERVA_DEPTO.Select(rs => new Reserva_Depto()
            {
                Reserva = new Reserva()
                {
                    Id = rs.RESERVA.ID_RESERVA,
                    Fecha_Inicio = rs.RESERVA.FECHA_INICIO,
                    Fecha_Fin = rs.RESERVA.FECHA_FIN,
                    Estado = rs.RESERVA.ESTADO,
                    Cliente_Id = rs.RESERVA.CLIENTE_ID_CLIENTE,

                },
                Servicio = new Servicio()
                {
                    Id_Servicio = rs.SERVICIO.ID_SERVICIO,
                    NombreServ = rs.SERVICIO.NOMBRE,
                    TipoServ = rs.SERVICIO.TIPO,
                    HorarioInicioServ = rs.SERVICIO.HORARIO_INICIO,
                    HorarioFinServ = rs.SERVICIO.HORARIO_FIN,
                    PuntoReunionServ = rs.SERVICIO.PUNTO_REUNION,
                    ValorServ = rs.SERVICIO.VALOR,
                    RecorridoServ = rs.SERVICIO.RECORRIDO,
                    VehiculoServ = rs.SERVICIO.VEHICULO,
                    ChoferServ = rs.SERVICIO.CHOFER,
                    EstadoServ = rs.SERVICIO.ESTADO_SERVICIO,
                    CupoServ = rs.SERVICIO.CUPO
                }
            }).ToList();
        }*/


        public bool Save()
        {
            try
            {
                /* falta crear el procedimiento almacenado */
                //db.INSERT_RESERVA_DEPTO(this.reserva.Id, this.depto.Id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
