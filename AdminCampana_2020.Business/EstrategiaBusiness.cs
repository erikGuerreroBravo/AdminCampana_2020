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
    public class EstrategiaBusiness:IEstrategiaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EstrategiaRepository estrategiaRepository;

        public EstrategiaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            estrategiaRepository = new EstrategiaRepository(unitOfWork);
        }


        public List<EstrategiaDomainModel> GetEstrategias()
        {

        }
    }
}
