using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Models;
namespace SistemaCitasRemotas.Controllers
{
    public class HistoriaController : Controller
    {
        private Historia objHistoria = new Historia();
        private Usuario objUsuario = new Usuario();
        private Diagnostico objDiagnostico = new Diagnostico();
        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objHistoria.Listar());
            }
            else
            {
                return View(/*objDia.Buscar(criterio)*/);
            }
        }

        public ActionResult Visualizar(int id)
        {
            ViewBag.Diagnostico = objDiagnostico.Listar();

            ViewBag.Usuario = objUsuario.Listar();
            return View(objHistoria.Obtener(id));
        }

        public ActionResult VerHistoriaUsuario(int id)
        {
            return View(objHistoria.VerHistoriaID(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Diagnostico = objDiagnostico.Listar();
            ViewBag.Usuario = objUsuario.Listar();
            return View(id == 0 ? new Historia() // Agregarmos un nuevo objeto
                : objHistoria.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Historia objHistoria)
        {
            if (ModelState.IsValid)
            {
                objHistoria.Guardar();
                return Redirect("~/Historia");
            }
            else
            {
                return View("~/Views/Historia/AgregarEditar.cshtml", objHistoria);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objHistoria.id = id;
            objHistoria.Eliminar();
            return Redirect("~/Historia");
        }
    }
}