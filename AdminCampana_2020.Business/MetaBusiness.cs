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
    public class MetaBusiness : IMetaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly MetaRepository metaRepository;


        public MetaBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            metaRepository = new MetaRepository(unitOfWork);
        }

        public List<MetaDomainModel> GetAllMetas()
        {
            List<MetaDomainModel> metasDM = new List<MetaDomainModel>();
            List<Meta> metas = new List<Meta>();

            metas = metaRepository.GetAll().ToList();

            foreach (Meta item in metas)
            {
                MetaDomainModel metaDM = new MetaDomainModel();

                metaDM.Id = item.id;
                metaDM.meta = item.meta1.Value;
                metaDM.Rol = new RolDomainModel
                {
                    Id = item.Rol.Id,
                    Nombre = item.Rol.Nombre
                };

                metasDM.Add(metaDM);

            }

            return metasDM;
        }

        public bool UpdateMeta(MetaDomainModel _meta)
        {
            bool respuesta = false;

            if (_meta != null)
            {
                Meta meta = metaRepository.SingleOrDefault(p => p.id == _meta.Id);

                meta.meta1 = _meta.meta;

                metaRepository.Update(meta);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
