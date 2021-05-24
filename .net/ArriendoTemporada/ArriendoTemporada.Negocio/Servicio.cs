using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArriendoTemporada.DALC;

namespace ArriendoTemporada.Negocio
{
    public class Servicio
    {
        public decimal Id_Servicio { get; set; }
        public string NombreServ { get; set; }
        public string TipoServ { get; set; }
        public DateTime HorarioInicioServ { get; set; }
        public DateTime HorarioFinServ { get; set; }
        public string PuntoReunionServ { get; set; }
        public int ValorServ { get; set; }
        public string RecorridoServ { get; set; }
        public string VehiculoServ { get; set; }
        public string ChoferServ { get; set; }
        public string EstadoServ { get; set; }
        public int CupoServ { get; set; }
        public Estado estado { get; set; }


        public enum Estado
        {
            DISPONIBLE,NO_DISPONIBLE
        }


        ArriendoTemporadaEntities db = new ArriendoTemporadaEntities();

        public List<Servicio> ReadAll()
        {
            return this.db.SERVICIO.Select(s => new Servicio()
            {
                Id_Servicio = s.ID_SERVICIO,
                NombreServ = s.NOMBRE,
                TipoServ = s.TIPO,
                HorarioInicioServ = s.HORARIO_INICIO,
                HorarioFinServ = s.HORARIO_FIN,
                PuntoReunionServ = s.PUNTO_REUNION,
                ValorServ = s.VALOR,
                RecorridoServ = s.RECORRIDO,
                VehiculoServ = s.VEHICULO,
                ChoferServ = s.CHOFER,
                EstadoServ = s.ESTADO_SERVICIO,
                CupoServ = s.CUPO

            }).OrderBy(r => r.Id_Servicio).ToList();
        }

        public List<Servicio> ReadId(decimal servicio_id)
        {
            return db.SERVICIO.Select(s => new Servicio()
            {
                Id_Servicio = s.ID_SERVICIO,
                NombreServ = s.NOMBRE,
                TipoServ = s.TIPO,
                HorarioInicioServ = s.HORARIO_INICIO,
                HorarioFinServ = s.HORARIO_FIN,
                PuntoReunionServ = s.PUNTO_REUNION,
                ValorServ = s.VALOR,
                RecorridoServ = s.RECORRIDO,
                VehiculoServ = s.VEHICULO,
                ChoferServ = s.CHOFER,
                EstadoServ = s.ESTADO_SERVICIO,
                CupoServ = s.CUPO

            }).Where(s => s.Id_Servicio == servicio_id).ToList();

        }


    }
}
