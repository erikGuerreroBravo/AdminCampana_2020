using AdminCampana_2020.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminCampana_2020.Controllers
{
    public class PersonaController : Controller
    {
                
        IPersonaBusiness IpersonaBusiness;
        IColoniaBusiness IcoloniaBusiness;
        public PersonaController(IPersonaBusiness _IpersonaBusiness, IColoniaBusiness _IcoloniaBusiness)
        {
            IpersonaBusiness = _IpersonaBusiness;
            IcoloniaBusiness = _IcoloniaBusiness;
        }

        // GET: Persona
        [HttpGet]
        public ActionResult Registro()
        {
            ViewBag.IdColonia = new SelectList(IcoloniaBusiness.GetColonias(), "id", "strAsentamiento");
            return View();
        }
    }
}