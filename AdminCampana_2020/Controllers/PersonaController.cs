using AdminCampana_2020.Business.Interface;
using AdminCampana_2020.Domain;
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
            ViewBag.IdSeccion = new SelectList(IseccionBusiness.GetSeccion(), "id", "strNombre");
            ViewBag.IdZona = new SelectList(IzonaBusiness.GetZonas(), "id", "strNombre");
            ViewBag.IdEstrategias = new SelectList(IestrategiaBusiness.GetEstrategias(), "id", "strNombre");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registro([Bind(Include = "StrNombre,StrApellidoPaterno,StrApellidoMaterno,StrEmail,TelefonoVM,StrNumeroCelular,DireccionVM")]PersonaVM personaVM, string IdColonia, string IdSeccion, string IdZona, string IdEstrategias)
        {
            var coloniaId = int.Parse(IdColonia);
            var seccionId = int.Parse(IdSeccion);
            var zonaId = int.Parse(IdZona);
            var estrategiaId = int.Parse(IdEstrategias);

            personaVM.EstrategiaVM = new EstrategiaVM();
            personaVM.EstrategiaVM.Id = estrategiaId;

            personaVM.DireccionVM.SeccionVM = new SeccionVM();
            personaVM.DireccionVM.SeccionVM.Id = seccionId;

            personaVM.DireccionVM.ColoniaVM = new ColoniaVM();
            personaVM.DireccionVM.ColoniaVM.Id = coloniaId;

            personaVM.DireccionVM.ZonaVM = new ZonaVM();
            personaVM.DireccionVM.ZonaVM.Id = zonaId;

            if (ModelState.IsValid)
            {

                EstrategiaDomainModel EstrategiDM = new EstrategiaDomainModel();
                DireccionDomainModel direccionDM = new DireccionDomainModel();

                SeccionDomainModel seccionDM = new SeccionDomainModel();
                ColoniaDomainModel coloniaDM = new ColoniaDomainModel();
                ZonaDomainModel zonaDM = new ZonaDomainModel();
                PersonaDomainModel personaDM = new PersonaDomainModel();
                TelefonoDomainModel telefonoDM = new TelefonoDomainModel();


                AutoMapper.Mapper.Map(personaVM.EstrategiaVM, EstrategiDM);
                AutoMapper.Mapper.Map(personaVM.DireccionVM, direccionDM);

                AutoMapper.Mapper.Map(personaVM.DireccionVM.SeccionVM, seccionDM);
                AutoMapper.Mapper.Map(personaVM.DireccionVM.ColoniaVM, coloniaDM);
                AutoMapper.Mapper.Map(personaVM.DireccionVM.ZonaVM, zonaDM);
                AutoMapper.Mapper.Map(personaVM.TelefonoVM, telefonoDM);

                AutoMapper.Mapper.Map(personaVM, personaDM);

                personaDM.DireccionDomainModel = direccionDM;
                personaDM.EstrategiaDomainModel = EstrategiDM;
                personaDM.DireccionDomainModel.SeccionDomainModel = seccionDM;
                personaDM.DireccionDomainModel.ColoniaDomainModel = coloniaDM;
                personaDM.DireccionDomainModel.ZonaDomainModel = zonaDM;
                personaDM.TelefonoDomainModel = telefonoDM;

                IpersonaBusiness.AddUpdatePersonal(personaDM);
            }

            ViewBag.IdColonia = new SelectList(IcoloniaBusiness.GetColonias(), "id", "strAsentamiento");
            ViewBag.IdSeccion = new SelectList(IseccionBusiness.GetSeccion(), "id", "strNombre");
            ViewBag.IdZona = new SelectList(IzonaBusiness.GetZonas(), "id", "strNombre");
            ViewBag.IdEstrategias = new SelectList(IestrategiaBusiness.GetEstrategias(), "id", "strNombre");
            return View("Registro");
        }


        [HttpGet]
        [AllowAnonymous]
        [Authorize]
        public ActionResult Registros()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<PersonaDomainModel> personasDM = IpersonaBusiness.GetAllPersonas();
                List<PersonaVM> personasVM = new List<PersonaVM>();
                AutoMapper.Mapper.Map(personasDM, personasVM);
                return View(personasVM);
            }
            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Consultar()
        {
            return Json(IpersonaBusiness.GetAllPersonas(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize]
        public ActionResult Editar(int _id)
        {


            if (User.Identity.IsAuthenticated)
            {
                PersonaDomainModel personaDM = IpersonaBusiness.GetPersonaById(_id);
                if (personaDM != null)
                {
                    PersonaVM personaVM = new PersonaVM();
                    AutoMapper.Mapper.Map(personaDM, personaVM);
                    TelefonoVM telefonoVM = new TelefonoVM();
                    AutoMapper.Mapper.Map(personaDM.TelefonoDomainModel, telefonoVM);
                    personaVM.TelefonoVM = telefonoVM;
                    return View("Editar", personaVM);
                }
                else
                {
                    return RedirectToAction("InternalServerError", "Error");
                }
            }
            return RedirectToAction("Login","Account");
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize]
        public ActionResult Editar([Bind(Include = "Id,StrNombre,StrApellidoPaterno,StrApellidoMaterno,StrEMail,TelefonoVM")]PersonaVM personaVM)
        {
            if (personaVM != null && ModelState.IsValid)
            {
                PersonaDomainModel personaDM = new PersonaDomainModel();
                TelefonoDomainModel telefonoDM = new TelefonoDomainModel();
                AutoMapper.Mapper.Map(personaVM.TelefonoVM,telefonoDM);
                AutoMapper.Mapper.Map(personaVM,personaDM);
                personaDM.TelefonoDomainModel = telefonoDM;
                IpersonaBusiness.UpdatePersonal(personaDM);

            }
            return RedirectToAction("Registros", "Persona");
        }

       
    }
}