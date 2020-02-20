using AdminCampana_2020.Encript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminCampana_2020.ViewModels;
using AdminCampana_2020.Domain;
using AdminCampana_2020.Business.Interface;

namespace AdminCampana_2020.Controllers
{
    public class AccountController : Controller
    {
        IUsuarioBusiness usuarioBusiness;
        public AccountController(IUsuarioBusiness _usuarioBusiness)
        {
            usuarioBusiness = _usuarioBusiness;
        }


        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM loginView, string returnUrl)
        {
            ActionResult result; //esto se debe inicializar
            string clave = Funciones.Encrypt(loginView.Password); //encryptamos el password
            UsuarioDomainModel usuarioDM =  
        }



    }
}