using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace WEBArriendoTemporada.NEGOCIO
{
    public class Correos
    {
        public void enviarCorreoDeConfirmacion(string correo, string nombre, string apellido)
        {
            string txtFrom = "turismoreal2019portafolio@gmail.com";
            string txtpass = "turismoreal2019";
            string txtcopy = "turismoreal2019portafolio@gmail.com";
            string txtTo = correo;
            string txtSubject = "Cuenta Activada";
            string txtMensaje = "Bienvenido a Turismo Real " + nombre + " " + apellido + ", Tu cuenta se encuentra activa, ya puedes ingresar a realizar tu reserva.";

            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txtFrom);
                msg.To.Add(txtTo);
                msg.Subject = txtSubject;
                msg.Body = txtMensaje;
                MailAddress ms = new MailAddress(txtcopy);
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential(txtFrom, txtpass);
                sc.EnableSsl = true;
                sc.Send(msg);


            }
            catch (Exception)
            {

            }
        }

        public bool recibirCorreoDeUsuario(string nombre, string email, string asunto, string mensaje)
        {
            string txtFrom = "turismoreal2019portafolio@gmail.com";
            string txtpass = "turismoreal2019";
            string txtcopy = "turismoreal2019portafolio@gmail.com";
            string txtTo = email;
            string txtSubject = asunto;
            string txtMensaje = " Turismo Real :" + nombre + ",te envio un mensaje con lo siguiente: " +
                "------------ " + mensaje;

            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txtFrom);
                msg.To.Add(txtTo);
                msg.Subject = txtSubject;
                msg.Body = txtMensaje;
                MailAddress ms = new MailAddress(txtcopy);
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential(txtFrom, txtpass);
                sc.EnableSsl = true;
                sc.Send(msg);
                return true;


            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool asignacionDeArriendo(string nombre, string email, string asunto, string arriendo)
        {
            ReservaBLL arr = new ReservaBLL();
            arr = arr.buscarReserva(int.Parse(arriendo));
            DepartamentoBLL dpto = new DepartamentoBLL();
            dpto = dpto.buscarDepartamento(arr._departamento_id_departamento);
            string txtFrom = "turismoreal2019portafolio@gmail.com";
            string txtpass = "turismoreal2019";
            string txtcopy = "turismoreal2019portafolio@gmail.com";
            string txtTo = email;
            string txtSubject = asunto;
            string txtMensaje = "Estimado " + nombre + "\n" + "" +
                "Se te ha asignado el arriendo de código:  " + arriendo + "\n" +
                "\n" +
                "Cuyo Chek-out tiene como fecha: " + arr._check_Out.ToString("dd/MM/yyyy") + "\n" +
                "\n" +
                "Direccion: " + dpto._Direccion +
                "\n" +
                "Que tengas un exelente día, cualquier duda conectarse con administracion.";


            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txtFrom);
                msg.To.Add(txtTo);
                msg.Subject = txtSubject;
                msg.Body = txtMensaje;
                MailAddress ms = new MailAddress(txtcopy);
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential(txtFrom, txtpass);
                sc.EnableSsl = true;
                sc.Send(msg);
                return true;


            }
            catch (Exception)
            {
                return false;
            }

        }
        public void enviarCorreoPago(UsuarioBLL usr, ReservaBLL arr, int idArriendo)
        {
            string txtFrom = "turismoreal2019portafolio@gmail.com";
            string txtpass = "turismoreal2019";
            string txtcopy = "turismoreal2019portafolio@gmail.com";
            string txtTo = usr._correo;
            string txtSubject = "BOLETA";
            string txtMensaje = "Bienvenido a Turismo Real " + usr._nombre + " " + usr._apellido + "\n " +
                "ID ARIIENDO: " + idArriendo + "\n" +
                "Pagado: " + arr._anticipo + "\n" +
                "Restante: " + (arr._valor_final - arr._anticipo) + "\n";

            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txtFrom);
                msg.To.Add(txtTo);
                msg.Subject = txtSubject;
                msg.Body = txtMensaje;
                MailAddress ms = new MailAddress(txtcopy);
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential(txtFrom, txtpass);
                sc.EnableSsl = true;
                sc.Send(msg);


            }
            catch (Exception)
            {

            }
        }
    }
}