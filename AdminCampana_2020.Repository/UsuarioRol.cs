using AdminCampana_2020.Repository.Infraestructure;
using AdminCampana_2020.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Repository
{
    public class UsuarioRol : BaseRepository<Usuario_Rol>
    {
        public UsuarioRol(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
