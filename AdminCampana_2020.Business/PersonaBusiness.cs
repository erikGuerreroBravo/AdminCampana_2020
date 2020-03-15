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


        public string UpdatePersonal(PersonaDomainModel personaDM)
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
                    persona.Telefono = new Telefono();
                    persona.Telefono.strNumeroCelular = personaDM.TelefonoDomainModel.StrNumeroCelular;
                    personaRepository.Update(persona);
                    resultado = "Se Actualizo correctamente";
                }
            }
            return resultado;
        }


        public List<PersonaDomainModel> GetAllPersonas()
        {
            List<PersonaDomainModel> personas = null;
            personas = personaRepository.GetAll().Select(p => new PersonaDomainModel
            {
                Id = p.id,
                StrNombre = p.strNombre,
                StrApellidoPaterno = p.strApellidoPaterno,
                StrApellidoMaterno = p.strApellidoMaterno,
                StrEmail = p.strEmail,
                
            }).OrderByDescending(p=>p.StrNombre).ToList<PersonaDomainModel>();
            return personas;
        }


        public PersonaDomainModel GetPersonaById(int id)
        {
            Persona persona = personaRepository.SingleOrDefault(p => p.id == id);
            if (persona != null)
            {
                PersonaDomainModel personaDM = new PersonaDomainModel();
                personaDM.Id = persona.id;
                personaDM.StrNombre = persona.strNombre;
                personaDM.StrApellidoPaterno = persona.strApellidoPaterno;
                personaDM.StrApellidoMaterno = persona.strApellidoMaterno;
                personaDM.StrEmail = persona.strEmail;

                TelefonoDomainModel telefonoDM = new TelefonoDomainModel();
                telefonoDM.StrNumeroCelular = persona.Telefono.strNumeroCelular;
                personaDM.TelefonoDomainModel = telefonoDM;
                return personaDM;
            }
            else
            {
                return null;
            }


        }

    }
}
