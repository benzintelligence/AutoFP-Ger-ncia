using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Peca
{
    public class ListPecaViewModel
    {
        [Display(Name = @"Código de distribuidor")]
        public string CodigoDistribuidor { get; set; }

        [Display(Name = @"Produto")]
        public string Nome { get; set; }

        [Display(Name = @"Preço de:")]
        public decimal PrecoDe { get; set; }

        [Display(Name = @"Preço para:")]
        public decimal PrecoPara { get; set; }
    }
}