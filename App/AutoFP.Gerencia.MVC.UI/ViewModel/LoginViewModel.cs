using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = @"Usuário")]
        [Required(ErrorMessage = @"Digite seu usuário", AllowEmptyStrings = false)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = @"Digite sua senha", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public string ReturnUrl { get; set; }
    }
}