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

            //Session["id_depto"] = id_depto;
            //decimal depto_id = (decimal)Session["id_depto"];

            return View();
        }

        /* PRUEBA */
        public ActionResult Reserva_Servicio(decimal reserva_id, decimal servicio_id)
        {
            Session["reserva_id"] = reserva_id;
            decimal id = (decimal)Session["reserva_id"];
            ViewBag.reserva = new Reserva().ReadId(id);

            Session["servicio_id"] = servicio_id;
            decimal s_id = (decimal)Session["servicio_id"];
            ViewBag.servicio = new Servicio().ReadId(s_id);


            //return View("Reserva_Servicio", new { reserva_id, servicio_id });

            return View();

            
            
                        
        }
        public ActionResult Guardar_Servicio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Guardar_Servicio(Reserva_Servicio rs, decimal reserva_id, decimal servicio_id)
        {
            Session["reserva_id"] = reserva_id;
            decimal id = (decimal)Session["reserva_id"];
            ViewBag.reserva = new Reserva().ReadId(id);

            Session["servicio_id"] = servicio_id;
            decimal s_id = (decimal)Session["servicio_id"];
            ViewBag.servicio = new Servicio().ReadId(s_id);

            try
            {
                rs.Save();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("Index", new { reserva_id, servicio_id });
            }
            catch (Exception)
            {
                return View();
            }
        }

        /* END PRUEBA */

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
               /* r_depto.Save();*/
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
            var Cliente_Id = Session["cliente_id"];

            Reserva r = new Reserva().Find(id);

            if (r == null)
            {
                TempData["mensaje"] = "La reserva no existe";
                return RedirectToAction("Details", new { Cliente_Id });
            }
            EnviarCliente();
            return View(r);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(Reserva reserva)
        {
            var Cliente_Id = Session["cliente_id"];
            //Session["cliente_id"] = reserva.Cliente_Id;
            try
            {
                // TODO: Add update logic here
                reserva.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Details", new { Cliente_Id});
            }
            catch
            {
                return View(reserva);
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            //if (new Reserva().Find(id) == null)
            //{
            //    TempData["mensaje"] = "No existe la reserva";
            //    return RedirectToAction("Details");
            //}
            var Cliente_Id = Session["cliente_id"];

            if (new Reserva().Delete(id))
            {
                TempData["mensaje"] = "Eliminado correctamente";
                return RedirectToAction("Details", new { Cliente_Id });
            }
            TempData["mensaje"] = "No se ha podido eliminar";
            return RedirectToAction("Details", new { Cliente_Id });
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
