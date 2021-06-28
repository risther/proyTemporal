using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Models;

namespace SistemaCitasRemotas.Controllers
{
    public class RecetaController : Controller
    {
        // GET: Receta
        // private Usuario objUsuario = new Usuario();
        //private Docente objDocente = new Docente();
        private Receta objReceta = new Receta();
        private Usuario objUsuario = new Usuario();
        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objReceta.Listar());
            }
            else
            {
                return View(objReceta.Buscar(criterio));
            }
        }

        public ActionResult VerDetalleRecetaCliente(int id)
        {
            return View(objReceta.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Usuario = objUsuario.Listar();

            return View(id == 0 ? new Receta() // Agregarmos un nuevo objeto
                : objReceta.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult ListarRecetaMedico(int id = 0)
        {
            //ViewBag.Usuario = objUsuario.Listar();

            return View(objReceta.ListarRecetaMedico(id));
        }

        public ActionResult ListarRecetaCliente(int id = 0)
        {
            //ViewBag.Usuario = objUsuario.Listar();

            return View(objReceta.ListarRecetaCliente(id));
        }
       

        public ActionResult Guardar(Receta objReceta)
        {
            if (ModelState.IsValid)
            {
                objReceta.Guardar();
                return Redirect("~/Receta");
            }
            else
            {
                return View("~/Views/Receta/AgregarEditar.cshtml", objReceta);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objReceta.id = id;
            objReceta.Eliminar();
            return Redirect("~/Receta");
        }
    }
}