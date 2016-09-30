using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.CategoriaPeca
{
    public class ListCategoriaPecaViewModel
    {
        [Display(Name = @"#ID")]
        public int CategoriaPecaId { get; set; }

        [Display(Name = @"Categoria")]
        public string Descricao { get; set; }
    }
}