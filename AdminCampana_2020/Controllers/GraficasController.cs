using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AdminCampana_2020.Controllers
{
    public class GraficasController : Controller
    {
        // GET: Graficas
        [Authorize]
        public ActionResult Create()
        {
            //delcaramos la variable claimsprincipal
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                ViewBag.Usuario = Principal.Identity.Name;
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
    }
}