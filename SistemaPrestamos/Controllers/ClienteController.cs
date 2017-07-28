using SistemaPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaPrestamos.Controllers
{
    public class ClienteController : Controller
    {
        [HttpPost]
        public JsonResult CreatePerson()
        {
            using (var db = new PrestamosDB())
                try
                {
                    var result = db.cliente.ToList();
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

        //metedo en donde se crearan nuevos prestamos 
        [HttpPost]
        public JsonResult Create(Cliente cliente)
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

                    var addPres = db.cliente.Add(cliente);
                    db.SaveChanges();
                    return Json(new { Result = "OK", Record = addPres });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
        }

        //metodo para modificar los prestamos 
        [HttpPost]
        public JsonResult Update(Cliente cliente)
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

                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { Result = "OK" });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
        }

        //metodo utilizado para eliminar prestamos 
        [HttpPost]
        public JsonResult Delete(int ClienteID)
        {
            using (var db = new PrestamosDB())

                try
                {
                    var result = db.cliente.Find(ClienteID);
                    db.cliente.Remove(result);
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
