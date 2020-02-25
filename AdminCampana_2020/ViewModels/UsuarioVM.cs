using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCampana_2020.ViewModels
{
    public class UsuarioVM
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string ProviderName { get; set; }
        public string ProviderKey { get; set; }
        public List<UsuarioVM> UsuarioRolesVM { get; set; }
    }
}