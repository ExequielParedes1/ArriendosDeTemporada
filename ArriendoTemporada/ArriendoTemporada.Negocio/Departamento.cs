using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArriendoTemporada.DALC;

namespace ArriendoTemporada.Negocio
{
    public class Departamento
    {
        public decimal Id { get; set; }
        public string Numero_dpto { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string Region { get; set; }
        public string Estado { get; set; }
        public decimal Valor { get; set; }


        ArriendoTemporadaEntities db = new ArriendoTemporadaEntities();

        public List<Departamento> ReadAll()
        {
            return this.db.DPTO.Select(d => new Departamento()
            {
                Id = d.ID_DPTO,
                Numero_dpto = d.NUM_DEPTO,
                Direccion = d.DIRECCION,
                Descripcion = d.DESCRIPCION,
                Region = d.REGION,
                Estado = d.ESTADO,
                Valor = d.VALOR_DIARIO,

            }).ToList();
        }



    }
}
