using AdminCampana_2020.Business.Interface;
using AdminCampana_2020.Domain;
using AdminCampana_2020.Repository;
using AdminCampana_2020.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Business
{
    public class ZonaBusiness: IZonaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ZonaRepository zonaRepository;

        public ZonaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            zonaRepository = new ZonaRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas las colonias
        /// </summary>
        /// <returns>regresa una lista de colonias</returns>
        public List<ZonaDomainModel> GetZonas()
        {
            List<ZonaDomainModel> zonas = null;
            zonas = zonaRepository.GetAll().Select(p => new ZonaDomainModel
            {
                Id = p.id,
                StrNombre = p.strNombre,
                StrDescripcion = p.strDescripcion
            }).ToList();
            return zonas;
        }


    }
}
