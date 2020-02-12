using AdminCampana_2020.Business.Interface;
using AdminCampana_2020.ViewModels;
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
        ISeccionBusiness IseccionBusiness;
        IZonaBusiness IzonaBusiness;
        IEstrategiaBusiness IestrategiaBusiness;
        public PersonaController(IPersonaBusiness _IpersonaBusiness, IColoniaBusiness _IcoloniaBusiness,
            ISeccionBusiness _IseccionBusiness, IZonaBusiness _IzonaBusiness, IEstrategiaBusiness _IestrategiaBusiness)
        {
            IpersonaBusiness = _IpersonaBusiness;
            IcoloniaBusiness = _IcoloniaBusiness;
            IseccionBusiness = _IseccionBusiness;
            IzonaBusiness = _IzonaBusiness;
            IestrategiaBusiness = _IestrategiaBusiness;
        }

        // GET: Persona
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registro()
        {
            ViewBag.IdColonia = new SelectList(IcoloniaBusiness.GetColonias(), "id", "strAsentamiento");
            ViewBag.IdSeccion = new SelectList(IseccionBusiness.GetSeccion(),"id","strNombre");
            ViewBag.IdZona = new SelectList(IzonaBusiness.GetZonas(),"id","strNombre");
            ViewBag.IdEstrategias = new SelectList(IestrategiaBusiness.GetEstrategias(),"id","strNombre");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registro(PersonaVM personaVM)
        {
            return View();
        }

    }
}