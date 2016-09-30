using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.CategoriaPeca
{
    public class NewCategoriaPecaViewModel
    {
        [Required]
        [Display(Name = @"Descrição")]
        public string Descricao { get; set; }
    }
}