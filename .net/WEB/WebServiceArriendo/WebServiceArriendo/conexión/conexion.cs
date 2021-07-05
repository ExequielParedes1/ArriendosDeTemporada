using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace WebServiceArriendo.conexión
{
    public class conexion
    {
        private OracleConnection cn { get; set; }

        public OracleConnection conectar()
        {
            if (cn == null)
            {
                string connString = "Data Source=localhost;User Id=ATEMPORADA; Password=duoc;";
                cn = new OracleConnection(connString);
            }
            return cn;
        }
    }
}