using AdminCampana_2020.Repository;
using AdminCampana_2020.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Business
{
    public class UserManager : IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly UsuarioRepository usuarioRepository;

        public UserManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            usuarioRepository = new UsuarioRepository(unitOfWork);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
