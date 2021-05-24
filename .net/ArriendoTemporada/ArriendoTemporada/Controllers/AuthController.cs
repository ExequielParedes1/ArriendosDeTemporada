using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArriendoTemporada.Negocio;
using System.Web.Security;

namespace ArriendoTemporada.Controllers
{
    public class AuthController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Cliente cliente, string ReturnUrl)
        {
            if (IsValid(cliente))
            {
                FormsAuthentication.SetAuthCookie(cliente.Rut_Cliente, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                Session["username"] = cliente.Rut_Cliente;
                Cliente cl = new Cliente().ReadAll().Find(x => x.Rut_Cliente == (string)Session["username"]);
                Session["username"] = cl.Rut_Cliente;
                Session["cliente_id"] = cl.Id;
                return RedirectToAction("Index", "Home", new { cl.Rut_Cliente, cl.Id });
            }
            TempData["mensaje"] = "Nombre o usuario Incorrectos";
            return View(cliente);

        }

        private bool IsValid(Cliente cliente)
        {
            return cliente.Autenticar();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}