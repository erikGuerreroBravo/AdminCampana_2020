using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminCampana_2020.Domain;
using AdminCampana_2020.ViewModels;
using AutoMapper;

namespace AdminCampana_2020.Infraestructure
{
    public class AutomaperWebProfile : AutoMapper.Profile
    {

        public AutomaperWebProfile()
        {
            ///entidad persona
            CreateMap<PersonaVM, PersonaDomainModel>();
            CreateMap<PersonaDomainModel, PersonaVM>();
            //entidad direccion
            CreateMap<DireccionVM, DireccionDomainModel>();
            CreateMap<DireccionDomainModel, DireccionVM>();
            ///entidad telefono
            CreateMap<TelefonoVM, TelefonoDomainModel>();
            CreateMap<TelefonoDomainModel, TelefonoVM>();
            //entidad colonia
            CreateMap<ColoniaVM, ColoniaDomainModel>();
            CreateMap<ColoniaDomainModel, ColoniaVM>();


        }

        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }


    }
}