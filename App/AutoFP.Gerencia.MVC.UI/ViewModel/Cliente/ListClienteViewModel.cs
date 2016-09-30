using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Cliente
{
    public class ListClienteViewModel
    {
        [Display(Name = @"# ID")]
        public int ClienteId { get; set; }

        [Display(Name = @"Cliente")]
        public string ClienteNome { get; set; }

        [Display(Name = @"Tipo")]
        public string TipoPessoa { get; set; }
    }
}