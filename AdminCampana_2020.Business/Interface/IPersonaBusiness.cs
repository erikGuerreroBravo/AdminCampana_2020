using AdminCampana_2020.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Business.Interface
{
    public interface IPersonaBusiness
    {
        string AddUpdatePersonal(PersonaDomainModel personaDM);
        List<PersonaDomainModel> GetAllPersonas();
        PersonaDomainModel GetPersonaById(int id);
    }
}
