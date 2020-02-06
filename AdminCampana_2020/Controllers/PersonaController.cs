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
        public PersonaController(IPersonaBusiness _IpersonaBusiness)
        {
            IpersonaBusiness = _IpersonaBusiness;
            
        }

        // GET: Persona
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }
    }
}