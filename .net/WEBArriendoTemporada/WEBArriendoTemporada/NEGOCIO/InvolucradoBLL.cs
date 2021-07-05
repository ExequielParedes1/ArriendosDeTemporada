using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class InvolucradoBLL
    {
        public string usuario_correo { get; set; }
        public int reserva_id_reserva { get; set; }

        public int agregarInvolucrado(InvolucradoBLL nuevo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.InvolucradoBLL otro = new WSarriendo.InvolucradoBLL();

            otro.usuario_correo = nuevo.usuario_correo;
            otro.reserva_id_reserva = nuevo.reserva_id_reserva;

            return wcf.AgregarInvolucrado(otro);
        }

        public List<InvolucradoBLL> listaInvolucradosFuncionario()
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            List<InvolucradoBLL> lista = new List<InvolucradoBLL>();
            foreach (var item in wcf.ListarUsuario())
            {
                if (item.Tipo.Equals("funcionario"))
                {
                    foreach (var item2 in wcf.ListaInvolucrado())
                    {
                        if (item.Correo.Equals(item2.usuario_correo))
                        {
                            InvolucradoBLL nuevo = new InvolucradoBLL();
                            nuevo.usuario_correo = item2.usuario_correo;
                            nuevo.reserva_id_reserva = item2.reserva_id_reserva;

                            lista.Add(nuevo);
                        }
                    }
                }
            }
            return lista;
        }
        public UsuarioBLL buscarFuncionarioAsociado(int idReserva)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            UsuarioBLL funcionario = new UsuarioBLL();
            foreach (var item in wcf.ListarUsuario())
            {
                if (item.Tipo.Equals("funcionario"))
                {
                    foreach (var item2 in wcf.ListaInvolucrado())
                    {
                        if (item2.usuario_correo.Equals(item.Correo) && item2.reserva_id_reserva == idReserva)
                        {
                            funcionario._correo = item.Correo;
                            funcionario._nombre = item.Nombre;
                            funcionario._apellido = item.Apellido;
                            funcionario._numeroContacto = item.NumeroContacto;
                            funcionario._cedula = item.Cedula;
                            funcionario._estado = item.Estado;
                            funcionario._tipo = item.Tipo;

                            return funcionario;
                        }
                    }
                }
            }
            return funcionario;


        }
        public int eliminarFuncionarioAsociado(InvolucradoBLL inv)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            WSarriendo.InvolucradoBLL nuevo = new WSarriendo.InvolucradoBLL();
            nuevo.reserva_id_reserva = inv.reserva_id_reserva;
            nuevo.usuario_correo = inv.usuario_correo;


            return wcf.EliminarAsociacionFuncionario(nuevo);
        }

        public UsuarioBLL buscarUsuarioInvolucrado(int idArriendo, string tipo)
        {
            WSarriendo.arriendoTemporadaSoapClient wcf = new WSarriendo.arriendoTemporadaSoapClient();
            UsuarioBLL nuevo = new UsuarioBLL();

            foreach (var item in wcf.ListaInvolucrado())
            {
                foreach (var item2 in nuevo.listarUsuario())
                {
                    if (item.usuario_correo.Equals(item2._correo) && idArriendo == item.reserva_id_reserva && item2._tipo.Equals(tipo))
                    {
                        nuevo._correo = item2._correo;
                        nuevo._cedula = item2._cedula;
                        nuevo._nombre = item2._nombre;
                        nuevo._apellido = item2._apellido;
                        nuevo._numeroContacto = item2._numeroContacto;
                        nuevo._estado = item2._estado;
                        nuevo._tipo = item2._tipo;

                        return nuevo;
                    }
                }
            }
            return nuevo;
        }
    }
}