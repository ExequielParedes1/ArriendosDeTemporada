using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArriendoTemporada.DALC;

namespace ArriendoTemporada.Negocio
{
    public class Cliente
    {
        public decimal Id { get; set; }
        public string Rut_Cliente { get; set; }
        public string Pasaporte { get; set; }
        public string Passwrd { get; set; }
        public string Nombre { get; set; }
        public string Apellido_P { get; set; }
        public string Apellido_M { get; set; }
        public decimal Num_Celular { get; set; }
        public string Correo { get; set; }
        public string Nacionalidad { get; set; }
        public string Cliente_Frecuente { get; set; }
        public string Estado_Cliente { get; set; }


        ArriendoTemporadaEntities db = new ArriendoTemporadaEntities();

        public List<Cliente> ReadAll()
        {
            return this.db.CLIENTE.Select(c => new Cliente()
            {
                Id = c.ID_CLIENTE,
                Rut_Cliente = c.RUT_CLIENTE,
                Pasaporte = c.PASAPORTE,
                Passwrd = c.PASSWRD,
                Nombre = c.NOMBRE,
                Apellido_P = c.APELLIDO_P,
                Apellido_M = c.APELLIDO_M,
                Num_Celular = c.NUM_CELULAR,
                Correo = c.CORREO,
                Nacionalidad = c.NACIONALIDAD,
                Cliente_Frecuente = c.CLIENTE_FRECUENTE,
                Estado_Cliente = c.ESTADO_CLIENTE,

            }).ToList();
        }

        public bool Autenticar()
        {
            return db.CLIENTE.Where(c => c.RUT_CLIENTE == this.Rut_Cliente && c.PASSWRD ==
            this.Passwrd).FirstOrDefault() != null;
        }
    }
}
