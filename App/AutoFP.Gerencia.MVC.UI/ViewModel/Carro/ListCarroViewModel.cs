using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Carro
{
    public class ListCarroViewModel
    {
        [Display(Name = @"#ID")]
        public int CarroId { get; set; }

        public string Carro { get; set; }

        public string Montadora { get; set; }
    }
}