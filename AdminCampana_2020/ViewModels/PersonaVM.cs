using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCampana_2020.ViewModels
{
    public class PersonaVM
    {
        public int Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno { get; set; }
        public string StrEmail { get; set; }
        public string StrObservaciones { get; set; }
        public DireccionVM DireccionVM { get; set; }
        public TelefonoVM TelefonoVM { get; set; }
    }
}