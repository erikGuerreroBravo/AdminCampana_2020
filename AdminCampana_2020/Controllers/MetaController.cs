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
    public class MetaController : Controller
    {

        private IMetaBusiness metaBusiness;

        public MetaController(IMetaBusiness metaBusiness)
        {
            this.metaBusiness = metaBusiness;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMetaEstablecida()
        {
            List<MetaVM> metasVM = null;
            List<MetaDomainModel> metasDM = new List<MetaDomainModel>();

            metasDM = metaBusiness.GetAllMetas();

            if (metasDM.Count > 0)
            {
                metasVM = new List<MetaVM>();
                AutoMapper.Mapper.Map(metasDM, metasVM);
            }

            
            return Json(metasVM,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateMeta(MetaVM metaVm)
        {

            if (metaVm.Id > 0)
            {
                MetaDomainModel metaDM = new MetaDomainModel();
                AutoMapper.Mapper.Map(metaVm, metaDM);
                metaBusiness.UpdateMeta(metaDM);
            }
           

            return View();
        }
    }
}