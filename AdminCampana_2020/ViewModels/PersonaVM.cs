using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminCampana_2020.ViewModels
{
    public class PersonaVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Campo es Obligatorio")]
        [DataType(DataType.Text,ErrorMessage ="El Campo Solo Acepta Letras")]
        public string StrNombre { get; set; }
        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El Campo Solo Acepta Letras")]
        public string StrApellidoPaterno { get; set; }
        [Required(ErrorMessage = "El Campo es Obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El Campo Solo Acepta Letras")]
        public string StrApellidoMaterno { get; set; }

        [DataType(DataType.EmailAddress)]
        public string StrEmail { get; set; }
        public string StrObservaciones { get; set; }
        public DireccionVM DireccionVM { get; set; }
        public TelefonoVM TelefonoVM { get; set; }
        public EstrategiaVM EstrategiaVM { get; set; }
    }
}