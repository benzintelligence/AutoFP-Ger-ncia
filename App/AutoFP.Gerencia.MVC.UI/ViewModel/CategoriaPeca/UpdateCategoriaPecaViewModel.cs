using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.CategoriaPeca
{
    public class UpdateCategoriaPecaViewModel
    {
        [Key]
        public int CategoriaPecaId { get; set; }

        [Display(Name = @"Descrição")]
        public string Descricao { get; set; }
    }
}