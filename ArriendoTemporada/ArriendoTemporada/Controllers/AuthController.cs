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
                if(ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                Session["username"] = cliente.Rut_Cliente;
                return RedirectToAction("Index", "Home");
            }
            TempData["mensaje"] = "Nombre o usuario Incorrectos";
            return View(cliente);
                
        }

        private bool IsValid(Cliente cliente)
        {
            return cliente.Autenticar();
        }

        public ActionResult LogOut ()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}