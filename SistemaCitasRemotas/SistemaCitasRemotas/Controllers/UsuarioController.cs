using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SistemaCitasRemotas.Models;
namespace SistemaCitasRemotas.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
         private Usuario objUsuario = new Usuario();
        private TipoUsuario objTipoUsuario = new TipoUsuario();
        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objUsuario.Listar());
            }
            else
            {
                return View(objUsuario.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objUsuario.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            
            ViewBag.TipoUsuario = objTipoUsuario.Listar();
            return View(id == 0 ? new Usuario() // Agregarmos un nuevo objeto
                : objUsuario.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Registrarse(int id = 0)
        {
            
            ViewBag.TipoUsuario = objTipoUsuario.Listar();
            return View(id == 0 ? new Usuario() // Agregarmos un nuevo objeto
                : objUsuario.Obtener(id) //Devuelve el id del objeto
                );
        }
        public ActionResult GuardarRegistrarse(Usuario objUsuario)
        {
            if (ModelState.IsValid)
            {
                objUsuario.clave = MD5Hash(objUsuario.clave);
                objUsuario.idTipoUsuario = 1;
                objUsuario.Guardar();
                Response.Write("<script languages=javascript>alert('Se registro exitosamente');</script>");
                return Redirect("~/Login");
            }
            else
            {
                return View("~/Views/Usuario/Registrarse.cshtml", objUsuario);
            }
        }
        public ActionResult Guardar(Usuario objUsuario)
        {
            if (ModelState.IsValid)
            {

               
                objUsuario.Guardar();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml", objUsuario);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objUsuario.id = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario");
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