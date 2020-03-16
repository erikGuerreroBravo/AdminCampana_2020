using System;
using System.Collections.Generic;
using AdminCampana_2020.Repository;

namespace AdminCampana_2020.Domain
{
    public class UsuarioRolDomainModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public UsuarioDomainModel Usuario { get; set; }
        public RolDomainModel Rol { get; set; }

    }
}
