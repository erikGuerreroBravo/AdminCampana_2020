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
    public class RolBusiness : IRolBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly RolRepository rolRepository;


        public RolBusiness(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
            rolRepository = new RolRepository(unitOfWork);
        }

        public List<RolDomainModel> GetRoles()
        {
            List<RolDomainModel> rolDomainModels = new List<RolDomainModel>();
            List<Rol> rols = new List<Rol>();

            rols = rolRepository.GetAll().ToList();

            foreach (Rol item in rols)
            {
                RolDomainModel rolDomainModel = new RolDomainModel();

                rolDomainModel.Id = item.Id;
                rolDomainModel.Nombre = item.Nombre;

                rolDomainModels.Add(rolDomainModel);
            }

            RolDomainModel rolDomainModel1 = new RolDomainModel();

            rolDomainModel1.Id = 0;
            rolDomainModel1.Nombre = "Seleccionar";

            rolDomainModels.Insert(0, rolDomainModel1);

            return rolDomainModels;
        }

    }
}
