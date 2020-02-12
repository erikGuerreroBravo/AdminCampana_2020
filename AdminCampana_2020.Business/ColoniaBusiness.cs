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
    public class ColoniaBusiness : IColoniaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ColoniaRepository coloniaRepository;

        public ColoniaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            coloniaRepository = new ColoniaRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas las colonias
        /// </summary>
        /// <returns>regresa una lista de colonias</returns>
        public List<ColoniaDomainModel> GetColonias()
        {
            List<ColoniaDomainModel> colonias = null;
            colonias = coloniaRepository.GetAll().Select(p => new ColoniaDomainModel
            {
                Id = p.id,
                StrAsentamiento = p.strAsentamiento,
                StrTipoDeAsentamiento = p.strTipoDeAsentamiento
            }).ToList();
            return colonias;
        }
        
    }
}
