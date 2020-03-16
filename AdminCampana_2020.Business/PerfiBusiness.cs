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
    public class PerfiBusiness : IPerfilBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PerfilRepository perfilRepository;

        public PerfiBusiness(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
            perfilRepository = new PerfilRepository(unitOfWork);
        }

        public List<PerfilDomainModel> GetAllPerfiles() 
        {
            List<PerfilDomainModel> perfilDomainModels = new List<PerfilDomainModel>();
            List<Perfil> perfils = new List<Perfil>();

            perfils = perfilRepository.GetAll().ToList();

            foreach (Perfil item in perfils)
            {
                PerfilDomainModel perfilDomainModel = new PerfilDomainModel();

                perfilDomainModel.Id = item.id;
                perfilDomainModel.strDescripcion = item.strDescripcion;
                perfilDomainModel.strValor = item.strValor;

                perfilDomainModels.Add(perfilDomainModel);
            }

            PerfilDomainModel perfilDomainModel1 = new PerfilDomainModel();

            perfilDomainModel1.Id = 0;
            perfilDomainModel1.strDescripcion = "Seleccionar";
            perfilDomainModel1.strValor = "Seleccionar";

            perfilDomainModels.Insert(0, perfilDomainModel1);

            return perfilDomainModels;
        }
    }
}
