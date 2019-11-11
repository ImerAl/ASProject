using Proyecto_Fase2.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Fase2.Models;
using Proyecto_Fase2.ModeloLogin.Commons;

namespace Proyecto_Fase2.Controllers
{
    [NoLoginAttribute]
    public class LoginController : Controller
    {
        private Users um = new Users();

        public ActionResult Index()
        {

            if (TempData["Error"] != null)
            {
                ViewBag.Error = "<div class='alert alert-danger'><strong>Error</strong> Usuario o contraseña incorrecto</div>";
                return View();
            }

            return View();
        }

        public ActionResult Autenticar(LoginViewModel model)
        {
            var rm = new ResponseModel();

            TempData.Clear();
            if (ModelState.IsValid)
            {
                this.um.Email = model.Credenciales;
                this.um.Password = model.Password;

                rm = um.Autenticarse();

                if (rm.response)
                {
                    return RedirectToAction("", "Home");
                }
                else
                {
                    TempData["Error"] = "1";
                    return RedirectToAction("", "Login");
                }
            }
            else
            {
                rm.SetResponse(false, "Debe llenar los campos para poder autenticarse.");
            }

            return Json(rm);
        }
    }
}