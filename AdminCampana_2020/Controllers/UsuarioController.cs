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
    public class UsuarioController : Controller
    {

        private IUsuarioBusiness usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            this.usuarioBusiness = usuarioBusiness;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioVM usuarioVM)
        {

            if (usuarioVM.Id > 0)
            {
                UsuarioDomainModel usuarioDM = new UsuarioDomainModel();
                AutoMapper.Mapper.Map(usuarioVM,usuarioDM);
                usuarioBusiness.AddUpdateUsuarios(usuarioDM);
            }

            return View();
        }
        

    }
}