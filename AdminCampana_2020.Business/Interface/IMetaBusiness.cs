using AdminCampana_2020.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Business.Interface
{
    public interface IMetaBusiness
    {
        List<MetaDomainModel> GetAllMetas();
        bool UpdateMeta(MetaDomainModel _meta);
    }
}
