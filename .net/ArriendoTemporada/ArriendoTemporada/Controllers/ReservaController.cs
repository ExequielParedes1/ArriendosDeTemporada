using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArriendoTemporada.Negocio;

namespace ArriendoTemporada.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            ViewBag.reserva = new Reserva().ReadAll();
            return View();
        }

        // GET: Reserva/Details/5
        public ActionResult Details(decimal cliente_id)
        {
            Session["cliente_id"] = cliente_id;
            decimal id = (decimal)Session["cliente_id"];
            ViewBag.reserva = new Reserva().ReadId(id);

            //ArriendoTemporadaEntities ctx = new ArriendoTemporadaEntities();

            //var servicio = ctx.SERVICIO.ToList();
            //var lista = new SelectList(servicio, "ID", "NOMBRE");
            //ViewData["servicio"] = lista;
            return View();
        }

        public ActionResult ReservaServicio(decimal cliente_id)
        {
            Session["cliente_id"] = cliente_id;
            decimal id = (decimal)Session["cliente_id"];
            ViewBag.reserva = new Reserva().ReadId(id);

            return View();
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            EnviarCliente();
            return View();
        }
        private void EnviarCliente()
        {
            ViewBag.cliente = new Cliente().ReadAll();
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(Reserva reserva)
        {
            var Cliente_Id = Session["cliente_id"];
            Session["cliente_id"] = reserva.Cliente_Id;
            try
            {
                // TODO: Add insert logic here

                reserva.Save();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("Details", new { Cliente_Id });
            }
            catch
            {
                return View(reserva);
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            Reserva r = new Reserva().Find(id);

            if (r == null)
            {
                TempData["mensaje"] = "La reserva no existe";
                return RedirectToAction("Index");
            }
            EnviarCliente();
            return View(r);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(Reserva reserva)
        {
            try
            {
                // TODO: Add update logic here
                reserva.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(reserva);
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Reserva().Find(id) == null)
            {
                TempData["mensaje"] = "No existe la reserva";
                return RedirectToAction("Index");
            }
            if (new Reserva().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se ha podido eliminar";
            return RedirectToAction("Index");
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
