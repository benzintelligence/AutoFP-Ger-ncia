using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Fornecedor
{
    public class NewFornecedorViewModel
    {
        #region Pessoa jurídica
        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"CNPJ")]
        public string Cnpj { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"Razão social")]
        public string RazaoSocial { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"Nome fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = @"Inscrição municipal")]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = @"Inscrição estadual")]
        public string InscricaoEstadual { get; set; }

        public bool Isento { get; set; }
        #endregion

        #region Email
        [Display(Name = @"E-mail")]
        [Required(ErrorMessage = @"Um e-mail é necessário", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = @"Informe um e-mail válido")]
        public string Email { get; set; }
        #endregion

        #region Telefones
        // Telefone 1
        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"DDD + Telefone")]
        public string TelefoneNumero1 { get; set; }

        [Display(Name = @"Tipo")]
        public int TipoTelefone1 { get; set; }

        // Telefone 2
        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"DDD + Telefone")]
        public string TelefoneNumero2 { get; set; }

        [Display(Name = @"Tipo")]
        public int TipoTelefone2 { get; set; }
        #endregion

        #region Endereço
        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"Logradouro")]
        public string Rua { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"Número")]
        public string EnderecoNumero { get; set; }

        public string Complemento { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Bairro { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"CEP")]
        public string Cep { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"Ponto de referência")]
        public string PontoReferencia { get; set; }

        [Required]
        [Display(Name = @"Cidade")]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = @"Estado")]
        public string Estado { get; set; }
        #endregion
    }
}