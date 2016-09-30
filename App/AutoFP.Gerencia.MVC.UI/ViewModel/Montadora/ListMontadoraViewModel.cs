using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Montadora
{
    public class ListMontadoraViewModel
    {
        [Display(Name = @"#ID")]
        public int MontadoraId { get; set; }

        [Display(Name = @"Montadora")]
        public string Montadora { get; set; }

        [Display(Name = @"Destaque")]
        public bool Destacar { get; set; }
    }
}