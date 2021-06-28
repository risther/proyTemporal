using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//importando bibliotecas
using SistemaCitasRemotas.Models;
using SistemaCitasRemotas.Filters;
using System.Text;
using System.Security.Cryptography;

namespace SistemaCitasRemotas.Controllers
{
    //[Autenticado]
    public class MedicoController : Controller
    {
        // GET: Usuario
        //private Usuario objUsuario = new Usuario();
        private Medico objMedico = new Medico();
        private TipoUsuario objTipoUsuario = new TipoUsuario();
        private Especialidad objEspecialidad = new Especialidad();

        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objMedico.Listar());
            }
            else
            {
                return View(objMedico.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objMedico.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.TipoUsuario = objTipoUsuario.Listar();
            ViewBag.Especialidad = objEspecialidad.Listar();
            return View(id == 0 ? new Medico() // Agregarmos un nuevo objeto
                : objMedico.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Medico objMedico)
        {
            if (ModelState.IsValid)
            {
                objMedico.clave= MD5Hash(objMedico.clave);
                objMedico.Guardar();
                return Redirect("~/Medico");
            }
            else
            {
                return View("~/Views/Medico/AgregarEditar.cshtml", objMedico);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objMedico.id = id;
            objMedico.Eliminar();
            return Redirect("~/usuario");
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }


    }
}