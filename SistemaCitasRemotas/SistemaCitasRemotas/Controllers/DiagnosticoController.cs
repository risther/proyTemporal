using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Models;
namespace SistemaCitasRemotas.Controllers
{
    public class DiagnosticoController : Controller
    {
        private Diagnostico objDiagnostico = new Diagnostico();
        private Usuario objUsuario = new Usuario();
        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objDiagnostico.Listar());
            }
            else
            {
                return View(/*objDia.Buscar(criterio)*/);
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objDiagnostico.Obtener(id));
        }


        public ActionResult AgregarEditar(int id = 0)
        {
            //ViewBag.TipoUsuario = objTipoUsuario.Listar();
            //ViewBag.Especialidad = objEspecialidad.Listar();
            return View(id == 0 ? new Diagnostico() // Agregarmos un nuevo objeto
                : objDiagnostico.Obtener(id) //Devuelve el id del objeto
                );
        }
        public ActionResult VerDiagnosticoDoctor(int id = 0)
        {
            //ViewBag.TipoUsuario = objTipoUsuario.Listar();
            //ViewBag.Especialidad = objEspecialidad.Listar();
            return View(objDiagnostico.Listar());
        }

        public ActionResult VerDiagnosticoPaciente()
        {
            //ViewBag.TipoUsuario = objTipoUsuario.Listar();
            //ViewBag.Especialidad = objEspecialidad.Listar();
            return View(objDiagnostico.Listar());
        }

        public ActionResult AgregarDiagnosticoDoctor(int id = 0)
        {
            ViewBag.Usuario = objUsuario.Listar();
            //ViewBag.Especialidad = objEspecialidad.Listar();
            return View(id == 0 ? new Diagnostico() // Agregarmos un nuevo objeto
                : objDiagnostico.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Diagnostico objDiagnostico)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                string codigo = "Diag-" + rnd.Next(1,100);
                objDiagnostico.codigo = codigo;
                objDiagnostico.Guardar();
                return Redirect("~/Diagnostico");
            }
            else
            {
                return View("~/Views/Diagnostico/AgregarEditar.cshtml", objDiagnostico);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objDiagnostico.id = id;
            objDiagnostico.Eliminar();
            return Redirect("~/Diagnostico");
        }
    }
}