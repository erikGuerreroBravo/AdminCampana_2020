using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCampana_2020.ViewModels
{
    public class UsuarioRolVM
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public UsuarioVM Usuario { get; set; }
        public RolVM Rol { get; set; }
    }
}