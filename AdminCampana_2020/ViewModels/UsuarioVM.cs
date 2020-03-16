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
        public int idPerfil { get; set; }
        public int idRol { get; set; }

        //Objetos de las relaciones

        public PerfilVM Perfil { get; set; }
        public List<UsuarioRolVM> UsuarioRoles { get; set; }
    }
}