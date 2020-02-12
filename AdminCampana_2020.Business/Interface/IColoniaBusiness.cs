using AdminCampana_2020.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Business.Interface
{
    /// <summary>
    /// Este metodo se encarga de consultar todas las colonias
    /// </summary>
    /// <returns>regresa una lista de colonias</returns>
    public interface IColoniaBusiness
    {
        List<ColoniaDomainModel> GetColonias();
    }
}
