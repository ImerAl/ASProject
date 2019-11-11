using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_Fase2.ModeloLogin.Commons
{
    public class LoginViewModel
    {
        [Required]
        public string Credenciales{ get; set; }

        [Required]
        public string Password { get; set; }
    }
}