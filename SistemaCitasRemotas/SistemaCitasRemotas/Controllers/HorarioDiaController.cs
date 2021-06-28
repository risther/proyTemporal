using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Models;
namespace SistemaCitasRemotas.Controllers
{
    public class HorarioDiaController : Controller
    {
        private HorarioDia objHorarioDia = new HorarioDia();
        private Horario objHorario = new Horario();
        private Especialidad objEspecialidad = new Especialidad();
        private Dia objDia = new Dia();
        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objHorarioDia.Listar());
            }
            else
            {
                return View(/*objDia.Buscar(criterio)*/);
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objHorarioDia.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Especialidad = objEspecialidad.Listar();
            ViewBag.Horario = objHorario.Listar();
            ViewBag.Dia = objDia.Listar();
            return View(id == 0 ? new HorarioDia() // Agregarmos un nuevo objeto
                : objHorarioDia.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(HorarioDia objHorarioDia)
        {
            if (ModelState.IsValid)
            {
                objHorarioDia.Guardar();
                return Redirect("~/HorarioDia");
            }
            else
            {
                return View("~/Views/HorarioDia/AgregarEditar.cshtml", objHorarioDia);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objHorarioDia.id = id;
            objHorarioDia.Eliminar();
            return Redirect("~/HorarioDia");
        }
    }
}