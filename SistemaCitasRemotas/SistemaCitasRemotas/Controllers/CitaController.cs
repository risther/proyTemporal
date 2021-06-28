using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Filters;
using SistemaCitasRemotas.Models;

namespace SistemaCitasRemotas.Controllers
{
    public class CitaController : Controller
    {
        Cita objCita = new Cita();
        Usuario objUsuario = new Usuario();

        // GET: Cita
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCita.Listar());
            }
            else
            {
                return View(objCita.Buscar(criterio));
            }
        }



        public ActionResult Visualizar(int id)
        {
            return View(objCita.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Paciente = objUsuario.Listar();
            return View(id == 0 ? new Usuario()  // agrega un nuevo objeto
                                : objUsuario.Obtener(id)); //devuelve el id del objeto
        }
        public ActionResult Guardar(Cita objCita)
        {

            if (ModelState.IsValid)
            {
                objCita.Guardar();
                return Redirect("~/Cita");
            }
            else
            {
                return View("~/Views/Cita/AgregarEditar.cshtml", objCita);
            }
        }
        public ActionResult Eliminar(int id)
        {
            objCita.id = id;
            objCita.Eliminar();
            return Redirect("~/Cita");
        }
    }
}