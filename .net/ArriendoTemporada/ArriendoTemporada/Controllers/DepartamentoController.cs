using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArriendoTemporada.Negocio;

namespace ArriendoTemporada.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index(Departamento dpto)
        {
            ViewBag.departamento = new Departamento().ReadAll();
            return View();
        }
    }
}