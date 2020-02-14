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
    public class PersonaBusiness: IPersonaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PersonaRepository personaRepository;

        public PersonaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            personaRepository = new PersonaRepository(unitOfWork);

        }

        /// <summary>
        /// Metodo se encarga de insertar o actualizar un registro de la entidad personaDM
        /// </summary>
        /// <param name="personaDM">Entidad PersonaDM</param>
        /// <returns>una cadena con el valor de la operación</returns>
        public string AddUpdatePersonal(PersonaDomainModel personaDM)
        {
            string resultado = string.Empty;
            if (personaDM != null)
            {

                Persona persona = personaRepository.SingleOrDefault(p => p.id == personaDM.Id);

                if (persona != null)
                {
                    persona.strNombre = personaDM.StrNombre;
                    persona.strApellidoPaterno = personaDM.StrApellidoPaterno;
                    persona.strApellidoMaterno = personaDM.StrApellidoMaterno;
                    persona.strEmail = personaDM.StrEmail;
                    persona.Direccion = new Direccion();
                    persona.Direccion.id = personaDM.Id;
                    persona.Direccion.strCalle = personaDM.DireccionDomainModel.StrCalle;
                    persona.Direccion.strNumeroInterior = personaDM.DireccionDomainModel.StrNumeroInterior;
                    persona.Direccion.strNumeroExterior = personaDM.DireccionDomainModel.StrNumeroExterior;
                    persona.Direccion.idColonia = personaDM.DireccionDomainModel.ColoniaDomainModel.Id;
                    persona.Direccion.idSeccion = personaDM.DireccionDomainModel.SeccionDomainModel.Id;
                    persona.Direccion.idZona = personaDM.DireccionDomainModel.ZonaDomainModel.Id;
                    persona.Estrategia = new Estrategia();
                    persona.Estrategia.id = personaDM.EstrategiaDomainModel.Id;
                    persona.Telefono = new Telefono();
                    persona.Telefono.strNumeroCelular = personaDM.TelefonoDomainModel.StrNumeroCelular;
                    personaRepository.Update(persona);
                    resultado = "Se Actualizo correctamente";

                }

                else
                {
                    persona = new Persona();
                    persona.strNombre = personaDM.StrNombre;
                    persona.strApellidoPaterno = personaDM.StrApellidoPaterno;
                    persona.strApellidoMaterno = personaDM.StrApellidoMaterno;
                    persona.strEmail = personaDM.StrEmail;
                    persona.Direccion = new Direccion();
                    persona.Direccion.id = personaDM.Id;
                    persona.Direccion.strCalle = personaDM.DireccionDomainModel.StrCalle;
                    persona.Direccion.strNumeroInterior = personaDM.DireccionDomainModel.StrNumeroInterior;
                    persona.Direccion.strNumeroExterior = personaDM.DireccionDomainModel.StrNumeroExterior;
                    persona.Direccion.idColonia = personaDM.DireccionDomainModel.ColoniaDomainModel.Id;
                    persona.Direccion.idSeccion = personaDM.DireccionDomainModel.SeccionDomainModel.Id;
                    persona.Direccion.idZona = personaDM.DireccionDomainModel.ZonaDomainModel.Id;

                    persona.Estrategia = new Estrategia();
                    persona.Estrategia.id = personaDM.EstrategiaDomainModel.Id;

                    persona.Telefono = new Telefono();
                    persona.Telefono.strNumeroCelular = personaDM.TelefonoDomainModel.StrNumeroCelular;
                    personaRepository.Insert(persona);
                    resultado = "Se Inserto de Forma Correcta";
                }

            }
            return resultado;
        }

    }
}
