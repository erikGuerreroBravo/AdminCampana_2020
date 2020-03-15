using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Domain
{
    public class MetaDomainModel
    {
        public int Id { get; set; }
        public string meta { get; set; }
        public RolDomainModel Rol { get; set; }
    }
}
