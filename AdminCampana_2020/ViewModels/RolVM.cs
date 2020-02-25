using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCampana_2020.ViewModels
{
    public class RolVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<UsuarioVM> UsuarioRolesVM { get; set; }
    }
}