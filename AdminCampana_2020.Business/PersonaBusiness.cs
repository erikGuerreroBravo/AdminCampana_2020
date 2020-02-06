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
    public class PersonaBusiness: IPersonaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PersonaRepository personaRepository;

        public PersonaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            personaRepository = new PersonaRepository(unitOfWork);

        }

        public string AddUpdatePersonal(PersonaDomainModel personaDM)
        {
            return "";
        }

    }
}
