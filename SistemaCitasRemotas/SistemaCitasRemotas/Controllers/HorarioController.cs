using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Models;
namespace SistemaCitasRemotas.Controllers
{
    public class HorarioController : Controller
    {
        private Horario objHorario = new Horario();

        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objHorario.Listar());
            }
            else
            {
                return View(/*objDia.Buscar(criterio)*/);
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objHorario.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            //ViewBag.TipoUsuario = objTipoUsuario.Listar();
            //ViewBag.Especialidad = objEspecialidad.Listar();
            return View(id == 0 ? new Horario() // Agregarmos un nuevo objeto
                : objHorario.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Horario objHorario)
        {
            if (ModelState.IsValid)
            {
                objHorario.Guardar();
                return Redirect("~/Horario");
            }
            else
            {
                return View("~/Views/Horario/AgregarEditar.cshtml", objHorario);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objHorario.id = id;
            objHorario.Eliminar();
            return Redirect("~/Horario");
        }

    }
}