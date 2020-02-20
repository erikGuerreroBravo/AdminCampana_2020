using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Domain
{
    public class RolDomainModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<UsuarioDomainModel> UsuarioRolesDM { get; set; }
    }
}
