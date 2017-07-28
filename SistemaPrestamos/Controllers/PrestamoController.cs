using SistemaPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaPrestamos.Controllers
{
    public class PrestamoController : Controller
    {
        //listado de prestamos
        [HttpPost]
        public JsonResult ListadoPrestamos()
        {
            using (var db = new PrestamosDB())
                try
                {
                    var result = db.prestar.ToList();
                    return Json(new { Result = "OK", Records = result });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
        }

        public ActionResult Index()
        {
            return View();
        }

        //creacion de prestamos
        [HttpPost]
        public JsonResult CrearPrestamos(Prestamo pres)
        {
            using (var db = new PrestamosDB())

                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Json(new
                        {
                            Result = "ERROR",
                            Message = "Form is not valid! " +
                          "Please correct it and try again."
                        });
                    }

                    var addPres = db.prestar.Add(pres);
                    db.SaveChanges(); // Esto es lo que guarda en la base de datos

                    return Json(new { Result = "OK", Record = addPres });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
        }

        //modificacion de prestamos
        [HttpPost]
        public JsonResult ModificarPrestamo(Prestamo pres)
        {
            using (var db = new PrestamosDB())

                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Json(new
                        {
                            Result = "ERROR",
                            Message = "Form is not valid! " +
                            "Please correct it and try again."
                        });
                    }

                    db.Entry(pres).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { Result = "OK" });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
        }

        //eliminar prestamos
        [HttpPost]
        public JsonResult EliminarPrestamo(int prestarID)
        {
            using (var db = new PrestamosDB())

                try
                {
                    var result = db.prestar.Find(prestarID);
                    db.prestar.Remove(result);
                    db.SaveChanges();
                    return Json(new { Result = "OK" });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
        }


    }
}
