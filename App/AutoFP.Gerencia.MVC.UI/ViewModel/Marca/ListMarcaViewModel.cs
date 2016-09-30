using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Marca
{
    public class ListMarcaViewModel
    {
        [Display(Name = @"#ID")]
        public int MarcaId { get; set; }

        [Display(Name = @"Marca")]
        public string Descricao { get; set; }

        [Display(Name = @"Destaque")]
        public bool Destacar { get; set; }
    }
}