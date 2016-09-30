using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Fornecedor
{
    public class ListFornecedorViewModel
    {
        [Display(Name = @"#ID")]
        public int FornecedorId { get; set; }

        [Display(Name = @"CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = @"Razão Social")]
        public string RazaoSocial { get; set; }
    }
}