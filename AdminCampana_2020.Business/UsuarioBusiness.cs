using AdminCampana_2020.Business.Interface;
using AdminCampana_2020.Domain;
using AdminCampana_2020.Repository;
using AdminCampana_2020.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Business
{
    public class UsuarioBusiness:IUsuarioBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UsuarioRepository usuarioRepository;
        public UsuarioBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            usuarioRepository = new UsuarioRepository(unitOfWork);
        }

        public UsuarioDomainModel ValidarLogin(string email, string password)
        {
            UsuarioDomainModel usuarioDM = null;
            
            try
            {
                Usuario usuario = usuarioRepository.SingleOrDefault(p => p.Email == email && p.Clave == password);
                if (usuario != null)
                {
                    usuarioDM.Id = usuario.Id;
                    usuarioDM.Nombres = usuario.Nombres;
                    usuarioDM.Apellidos = usuario.Apellidos;
                    usuarioDM.Clave = usuario.Clave;
                    usuarioDM.ProviderKey = usuario.ProviderKey;
                    usuarioDM.ProviderName = usuario.ProviderName;
                    List<UsuarioRolDomainModel> rolesDM = new List<UsuarioRolDomainModel>();
                    foreach (Usuario_Rol user in usuario.Usuario_Rol)
                    {
                        UsuarioRolDomainModel usuarioRolDM = new UsuarioRolDomainModel();
                        RolDomainModel rolDM = new RolDomainModel();
                        usuarioRolDM.IdUsuario = user.Id_Usuario;
                        usuarioRolDM.IdRol = user.Id_rol;
                        rolDM.Id = user.Rol.Id;
                        rolDM.Nombre = user.Rol.Nombre;
                        usuarioRolDM.Rol = rolDM;
                        rolesDM.Add(usuarioRolDM);
                    }
                    usuarioDM.UsuarioRolesDM = rolesDM;
                }
                return usuarioDM;
            }
            catch (Exception ex)
            {
                
                return usuarioDM;
            }
            
        }
    }
}
