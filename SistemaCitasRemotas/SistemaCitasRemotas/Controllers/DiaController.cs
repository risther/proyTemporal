using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Models;
namespace SistemaCitasRemotas.Controllers
{
    public class DiaController : Controller
    {
      
        private Dia objDia = new Dia();

        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objDia.Listar());
            }
            else
            {
                return View(/*objDia.Buscar(criterio)*/);
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objDia.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            //ViewBag.TipoUsuario = objTipoUsuario.Listar();
            //ViewBag.Especialidad = objEspecialidad.Listar();
            return View(id == 0 ? new Dia() // Agregarmos un nuevo objeto
                : objDia.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Dia objDia)
        {
            if (ModelState.IsValid)
            {
                objDia.Guardar();
                return Redirect("~/Dia");
            }
            else
            {
                return View("~/Views/Dia/AgregarEditar.cshtml", objDia);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objDia.id = id;
            objDia.Eliminar();
            return Redirect("~/Dia");
        }

       
    }
}