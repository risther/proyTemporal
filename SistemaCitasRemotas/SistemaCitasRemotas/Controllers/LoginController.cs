using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//importando bibliotecas
using SistemaCitasRemotas.Models;
using SistemaCitasRemotas.Filters;

namespace SistemaCitasRemotas.Controllers
{
    public class LoginController : Controller
    {

        Usuario objUsuario = new Usuario();
        Medico objMedico = new Medico();
        // GET: Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Autenticar(string Usuario, string Password)
        {
            int tipo = Convert.ToInt32(Request["tipo"]);
            string enlace = "";
            var rm = objUsuario.Autenticar(Usuario, Password); ;
            if (tipo == 2)
            {
                rm = objMedico.Autenticar(Usuario, Password);
                enlace = "~/Medico";

                if (rm.response)
                {
                    rm.href = Url.Content(enlace);
                }

            }
            else
            {
                enlace = "~/Home";
                if (rm.response)
                {
                    rm.href = Url.Content(enlace);
                }
            }



            return Json(rm);

        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }



    }
}