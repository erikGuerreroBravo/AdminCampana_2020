using AdminCampana_2020.Business;
using AdminCampana_2020.Business.Interface;
using AdminCampana_2020.Repository.Infraestructure;
using AdminCampana_2020.Repository.Infraestructure.Contract;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AdminCampana_2020
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUsuarioBusiness, UsuarioBusiness>();
            container.RegisterType<IRolBusiness, RolBusiness>();
            container.RegisterType<IUsuarioRolBusiness, UsuarioRolBusiness>();

            container.RegisterType<IPersonaBusiness, PersonaBusiness>();
            container.RegisterType<IColoniaBusiness, ColoniaBusiness>();
            container.RegisterType<ISeccionBusiness, SeccionBusiness>();
            container.RegisterType<IZonaBusiness, ZonaBusiness>();
            container.RegisterType<IEstrategiaBusiness, EstrategiaBusiness>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IMetaBusiness, MetaBusiness>();
            container.RegisterType<IPerfilBusiness, PerfiBusiness>();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}