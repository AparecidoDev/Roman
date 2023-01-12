using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o E-mail do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha do usuário!")]
        public string Senha { get; set; }

    }
}
