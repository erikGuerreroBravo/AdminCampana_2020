using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminCampana_2020.ViewModels
{
    public class LoginVM
    {

        [Display(Name = "Correo:")]
        public string Email { get; set; }
        [Display(Name = "Clave de Acceso:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}